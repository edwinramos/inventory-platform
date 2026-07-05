using InventoryPlatform.Application.Features.Authentication.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InventoryPlatform.Api.Endpoints;

public static class AuthenticationEndpoints
{
    public static IEndpointRouteBuilder MapAuthenticationEndpoints(
        this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/auth/register",
                async (
                    [FromBody] RegisterCommand command,
                    [FromServices] ISender sender) =>
                {
                    var response = await sender.Send(command);

                    return Results.Created(
                        $"/api/users/{response.Email}",
                        response);
                })
            .WithName("Register")
            .WithTags("Authentication")
            .Produces<RegisterResponse>(StatusCodes.Status201Created)
            .ProducesValidationProblem();

        return app;
    }
}
