using FluentValidation;

namespace Catalog.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(command => command.CreateProtuctRequestDto.Title)
                .NotEmpty().MaximumLength(64);
        }
    }
}