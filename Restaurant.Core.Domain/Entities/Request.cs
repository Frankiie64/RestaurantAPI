using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Domain.Entities
{
    public class Request
    {
        public int IdTable { get; set; }
        public Table Table { get; set; }
        public ICollection<int> IdDishes { get; set; }
        public double Subtotal { get; set; }
        public enum Stauts { InProcess,Completed }
    }
}
