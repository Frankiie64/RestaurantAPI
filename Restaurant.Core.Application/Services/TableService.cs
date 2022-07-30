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
    public class TableService : GenericServices<SaveTableDto, TableDto, Table>, ITableService
    {
        private readonly ITableRepository repo;
        private readonly IMapper mapper;
        public TableService(ITableRepository repo, IMapper mapper) : base(repo, mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        public async Task<List<TableDto>> GetAllViewModelWithIncludeAsync()  
        {
            var list = mapper.Map<List<TableDto>>(await repo.GetAllWithIncludeAsync(new List<string> { "Orders" }));

            foreach (var item in list)
            {
                item.Disponibility = item.Stauts.ToString();
            }

            return list;
        }
    }
}
