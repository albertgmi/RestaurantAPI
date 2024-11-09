using AutoMapper;
using RestaurantAPI.Entities;
using RestaurantAPI.Models;
using System.Runtime.CompilerServices;

namespace RestaurantAPI.Services
{
    public class UserService : IUserService
    {
        private readonly RestaurantDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<DishService> _logger;

        public UserService(RestaurantDbContext context, IMapper mapper, ILogger<DishService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }
        public void RegisterUser(RegisterUserDto userDto)
        {
            var user = new User()
            {
                Email = userDto.Email,
                // PasswordHash = userDto.Password, póki co bez hasła
                Nationality = userDto.Nationality,
                DateOfBirth = userDto.DateOfBirth,
                RoleId = userDto.RoleId
            };
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
