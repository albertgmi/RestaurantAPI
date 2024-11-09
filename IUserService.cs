using RestaurantAPI.Models;

namespace RestaurantAPI
{
    public interface IUserService
    {
        void RegisterUser(RegisterUserDto userDto);
        string GenerateJwt(UserLoginDto loginDto);
    }
}
