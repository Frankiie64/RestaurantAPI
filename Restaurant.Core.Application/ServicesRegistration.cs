using Restaurant.Core.Application.Interfaces.Services;
using Restaurant.Core.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Application
{
    public static class ServicesRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            #region AutoMapper

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            #endregion
            #region Services 
            services.AddTransient(typeof(IGenericServices<,,>), typeof(GenericServices<,,>));
            services.AddTransient<IIngredientServices, IngredientServices>();
            services.AddTransient<IUserService, UserService>();           
            #endregion
        }
    }
}
