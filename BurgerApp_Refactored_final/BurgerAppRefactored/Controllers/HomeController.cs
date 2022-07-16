using BurgerAppRefactored.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BurgerApp.Services_Refactored.Interfaces;
using BurgerApp.ViewModels_Refactored.HomeViewModels;
using BurgerApp.Domain_Refactored.Models;

namespace BurgerAppRefactored.Controllers
{
    public class HomeController : Controller
    {
        private IBurgerService _burgerService;
        public HomeController(IBurgerService burgerService)
        {
            _burgerService= burgerService;
        }
        

        public IActionResult Index()
        {
            try
            {
                HomeViewModel homeViewModel = new HomeViewModel();
                homeViewModel.MostPopularBurger = _burgerService.GetMostPopularBurger();    
                homeViewModel.NumberOfOrders = _burgerService.GetTheNumberOfOrders();
                homeViewModel.AveragePrice = _burgerService.GetTheAveragePriceOfOrders();
                return View(homeViewModel);
            }
            catch (Exception ex)
            {
                return View("CustomErrorMessage");
            }
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("AboutUs")]
        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}