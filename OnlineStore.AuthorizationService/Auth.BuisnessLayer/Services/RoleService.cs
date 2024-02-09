using Auth.BuisnessLayer.Abstractions.Interfaces;
using Auth.BuisnessLayer.DTOs.RequestDTOs;
using Auth.BuisnessLayer.DTOs.ResponseDTOs;
using Auth.BuisnessLayer.Exceptions;
using Auth.DataAccessLayer.Entity;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Auth.BuisnessLayer.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public RoleService(
            RoleManager<IdentityRole> roleManager, 
            IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<RoleResponseDto> СreateRoleAsync(RoleRequestDto roleRequestDto, CancellationToken cancellationToken)
        {
            var foundRole = await _roleManager.FindByNameAsync(roleRequestDto.Name);

            if (foundRole is not null)
            {
                throw new RoleAlreadyExistsException();
            }

            var newRole = _mapper.Map<Role>(roleRequestDto);
            var roleCreationResult = await _roleManager.CreateAsync(newRole);

            if (!roleCreationResult.Succeeded)
            {
                throw new RoleCreationException();
            }

            var roleResponseDto = _mapper.Map<RoleResponseDto>(newRole);

            return roleResponseDto;
        }

        public async Task<IEnumerable<RoleResponseDto>> GetAllRoleAsync(CancellationToken cancellationToken)
        {
            var rolesList = await _roleManager.Roles.ToListAsync();
            var roleResponseDtoList = _mapper.Map<List<RoleResponseDto>>(rolesList);

            return roleResponseDtoList;
        }

        public async Task<RoleResponseDto> GetRoleByNameAsync(string roleName, CancellationToken cancellationToken)
        {
            var foundRole = await _roleManager.FindByNameAsync(roleName);

            if (foundRole is null)
            {
                throw new RoleNotFoundException();
            }

            var roleResponseDto = _mapper.Map<RoleResponseDto>(foundRole);

            return roleResponseDto;
        }

        public async Task DeleteRoleByNameAsync(string roleName, CancellationToken cancellationToken)
        {
            var foundRole = await _roleManager.FindByNameAsync(roleName);

            if (foundRole is null)
            {
                throw new RoleNotFoundException();
            }

            var roleDeleteResult = await _roleManager.DeleteAsync(foundRole);

            if (!roleDeleteResult.Succeeded)
            {
                throw new UserDeleteException();
            }
        }
    }
}