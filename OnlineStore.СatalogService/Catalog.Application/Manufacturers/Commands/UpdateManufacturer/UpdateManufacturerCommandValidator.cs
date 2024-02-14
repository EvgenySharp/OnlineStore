using Catalog.Application.Manufacturers.Commands.UpdateBook;
using FluentValidation;

namespace Catalog.Application.Manufacturers.Commands.UpdateManufacturer
{
    public class UpdateManufacturerCommandValidator : AbstractValidator<UpdateManufacturerCommand>
    {
        public UpdateManufacturerCommandValidator()
        {
            RuleFor(command => command.ManufacturerId)
                .NotEqual(Guid.Empty);

            RuleFor(command => command.JsonPatchManufacturerDto)
                .NotNull().WithMessage("JsonPatch is required.")
                .SetValidator(new JsonPatchDocumentManufacturerValidator());
        }
    }
}