using BurgerApp.DataAccess_Refactored.EntityFrameworkImplementations;
using BurgerApp.DataAccess_Refactored.Interfaces;
using BurgerApp.Domain_Refactored.Models;
using Microsoft.Extensions.DependencyInjection;
using BurgerApp.Services_Refactored.Interfaces;
using BurgerApp.Services_Refactored.Implementations;
using BurgerApp.DataAccess_Refactored;
using Microsoft.EntityFrameworkCore;




namespace BurgerApp.Helpers_Refactored
{
    public static class InjectionHelper
    {
        public static void InjectRepositories(IServiceCollection services)
        {
            services.AddTransient<IRepository<Burger>,BurgerEFRepository>();
            services.AddTransient<IRepository<Order>, OrderEFRepository>();
            services.AddTransient<IRepository<User>, UseEFRepository>();

        }


        public static void InjectServices(IServiceCollection services)
        {
            services.AddTransient<IBurgerService, BurgerService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IUserService, UserService>();
        }

        public static void InjectDbContext(IServiceCollection services)
        {
            services.AddDbContext<BurgerAppDbContext>(options =>
            {
                
                options.UseSqlServer("Server=.\\sqlexpress;Database=BurgerAppDb;Trusted_Connection=True;");

            });
        }
    }
}
