using Restaurant.Core.Application.Dtos.OrderWithDish;
using Restaurant.Core.Application.Dtos.Table;
using Restaurant.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Application.Dtos.Request
{
    public class RequestDto
    {
        public int Id { get; set; }
        public int IdTable { get; set; }
        public TableDto Table { get; set; }
        public double Subtotal { get; set; }
        public string Disponibility { get; set; }
        public StautsRequest stauts { get; set; }
        public ICollection<OrderWithDishDto> Dishes { get; set; }
    }
}
