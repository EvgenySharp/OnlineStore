using Catalog.Application.Validation;
using Catalog.Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.JsonPatch;

namespace Catalog.Application.Products.Commands.UpdateProduct.UpdateTitle
{
    public class JsonPatchDocumentProductValidator : AbstractValidator<JsonPatchDocument<Product>>
    {
        public JsonPatchDocumentProductValidator()
        {
            RuleForEach(patchDoc => patchDoc.Operations)
                .SetValidator(new OperationValidator<Product>());
        }
    }
}