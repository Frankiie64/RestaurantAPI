using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Application.Dtos.User
{
    public class RegisterUserDto
    {
        [Required(ErrorMessage = "Este Campo es Obligatorio")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Este Campo es Obligatorio")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "Este Campo es Obligatorio")]
        public string DocumementId { get; set; }
        [Required(ErrorMessage = "Este Campo es Obligatorio")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Este Campo es Obligatorio")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Este Campo es Obligatorio")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Este Campo es Obligatorio")]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Este Campo es Obligatorio")]
        public string PhoneNumber { get; set; }
    }
}
