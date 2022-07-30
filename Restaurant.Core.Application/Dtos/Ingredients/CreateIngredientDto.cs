using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Application.Dtos.Indredients
{
    public class CreateIngredientDto
    {
        [Required(ErrorMessage ="Este campo es obligatorio.")]
        public string Name { get; set; }
    }
}
