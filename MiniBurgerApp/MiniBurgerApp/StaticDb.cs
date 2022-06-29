using MiniBurgerApp.Models.Domain;
using MiniBurgerApp.Models.Enums;


namespace MiniBurgerApp
{
    public static class StaticDb
    {
        public static int BurgerId = 3;
        public static int OrderId = 3;



        public static List<Burger> Burgers = new List<Burger>()
        {


            new Burger()
            {
                Id = 1,
                Name = "Veggie",
                Price = 350,
                BurgerType = TypeOfBurger.Vegeterian,
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
                }
            },
            new Burger()
            {
                Id=2,
                Name ="Black Angus",
                Price = 500,
                BurgerType = TypeOfBurger.Classic,
                HasFries=true,
                RecipeSteps=new List<string>
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
                }
            },
            new Burger()
            {
                Id = 3,
                Name ="The beyond Burger",
                Price = 450,
                BurgerType = TypeOfBurger.Vegan,
                HasFries = false,
                RecipeSteps= new List<string>
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
                }

            }

        };

        public static List<Order> Orders = new List<Order>()
        {
            new Order()
            {
                Id = 1,
                BurgerId = 1,
                Burger = Burgers.First(),
                StoreAddress = StoreAddress.Aerodrom,
                PaymentMethod  = PaymentMethod.Cash,
              RecipientFullName = "Bogdan Bogdanovic",
                RecipientLocation = "Nataniel b/b",
                IsDelivered = true
            },
             new Order()
            {
                Id = 2,
                BurgerId = 3,
                Burger = Burgers.First(x => x.Id ==3),
                StoreAddress = StoreAddress.Karposh,
                PaymentMethod  = PaymentMethod.Card,
               RecipientFullName = "Jovana Jovanovska",
                RecipientLocation = "Petar Mandzukov b/b",
                IsDelivered = false
            },
              new Order()
            {
                Id = 1,
                BurgerId = 2,
                Burger = Burgers.First(x=> x.Id ==2),
                StoreAddress = StoreAddress.Vlae,
                PaymentMethod  = PaymentMethod.Cash,
               RecipientFullName = "Tamara Ristovska",
                RecipientLocation = "Dame Gruev b/b",
                IsDelivered = true
            }
        };
    }
}
