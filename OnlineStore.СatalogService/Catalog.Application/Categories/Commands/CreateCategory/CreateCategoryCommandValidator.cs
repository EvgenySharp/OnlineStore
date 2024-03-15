using Catalog.Application.Categories.Commands.CreateCategories;
using FluentValidation;

namespace Catalog.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(command => command.CreateCategoryRequestDto.Title)
                .NotEmpty().MaximumLength(64);
        }
    }
}