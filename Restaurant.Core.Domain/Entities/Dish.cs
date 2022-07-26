using Restaurant.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Domain.Entities
{
    public class Dish : AuditableBaseEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int DishFor { get; set; }
        public enum Category {Entry,Launch,Desser,Drink }
        public Category DishCategory { get; set; }
        //Navegation Property
        public ICollection<InfoDish> Ingredients { get; set; }
    }
}
