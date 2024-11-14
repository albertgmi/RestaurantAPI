using RestaurantAPI.Entities;

namespace RestaurantAPI.Seeders
{
    public interface IRestaurantSeeder
    {
        void Seed(RestaurantDbContext dbContext);
    }
}
