using BurgerApp.Domain_Refactored.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace BurgerApp.Domain_Refactored.Models
{
    public class Burger
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public TypeOfBurger TypeOfBurger { get; set; }
        public bool HasFries { get; set; }
        
        //public List<String> RecipeSteps { get; set; }
        public List<BurgerBasket> FoodPornBasket { get; set; }
    }
}
