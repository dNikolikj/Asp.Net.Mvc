using Asp.Net_Class04.Models;
using Microsoft.AspNetCore.Mvc;
using Asp.Net_Class04.Models.ViewModels;
using Asp.Net_Class04.Models.Domain;
using Asp.Net_Class04.Models.Mappers;

using System.Diagnostics;

namespace Asp.Net_Class04.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult SeeUsers()
        {
            List<User> usersDb = StaticDb.Users;
            List<UserViewModel> usersViewModels = usersDb.Select(x => UserMapper.ToUserViewModelMapper(x)).ToList();
            return View(usersViewModels);

        }

        [Route("AboutUs")]
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
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