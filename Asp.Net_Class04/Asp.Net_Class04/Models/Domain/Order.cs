using Asp.Net_Class04.Models.Enums;

namespace Asp.Net_Class04.Models.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public int PizzaId { get; set; }
        public int UserId { get; set; }
        public Pizza Pizza { get; set; }
        public User User { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public bool Delivered { get; set; }
    }
}
