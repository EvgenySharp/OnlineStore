using Catalog.Application.Validation;
using Catalog.Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.JsonPatch;

namespace Catalog.Application.Categories.Commands.UpdateCategory
{
    public class JsonPatchDocumentCategoryValidator : AbstractValidator<JsonPatchDocument<Category>>
    {
        public JsonPatchDocumentCategoryValidator()
        {
            RuleForEach(patchDoc => patchDoc.Operations)
                .SetValidator(new OperationValidator<Category>());
        }
    }
}