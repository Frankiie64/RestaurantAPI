using Restaurant.Core.Application.Dtos.Table;
using Restaurant.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Application.Interfaces.Services
{
    public interface ITableService : IGenericServices<SaveTableDto, TableDto, Table>
    {
        Task<List<TableDto>> GetAllViewModelWithIncludeAsync();
    }
}
