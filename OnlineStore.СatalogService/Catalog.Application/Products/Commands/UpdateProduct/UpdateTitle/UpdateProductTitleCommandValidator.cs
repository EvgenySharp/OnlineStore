using FluentValidation;

namespace Catalog.Application.Products.Commands.UpdateProduct.UpdateTitle
{
    public class UpdateProductTitleCommandValidator : AbstractValidator<UpdateProductTitleCommand>
    {
        public UpdateProductTitleCommandValidator()
        {
            RuleFor(command => command.ProductId)
                .NotEqual(Guid.Empty);

            RuleFor(command => command.JsonPatchProductDto)
                .NotNull().WithMessage("JsonPatch is required.")
                .SetValidator(new JsonPatchDocumentProductValidator());
        }
    }
}