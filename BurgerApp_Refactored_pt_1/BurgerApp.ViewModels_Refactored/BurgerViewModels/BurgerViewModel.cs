using System.ComponentModel.DataAnnotations;
using BurgerApp.Domain_Refactored.Enums;


namespace BurgerApp.ViewModels_Refactored.BurgerViewModels
{
    public class BurgerViewModel
    {
        public int Id { get; set; }
        [Display(Name = "A la dN")]
        public string BurgerName { get; set; }
        [Display(Name = @"Your ""cup"" of burger")]
        public TypeOfBurger TypeOfBurger { get; set; }
        [Display(Name = "Would you like fries?")]
        public bool Fries { get; set; }

    }
}
