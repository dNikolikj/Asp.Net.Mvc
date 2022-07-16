using BurgerApp.Domain_Refactored.Enums;
using System.ComponentModel.DataAnnotations;

namespace BurgerApp.ViewModels_Refactored.OrderViewModels
{
    public class OrderViewModel
    {

        public int Id { get; set; }
        [Display(Name = "Would you prefer to pay in cash or by credit card?")]
        public PaymentMethod PaymentMethod { get; set; }
        [Display(Name = "Pick your closest Burger Shop:")]
        public StoreAddress StoreAddress { get; set; }
        [Display(Name = "Is the order at your address?")]
        public bool Delivered { get; set; }

        [Display(Name = "There is no wrong burger choice!")]
        public int BurgerId { get; set; }
        [Display(Name = "You can hadle this burger Master")]
        public int UserId { get; set; }

    }
}
