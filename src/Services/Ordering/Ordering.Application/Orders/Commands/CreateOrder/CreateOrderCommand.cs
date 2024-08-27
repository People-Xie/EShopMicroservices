using FluentValidation;

namespace Ordering.Application.Orders.Commands.CreateOrder;

public record CreateOrderResult(Guid Id);

public record CreateOrderCommand(OrderDto Order) : ICommand<CreateOrderResult>;

public class CreateOrderCommandValidation : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidation()
    {
        RuleFor(x => x.Order.OrderName).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Order.CustomerId).NotEmpty().WithMessage("CustomreId is required");
        RuleFor(x => x.Order.OrderItems).NotEmpty().WithMessage("OrderItems should not be empty");
    }
}