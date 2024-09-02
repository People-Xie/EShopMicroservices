using BuildingBlocks.Pagination;
using Ordering.Application.Orders.Queries.GetOrders;

namespace Ordering.API.Endpoints;

//public record GetOrdersRequest(PaginationRequest paginationRequest);
public record GetOrdersResponse(PaginatedResult<OrderDto> Orders);

public class GetOrders : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/orders", async ([AsParameters] PaginationRequest request, ISender sender) =>
        {
            var orders = await sender.Send(new GetOrdersQuery(request));
            var result = orders.Adapt<GetOrdersResponse>();
            return Results.Ok(result);
        })
        .WithName("GetOrders")
        .Produces<GetOrdersResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Orders")
        .WithDescription("Get Orders");
    }
}
