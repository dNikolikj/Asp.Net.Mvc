using Asp.Net.Class_03.Models.Domain;
using Asp.Net.Class_03.Models.Enums;

namespace Asp.Net.Class_03
{
    public static class StaticDb
    {
        public static int UserId = 2;
        public static List<Pizza> Pizzas = new List<Pizza>()
        {
            new Pizza()
            {
                Id = 1,
                Name = "Capri",
                Price = 300,
                PizzaSize = PizzaSize.Normal,
                IsOnPromotion = true,
                HasExtras = false
            },
            new Pizza ()
            {
                Id = 2,
                Name ="Pepperoni",
                Price = 400,
                PizzaSize = PizzaSize.Family,
                IsOnPromotion= false,
                HasExtras = true,
            }
        };

        public static List<User> Users = new List<User>()
        {
            new User()
            {
                Id =1,
                FirstName = "Tanja",
                LastName = "Stojanovska",
                PhoneNumber ="43243243243"
            },
            new User()
            {
                Id=2,
                FirstName = "Stefan",
                LastName= "Trajkov",
                PhoneNumber  = "43924324324"
            }
        };

        public static List<Order> Orders = new List<Order>()
        {new Order  ()
        {
            Id   = 1,
            PizzaId = 1,
            UserId = 2,
            Pizza = Pizzas.First(),
            User = Users.First(x => x.Id == 2),
            Address = "Kraishka no.20",
            PaymentMethod  = PaymentMethod.Cash
        }, new Order
            {
                Id = 2,
                PizzaId = 1,
                UserId = 2,
                Pizza = Pizzas.First(x => x.Id == 2),
                User = Users.First(x => x.Id == 1),
                Address = "Leninova b/b",
                PaymentMethod = PaymentMethod.Card
            }

        };
    }
}
