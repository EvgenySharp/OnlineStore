using Catalog.Application.DTOs.RequestDtos.Manufacturers;
using FluentValidation;

namespace Catalog.Application.Validation.ValidationRules
{
    public class CreateCategoryRequestDtoValidator : AbstractValidator<CreateManufacturerRequestDto>
    {
        public CreateCategoryRequestDtoValidator()
        {
            RuleFor(category => category.Title)
                .NotEmpty().MaximumLength(48);
        }
    }
}