using Asp.Net.Class_03.Models.Domain;
using Asp.Net.Class_03.Models.ViewModels;
using Asp.Net.Class_03.Models.Mappers;



namespace Asp.Net.Class_03.Models.Mappers
{ //This method will be called in all places where we need to map from Order to OrderDetailsViewModel
    public static class OrderMapper
    {
        public static OrderDetailsViewModel ToOrderDetailsViewModel(Order orderDb)
        {
            return new OrderDetailsViewModel
            {
                PaymentMethod = orderDb.PaymentMethod,
                PizzaName = orderDb.Pizza.Name,
                Price = (int)orderDb.Pizza.Price,
                UserAdress = orderDb.Address,
                UserFullName = $"{orderDb.User.FirstName} {orderDb.User.LastName}"
            };
        }
    }
}
