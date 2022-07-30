using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Application.Dtos.OrderWithDish
{
    public class SaveOrderWithDishDto
    {
        public int Id { get; set; }
        public int IdOrder { get; set; }
        public int IdDish { get; set; }
    }
}
