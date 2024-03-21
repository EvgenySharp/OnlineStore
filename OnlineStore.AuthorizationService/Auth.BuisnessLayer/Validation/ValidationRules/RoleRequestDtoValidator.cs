using Auth.BuisnessLayer.DTOs.RequestDTOs;
using FluentValidation;

namespace Auth.BuisnessLayer.Validation.ValidationRules
{
    public class RoleRequestDtoValidator : AbstractValidator<RoleRequestDto>
    {
        public RoleRequestDtoValidator()
        {
            RuleFor(role => role.Name)
                .NotEmpty().MaximumLength(128);
        }
    }
}