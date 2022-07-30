using Restaurant.Core.Application.Dtos.Indredients;
using Restaurant.Core.Application.Dtos.InfoDish;
using Restaurant.Core.Application.Enums;
using Restaurant.Core.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Application.Dtos.Dish
{
    public class DishDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int DishFor { get; set; }
        public string Cateogry { get; set; }
        public Category DishCategory { get; set; }
        public List<IngredientDto> Ingredients { get; set; }

    }
}
