using RestaurantAPI.Models;
using System.Security.Claims;

namespace RestaurantAPI.Services.Restaurant
{
    public interface IRestaurantService
    {
        Guid Create(CreateRestaurantDto dto);
        PagedResult<RestaurantDto> GetAll(RestaurantQuery query);
        RestaurantDto GetById(string id);
        void Delete(string id);
        void Update(string id, UpdateRestaurantDto dto);
    }
}