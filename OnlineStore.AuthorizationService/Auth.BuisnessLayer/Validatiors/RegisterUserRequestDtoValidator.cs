using Auth.BuisnessLayer.DTOs.RequestDTOs;
using FluentValidation;

namespace Auth.BuisnessLayer.Validatiors
{
    public class RegisterUserRequestDtoValidator : AbstractValidator<RegisterUserRequestDto>
    {
        public RegisterUserRequestDtoValidator()
        {
            RuleFor(user => user.Name)
                .NotEmpty().MinimumLength(4).MaximumLength(48);

            RuleFor(user => user.Password)
                .NotEmpty().MaximumLength(24);

            RuleFor(user => user.ConfirmPassword)
                .NotEmpty().Equal(user => user.Password).MaximumLength(24);
        }
    }
}