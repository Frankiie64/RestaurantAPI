using AutoMapper;
using Restaurant.Core.Application.Dtos.InfoDish;
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
    public class InfoDishServices : GenericServices<SaveInfoDishDto, InfoDishDto, InfoDish>, IInfoDishServices
    {
        private readonly IInfoDishRepository repo;
        private readonly IMapper mapper;
        public InfoDishServices(IInfoDishRepository repo, IMapper mapper) : base(repo, mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
    }
}
