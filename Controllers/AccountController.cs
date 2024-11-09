using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Entities;
using RestaurantAPI.Models;
using RestaurantAPI.Services;

namespace RestaurantAPI.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _service;
        public AccountController(IUserService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public ActionResult Register([FromBody] RegisterUserDto userDto)
        {
            _service.RegisterUser(userDto);
            return Ok();
        }
    }
}
