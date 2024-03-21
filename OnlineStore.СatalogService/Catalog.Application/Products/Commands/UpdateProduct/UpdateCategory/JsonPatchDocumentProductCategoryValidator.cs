using Catalog.Application.Validation;
using Catalog.Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.JsonPatch;

namespace Catalog.Application.Products.Commands.UpdateProduct.UpdateCategory
{
    public class JsonPatchDocumentProductCategoryValidator : AbstractValidator<JsonPatchDocument<Product>>
    {
        public JsonPatchDocumentProductCategoryValidator()
        {
            RuleForEach(patchDoc => patchDoc.Operations)
                .SetValidator(new OperationValidator<Product>());
        }
    }
}