using Auth.BuisnessLayer.DTOs.RequestDTOs;
using FluentValidation;

namespace Auth.BuisnessLayer.Validation.ValidationRules
{
    public class LoginUserRequestDtoValidator : AbstractValidator<LoginUserRequestDto>
    {
        public LoginUserRequestDtoValidator()
        {
            RuleFor(user => user.Name)
                .NotEmpty().MaximumLength(48);

            RuleFor(user => user.Password)
                .NotEmpty();
        }
    }
}