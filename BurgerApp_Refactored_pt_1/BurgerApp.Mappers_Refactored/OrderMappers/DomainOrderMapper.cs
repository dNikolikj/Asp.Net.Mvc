using BurgerApp.Domain_Refactored.Models;
using BurgerApp.ViewModels_Refactored.OrderViewModels;

namespace BurgerApp.Mappers_Refactored.OrderMappers
{
   public static  class DomainOrderMapper
    {
        public static Order ToDomainModel(OrderViewModel orderViewModel)
        {
            return new Order()
            {
                Id = orderViewModel.Id,
                PaymentMethod = orderViewModel.PaymentMethod,
                StoreAddress = orderViewModel.StoreAddress,
                IsDelivered = orderViewModel.Delivered,
                UserId = orderViewModel.UserId,
                FoodPornBasket = new List<BurgerBasket>()
            }; 
        }
    }
}
