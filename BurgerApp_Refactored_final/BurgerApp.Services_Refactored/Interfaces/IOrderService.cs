using BurgerApp.ViewModels_Refactored.OrderViewModels;


namespace BurgerApp.Services_Refactored.Interfaces
{
    public interface IOrderService
    {
        List<OrderDetailsViewModel> GetAllOrders();
        
        OrderDetailsViewModel SelectOrderById(int id);

        void CreateOrder(OrderViewModel orderViewModel);
        OrderViewModel EditOrder(int id);
        void EditOrderPost(OrderViewModel orderViewModel);

        void AddBurgerToOrder(AddBurgerToTheBasketViewModel basketViewModel);


        void DeleteOrder(int orderId);

    }
}
