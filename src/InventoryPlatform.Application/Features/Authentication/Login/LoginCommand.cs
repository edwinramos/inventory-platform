using MediatR;

namespace InventoryPlatform.Application.Features.Authentication.Login;

public sealed record LoginCommand(
    string Email,
    string Password)
    : IRequest<LoginResponse>;
