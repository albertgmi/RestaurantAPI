using RestaurantAPI.Models;

namespace RestaurantAPI.Services.UserFolder
{
    public interface IUserService
    {
        void RegisterUser(RegisterUserDto userDto);
        string GenerateJwt(UserLoginDto loginDto);
    }
}
