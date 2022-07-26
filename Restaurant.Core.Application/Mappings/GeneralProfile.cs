using AutoMapper;
using Restaurant.Core.Application.Dtos.Account;
using Restaurant.Core.Application.Dtos.Indredients;
using Restaurant.Core.Application.Dtos.User;
using Restaurant.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<RegisterUserDto, RegisterRequest>()
             .ForMember(x => x.Id, opt => opt.Ignore())
             .ForMember(x => x.Rol, opt => opt.Ignore())
             .ReverseMap();

            CreateMap<CreateIngredientDto, SaveIngredientDto>()
             .ForMember(x => x.Id, opt => opt.Ignore())
             .ReverseMap();

            CreateMap<Ingredients, SaveIngredientDto>()
            .ReverseMap()
            .ForMember(x => x.Dishes, opt => opt.Ignore());

            CreateMap<Ingredients, IngredientDto>()
            .ReverseMap()
            .ForMember(x => x.Dishes, opt => opt.Ignore());
            
        }
    }
}
