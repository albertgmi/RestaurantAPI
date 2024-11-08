using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Entities;
using RestaurantAPI.Models;
using RestaurantAPI.Services;

namespace RestaurantAPI.Controllers
{
    [Route("api/restaurant")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _service;
        public RestaurantController(IRestaurantService service)
        {
            _service = service;
        }
        [HttpPut("{id}")]
        public ActionResult Update([FromRoute]string id, [FromBody]UpdateRestaurantDto dto)
        {
            _service.Update(id, dto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] string id)
        {
            _service.Delete(id);
            return NoContent();
        }
        [HttpPost]
        public ActionResult CreateRestaurant([FromBody] CreateRestaurantDto dto)
        {
            var restaurantId = _service.Create(dto);
            return Created($"/api/restaurant/{restaurantId}", null);
        }

        [HttpGet]
        public ActionResult<IEnumerable<RestaurantDto>> GetAll()
        {
            var restaurantsDtos = _service.GetAll();
            return Ok(restaurantsDtos);
        }
        [HttpGet("{id}")]
        public ActionResult<RestaurantDto> GetOne([FromRoute]string id)
        {
            var restaurantDto = _service.GetById(id);
            return Ok(restaurantDto);
        }
    }
}
