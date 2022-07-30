using Restaurant.Core.Application.Dtos.OrderWithDish;
using Restaurant.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Application.Interfaces.Services
{
    public interface IOrderWithDishServices : IGenericServices<SaveOrderWithDishDto, OrderWithDishDto, OrderWithDish>
    {
    }
}
