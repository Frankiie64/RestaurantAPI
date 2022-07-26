using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Application.Dtos.Account
{
    public class AuthenticationRequest
    {
        [Required(ErrorMessage = "Este Campo es Obligatorio")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Este Campo es Obligatorio")]
        public string Password { get; set; }
        
    }
}
