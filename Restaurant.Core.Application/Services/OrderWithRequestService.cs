using AutoMapper;
using Restaurant.Core.Application.Dtos.OrderWithDish;
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
    public class OrderWithRequestService : GenericServices<SaveOrderWithDishDto, OrderWithDishDto, OrderWithDish>, IOrderWithDishServices
    {
        private readonly IOrderWithDishRepository repo;
        private readonly IMapper mapper;
        public OrderWithRequestService(IOrderWithDishRepository repo, IMapper mapper) : base(repo, mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
    }
}
