using InventoryPlatform.Application.Features.Products.CreateProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InventoryPlatform.Api.Endpoints;

public static class ProductEndpoints
{
    public static IEndpointRouteBuilder MapProductEndpoints(
        this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/products")
            .WithTags("Products")
            .RequireAuthorization();

        group.MapPost("/", CreateProduct);

        return app;
    }

    private static async Task<IResult> CreateProduct(
        [FromBody] CreateProductCommand command,
        [FromServices] ISender sender)
    {
        var response = await sender.Send(command);

        return Results.Created(
            $"/api/products/{response.Id}",
            response);
    }
}
