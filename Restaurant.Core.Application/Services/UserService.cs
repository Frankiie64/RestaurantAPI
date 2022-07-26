using AutoMapper;
using Restaurant.Core.Application.Dtos.Account;
using Restaurant.Core.Application.Enums;
using Restaurant.Core.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IAccountServices accountServices;
        private readonly IMapper mapper;

        public UserService(IAccountServices accountServices, IMapper mapper)
        {
            this.accountServices = accountServices;
            this.mapper = mapper;
        }

        public async Task<AuthenticationResponse> LoginAsync(AuthenticationRequest LoginRequest)
        {
            AuthenticationResponse response = await accountServices.AuthenticationAsync(LoginRequest);
            return response;
        }
        public async Task SignOutAsync()
        {
            await accountServices.SignOutAsync();
        }
        public async Task<RegisterResponse>  RegisterAsync(RegisterRequest registerRequest, string origin)
        {
            return await accountServices.RegisterUserAsync(registerRequest, origin);
        }
        public async Task<RegisterResponse> UpdateUserAsync(RegisterRequest registerRequest)
        {
            return await accountServices.UpdateUserAsync(registerRequest);
        }
        public async Task<string> ConfirmEmailAsync(string userId, string token)
        {
            return await accountServices.ConfirmEmailAsync(userId, token);
        }
        public async Task<ForgotPassWordResponse> ForgotPasswordAsync(ForgotPassowordRequest forgotRequest, string origin)
        {
            return await accountServices.ForgotPasswordRequestAsync(forgotRequest, origin);
        }
        public async Task<ResetPasswordResponse> ResetPasswordAsync(ResetPasswordRequest resetRequest)
        {
            return await accountServices.ResetPasswordAsync(resetRequest);
        }
        
    }
}
