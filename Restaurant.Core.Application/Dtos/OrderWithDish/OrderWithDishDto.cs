using Restaurant.Core.Application.Dtos.Dish;
using Restaurant.Core.Application.Dtos.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Application.Dtos.OrderWithDish
{
    public class OrderWithDishDto
    {
        public int Id { get; set; }
        public int IdOrder { get; set; }
        public int IdDish { get; set; }
        public DishDto Dish { get; set; }
    }
}
