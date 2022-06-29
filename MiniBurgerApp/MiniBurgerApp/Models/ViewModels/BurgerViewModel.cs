using MiniBurgerApp.Models.Enums;
using System.ComponentModel.DataAnnotations;
namespace MiniBurgerApp.Models.ViewModels
{
    public class BurgerViewModel
    {

        public int Id { get; set; }

        public int Price { get; set; }
        [Display(Name = "A la dN")]
        public string BurgerName { get; set; }
        [Display(Name =@"Your ""cup"" of burger")]
        public TypeOfBurger ChooseYourBurgerFit { get; set; }
     
        public bool Fries { get; set; }
        public List<string> ChefsLitlleMagic { get; set; }   

    }



}
