using MiniBurgerApp.Models.Enums;

namespace MiniBurgerApp.Models.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public int BurgerId { get; set; }
        public Burger Burger { get; set; }
        public StoreAddress StoreAddress { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        public string RecipientFullName { get; set; }   
        public string RecipientLocation { get; set; }
        public bool IsDelivered { get; set; }
    }
}
