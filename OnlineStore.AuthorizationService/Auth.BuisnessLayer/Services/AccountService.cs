using Auth.BuisnessLayer.Abstractions.Interfaces;
using Auth.BuisnessLayer.DTOs.RequestDTOs;
using Auth.BuisnessLayer.DTOs.ResponseDTOs;
using Auth.BuisnessLayer.Exceptions;
using Auth.DataAccessLayer.Entity;
using Auth.DataAccessLayer.Enums;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Auth.BuisnessLayer.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly TokenService _tokenService;
        private readonly IMapper _mapper;

        public AccountService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _tokenService = new TokenService();
            _mapper = mapper;
        }

        public async Task<LoginUserResponseDto> LoginUserAsync(LoginUserRequestDto loginUserRequestDto, CancellationToken cancellationToken=default)
        {
            var userEntity = await _userManager.FindByNameAsync(loginUserRequestDto.Name);

            if (userEntity is null)
            {
                throw new UserNotFoundException();
            }

            var signInResult = await _signInManager.PasswordSignInAsync(userEntity, loginUserRequestDto.Password, false, false);
            
            if (!signInResult.Succeeded)
            {
                throw new UserLoginException();
            }

            var loginUserResponseDto = _mapper.Map<LoginUserResponseDto>(userEntity);

            await _tokenService.SetJwtTokenAsync(loginUserResponseDto, cancellationToken);
            
            return loginUserResponseDto;
        }

        public async Task<RegisterUserResponseDto> RegisterUserAsync(RegisterUserRequestDto registerUserRequestDto, CancellationToken cancellationToken)
        {
            var foundUser = await _userManager.FindByNameAsync(registerUserRequestDto.Name);

            if (foundUser is not null)
            {
                throw new UserAlreadyExistsException();
            }

            var newUser = _mapper.Map<User>(registerUserRequestDto);
            var userCreationResult = await _userManager.CreateAsync(newUser, registerUserRequestDto.Password);

            if (!userCreationResult.Succeeded)
            {
                throw new UserCreationException();
            }

            await _userManager.AddToRoleAsync(newUser, Roles.User.ToString());

            var userResponseDto = _mapper.Map<RegisterUserResponseDto>(newUser);

            return userResponseDto;
        }
        
        public async Task<IEnumerable<GetUserResponseDto>> GetAllUserAsync(CancellationToken cancellationToken)
        {
            var usersList = await _userManager.Users.ToListAsync();
            var getUserResponseDtoList = new List<GetUserResponseDto>();
            
            foreach (var user in usersList) 
            {
                getUserResponseDtoList.Add(_mapper.Map<GetUserResponseDto>(user));
            }

            return getUserResponseDtoList;
        }

        public async Task<GetUserResponseDto> GetUserByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var foundUser = await _userManager.FindByIdAsync(id.ToString());

            if (foundUser is null)
            {
                throw new UserNotFoundException();
            }

            var getUserResponseDto = _mapper.Map<GetUserResponseDto>(foundUser);

            return getUserResponseDto;
        }

        public async Task UpdatePasswordAsync(UpdateUserRequestDto updateUserRequestDto, CancellationToken cancellationToken)
        {
            var foundUser = await _userManager.FindByNameAsync(updateUserRequestDto.Name);
            
            if (foundUser is null)
            {
                throw new UserNotFoundException();
            }

            var userChangeResult = await _userManager.ChangePasswordAsync(foundUser, updateUserRequestDto.CurrentPassword, updateUserRequestDto.NewPassword);

            if (!userChangeResult.Succeeded)
            {
                throw new UserUpdateException();
            }

            return;
        }

        public async Task DeleteUserByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var foundUser = await _userManager.FindByIdAsync(id.ToString());

            if (foundUser is null)
            {
                throw new UserNotFoundException();
            }

            var userDeleteResult = await _userManager.DeleteAsync(foundUser);

            if (!userDeleteResult.Succeeded)
            {
                throw new UserDeleteException();
            }

            return;
        }

        public async Task<RoleResponseDto> СreateRoleAsync(RoleRequestDto roleRequestDto, CancellationToken cancellationToken)
        {
            //var s = (Roles)roleRequestDto;
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
            var roleResponseDtoList = new List<RoleResponseDto>();

            foreach (var role in rolesList)
            {
                roleResponseDtoList.Add(_mapper.Map<RoleResponseDto>(role));
            }

            return roleResponseDtoList;
        }

        public async Task<RoleResponseDto> GetRoleByNameAsync(RoleRequestDto roleRequestDto, CancellationToken cancellationToken)
        {
            var foundRole = await _roleManager.FindByNameAsync(roleRequestDto.Name);

            if (foundRole is null)
            {
                throw new RoleNotFoundException();
            }

            var roleResponseDto = _mapper.Map<RoleResponseDto>(foundRole);

            return roleResponseDto;
        }

        public async Task DeleteRoleByNameAsync(RoleRequestDto roleRequestDto, CancellationToken cancellationToken)
        {
            var foundRole = await _roleManager.FindByNameAsync(roleRequestDto.Name);

            if (foundRole is null)
            {
                throw new RoleNotFoundException();
            }

            var roleDeleteResult = await _roleManager.DeleteAsync(foundRole);

            if (!roleDeleteResult.Succeeded)
            {
                throw new UserDeleteException();
            }

            return;
        }
    }
}