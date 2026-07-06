using InventoryPlatform.Domain.Identity;

namespace InventoryPlatform.Application.Common.Interfaces;

public interface IIdentityService
{
    Task<(bool Succeeded, IEnumerable<string> Errors)> CreateUserAsync(
        string firstName,
        string lastName,
        string email,
        string password);
    
    Task<ApplicationUser?> AuthenticateAsync(
        string email,
        string password);
}
