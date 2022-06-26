using Microsoft.AspNetCore.Mvc;
using Asp.Net.Class_03.Models.Domain;
using Asp.Net.Class_03.Models.Enums;
using Asp.Net.Class_03.Models.ViewModels;
using Asp.Net.Class_03.Models.Mappers;

namespace Asp.Net.Class_03.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            List<Order> dbOrders = StaticDb.Orders;

            //=======FIRST WAY============
            //List<OrderDetailsViewModel> dbOrdersDetailsViewModels = dbOrders.Select(x => new OrderDetailsViewModel
            //{
            //    PaymentMethod = x.PaymentMethod,
            //    PizzaName = x.Pizza.Name,
            //    Price = x.Pizza.Price,
            //    UserFullName = $"{x.User.FirstName} + {x.User.LastName}"
            //}).ToList();    

            //=======SECOND WAY============
            //List<OrderDetailsViewModel> orderViewModels = new List<OrderDetailsViewModel>();
            //foreach (Order order in dbOrders) 
            //{
            //    orderViewModels.Add(new OrderDetailsViewModel
            //    {
            //        PaymentMethod = order.PaymentMethod,
            //        PizzaName = order.Pizza.Name,
            //        Price =order.Pizza.Price + 50,
            //        UserFullName = $"{order.User.FirstName} + {order.User.LastName}",
            //    }) ;
            //}
            //=======THIRD WAY============
            //From each object in ordersDb list we project (map) an object of type OrderDetailsViewModel
            List<OrderDetailsViewModel> orderViewModels = dbOrders.Select(x => OrderMapper.ToOrderDetailsViewModel(x)).ToList();


            return View(orderViewModels);
        }

        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return View("Empty");
            }
            Order orderDb = StaticDb.Orders.FirstOrDefault(o => o.Id == id);
            if(orderDb == null)
            {
                return View("Home", "Index");
            }

            //======map from domain to view model===========

            //OrderDetailsViewModel orderDetailsViewModel = new OrderDetailsViewModel
            //{
            //    PaymentMethod = orderDb.PaymentMethod,
            //    PizzaName = orderDb.Pizza.Name,
            //    Price = orderDb.Pizza.Price + 50,
            //    UserFullname = $"{orderDb.User.FirstName} {orderDb.User.LastName}"
            //};
            //From orderDb we project (map) an object of type OrderDetailsViewModel
            OrderDetailsViewModel orderDetailsViewModel = OrderMapper.ToOrderDetailsViewModel(orderDb);

            //return View(orderDb);
            return View(orderDetailsViewModel);
        }


        public IActionResult Empty()
        {
            return new EmptyResult();
        }
    }

    




   
}
