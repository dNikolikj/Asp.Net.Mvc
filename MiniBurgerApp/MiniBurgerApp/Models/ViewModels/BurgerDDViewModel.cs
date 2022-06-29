using System.ComponentModel.DataAnnotations;

namespace MiniBurgerApp.Models.ViewModels
{
    public class BurgerDDViewModel
    {

        [Display(Name="BurgerName")]
        public string Name { get; set; }

    }
}
