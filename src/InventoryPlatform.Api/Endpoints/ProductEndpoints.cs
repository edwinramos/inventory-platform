using InventoryPlatform.Application.Features.Products.CreateProduct;
using InventoryPlatform.Application.Features.Products.GetProduct;
using InventoryPlatform.Application.Features.Products.GetProducts;
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
        group.MapGet("/{id:guid}", GetProduct);
        group.MapGet("/", GetProducts);
        
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
    
    private static async Task<IResult> GetProduct(
        Guid id,
        ISender sender)
    {
        var response = await sender.Send(
            new GetProductQuery(id));

        return Results.Ok(response);
    }
    
    private static async Task<IResult> GetProducts(
        [AsParameters] GetProductsQuery query,
        ISender sender)
    {
        var response = await sender.Send(new GetProductsQuery(query.Page, query.PageSize));
        
        return Results.Ok(response);
    }
}
