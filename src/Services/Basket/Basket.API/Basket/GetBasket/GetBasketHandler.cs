namespace Basket.API.Basket.GetBasket;

public record GetBasetQuery(string userName) : IQuery<GetBasketResult>;
public record GetBasketResult(ShoppingCart Card);

public class GetBasketQueryHandler(IBasketRepository repository) : IQueryHandler<GetBasetQuery, GetBasketResult>
{
    public async  Task<GetBasketResult> Handle(GetBasetQuery query, CancellationToken cancellationToken)
    {
        var basket = await repository.GetBasket(query.userName);

        return new GetBasketResult(basket);
    }
}
