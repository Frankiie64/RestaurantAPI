using AutoMapper;
using Restaurant.Core.Application.Dtos.Request;
using Restaurant.Core.Application.Dtos.Table;
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
    public class RequestService : GenericServices<SaveRequestDto, RequestDto, Request>, IRequestServices
    {
        private readonly IRequestRepository repo;
        private readonly IDishServices dishServices;
        private readonly ITableService tableService;
        private readonly IMapper mapper;
        public RequestService(IRequestRepository repo, IMapper mapper, IDishServices dishServices, ITableService tableService) : base(repo, mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
            this.dishServices = dishServices;
            this.tableService = tableService;
        }

        public async Task<List<RequestDto>> GetAllViewModelWithIncludeAsync()
        {
            var listMapped = mapper.Map<List<RequestDto>>( await repo.GetAllWithIncludeAsync(new List<string> { "Dishes"}));
            

            foreach (var item in listMapped)
            {
                foreach (var plate in item.Dishes)
                {
                    plate.Dish = await dishServices.GetByIdModel(plate.IdDish);
                }

                item.Disponibility = item.stauts.ToString();

                foreach (var prices in item.Dishes)
                {
                    item.Subtotal += prices.Dish.Price;
                }
                var save = await tableService.GetByIdSaveViewModelAsync(item.IdTable);
                item.Table = mapper.Map<TableDto>(save);

                item.Table.Disponibility = item.Table.Stauts.ToString();
            }


            return listMapped;
        }

        public async Task<RequestDto> GetByIdModel(int id)
        {
            var list = await GetAllViewModelWithIncludeAsync();

            return list.Where(x => x.Id == id).SingleOrDefault();
        }

        public override async Task<List<RequestDto>> GetAllViewModelAsync()
        {
            var listMapped = mapper.Map<List<RequestDto>>(await repo.GetAllWithIncludeAsync(new List<string> { "Dishes" }));

            foreach (var item in listMapped)
            {
                foreach (var plate in item.Dishes)
                {
                    plate.Dish = await dishServices.GetByIdModel(plate.IdDish);
                }

                item.Disponibility = item.stauts.ToString();

                foreach (var prices in item.Dishes)
                {
                    item.Subtotal += prices.Dish.Price;
                }

            }

            return listMapped;
        }

    }
}
