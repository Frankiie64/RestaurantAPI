using Restaurant.Core.Application.Dtos.Account;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.Core.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<string> ConfirmEmailAsync(string userId, string token);
        Task<ForgotPassWordResponse> ForgotPasswordAsync(ForgotPassowordRequest forgotRequest, string origin);
        Task<AuthenticationResponse> LoginAsync(AuthenticationRequest LoginRequest);
        Task<RegisterResponse> RegisterAsync(RegisterRequest registerRequest, string origin);
        Task<ResetPasswordResponse> ResetPasswordAsync(ResetPasswordRequest resetRequest);       
        Task<RegisterResponse> UpdateUserAsync(RegisterRequest registerRequest);
        Task SignOutAsync();
    }
}