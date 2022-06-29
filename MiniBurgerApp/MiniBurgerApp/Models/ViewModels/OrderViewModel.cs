using MiniBurgerApp.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace MiniBurgerApp.Models.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int Price { get; set; }
        [Display(Name = "A la dN burger:")]
        public string BurgerName { get; set; }
        [Display(Name = "Your full name:")]
        public string RecipientFullName { get; set; }
        [Display(Name = "Your address:")]
        public string RecipientAddress { get; set; }
        [Display(Name = "State the location of our store:")]
        
        public StoreAddress StoreAddress { get; set; }
        [Display(Name = "Would you prefere to pay in cash or by card:")]
        public PaymentMethod PaymentMethod { get; set; }
        [Display(Name="Delivered")]
        public bool IsDelivered { get; set; }
    }
}
