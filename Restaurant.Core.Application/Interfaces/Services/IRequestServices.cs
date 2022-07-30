using Restaurant.Core.Application.Dtos.Request;
using Restaurant.Core.Application.Dtos.Table;
using Restaurant.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Application.Interfaces.Services
{
    public interface IRequestServices : IGenericServices<SaveRequestDto, RequestDto, Request>
    {
        Task<RequestDto> GetByIdModel(int id);
        Task<List<RequestDto>> GetAllViewModelWithIncludeAsync();
    }
}
