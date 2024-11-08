using RestaurantAPI.Entities;

namespace RestaurantAPI
{
    public interface IRestaurantSeeder
    {
        void Seed(RestaurantDbContext dbContext);
    }
}
