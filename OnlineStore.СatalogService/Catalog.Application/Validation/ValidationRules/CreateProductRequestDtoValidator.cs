using Catalog.Application.DTOs.RequestDtos.Products;
using FluentValidation;

namespace Catalog.Application.Validation.ValidationRules
{
    public class CreateProductRequestDtoValidator : AbstractValidator<CreateProductRequestDto>
    {
        public CreateProductRequestDtoValidator()
        {
            RuleFor(category => category.Title)
                .NotEmpty().MaximumLength(48);
        }
    }
}