using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Domain.Entities
{
    public class Ingredients
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<InfoDish> Dishes { get; set; }
    }
}
