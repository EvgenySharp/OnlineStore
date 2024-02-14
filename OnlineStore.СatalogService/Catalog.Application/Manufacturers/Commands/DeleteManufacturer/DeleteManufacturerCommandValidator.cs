using FluentValidation;

namespace Catalog.Application.Manufacturers.Commands.DeleteManufacturer
{
    public class DeleteManufacturerCommandValidator : AbstractValidator<DeleteManufacturerCommand>
    {
        public DeleteManufacturerCommandValidator()
        {
            RuleFor(command => command.Id)
                .NotEqual(Guid.Empty);
        }
    }
}