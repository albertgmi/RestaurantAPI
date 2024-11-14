using System.Security.Claims;

namespace RestaurantAPI.Services.UserFolder
{
    public interface IUserContextService
    {
        ClaimsPrincipal User { get; }
        Guid? GetUserId { get; }
    }
}
