using Microsoft.AspNetCore.Mvc;
using MiniBurgerApp.Models.Domain;
using MiniBurgerApp.Models.Mappers;
using MiniBurgerApp.Models.ViewModels;

namespace MiniBurgerApp.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult SeeOrders()
        {
            List<Order> ordersDb = StaticDb.Orders;
            List<OrderViewModel> ordersViewModels = ordersDb.Select(x => OrderMapper.ToOrderViewModel(x)).ToList();
            ViewBag.Title = "Here are our recently made orders:";
            return View(ordersViewModels);
        }


        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return View("ResourceNotFound");
            }

            Order orderDb = StaticDb.Orders.FirstOrDefault(x => x.Id == id);
            if(orderDb == null)
            {
                return View("CustomErrorMessage");
            }

            OrderViewModel orderViewModel = OrderMapper.ToOrderViewModel(orderDb);

            ViewBag.Title = "See the details for the selected order:";
            return View(orderViewModel);
        } 

        public IActionResult AddNewOrder()
        {
            OrderViewModel orderViewModel = new OrderViewModel();

            return View(orderViewModel);

        }

        [HttpPost]
        public IActionResult AddNewOrderPost(OrderViewModel orderViewModel)
        {
            Burger burgerDb = StaticDb.Burgers.FirstOrDefault(b => b.Name == orderViewModel.BurgerName);
            if(burgerDb == null)
            {
                return View("ResourceNotFound");
            }

            Order recentlyAddedOrder = new Order()
            {
                Id = StaticDb.OrderId + 1,
                PaymentMethod = orderViewModel.PaymentMethod,
                StoreAddress = orderViewModel.StoreAddress,
                Burger = burgerDb,
                BurgerId =burgerDb.Id,
                IsDelivered = orderViewModel.IsDelivered,
                RecipientFullName = orderViewModel.RecipientFullName,
                RecipientLocation =orderViewModel.RecipientAddress
                

            }; 
            StaticDb.Orders.Add(recentlyAddedOrder);
            StaticDb.OrderId++;
            return RedirectToAction("SeeOrders");
        }

        public IActionResult ModifyOrder(int? id)
        {
            if(id == null)
            {
                return View("ResourceNotFound");
            }

            Order orderDb = StaticDb.Orders.FirstOrDefault(o => o.Id == id);  
            if(orderDb == null)
            {
                return View("ResourceNotFound");
            }
            OrderViewModel orderViewModel = OrderMapper.ToOrderViewModel(orderDb);  
            return View(orderViewModel);
        }
        [HttpPost]
        public IActionResult ModifyOrderPost(OrderViewModel orderViewModel)
        {

            Order orderDb = StaticDb.Orders.FirstOrDefault( o => o.Id == orderViewModel.Id);
            if(orderDb == null)
            {
                return View("ResourceNotFound");
            }
            Burger burgerDb = StaticDb.Burgers.FirstOrDefault(o => o.Name == orderViewModel.BurgerName);
            if(burgerDb == null)
            {
                return View("ResourceNotFound");
            }

            StaticDb.Orders.FirstOrDefault(x => x.Id == orderViewModel.Id).Burger = burgerDb;
            StaticDb.Orders.FirstOrDefault(x => x.Id == orderViewModel.Id).BurgerId = burgerDb.Id;
            StaticDb.Orders.FirstOrDefault(x => x.Id == orderViewModel.Id).IsDelivered = orderViewModel.IsDelivered;
            StaticDb.Orders.FirstOrDefault(x => x.Id == orderViewModel.Id).RecipientLocation = orderViewModel.RecipientAddress;
            StaticDb.Orders.FirstOrDefault(x => x.Id == orderViewModel.Id).RecipientFullName = orderViewModel.RecipientFullName;
            StaticDb.Orders.FirstOrDefault(x => x.Id == orderViewModel.Id).StoreAddress = orderViewModel.StoreAddress;
            StaticDb.Orders.FirstOrDefault(x => x.Id == orderViewModel.Id).PaymentMethod = orderViewModel.PaymentMethod;
            StaticDb.Orders.FirstOrDefault(x => x.Id == orderViewModel.Id).Id = orderDb.Id;



            return RedirectToAction("SeeOrders");
        }
    


        public IActionResult DeleteOrder(int? id)
        {
            if(id == null)
            {
                return View("CustomErrorMessage");
            }
            Order order = StaticDb.Orders.FirstOrDefault(o => o.Id == id);
            if(order == null)
            {
                return View("ResourceNotFound");
            }
            int index = StaticDb.Orders.FindIndex(x => x.Id == id);
            if(index == -1)
            {
                return View("ResourceNotFound");
            }

            StaticDb.Orders.RemoveAt(index);
            return RedirectToAction("SeeOrders");
        }


    }
}
