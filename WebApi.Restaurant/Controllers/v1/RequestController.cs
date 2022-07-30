using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Core.Application.Dtos.OrderWithDish;
using Restaurant.Core.Application.Dtos.Request;
using Restaurant.Core.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Restaurant.Controllers;

namespace WebApi.Restaurant.Controllers.v1
{
    [ApiVersion("1.0")]
    [Authorize(Roles = "Waiter")]
    public class RequestController : BaseApiController
    {
        private readonly IRequestServices services;
        private readonly IOrderWithDishServices servicesOrder;
        private readonly IMapper mapper;

        public RequestController(IRequestServices services, IMapper mapper, IOrderWithDishServices servicesOrder)
        {
            this.services = services;
            this.servicesOrder = servicesOrder;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RequestDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var orders = await services.GetAllViewModelWithIncludeAsync();

                if (orders == null || orders.Count == 0)
                {
                    return NotFound();
                }

                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RequestDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var order = await services.GetByIdModel(id);

                if (order == null)
                {
                    return NotFound();
                }

                return Ok(order);
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
        public async Task<IActionResult> Post(CreateRequestDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var data = mapper.Map<SaveRequestDto>(dto);

                var created = await services.CreateAsync(data);

                foreach (var plates in dto.Dishes)
                {
                    SaveOrderWithDishDto model = new SaveOrderWithDishDto
                    {
                        IdOrder = created.Id,
                        IdDish = plates
                    };
                    await servicesOrder.CreateAsync(model);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SaveRequestDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(int id, SaveRequestDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var order = await services.GetByIdModel(id);

                if (order == null)
                {
                    return NotFound();
                }

                var list = await servicesOrder.GetAllViewModelAsync();

                foreach (var item in list)
                {
                    if (item.IdOrder == dto.Id)
                    {
                        await servicesOrder.DeleteAsync(item.Id);
                    }
                }
                foreach (var plates in dto.Dishes)
                {
                    SaveOrderWithDishDto model = new SaveOrderWithDishDto
                    {
                        IdOrder = id,
                        IdDish = plates
                    };
                    await servicesOrder.CreateAsync(model);
                }

                await services.UpdateAsync(dto, id);


                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await services.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}

   
