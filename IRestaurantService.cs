using RestaurantAPI.Models;

namespace RestaurantAPI.Services
{
    public interface IRestaurantService
    {
        Guid Create(CreateRestaurantDto dto);
        IEnumerable<RestaurantDto> GetAll();
        RestaurantDto GetById(string id);
        void Delete(string id);
        void Update(string id, UpdateRestaurantDto dto);
    }
}