using BurgerApp.Domain_Refactored.Models;
using BurgerApp.ViewModels_Refactored.OrderViewModels;


namespace BurgerApp.Mappers_Refactored.OrderMappers
{
    public static class OrderDetailsViewModelMapper
    {
        public static OrderDetailsViewModel ToOrderDetailsViewModel(Order orderDb)
        {

            return new OrderDetailsViewModel()
            {
                Id = orderDb.Id,
                UserFullName = $"{orderDb.User.FirstName} {orderDb.User.LastName}",
                PaymentMethod = orderDb.PaymentMethod,
                YourMapPick = orderDb.StoreAddress,
                Price = orderDb.TotalCost(), 
                SoundsDelicious = orderDb.FoodPornBasket.Select(b => b.Burger.Name).ToList()
            };

            
        }

        public static double TotalCost(this Order orderDb)
        {
            double orderPrice =( orderDb.FoodPornBasket.Sum(b => b.Burger.Price)) * orderDb.FoodPornBasket.Count;

            if (orderDb.IsDelivered == true)
            {
                return orderPrice + 30;
            }
            return orderPrice;
        }
    }
}
