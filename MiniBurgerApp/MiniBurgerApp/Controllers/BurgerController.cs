using Microsoft.AspNetCore.Mvc;
using MiniBurgerApp.Models.Domain;
using MiniBurgerApp.Models.Mappers;
using MiniBurgerApp.Models.ViewModels;

namespace MiniBurgerApp.Controllers
{
    public class BurgerController : Controller
    {
        public IActionResult BurgerMenu()
        {

            List<Burger> burgersDb = StaticDb.Burgers;

            List<BurgerViewModel> burgersViewModel = burgersDb.Select(b => BurgerMapper.ToBurgerViewModel(b)).ToList();

            ViewData["Title"] = "Chef's specials";
            ViewData["Subtitle"] = "Voila! Bon appetit! ";

            return View(burgersViewModel);
        }

        public IActionResult ChefMagic(int? id)
        {
            if (id == null)
            {
                return View("ResourceNotFound");
            }

            Burger burgerDb = StaticDb.Burgers.FirstOrDefault(b => b.Id == id);
            if (burgerDb == null)
            {
                return RedirectToAction("Index");
            }
            BurgerViewModel burgerViewModel = BurgerMapper.ToBurgerViewModel(burgerDb);

            ViewBag.Blessing = "You've been blessed by the holy spirit of our Chef 😋";

            return View(burgerViewModel);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return View("CustomErrorMessage");
            }
            Burger burgerDb = StaticDb.Burgers.FirstOrDefault(b => b.Id == id);

            if (burgerDb == null)
            {
                return View("CustomErrorMessage");
            }

            BurgerViewModel burgerViewModel = BurgerMapper.ToBurgerViewModel(burgerDb);

            ViewData["Title"] = "Details for the choosen one:";
            return View(burgerViewModel);
        }

        public IActionResult MakeBurger()
        {
            BurgerViewModel burgerViewModel = new BurgerViewModel();
            ViewBag.Burgers = StaticDb.Burgers.Select(b => new BurgerDDViewModel
            {
                
                Name = b.Name
            });

            return View(burgerViewModel);
        }
        [HttpPost]
        public IActionResult MakeBurgerPost(BurgerViewModel burgerViewModel)
        {

            Burger newBurger = new Burger()
            {
                Id = StaticDb.BurgerId + 1,
                Name = burgerViewModel.BurgerName,
                BurgerType = burgerViewModel.ChooseYourBurgerFit,
                HasFries = burgerViewModel.Fries, 
                Price = 450
             
            };
            ViewBag.Burgers = StaticDb.Burgers.Select(b => new BurgerDDViewModel
            {

                Name = b.Name
            });

            StaticDb.Burgers.Add(newBurger);
            StaticDb.BurgerId++;
            return RedirectToAction("BurgerMenu");

        }
        public IActionResult EditBurger(int? id)
        {
            if (id == null)
            {
                return View("CustomErrorMessage");
            }

            Burger burgerDb = StaticDb.Burgers.FirstOrDefault(o => o.Id == id);
            if (burgerDb == null)
            {
                return View("ResourceNotFound");
            }

            ViewBag.Burgers = StaticDb.Burgers.Select(b => new BurgerDDViewModel
            {
                

                Name = b.Name,
            });
            BurgerViewModel burgerViewModel = BurgerMapper.ToBurgerViewModel(burgerDb);

            return View(burgerViewModel);
        }
        [HttpPost]
        public IActionResult EditBurgerPost(BurgerViewModel burgerViewModel)
        {

            Burger burgerDb = StaticDb.Burgers.FirstOrDefault(x => x.Id == burgerViewModel.Id);
            if (burgerDb == null)
            {
                return View("CustomErrorMessage");
            }

            StaticDb.Burgers.FirstOrDefault(x => x.Id == burgerViewModel.Id).Name = burgerViewModel.BurgerName;
            StaticDb.Burgers.FirstOrDefault(x => x.Id == burgerViewModel.Id).BurgerType = burgerViewModel.ChooseYourBurgerFit;
            StaticDb.Burgers.FirstOrDefault(x => x.Id == burgerViewModel.Id).HasFries = burgerViewModel.Fries;
            StaticDb.Burgers.FirstOrDefault(x => x.Id == burgerViewModel.Id).Id = burgerViewModel.Id;


            return RedirectToAction("BurgerMenu");
        }

        public IActionResult DeleteBurger(int? id)
        {
            if(id == null)
            {
                return View("ResourceNotFound");
            }
            Burger burgerDb = StaticDb.Burgers.FirstOrDefault(b => b.Id == id);

            if (burgerDb == null)
            {
                return View("ResourceNotFound");
            }
            int index = StaticDb.Burgers.FindIndex(x => x.Id == id);
            if(index == -1)
            {
                return View("ResourceNotFound");
            }
            StaticDb.Burgers.RemoveAt(index);
            return RedirectToAction("BurgerMenu");
        }
        

    }

}
