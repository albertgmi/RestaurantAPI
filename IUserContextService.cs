using System.Security.Claims;

namespace RestaurantAPI
{
    public interface IUserContextService
    {
        ClaimsPrincipal User { get; }
        Guid? GetUserId { get; }
    }
}
