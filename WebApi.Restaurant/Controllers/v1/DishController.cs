using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Core.Application.Dtos.Dish;
using Restaurant.Core.Application.Dtos.InfoDish;
using Restaurant.Core.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Restaurant.Controllers;

namespace WebApi.Restaurant.Controllers.v1
{
    [ApiVersion("1.0")]
    [Authorize(Roles = "Admin")]
    public class DishController : BaseApiController
    {
        private readonly IDishServices services;
        private readonly IInfoDishServices Infoservices;
        private readonly IMapper mapper;

        public DishController(IDishServices services, IMapper mapper, IInfoDishServices Infoservices)
        {
            this.services = services;
            this.Infoservices = Infoservices;
            this.mapper = mapper;            
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DishDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var dish = await services.GetAllViewModelWithIncludeAsync();

                if (dish == null || dish.Count == 0)
                {
                    return NotFound();
                }

                return Ok(dish);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DishDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var dish = await services.GetByIdModel(id);

                if (dish == null)
                {
                    return NotFound();
                }

                return Ok(dish);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(CreateDishDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var data = mapper.Map<SaveDishDto>(dto);

                var created = await services.CreateAsync(data);

                foreach (var IdIngredient in dto.Ingredients)
                {
                    SaveInfoDishDto model = new SaveInfoDishDto
                    {
                        IdDish = created.Id,
                        IdIngredient = IdIngredient
                    };

                    await Infoservices.CreateAsync(model);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DishDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(int id, SaveDishDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var ingredient = await services.GetByIdModel(id);

                if (ingredient == null)
                {
                    return NotFound();
                }

                var list = await Infoservices.GetAllViewModelAsync();

                foreach (var item in list)
                {
                    if (item.IdDish == dto.Id)
                    {
                        await Infoservices.DeleteAsync(item.Id);
                    }
                }

                await services.UpdateAsync(dto, id);

                foreach (var IdIngredient in dto.Ingredients)
                {
                    SaveInfoDishDto model = new SaveInfoDishDto
                    {
                        IdDish = ingredient.Id,
                        IdIngredient = IdIngredient
                    };

                    await Infoservices.CreateAsync(model);
                }

                var response = await services.GetByIdModel(id);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


    }
}
