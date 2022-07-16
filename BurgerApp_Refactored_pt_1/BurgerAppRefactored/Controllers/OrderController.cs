using BurgerApp.Services_Refactored.Interfaces;
using BurgerApp.ViewModels_Refactored.OrderViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BurgerAppRefactored.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService _orderService;
        private IUserService _userService;
        private IBurgerService _burgeService;

        public OrderController(IOrderService orderService, IUserService userService, IBurgerService burgerService)
        {
            _orderService = orderService;
            _userService = userService;
            _burgeService = burgerService;
        }
        public IActionResult SeeOrders()
        {
            try
            {
                List<OrderDetailsViewModel> orderDetailsViewModels = _orderService.GetAllOrders();
                ViewBag.Title = "Here are our recently made orders:";
                return View(orderDetailsViewModels);
            }
            catch (Exception ex)
            {
                return View("CustomErrorMessage");
            }



        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return View("ResourceNotFound");
            }

            try
            {
                OrderDetailsViewModel orderDetailsViewModel = _orderService.SelectOrderById(id.Value);
                ViewBag.Title = "See the details for the selected order:";
                return View(orderDetailsViewModel);

            }
            catch (Exception ex)
            {
                return View("ResourceNotFound");
            }

        }
        public IActionResult ModifyOrder(int? id)
        {
            if (id == null)
            {
                return View("CustomErrorMessage");
            }
            try
            {
                ViewBag.Users = _userService.GetUsersForDD();
                ViewBag.Burgers = _burgeService.GetBurgersForDD();
                OrderViewModel orderViewModel = _orderService.EditOrder(id.Value);
                return View(orderViewModel);

            }
            catch (Exception ex)
            {
                return View("CustomErrorMessage");
            }
        }

        public IActionResult ModifyOrderPost(OrderViewModel orderViewModel)
        {
            try
            {
                _orderService.EditOrderPost(orderViewModel);
                return RedirectToAction("Details", new { id = orderViewModel.Id });
            }
            catch (Exception ex)
            {
                return View("CustomErrorMessage");
            }
        }
        public IActionResult AddNewOrder()
        {
            OrderViewModel orderViewModel = new OrderViewModel();
            ViewBag.Users = _userService.GetUsersForDD();
            ViewBag.Burgers = _burgeService.GetBurgersForDD();
            return View(orderViewModel);
        }
        [HttpPost]
        public IActionResult AddNewOrderPost(OrderViewModel orderViewModel)
        {
            try
            {
                _orderService.CreateOrder(orderViewModel);
                return RedirectToAction("SeeOrders");
            }catch (Exception ex)
            {
                return View("CustomErrorMessage");
            }
        }

        public IActionResult AddBurger(int id)
        {
            ViewBag.Burgers = _burgeService.GetBurgersForDD();
            AddBurgerToTheBasketViewModel addBurgerViewModel = new AddBurgerToTheBasketViewModel();
            addBurgerViewModel.OrderId = id;
            return View(addBurgerViewModel);
        }
        [HttpPost]
        public IActionResult AddBurgerPost(AddBurgerToTheBasketViewModel addBurgerViewModel)
        {
            try
            {
                _orderService.AddBurgerToOrder(addBurgerViewModel);
                return RedirectToAction("Details", new {id=addBurgerViewModel.OrderId});
            }catch (Exception ex)
            {
                return View("CustomErrorMessage");
            }
        }

        public IActionResult DeleteOrder(int? id)
        {
            if(id == null)
            {
                return View("ResourceNotFound");
            }

            try
            {
                OrderDetailsViewModel orderDetailsViewModel = _orderService.SelectOrderById(id.Value);  
                return View(orderDetailsViewModel);
            }catch (Exception ex)
            {
                return View("CustomErrorMessage");
            }
        }
        public IActionResult ConfirmDelete(int? id)
        {
            if(id == null)
            {
                return View("ResourceNotFound");
            }
            try
            {
                _orderService.DeleteOrder(id.Value);
                return RedirectToAction("SeeOrders");
            }catch (Exception ex)
            {
                return View("CustomErrorMessage");
            }
        }
    }
}
