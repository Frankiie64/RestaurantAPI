using Restaurant.Core.Application.Dtos.Indredients;
using Restaurant.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Application.Interfaces.Services
{
   public interface IIngredientServices : IGenericServices<SaveIngredientDto, IngredientDto,Ingredients>
    {
    }
}
