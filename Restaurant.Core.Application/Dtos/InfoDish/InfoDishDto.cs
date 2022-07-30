using Restaurant.Core.Application.Dtos.Dish;
using Restaurant.Core.Application.Dtos.Indredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Application.Dtos.InfoDish
{
    public class InfoDishDto
    {
        public int Id { get; set; }
        public int IdDish { get; set; }
        public DishDto Dish { get; set; }
        public int IdIngredient { get; set; }
        public IngredientDto Ingredients { get; set; }
    }
}
