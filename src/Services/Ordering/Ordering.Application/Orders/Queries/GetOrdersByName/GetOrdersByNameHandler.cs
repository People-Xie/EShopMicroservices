using Ordering.Application.Extensions;

namespace Ordering.Application.Orders.Queries.GetOrdersByName;

public class GetOrdersByNameHandler(IApplicationDbContext context)
    : IQueryHandler<GetOrdersByNameQuery, GetOrdersByNameResult>
{
    public async Task<GetOrdersByNameResult> Handle(GetOrdersByNameQuery query, CancellationToken cancellationToken)
    {
        var orders = await context.Orders
            .Include(o => o.OrderItems)
            .AsNoTracking()
            .Where(x => x.OrderName.Value.Contains(query.Name))
            .OrderBy(x => x.OrderName.Value)
            .ToListAsync(cancellationToken);

        var orderDtos = orders.ToOrderDtoList();

        return new GetOrdersByNameResult(orderDtos);        
    }
}
