using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Domain.Entities
{
    public class OrderWithDish
    {
        public int Id { get; set; }
        public int IdOrder { get; set; }
        public Request Order { get; set; }
        public int IdDish { get; set; }
    }
}
