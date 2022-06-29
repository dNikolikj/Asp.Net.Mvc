using System.ComponentModel.DataAnnotations;

namespace MiniBurgerApp.Models.ViewModels
{
    public class OrderDDViewModel
    {
        
        [Display(Name="Recipient Fullname")]
        public string RecipientFullName { get; set; }
    }
}
