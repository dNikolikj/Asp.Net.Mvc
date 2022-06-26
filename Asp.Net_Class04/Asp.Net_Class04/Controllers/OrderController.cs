using Microsoft.AspNetCore.Mvc;
using Asp.Net_Class04.Models.Domain;
using Asp.Net_Class04.Models.Enums;
using Asp.Net_Class04.Models.ViewModels;
using Asp.Net_Class04.Models.Mappers;
namespace Asp.Net_Class04.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            List<Order> ordersDb = StaticDb.Orders;

            List<OrderDetailsViewModel> ordersDetails = ordersDb.Select(x => OrderMapper.ToOrderDetailsViewModel(x)).ToList();

            ViewData["Title"] = "These are the orders made with our app:";
            ViewData["NumbersOfOrders"] = StaticDb.Orders.Count;
            ViewData["FirstUser"] = StaticDb.Orders.First().User;
            return View(ordersDetails);
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
                return View("ResourceNotFound");
            }

            OrderDetailsViewModel orderDetailsViewModel = OrderMapper.ToOrderDetailsViewModel(orderDb);

            ViewBag.Title = $"Details for order with id {id}.";
            ViewBag.User = orderDb.User;
            return View(orderDetailsViewModel); 
        }
    }
}
