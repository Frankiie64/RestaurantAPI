﻿using Restaurant.Core.Application.Interfaces.Repositories;
using Restaurant.Infrastructure.Persistence.Context;
using Restaurant.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Infrastructure.Persistence
{
    public static class ServicesRegistration
    {

        //Se le conoce como un Extension Methods - Decorator
        public static void AddPersitsenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region Configuration of Database
            if (configuration.GetValue<bool>("UseInMemoryDataBase"))
            {
                //Base de datos de texteo
                services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("DBInternetBaking"));
            }
            else
            {
                // Base de datos en producion

                services.AddDbContext<ApplicationDbContext>(Options =>
                Options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                m => m.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            }
            #endregion

            #region Dependency Injection

            //Generics
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            //Other repos
            services.AddTransient<IIngredientRepository, IngredientRepository>();
            services.AddTransient<IDishRepository, DishRepository>();
            services.AddTransient<IInfoDishRepository, InfoDishRepository>();
            services.AddTransient<IOrderWithDishRepository, OrderWithDishRepository>();
            services.AddTransient<ITableRepository, TableRepository>();
            services.AddTransient<IRequestRepository, RequestRepository>();

            #endregion

        }
    }
}