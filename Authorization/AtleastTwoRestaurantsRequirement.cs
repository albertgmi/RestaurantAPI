using Microsoft.AspNetCore.Authorization;

namespace RestaurantAPI.Authorization
{
    public class AtleastTwoRestaurantsRequirement : IAuthorizationRequirement
    {
        public int MinimumRestaurantCreated { get; }
        public AtleastTwoRestaurantsRequirement(int minimumRestaurantCreated)
        {
            MinimumRestaurantCreated = minimumRestaurantCreated;
        }
    }
}
