using BurgerApp.Domain_Refactored.Enums;
using BurgerApp.Domain_Refactored.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BurgerApp.DataAccess_Refactored
{
    public class BurgerAppDbContext : DbContext
    {

        public BurgerAppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Burger> Burgers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
            
            modelBuilder.Entity<Burger>()
             .HasMany(b => b.FoodPornBasket)
             .WithOne(b => b.Burger)
             .HasForeignKey(b => b.BurgerId);

            modelBuilder.Entity<Order>()
                .HasMany(b => b.FoodPornBasket)
                .WithOne(b => b.Order)
                .HasForeignKey(b => b.OrderId);

            modelBuilder.Entity<User>()
               .HasMany(o => o.Orders)
               .WithOne(u => u.User)
               .HasForeignKey(u => u.UserId);


            modelBuilder.Entity<Burger>()
            .HasData
            (
                 new Burger()
                 {
                     Id = 1,
                     Name = "Veggie",
                     Price = 450,
                     TypeOfBurger = TypeOfBurger.Vegeterian,
                     HasFries = true,
                    // RecipeSteps = new List<string>
                    //{
                    //           "~~~~~~~~~~~~~~~~~~~",
                    //"Preparing Veggie",
                    //"~~~~~~~~~~~~~~~~~~~",
                    //"Put bun",
                    //"Put mushrooms",
                    //"Put carrot",
                    //"Put broccoli",
                    //"Put onion",
                    //"Put smoked paprika",
                    //"Put chili powder",
                    //"Put bun",
                    //"~~~~~~~~~~~~~~~~~~~",
                    //"Done!",
                    //"~~~~~~~~~~~~~~~~~~~"
                    //},


                 },
                new Burger()
                {
                    Id = 2,
                    Name = "Black Angus",
                    Price = 500,
                    TypeOfBurger = TypeOfBurger.Classic,
                    HasFries = true,
                    //RecipeSteps = new List<string>
                    //    {
                    //"~~~~~~~~~~~~~~~~~~~",
                    //"Preparing Black Angus",
                    //"~~~~~~~~~~~~~~~~~~~",
                    //"Put bun",
                    //"Put patty",
                    //"Put lettuce",
                    //"Put tomato",
                    //"Put sauce",
                    //"Put bun",
                    //"~~~~~~~~~~~~~~~~~~~",
                    //"Done!",
                    //"~~~~~~~~~~~~~~~~~~~"
                    //},

                },
                new Burger()
                {
                    Id = 3,
                    Name = "The beyond Burger",
                    Price = 450,
                    TypeOfBurger = TypeOfBurger.Vegan,
                    HasFries = false,
                    //RecipeSteps = new List<string>()
                    //{
                    //"~~~~~~~~~~~~~~~~~~~",
                    //"Preparing The Beyond Burger",
                    //"~~~~~~~~~~~~~~~~~~~",
                    //"Put bun",
                    //"Put pea protein isolate",
                    //"Put expeller-pressed canola oil",
                    //"Put coconut oil",
                    //"Put rice protein",
                    //"Put cocoa butter",
                    //"Put sunflower licithin",
                    //"Put bun",
                    //"~~~~~~~~~~~~~~~~~~~",
                    //"Done!",
                    //"~~~~~~~~~~~~~~~~~~~"
                    //}



                });

            modelBuilder.Entity<Order>()
                .HasData
                (
                new Order()
                {
                    Id = 1,
                    PaymentMethod = PaymentMethod.Cash,
                    IsDelivered = true,
                    StoreAddress = StoreAddress.Aerodrom,
                    UserId = 1,
                   

                },
                new Order()
                {
                    Id = 2,
                    PaymentMethod = PaymentMethod.Card,
                    IsDelivered = false,
                    StoreAddress = StoreAddress.Karposh,
                    UserId = 2,
                  

                },
                new Order()
                {
                    Id = 3,
                    PaymentMethod = PaymentMethod.Card,
                    IsDelivered = false,
                    StoreAddress = StoreAddress.Vlae,
                    UserId = 3,
                    


                });

            modelBuilder.Entity<User>()
                .HasData
                (
                new User()
                {
                    Id = 1,
                    FirstName = "Ricky",
                    LastName = "Rubio",
                    Address = "09692, Canicosa De La Sierra",

                },
                new User()
                {
                    Id = 2,
                    FirstName = "John",
                    LastName = "Krasinski",
                    Address = "Long Branch, Cedar Avenue 331, New Jersey",


                },
                new User()
                {
                    Id = 3,
                    FirstName = "Paul",
                    LastName = "Ekman",
                    Address = "47 W 13th St, New York, NY 10011",


                });

            modelBuilder.Entity<BurgerBasket>()
                .HasData
                (
                new BurgerBasket()
                {
                    Id = 1,
                    BurgerId = 2,
                    NumberOfBurgers = 2,
                    OrderId = 1,
                },
                 new BurgerBasket()
                 {
                     Id = 2,
                     BurgerId = 1,
                     NumberOfBurgers = 1,
                     OrderId = 2
                 },
                  new BurgerBasket()
                  {
                      Id = 3,
                      BurgerId = 3,
                      NumberOfBurgers = 3,
                      OrderId = 3
                  });
        }

    }
}
