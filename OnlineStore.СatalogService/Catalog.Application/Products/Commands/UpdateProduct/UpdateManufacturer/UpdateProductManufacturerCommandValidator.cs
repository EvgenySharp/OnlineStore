using FluentValidation;

namespace Catalog.Application.Products.Commands.UpdateProduct.UpdateManufacturer
{
    public class UpdateProductManufacturerCommandValidator : AbstractValidator<UpdateProductManufacturerCommand>
    {
        public UpdateProductManufacturerCommandValidator()
        {
            RuleFor(command => command.ProductId)
                .NotEqual(Guid.Empty);

            RuleFor(command => command.JsonPatchProductDto)
                .NotNull().WithMessage("JsonPatch is required.")
                .SetValidator(new JsonPatchDocumentProductManufacturerValidator());
        }
    }
}