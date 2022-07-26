using Restaurant.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Domain.Entities
{
    public class InfoDish : AuditableBaseEntity
    {
        public int IdDish { get; set; }
        public Dish Dish { get; set; }
        public int IdIngredient { get; set; }
        public Ingredients Ingredients { get; set; }
    }
}
