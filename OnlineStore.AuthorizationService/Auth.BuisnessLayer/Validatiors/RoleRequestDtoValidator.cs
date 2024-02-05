using Auth.BuisnessLayer.DTOs.RequestDTOs;
using FluentValidation;

namespace Auth.BuisnessLayer.Validatiors
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