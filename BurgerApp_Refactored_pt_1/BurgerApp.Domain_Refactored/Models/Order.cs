using BurgerApp.Domain_Refactored.Enums;


namespace BurgerApp.Domain_Refactored.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int BurgerId { get; set; }
        public Burger Burger { get; set; }
        public StoreAddress StoreAddress { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public bool IsDelivered { get; set; }

        public List<BurgerBasket> FoodPornBasket { get; set; }  
    }
}
