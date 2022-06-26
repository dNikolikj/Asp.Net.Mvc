using Asp.Net_Class04.Models.Enums;
namespace Asp.Net_Class04.Models.ViewModels
{
    public class OrderDetailsViewModel
    {

        public string PizzaName { get; set; }
        public string UserFullname { get; set; }
        public int Price { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public bool Delivered { get; set; }
    }
}
