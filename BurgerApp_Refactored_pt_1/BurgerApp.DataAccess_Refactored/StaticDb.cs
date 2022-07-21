
using BurgerApp.Domain_Refactored.Enums;
using BurgerApp.Domain_Refactored.Models;


namespace BurgerApp.DataAccess_Refactored
{
    public static class StaticDb
    {
        public static int BurgerId { get; set; }
        public static int OrderId { get; set; }
        public static int UserId { get; set; }
        public static int BurgerBasketId { get; set; }

        public static List<Burger> Burgers { get; set; }
        public static List<Order> Orders { get; set; }
        public static List<User> Users { get; set; }


        static StaticDb()
        {
            BurgerId = 3;
            OrderId = 3;
            UserId = 3;
            BurgerBasketId = 3;

            Burgers = new List<Burger>()
            {
                new Burger ()
                {
                    Id = 1,
                    Name = "Veggie",
                    Price = 450,
                    TypeOfBurger = TypeOfBurger.Vegeterian,
                    HasFries = true,
                    RecipeSteps = new List<string>
                    {
                               "~~~~~~~~~~~~~~~~~~~",
                    "Preparing Veggie",
                    "~~~~~~~~~~~~~~~~~~~",
                    "Put bun",
                    "Put mushrooms",
                    "Put carrot",
                    "Put broccoli",
                    "Put onion",
                    "Put smoked paprika",
                    "Put chili powder",
                    "Put bun",
                    "~~~~~~~~~~~~~~~~~~~",
                    "Done!",
                    "~~~~~~~~~~~~~~~~~~~"
                    },
                    FoodPornBasket = new List<BurgerBasket>() {}

                },
                new Burger()
                {
                    Id = 2,
                    Name ="Black Angus",
                    Price = 500,
                    TypeOfBurger = TypeOfBurger.Classic,
                    HasFries=true,
                    RecipeSteps = new List<string>
                        {
                    "~~~~~~~~~~~~~~~~~~~",
                    "Preparing Black Angus",
                    "~~~~~~~~~~~~~~~~~~~",
                    "Put bun",
                    "Put patty",
                    "Put lettuce",
                    "Put tomato",
                    "Put sauce",
                    "Put bun",
                    "~~~~~~~~~~~~~~~~~~~",
                    "Done!",
                    "~~~~~~~~~~~~~~~~~~~"
                    },
                    FoodPornBasket = new List<BurgerBasket>(){}
                },
                new Burger()
                {
                    Id=3,
                    Name ="The beyond Burger",
                    Price = 450,
                    TypeOfBurger= TypeOfBurger.Vegan,
                    HasFries =false,
                    RecipeSteps = new List<string>()
                    {
                    "~~~~~~~~~~~~~~~~~~~",
                    "Preparing The Beyond Burger",
                    "~~~~~~~~~~~~~~~~~~~",
                    "Put bun",
                    "Put pea protein isolate",
                    "Put expeller-pressed canola oil",
                    "Put coconut oil",
                    "Put rice protein",
                    "Put cocoa butter",
                    "Put sunflower licithin",
                    "Put bun",
                    "~~~~~~~~~~~~~~~~~~~",
                    "Done!",
                    "~~~~~~~~~~~~~~~~~~~"
                    },
                    FoodPornBasket= new List<BurgerBasket>{}
                }
            };
            Users = new List<User>
            {
                new User()
                {
                    Id = 1,
                    FirstName = "Ricky",
                    LastName = "Rubio",
                    Address = "09692, Canicosa De La Sierra",
                    Orders = new List<Order>(){}
                },
                new User()
                {
                  Id = 2,
                  FirstName = "John",
                  LastName  =  "Krasinski",
                  Address = "Long Branch, Cedar Avenue 331, New Jersey",
                  Orders= new List<Order>(){}

                },
                new User()
                {
                    Id = 3,
                    FirstName = "Paul",
                    LastName= "Ekman",
                    Address = "47 W 13th St, New York, NY 10011",
                    Orders = new List<Order>{}

                }
            };
            Orders = new List<Order>
            {
                new Order()
                {
                    Id = 1,
                    PaymentMethod = PaymentMethod.Cash,
                    IsDelivered = true,
                    StoreAddress = StoreAddress.Aerodrom,
                    User = Users.First(),
                    FoodPornBasket= new List<BurgerBasket>
                    {
                        new BurgerBasket()
                        {
                            Id = 1,
                            Burger = Burgers.FirstOrDefault(x=> x.Id == 2),
                            BurgerId = Burgers[1].Id,
                            NumberOfBurgers=2,
                            OrderId=1,
                        }
                    }

                },
                new Order()
                {
                    Id = 2,
                    PaymentMethod = PaymentMethod.Card,
                    IsDelivered= false,
                    StoreAddress= StoreAddress.Karposh,
                    User = Users.FirstOrDefault(x => x.Id ==2),
                    FoodPornBasket = new List<BurgerBasket>
                    {
                        new BurgerBasket()
                        {
                            Id = 2,
                            Burger= Burgers.FirstOrDefault(x=> x.Id == 1),
                            BurgerId= Burgers[0].Id,
                            NumberOfBurgers = 1,
                            OrderId=2
                        }
                        
                        

                    }
                },
                new Order ()
                {
                    Id =3,
                    PaymentMethod= PaymentMethod.Card,
                    IsDelivered=false,
                    StoreAddress = StoreAddress.Vlae,
                    User = Users.FirstOrDefault(x => x.Id ==3),
        
                    FoodPornBasket= new List<BurgerBasket>
                    {
                        new BurgerBasket()
                        {
                            Id=3,
                            Burger = Burgers.Last(),
                            NumberOfBurgers = 3,
                            OrderId=3
                        }
                    }

                }
            };
        }

    }
}
