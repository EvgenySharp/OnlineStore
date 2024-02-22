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
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AccountService(
            UserManager<User> userManager, 
            SignInManager<User> signInManager, 
            ITokenService tokenService, 
            IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
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
            
            _tokenService.SetJwtToken(loginUserResponseDto, cancellationToken);
            
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
        
        public async Task<UsersPageResponseDto> GetAllUserAsync(GetUserRequestDto getUserRequestDto, CancellationToken cancellationToken)
        {
            var users = await _userManager.Users
                .Skip(getUserRequestDto.PageSize * (getUserRequestDto.PageCount-1))
                .Take(getUserRequestDto.PageSize)
                .OrderByDescending(u  => u.UserName)
                .ToListAsync();

            var useesPage = GetUsersPage(getUserRequestDto, users);

            return useesPage;
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

        public async Task СhangePasswordAsync(СhangePasswordRequestDto changePasswordRequestDto, CancellationToken cancellationToken)
        {
            var foundUser = await _userManager.FindByNameAsync(changePasswordRequestDto.Name);
            
            if (foundUser is null)
            {
                throw new UserNotFoundException();
            }

            var userChangeResult = await _userManager.ChangePasswordAsync(foundUser, changePasswordRequestDto.CurrentPassword, changePasswordRequestDto.NewPassword);

            if (!userChangeResult.Succeeded)
            {
                throw new UserUpdateException();
            }
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
        }

        private UsersPageResponseDto GetUsersPage(GetUserRequestDto getUserRequestDto, IEnumerable<User> users)
        {
            var usersPage = new UsersPageResponseDto
            {
                Users = _mapper.Map<List<GetUserResponseDto>>(users),
                PageCount = getUserRequestDto.PageCount,
                PageSize = getUserRequestDto.PageSize,
                TotalUsersCount = _userManager.Users.Count()
            };

            return usersPage;
        }
    }
}