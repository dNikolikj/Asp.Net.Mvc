using BurgerApp.Domain_Refactored.Models;
using BurgerApp.ViewModels_Refactored.OrderViewModels;


namespace BurgerApp.Mappers_Refactored.OrderMappers
{
    public static class OrderViewModelMapper
    {
        public static OrderViewModel ToOrderViewModel(Order orderDb)
        {
            return new OrderViewModel()
            {
                Id = orderDb.Id,
                PaymentMethod = orderDb.PaymentMethod,
                StoreAddress = orderDb.StoreAddress,
                Delivered = orderDb.IsDelivered,
                UserId = orderDb.UserId,
            };
        }
    }
}
