using InventoryPlatform.Application.Common.Interfaces;
using InventoryPlatform.Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace InventoryPlatform.Infrastructure.Identity;

public sealed class IdentityService : IIdentityService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public IdentityService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<(bool Succeeded, IEnumerable<string> Errors)> CreateUserAsync(
        string firstName,
        string lastName,
        string email,
        string password)
    {
        var user = new ApplicationUser
        {
            UserName = email,
            Email = email,
            FirstName = firstName,
            LastName = lastName
        };

        var result = await _userManager.CreateAsync(user, password);

        return (
            result.Succeeded,
            result.Errors.Select(e => e.Description));
    }
}
