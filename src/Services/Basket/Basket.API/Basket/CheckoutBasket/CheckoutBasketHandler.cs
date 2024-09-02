

using BuildingBlocks.Messaging.Events;
using MassTransit;

namespace Basket.API.Basket.CheckoutBasket;

public record CheckoutBasketCommand(BasketCheckoutDto BasketCheckoutDto) : ICommand<CheckoutBasketResult>;
public record CheckoutBasketResult(bool IsSuccess);

public class CheckoutBasketCommandValidator : AbstractValidator<CheckoutBasketCommand>
{
    public CheckoutBasketCommandValidator()
    {
        RuleFor(x => x.BasketCheckoutDto).NotNull().WithMessage("BasketCheckoutDto can't be null");
        RuleFor(x => x.BasketCheckoutDto.UserName).NotEmpty().WithMessage("UserName is required");
    }
}

public class CheckoutBasketHandler
    (IBasketRepository repository,IPublishEndpoint publishEndpoint) 
    : ICommandHandler<CheckoutBasketCommand, CheckoutBasketResult>
{
    public async Task<CheckoutBasketResult> Handle(CheckoutBasketCommand commad, CancellationToken cancellationToken)
    {
        var basket = await repository.GetBasket(commad.BasketCheckoutDto.UserName, cancellationToken);

        if (basket is null)
            return new CheckoutBasketResult(false);

        var eventMessage = commad.BasketCheckoutDto.Adapt<BasketCheckoutEvent>();
        eventMessage.TotalPrice = basket.TotalPrice;

        await publishEndpoint.Publish(eventMessage, cancellationToken);

        await repository.DeleteBasket(commad.BasketCheckoutDto.UserName, cancellationToken);

        return new CheckoutBasketResult(true);

    }
}
