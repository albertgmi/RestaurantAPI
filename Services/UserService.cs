using AutoMapper;
using Microsoft.AspNetCore.Identity;
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
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserService(RestaurantDbContext context, IMapper mapper, ILogger<DishService> logger, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _passwordHasher = passwordHasher;
        }
        public void RegisterUser(RegisterUserDto userDto)
        {
            var user = new User()
            {
                Email = userDto.Email,
                Nationality = userDto.Nationality,
                DateOfBirth = userDto.DateOfBirth,
                RoleId = userDto.RoleId
            };
            var hashedPassword = _passwordHasher.HashPassword(user, userDto.Password);

            user.PasswordHash = hashedPassword;

            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
