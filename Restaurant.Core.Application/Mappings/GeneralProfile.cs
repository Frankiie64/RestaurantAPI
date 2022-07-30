using AutoMapper;
using Restaurant.Core.Application.Dtos.Account;
using Restaurant.Core.Application.Dtos.Dish;
using Restaurant.Core.Application.Dtos.Indredients;
using Restaurant.Core.Application.Dtos.InfoDish;
using Restaurant.Core.Application.Dtos.OrderWithDish;
using Restaurant.Core.Application.Dtos.Request;
using Restaurant.Core.Application.Dtos.Table;
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

            CreateMap<Dish, DishDto>()
            .ForMember(x => x.Ingredients, opt => opt.Ignore())
             .ForMember(x => x.Cateogry, opt => opt.Ignore())
            .ReverseMap()
            .ForMember(x => x.Ingredients, opt => opt.Ignore());

            CreateMap<Dish, SaveDishDto>()
           .ForMember(x => x.Ingredients, opt => opt.Ignore())
         .ReverseMap()
          .ForMember(x => x.Ingredients, opt => opt.Ignore());

            CreateMap<Dish, CreateDishDto>()
           .ForMember(x => x.Ingredients, opt => opt.Ignore())
         .ReverseMap()
          .ForMember(x => x.Id, opt => opt.Ignore())
          .ForMember(x => x.Ingredients, opt => opt.Ignore());


            CreateMap<SaveDishDto, DishDto>()
            .ForMember(x => x.Ingredients, opt => opt.Ignore())
             .ForMember(x => x.Cateogry, opt => opt.Ignore())
            .ReverseMap()
            .ForMember(x => x.Ingredients, opt => opt.Ignore());


            CreateMap<CreateDishDto, DishDto>()
            .ForMember(x => x.Id, opt => opt.Ignore())
            .ForMember(x => x.Ingredients, opt => opt.Ignore())
             .ForMember(x => x.Cateogry, opt => opt.Ignore())
           .ReverseMap()
            .ForMember(x => x.Ingredients, opt => opt.Ignore());

            CreateMap<SaveDishDto, CreateDishDto>()
            .ReverseMap()
            .ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<InfoDish, InfoDishDto>()
            .ReverseMap();

            CreateMap<InfoDish, SaveInfoDishDto>()
            .ReverseMap()
            .ForMember(x => x.Dish, opt => opt.Ignore())
            .ForMember(x => x.Ingredients, opt => opt.Ignore());

            CreateMap<SaveDishDto, CreateInfoDishDto>()
            .ReverseMap()
            .ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<TableDto, Table>()
           .ReverseMap()
            .ForMember(x => x.Disponibility, opt => opt.Ignore());

            CreateMap<SaveTableDto, Table>()
            .ForMember(x => x.Orders, opt => opt.Ignore())
            .ReverseMap();

            CreateMap<CreateTableDto, SaveTableDto>()
           .ForMember(x => x.Id, opt => opt.Ignore())
            .ForMember(x => x.Stauts, opt => opt.Ignore())
           .ReverseMap();

            CreateMap<TableDto, SaveTableDto>()
         .ReverseMap()
        .ForMember(x => x.Disponibility, opt => opt.Ignore())
        .ForMember(x => x.Orders, opt => opt.Ignore());



            CreateMap<Request, SaveRequestDto>()
          .ForMember(x => x.Dishes, opt => opt.Ignore())
          .ReverseMap()
          .ForMember(x => x.Dishes, opt => opt.Ignore())        
          .ForMember(x => x.Table, opt => opt.Ignore());

            CreateMap<Request, RequestDto>()
            .ForMember(x => x.Disponibility, opt => opt.Ignore())
            .ReverseMap();

            CreateMap<CreateRequestDto,SaveRequestDto > ()
            .ForMember(x => x.Id, opt => opt.Ignore())
           .ReverseMap();

            CreateMap<OrderWithDish, OrderWithDishDto>()
           .ForMember(x => x.Dish, opt => opt.Ignore())
           .ReverseMap()
           .ForMember(x => x.Order, opt => opt.Ignore());

            CreateMap<OrderWithDish, SaveOrderWithDishDto>()
          .ReverseMap()
          .ForMember(x => x.Order, opt => opt.Ignore());

            CreateMap<CreateOrderWithDishDto, SaveOrderWithDishDto>()
         .ForMember(x => x.Id, opt => opt.Ignore())
         .ReverseMap();
        }
    }
}
