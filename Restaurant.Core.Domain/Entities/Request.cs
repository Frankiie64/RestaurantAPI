using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Domain.Entities
{
    public class Request
    {
        public int Id { get; set; }
        public int IdTable { get; set; }
        public Table Table { get; set; }
        public double Subtotal { get; set; }
        public StautsRequest stauts { get; set; }
        public ICollection<OrderWithDish> Dishes { get; set; }

    }
    public enum StautsRequest { InProcess = 1, Completed }
}
