using Catalog.Application.Validation;
using Catalog.Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.JsonPatch;

namespace Catalog.Application.Products.Commands.UpdateProduct.UpdateManufacturer
{
    public class JsonPatchDocumentProductManufacturerValidator : AbstractValidator<JsonPatchDocument<Product>>
    {
        public JsonPatchDocumentProductManufacturerValidator()
        {
            RuleForEach(patchDoc => patchDoc.Operations)
                .SetValidator(new OperationValidator<Product>());
        }
    }
}