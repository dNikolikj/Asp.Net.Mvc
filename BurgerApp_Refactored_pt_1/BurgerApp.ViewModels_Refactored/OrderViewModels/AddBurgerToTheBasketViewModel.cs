using BurgerApp.Domain_Refactored.Enums;
using System.ComponentModel.DataAnnotations;

namespace BurgerApp.ViewModels_Refactored.OrderViewModels
{
    public class AddBurgerToTheBasketViewModel
    {
        public int OrderId { get; set; }
        [Display(Name = "A la dN")]
        public int BurgerId { get; set; }
        [Display(Name = @"Your ""cup"" of burger")]
        public TypeOfBurger TypeOfBurger { get; set; }
        [Display(Name = "One it's never enough...")]
        public int NumberOfBurgers { get; set; }
    }
}

