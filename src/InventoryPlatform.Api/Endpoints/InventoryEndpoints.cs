using InventoryPlatform.Application.Features.Inventory.AddStock;
using InventoryPlatform.Application.Features.Inventory.GetCurrentStock;
using InventoryPlatform.Application.Features.Inventory.GetInventoryHistory;
using InventoryPlatform.Application.Features.Inventory.RemoveStock;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryPlatform.Api.Endpoints;

public static class InventoryEndpoints
{
    public static IEndpointRouteBuilder MapInventoryEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/inventory")
            .WithTags("Inventory")
            .RequireAuthorization();

        group.MapPost("/add-stock", AddStock)
            .WithName("AddStock")
            .Produces(StatusCodes.Status200OK)
            .ProducesValidationProblem();

        group.MapPost("/remove-stock", RemoveStock)
            .WithName("RemoveStock")
            .Produces(StatusCodes.Status200OK)
            .ProducesValidationProblem();
        
        group.MapGet("/{productId:guid}", GetCurrentStock)
            .WithName("GetCurrentStock")
            .Produces<GetCurrentStockResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);
        
        group.MapGet("/{productId:guid}/history", GetInventoryHistory)
            .WithName("GetInventoryHistory")
            .Produces<List<InventoryMovementDto>>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);
        
        return app;
    }

    private static async Task<IResult> AddStock(
        [FromBody] AddStockCommand command,
        [FromServices] ISender sender)
    {
        await sender.Send(command);

        return Results.Ok();
    }

    private static async Task<IResult> RemoveStock(
        [FromBody] RemoveStockCommand command,
        [FromServices] ISender sender)
    {
        await sender.Send(command);

        return Results.Ok();
    }
    
    private static async Task<IResult> GetCurrentStock(
        Guid productId,
        [FromServices] ISender sender)
    {
        var response = await sender.Send(
            new GetCurrentStockQuery(productId));

        return Results.Ok(response);
    }
    
    private static async Task<IResult> GetInventoryHistory(
        Guid productId,
        [FromServices] ISender sender)
    {
        var response = await sender.Send(
            new GetInventoryHistoryQuery(productId));

        return Results.Ok(response);
    }
}
