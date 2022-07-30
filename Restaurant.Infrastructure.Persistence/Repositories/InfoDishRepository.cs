using Restaurant.Core.Application.Interfaces.Repositories;
using Restaurant.Core.Domain.Entities;
using Restaurant.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Infrastructure.Persistence.Repositories
{
    public class InfoDishRepository : GenericRepository<InfoDish>, IInfoDishRepository
    {
        private readonly ApplicationDbContext db;

        public InfoDishRepository(ApplicationDbContext db) : base(db)
        {
            this.db = db;
        }
    }
}
