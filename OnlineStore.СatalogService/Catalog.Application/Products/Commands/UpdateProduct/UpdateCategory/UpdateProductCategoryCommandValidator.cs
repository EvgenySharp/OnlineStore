using FluentValidation;

namespace Catalog.Application.Products.Commands.UpdateProduct.UpdateCategory
{
    public class UpdateProductCategoryCommandValidator : AbstractValidator<UpdateProductCategoryCommand>
    {
        public UpdateProductCategoryCommandValidator()
        {           
            RuleFor(command => command.ProductId)
                .NotEqual(Guid.Empty);

            RuleFor(command => command.JsonPatchProductDto)
                .NotNull().WithMessage("JsonPatch is required.")
                .SetValidator(new JsonPatchDocumentProductCategoryValidator());
        }
    }
}