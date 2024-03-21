using FluentValidation;
using Microsoft.AspNetCore.JsonPatch.Operations;

namespace Catalog.Application.Validation
{
    public class OperationValidator<TModel> : AbstractValidator<Operation<TModel>> where TModel : class
    {
        public OperationValidator()
        {
            RuleFor(op => op.path)
                .NotEmpty().WithMessage("Path is required.");

            RuleFor(op => op.op)
                .NotEmpty().WithMessage("Operation type is required.")
                .Must(op => op == "replace").WithMessage("Only 'replace' operation is supported.");

            RuleFor(op => op.value)
                .NotNull().WithMessage("Value is required.");
        }
    }
}