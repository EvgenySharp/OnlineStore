using Catalog.Domain.Entities;
using FluentValidation;

namespace Catalog.Application.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator() 
        {
            RuleFor(command => command.CategoryId)
                .NotEqual(Guid.Empty);

            RuleFor(command => command.JsonPatchCategoryDto)
                .NotNull().WithMessage("JsonPatch is required.")
                .SetValidator(new JsonPatchDocumentCategoryValidator());
        }
    }
}