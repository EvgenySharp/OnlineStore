using Catalog.Application.DTOs.ResponseDtos.Manufacturers;
using FluentValidation;

namespace Catalog.Application.Manufacturers.Commands.CreateManufacturer
{
    public class CreateManufacturerCommandValidator : AbstractValidator<CreateManufacturerResponseDto>
    {
        public CreateManufacturerCommandValidator() 
        {
            RuleFor(command => command.Title)
                .NotEmpty().MaximumLength(64);
        }
    }
}