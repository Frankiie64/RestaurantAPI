﻿using Restaurant.Core.Application.Interfaces.Repositories;
using Restaurant.Core.Domain.Entities;
using Restaurant.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Infrastructure.Persistence.Repositories
{
    public class DishRepository : GenericRepository<Dish>, IDishRepository
    {
        private readonly ApplicationDbContext db;

        public DishRepository(ApplicationDbContext db) : base(db)
        {
            this.db = db;
        }
    }
}
