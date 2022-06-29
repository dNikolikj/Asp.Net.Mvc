using MiniBurgerApp.Models.Domain;
using MiniBurgerApp.Models.Enums;
using MiniBurgerApp.Models.ViewModels;
namespace MiniBurgerApp.Models.Mappers
{
    public static class OrderMapper
    {
        public static OrderViewModel ToOrderViewModel(Order orderDb)
        {
            return new OrderViewModel()
            {
                Id = orderDb.Id,
                Price = SetOrderPrice(orderDb),
                BurgerName = orderDb.Burger.Name,
                RecipientFullName = orderDb.RecipientFullName,
                RecipientAddress = orderDb.RecipientLocation,
                StoreAddress = orderDb.StoreAddress,
                PaymentMethod= orderDb.PaymentMethod,
                IsDelivered = orderDb.IsDelivered,

            };

        }



        public static int SetOrderPrice(Order orderDb)
        {

           if(orderDb.IsDelivered == true)
            {
                return orderDb.Burger.Price + 10;
            } 
           return orderDb.Burger.Price;
        }
       
    }
}
