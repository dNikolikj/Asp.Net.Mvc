using BurgerApp.DataAccess_Refactored.Implementations;
using BurgerApp.DataAccess_Refactored.Interfaces;
using BurgerApp.Domain_Refactored.Models;
using Microsoft.Extensions.DependencyInjection;
using BurgerApp.Services_Refactored.Interfaces;
using BurgerApp.Services_Refactored.Implementations;


namespace BurgerApp.Helpers_Refactored
{
    public static class InjectionHelper
    {
        public static void InjectRepositories(IServiceCollection services)
        {
            services.AddTransient<IRepository<Burger>, BurgerRepository>();
            services.AddTransient<IRepository<Order>, OrderRepository>();
            services.AddTransient<IRepository<User>, UserRepository>();

        }


        public static void InjectServices(IServiceCollection services)
        {
            services.AddTransient<IBurgerService, BurgerService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IUserService, UserService>();
        }
    }
}
