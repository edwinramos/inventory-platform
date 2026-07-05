using InventoryPlatform.Application.Common.Interfaces;
using MediatR;

namespace InventoryPlatform.Application.Features.Authentication.Register;

public sealed class RegisterCommandHandler
    : IRequestHandler<RegisterCommand, RegisterResponse>
{
    private readonly IIdentityService _identityService;

    public RegisterCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<RegisterResponse> Handle(
        RegisterCommand request,
        CancellationToken cancellationToken)
    {
        var result = await _identityService.CreateUserAsync(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);

        if (!result.Succeeded)
        {
            throw new Exception(string.Join(Environment.NewLine, result.Errors));
        }

        return new RegisterResponse(request.Email);
    }
}
