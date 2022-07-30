using AutoMapper;
using Restaurant.Core.Application.Dtos.Dish;
using Restaurant.Core.Application.Dtos.Indredients;
using Restaurant.Core.Application.Interfaces.Repositories;
using Restaurant.Core.Application.Interfaces.Services;
using Restaurant.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Application.Services
{
    public class DishServices : GenericServices<SaveDishDto, DishDto, Dish>, IDishServices
    {
        private readonly IDishRepository repo;
        private readonly IInfoDishRepository repoInfo;
        private readonly IMapper mapper;
        public DishServices(IDishRepository repo, IMapper mapper, IInfoDishRepository repoInfo) : base(repo, mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
            this.repoInfo = repoInfo;
        }
        public  async Task<List<DishDto>> GetAllViewModelWithIncludeAsync()
        {
            var list = await repo.GetAllWithIncludeAsync(new List<string> { "Ingredients", "Ingredients.Ingredients" });
            var listMapped = mapper.Map<List<DishDto>>(list);

            foreach (var item in listMapped)
            {
                foreach (var objecto in list)
                {
                    item.Ingredients = mapper.Map<List<IngredientDto>>(
                        objecto.Ingredients.Where(x => x.IdDish == item.Id).Select(x => x.Ingredients).ToList()
                        );
                }

                item.Cateogry = item.DishCategory.ToString();
                
            }           
            return listMapped;
        }

        public async Task<DishDto> GetByIdModel(int id)
        {
            var dish = await GetAllViewModelWithIncludeAsync();
            return dish.Where(x => x.Id == id).SingleOrDefault();
        }

    }

}
