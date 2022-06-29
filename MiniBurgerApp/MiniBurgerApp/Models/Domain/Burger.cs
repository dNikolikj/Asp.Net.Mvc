using MiniBurgerApp.Models.Enums;

namespace MiniBurgerApp.Models.Domain
{
    public class Burger
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }
        public TypeOfBurger BurgerType { get; set; }
      
        public bool HasFries { get; set; }
        public List<string> RecipeSteps { get; set; }

    }
}


