using Auth.BuisnessLayer.DTOs.RequestDTOs;
using FluentValidation;

namespace Auth.BuisnessLayer.Validatiors
{
    public class UpdateUserRequestDtoValidator : AbstractValidator<UpdateUserRequestDto>
    {
        public UpdateUserRequestDtoValidator()
        {
            RuleFor(user => user.Name)
                .NotEmpty().MaximumLength(48);

            RuleFor(user => user.CurrentPassword)
                .NotEmpty().MaximumLength(24);

            RuleFor(user => user.NewPassword)
                .NotEmpty().NotEqual(user => user.CurrentPassword).MaximumLength(24);
        }
    }
}