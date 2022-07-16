using Microsoft.AspNetCore.Mvc;
using BurgerApp.Domain_Refactored.Models;
using BurgerApp.Services_Refactored.Interfaces;
using BurgerApp.ViewModels_Refactored.BurgerViewModels;


namespace BurgerAppRefactored.Controllers
{
    public class BurgerController : Controller
    {   
        private IBurgerService _burgerService;



        public BurgerController(IBurgerService burgerService)
        {
            _burgerService = burgerService;
        }
        public IActionResult BurgerMenu()
        {
            try { 
            List<BurgerDetailsViewModel> burgerDetailsViewModel = _burgerService.PrintBurgerMenu();
            ViewData["Title"] = "Chef's specials";
            ViewData["SubHeader"] = "Voila! Bon appetit! ";
            return View(burgerDetailsViewModel);
            }catch (Exception ex)
            {
                return View("ResourceNotFound");
            }
        }

        public IActionResult ChefsLitlleMagic(int? id)
        {
            if(id == null)
            {
                return View("ResouceNotFound");
            }
            try
            {
                BurgerDetailsViewModel burgerDetailsViewModel = _burgerService.SeeDetailsForTheChosenBurger(id.Value);
                ViewBag.Blessing = "You've been blessed by the holy spirit of our Chef 😋";
                return View(burgerDetailsViewModel);    
            }catch (Exception ex)
            {
                return View("CustomErrorMessage");
            }
        }
        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return View("ResourceNotFound");
            }
            try 
            { 
                BurgerDetailsViewModel burgerDetailsViewModel =_burgerService.SeeDetailsForTheChosenBurger(id.Value);
                ViewData["Title"] = "Details for the choosen one:";
                return View(burgerDetailsViewModel);
            }
            catch(Exception ex)
            {
                return View("CustomErrorMessage");
            } 
        }
    }
}
