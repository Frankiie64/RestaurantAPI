﻿using Restaurant.Core.Domain.Common;
using Restaurant.Core.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Domain.Entities
{
    public class Dish 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int DishFor { get; set; }
        public Category DishCategory { get; set; }
        //Navegation Property
        public ICollection<InfoDish> Ingredients { get; set; }
    }

}
