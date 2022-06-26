using Asp.Net_Class04.Models.Enums;
using Asp.Net_Class04.Models.Domain;
namespace Asp.Net_Class04
{
    public static class StaticDb
    {
        public static int UserId = 2;
        public static List<Pizza> Pizzas = new List<Pizza>() {

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
            { Id = 1,FirstName = "Tanja",
              LastName = "Stojanovska",
              PhoneNumber = "43243242"
            },
            new User()
            { Id = 2,
              FirstName ="Stefan",
              LastName ="Trajkov",
              PhoneNumber ="32434324"
            }

        };

        public static List<Order> Orders = new List<Order>()
        {

            new Order()
            {
                Id = 1,
                PizzaId = 1,
                UserId = 2,
                Pizza = Pizzas.First(),
                User = Users.First(x=> x.Id == 2),
                PaymentMethod = Models.Enums.PaymentMethod.Cash,
                Delivered = true
            },
            new Order()
            {
                Id=2,
                PizzaId = 1,
                UserId= 2,
                Pizza = Pizzas.First(x=> x.Id == 2),
                User = Users.First(x=> x.Id == 1),
                PaymentMethod= Models.Enums.PaymentMethod.Card,
                Delivered= false
            }
        };


    }
}
