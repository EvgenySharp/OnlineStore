using Catalog.Application.Validation;
using Catalog.Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.JsonPatch;

namespace Catalog.Application.Manufacturers.Commands.UpdateManufacturer
{
    public class JsonPatchDocumentManufacturerValidator : AbstractValidator<JsonPatchDocument<Manufacturer>>
    {
        public JsonPatchDocumentManufacturerValidator()
        {
            RuleForEach(patchDoc => patchDoc.Operations)
                .SetValidator(new OperationValidator<Manufacturer>());
        }
    }
}