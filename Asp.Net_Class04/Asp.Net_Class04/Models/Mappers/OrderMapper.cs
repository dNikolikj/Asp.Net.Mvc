using Asp.Net_Class04.Models.Domain;
using Asp.Net_Class04.Models.Enums;
using Asp.Net_Class04.Models.ViewModels;
namespace Asp.Net_Class04.Models.Mappers
{
    public static class OrderMapper
    {

        public static OrderDetailsViewModel ToOrderDetailsViewModel(Order order)
        {
            return new OrderDetailsViewModel()
            {
                PaymentMethod = order.PaymentMethod,
                PizzaName = order.Pizza.Name,
                Price = order.Pizza.Price,
                UserFullname = $"{order.User.FirstName} {order.User.LastName}",
                Delivered = order.Delivered,
                

            };
        }
    }
}
