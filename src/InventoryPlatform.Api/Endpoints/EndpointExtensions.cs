using System.Reflection;
using InventoryPlatform.Api.Endpoints;

public static class EndpointExtensions
{
    public static IEndpointRouteBuilder MapEndpoints(
        this IEndpointRouteBuilder app)
    {
        var endpointType = typeof(IEndpoint);

        var endpoints = Assembly
            .GetExecutingAssembly()
            .DefinedTypes
            .Where(type =>
                type is { IsAbstract: false, IsInterface: false } &&
                endpointType.IsAssignableFrom(type));

        foreach (var endpoint in endpoints)
        {
            ((IEndpoint)Activator.CreateInstance(endpoint.AsType())!)
                .MapEndpoint(app);
        }

        return app;
    }
}
