﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Entities;
using RestaurantAPI.Models;
using RestaurantAPI.Services.RestaurantServiceFolder;
using System.Security.Claims;

namespace RestaurantAPI.Controllers
{
    [Route("api/restaurant")]
    [ApiController]
    [Authorize]
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
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult CreateRestaurant([FromBody] CreateRestaurantDto dto)
        {
            var userId = User.FindFirst(c=>c.Type == ClaimTypes.NameIdentifier).Value;

            var restaurantId = _service.Create(dto);
            return Created($"/api/restaurant/{restaurantId}", null);
        }

        [HttpGet]
        // [Authorize(Policy = "Atleast2restaurants")]
        public ActionResult<PagedResult<RestaurantDto>> GetAll([FromQuery] RestaurantQuery query)
        {
            var restaurantsDtos = _service.GetAll(query);
            return Ok(restaurantsDtos);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<RestaurantDto> GetOne([FromRoute]string id)
        {
            var restaurantDto = _service.GetById(id);
            return Ok(restaurantDto);
        }
    }
}
