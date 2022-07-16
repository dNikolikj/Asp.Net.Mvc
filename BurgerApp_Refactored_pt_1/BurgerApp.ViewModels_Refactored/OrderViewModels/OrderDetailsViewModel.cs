using BurgerApp.Domain_Refactored.Enums;

namespace BurgerApp.ViewModels_Refactored.OrderViewModels
{
    public class OrderDetailsViewModel
    {
        public int Id { get; set; }
        public string UserFullName { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public StoreAddress YourMapPick { get; set; }
        public double Price { get; set; }
        public bool Delivered { get; set; }
        public List<string> SoundsDelicious { get; set; }


    }
}
