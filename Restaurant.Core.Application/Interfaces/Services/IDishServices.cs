using Restaurant.Core.Application.Dtos.Dish;
using Restaurant.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Application.Interfaces.Services
{
   public interface IDishServices : IGenericServices<SaveDishDto,DishDto,Dish>
    {
        Task<List<DishDto>> GetAllViewModelWithIncludeAsync();
        Task<DishDto> GetByIdModel(int id);
    }
}
