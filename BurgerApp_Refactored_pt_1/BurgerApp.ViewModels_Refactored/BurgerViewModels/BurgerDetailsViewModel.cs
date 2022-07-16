using System.ComponentModel.DataAnnotations;
using BurgerApp.Domain_Refactored.Enums;
namespace BurgerApp.ViewModels_Refactored.BurgerViewModels
{
    public class BurgerDetailsViewModel
    {
        public int Id { get; set; }
        [Display(Name = "A la dN")]
        public string BurgerName { get; set; }
        [Display(Name = @"Your ""cup"" of burger")]
        public TypeOfBurger ChooseYourBurgerFit { get; set; }
        [Display(Name = "If you're good at something , never do it for free 😏.")]
        public double Price { get; set; }   
        public bool Fries { get; set; }
        public List<String> ChefsLitlleMagic { get; set; }
    }
}