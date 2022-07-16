using BurgerApp.Services_Refactored.Interfaces;
using BurgerApp.ViewModels_Refactored.OrderViewModels;
using BurgerApp.Domain_Refactored.Models;
using BurgerApp.Mappers_Refactored.OrderMappers;
using BurgerApp.DataAccess_Refactored.Interfaces;
using BurgerApp.DataAccess_Refactored.Implementations;


namespace BurgerApp.Services_Refactored.Implementations
{
    public class OrderService : IOrderService
    {
        private IRepository<Order> _orderRepository;
        private IRepository<Burger> _burgerRepository;
        private IRepository<User> _userRepository;

        public OrderService(IRepository<Order> orderRepository, IRepository<Burger> burgerRepository, IRepository<User> userRepository)
        {
            _orderRepository = orderRepository;
            _burgerRepository = burgerRepository;
            _userRepository = userRepository;
        }
        public void AddBurgerToOrder(AddBurgerToTheBasketViewModel basketViewModel)
        {
            Order orderDb = _orderRepository.GetById(basketViewModel.OrderId);
            if(orderDb == null)
            {
                throw new Exception($"The order with id {basketViewModel.OrderId} was not found!");
            }
            Burger burgerDb = _burgerRepository.GetById(basketViewModel.BurgerId);
            if(burgerDb == null)
            {
                throw new Exception($"The  burger with id {basketViewModel.BurgerId} was not found!");
            }
            if(basketViewModel.NumberOfBurgers <= 0)
            {
                throw new Exception("The number of added burgers must be greater than zero!");
            }

            orderDb.FoodPornBasket.Add(new BurgerBasket()
            {
                OrderId=orderDb.Id,
                Order = orderDb,
                Burger = burgerDb,
                BurgerId = burgerDb.Id,
                NumberOfBurgers = basketViewModel.NumberOfBurgers
            });
            _orderRepository.Update(orderDb);
        }

        public void CreateOrder(OrderViewModel orderViewModel)


        {
            User userDb = _userRepository.GetById(orderViewModel.UserId);
            if(userDb == null)
            {
                throw new Exception($"User with id {orderViewModel.UserId} was not found!");
            }
            Order recentlyAddedOrder = DomainOrderMapper.ToDomainModel(orderViewModel);
            recentlyAddedOrder.User = userDb;

            int recentlyAddedorderId = _orderRepository.Insert(recentlyAddedOrder);
            if(recentlyAddedorderId <= 0 )
            {
                throw new Exception("An error occurred , please try again later.");
            }
        }

        public void DeleteOrder(int orderId)
        {
            Order orderDb = _orderRepository.GetById(orderId);  
            if(orderDb == null)
            {
                throw new Exception($"The order with id {orderId} was not found! ");
            }
            _orderRepository.Delete(orderId);
        }

        public OrderViewModel EditOrder(int id)
        {
            Order orderDb = _orderRepository.GetById(id);
            if(orderDb==null)
            {
                throw new Exception($"The order with {id} was not found!");
            }
            return OrderViewModelMapper.ToOrderViewModel(orderDb);
        }

        public void EditOrderPost(OrderViewModel orderViewModel)
        {
            Order orderDb = _orderRepository.GetById(orderViewModel.Id);
            if(orderDb == null)
            {
                throw new Exception($"The order with id {orderViewModel.Id} was not found!");
            }
            User userDb = _userRepository.GetById(orderViewModel.UserId);
            if(userDb == null)
            {
                throw new Exception($"The user with id {orderViewModel.UserId} was not found!");
            }
            Burger burgerDb = _burgerRepository.GetById(orderViewModel.BurgerId);
            if(burgerDb == null)
            {
                throw new Exception($"The burger with id {orderViewModel.BurgerId} was not found!");
            }
            orderDb.UserId = orderViewModel.UserId;
            orderDb.StoreAddress = orderViewModel.StoreAddress;
            orderDb.User = userDb;
            orderDb.BurgerId=orderViewModel.BurgerId;
            orderDb.Burger = burgerDb;
            orderDb.PaymentMethod = orderViewModel.PaymentMethod;
            orderDb.IsDelivered = orderViewModel.Delivered;
            
            _orderRepository.Update(orderDb);
        }

        public List<OrderDetailsViewModel> GetAllOrders()
        {
            List<Order> ordersDb = _orderRepository.GetAll();
            List<OrderDetailsViewModel> ordersDetailsViewModels = ordersDb.Select(o => OrderDetailsViewModelMapper.ToOrderDetailsViewModel(o)).ToList();
            return ordersDetailsViewModels;
        }

        public OrderDetailsViewModel SelectOrderById(int id)
        {
            Order orderDb = _orderRepository.GetById(id);
            if(orderDb == null)
            {
                throw new Exception($"The order with id {id} was not found!");
            }
            OrderDetailsViewModel orderDetailsViewModel = OrderDetailsViewModelMapper.ToOrderDetailsViewModel(orderDb);
            return orderDetailsViewModel;
        }
    }
}
