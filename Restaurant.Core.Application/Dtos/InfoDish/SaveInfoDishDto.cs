using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Application.Dtos.InfoDish
{
    public class SaveInfoDishDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public int IdDish { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public int IdIngredient { get; set; }
    }
}
