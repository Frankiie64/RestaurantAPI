using Restaurant.Core.Application.Enums;
using Restaurant.Core.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Application.Dtos.Dish
{
   public class SaveDishDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int DishFor { get; set; }
        public Category DishCategory { get; set; }
        public List<int> Ingredients { get; set; }
    }
}
