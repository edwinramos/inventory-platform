using InventoryPlatform.Application.Common.Interfaces;
using MediatR;

namespace InventoryPlatform.Application.Features.Authentication.Login;

public sealed class LoginCommandHandler
    : IRequestHandler<LoginCommand, LoginResponse>
{
    private readonly IIdentityService _identityService;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public LoginCommandHandler(
        IIdentityService identityService,
        IJwtTokenGenerator jwtTokenGenerator)
    {
        _identityService = identityService;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<LoginResponse> Handle(
        LoginCommand request,
        CancellationToken cancellationToken)
    {
        var user = await _identityService.AuthenticateAsync(
            request.Email,
            request.Password);

        if (user is null)
        {
            throw new UnauthorizedAccessException("Invalid email or password.");
        }

        var accessToken = _jwtTokenGenerator.GenerateToken(
            user.Id,
            user.Email!);

        return new LoginResponse(
            accessToken,
            DateTime.UtcNow.AddMinutes(60));
    }
}
