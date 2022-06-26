using Microsoft.AspNetCore.Mvc;
using Asp.Net.Class_03.Models.Domain;
using Asp.Net.Class_03.Models.ViewModels;
using Asp.Net.Class_03.Models.Mappers;


namespace Asp.Net.Class_03.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult GetPizzas()
        {
            List<Pizza> dbPizzas = StaticDb.Pizzas;


            List<PizzaViewModel> pizzaViewModels = dbPizzas.Select(x => x.ToPizzaViewModelMapper()).ToList();

            return View(pizzaViewModels);
            //return View(dbPizzas);
        }
       
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error");
            }

            Pizza pizza = StaticDb.Pizzas.FirstOrDefault(x => x.Id == id);
            if (pizza == null)
            {
                return new EmptyResult();
            }

            PizzaViewModel pizzaViewModel = pizza.ToPizzaViewModelMapper();
            return View(pizzaViewModel);
        }

       
        public IActionResult Error()
        {
            return View();  
        }
    }
}
