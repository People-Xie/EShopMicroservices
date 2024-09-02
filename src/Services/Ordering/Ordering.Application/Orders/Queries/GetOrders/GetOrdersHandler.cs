
using BuildingBlocks.Pagination;
using Ordering.Domain.Enums;

namespace Ordering.Application.Orders.Queries.GetOrders;

public class GetOrdersHandler(IApplicationDbContext context) : IQueryHandler<GetOrdersQuery, GetOrdersResult>
{
    public async Task<GetOrdersResult> Handle(GetOrdersQuery query, CancellationToken cancellationToken)
    {
        var pageIndex = query.PaginationRequest.pageIndex;
        var pageSize = query.PaginationRequest.pageSize;
        var count = await context.Orders.LongCountAsync(cancellationToken);


        var orders = await context.Orders
            .Include(o => o.OrderItems)
            .OrderBy(o => o.OrderName.Value)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return new GetOrdersResult(new PaginatedResult<OrderDto>(
            pageIndex,
            pageSize,
            count,
            orders.ToOrderDtoList() ));
    }
}
