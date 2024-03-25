using FluentValidation;
using Order.Application.DTOs.RequestDtos.Orders;

namespace Order.Application.Validation.ValidationRules
{
    public class OrderRequestDtoValidator : AbstractValidator<CreateOrderRequestDto>
    {
        public OrderRequestDtoValidator()
        {
            RuleFor(order => order.FirstName)
                .NotEmpty().MaximumLength(128);

            RuleFor(order => order.LastName)
                .NotEmpty().MaximumLength(128);

            RuleFor(order => order.Address)
                .NotEmpty().MaximumLength(128);

            RuleFor(order => order.Comment)
                .NotEmpty().MaximumLength(128);

            RuleFor(order => order.Email)
                .NotEmpty().MaximumLength(128);

            RuleFor(order => order.Town)
                .NotEmpty().MaximumLength(128);

            RuleFor(order => order.ProductIds)
                .NotEmpty();
        }
    }
}