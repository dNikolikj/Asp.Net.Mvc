using Asp.Net.Class_03.Models.Enums;

namespace Asp.Net.Class_03.Models.ViewModels
{
    public class OrderDetailsViewModel
    {
        public string PizzaName { get; set; }
        public string UserFullName { get; set; }
        
        public int Price { get; set; }
        public string UserAdress { get; set; }  
        public PaymentMethod PaymentMethod { get; set; }
    }
}
