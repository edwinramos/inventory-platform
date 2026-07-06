using InventoryPlatform.Application.Features.Authentication.Login;
using InventoryPlatform.Application.Features.Authentication.Register;
using MediatR;

namespace InventoryPlatform.Api.Endpoints;

public static class AuthenticationEndpoints
{
    public static IEndpointRouteBuilder MapAuthenticationEndpoints(
        this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/auth/register", Register)
            .WithName("Register")
            .WithTags("Authentication")
            .Produces<RegisterResponse>(StatusCodes.Status201Created)
            .ProducesValidationProblem();

        app.MapPost("/api/auth/login", Login)
            .WithName("Login")
            .WithTags("Authentication")
            .Produces<LoginResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status401Unauthorized)
            .ProducesValidationProblem();

        return app;
    }

    private static async Task<IResult> Register(
        RegisterCommand command,
        ISender sender)
    {
        var response = await sender.Send(command);

        return Results.Created(
            $"/api/users/{response.Email}",
            response);
    }

    private static async Task<IResult> Login(
        LoginCommand command,
        ISender sender)
    {
        var response = await sender.Send(command);

        return Results.Ok(response);
    }
}
