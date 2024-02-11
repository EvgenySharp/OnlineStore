using Catalog.Application.DTOs.RequestDtos.Manufacturers;
using FluentValidation;

namespace Catalog.Application.Validation.ValidationRules
{
    public class CreateManufacturerRequestDtoValidator : AbstractValidator<CreateManufacturerRequestDto>
    {
        public CreateManufacturerRequestDtoValidator() 
        {
            RuleFor(manufacturer => manufacturer.Title)
                .NotEmpty().MaximumLength(48);
        }
    }
}