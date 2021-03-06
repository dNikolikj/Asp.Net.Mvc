using Microsoft.AspNetCore.Mvc;
using  Asp.Net_Class04.Models.Domain;
using Asp.Net_Class04.Models.ViewModels;
using Asp.Net_Class04.Models.Mappers;

namespace Asp.Net_Class04.Controllers
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
