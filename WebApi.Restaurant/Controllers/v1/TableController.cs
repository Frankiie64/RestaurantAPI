using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Core.Application.Dtos.OrderWithDish;
using Restaurant.Core.Application.Dtos.Table;
using Restaurant.Core.Application.Interfaces.Services;
using Restaurant.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Restaurant.Controllers;

namespace WebApi.Restaurant.Controllers.v1
{
    [ApiVersion("1.0")]
    [Authorize]
    public class TableController : BaseApiController
    {
        private readonly ITableService services;
        private readonly IRequestServices Orderservices;
        private readonly IMapper mapper;

        public TableController(ITableService services, IMapper mapper, IRequestServices Orderservices)
        {
            this.services = services;
            this.mapper = mapper;
            this.Orderservices = Orderservices;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TableDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var Table = await services.GetAllViewModelAsync();

                if (Table == null || Table.Count == 0)
                {
                    return NotFound();
                }

                foreach (var item in Table)
                {
                    item.Disponibility = item.Stauts.ToString();
                }

                return Ok(Table);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TableDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var ingredient = await services.GetByIdSaveViewModelAsync(id);

                if (ingredient == null)
                {
                    return NotFound();
                }

                return Ok(ingredient);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [Authorize(Roles = "Waiter")]
        [HttpGet("GetOrders/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderWithDishDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetOrders(int id)
        {
            try
            {

                var table = await Orderservices.GetAllViewModelAsync();

                table = table.Where(x => x.IdTable == id).ToList();

                if (table == null || table.Count == 0)
                {
                    return NotFound();
                }

                return Ok(table);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [Authorize(Roles = "Waiter")]
        [HttpGet("ChangeStatus")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ChangeStatus(int id, StautsTable status)
        {
            try
            {
                if (id == 0 || (int)status == 0)
                {
                    return BadRequest();
                }

                var table = await services.GetByIdSaveViewModelAsync(id);

                if (table == null)
                {
                    return NotFound();
                }

                table.Stauts = status;

                await services.UpdateAsync(table, id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(CreateTableDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var data = mapper.Map<SaveTableDto>(dto);

                data.Stauts = StautsTable.Availble;
                await services.CreateAsync(data);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SaveTableDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(int id, CreateTableDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var ingredient = await services.GetByIdSaveViewModelAsync(id);

                if (ingredient == null)
                {
                    return NotFound();
                }

                var tableMapped = mapper.Map<SaveTableDto>(dto);

                tableMapped.Stauts = ingredient.Stauts;

                await services.UpdateAsync(tableMapped, id);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [Authorize(Roles = "Admin")]
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
