using Restaurant.Core.Application.Dtos.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Application.Interfaces.Services
{
   public interface IEmailService
    {
        Task SendAsync(EmailRequest request);
    }
}
