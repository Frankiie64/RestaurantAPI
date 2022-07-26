using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Core.Application.Dtos.Account;
using Restaurant.Core.Application.Dtos.User;
using Restaurant.Core.Application.Enums;
using Restaurant.Core.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Restaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountServices _accountService;
        private readonly IMapper mapper;
        public AccountController(IAccountServices accountService,IMapper mapper)
        {
            _accountService = accountService;
            this.mapper = mapper;
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateAsync(AuthenticationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(StatusCodes.Status400BadRequest);
            }

            var response = await _accountService.AuthenticationAsync(request);
            if (response.HasError)
            {
                return NotFound(response.Error);
            }

            return Ok(response);
        }
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("register-waiter")]
        public async Task<IActionResult> RegisterWaiterAsync(RegisterUserDto request)
        {
            var origin = Request.Headers["origin"];
            var userRequest = mapper.Map<RegisterRequest>(request);
            userRequest.Rol = Roles.Waiter.ToString();
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                await _accountService.RegisterUserAsync(userRequest, origin);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("register-admin")]
        public async Task<IActionResult> RegisterAdminAsync(RegisterUserDto request)
        {
            var origin = Request.Headers["origin"];
            var userRequest = mapper.Map<RegisterRequest>(request);
            userRequest.Rol = Roles.Admin.ToString();
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }              
                await _accountService.RegisterUserAsync(userRequest,origin);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }         
        }

        /*
        [HttpGet("confirm-email")]
        public async Task<IActionResult> RegisterAsync([FromQuery] string userId, [FromQuery] string token)
        {
            return Ok(await _accountService.ConfirmEmailAsync(userId, token));
        }


        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPasswordAsync(ForgotPassowordRequest request)
        {
            var origin = Request.Headers["origin"];
            return Ok(await _accountService.ForgotPasswordRequestAsync(request, origin));
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPasswordAsync(ResetPasswordRequest request)
        {
            return Ok(await _accountService.ResetPasswordAsync(request));
        }*/
    }
}
