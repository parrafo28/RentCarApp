using Microsoft.AspNetCore.Mvc;
using RentCarApp.Frontend.Models;
using System.Diagnostics;

namespace RentCarApp.Frontend.Controllers
{
    public class HomeController : Controller
    { 

        private IActionResult Index()
        {
            var mySecretKey = "sdfsdfsdfsdf";
            return View();
        }

        public IActionResult Privacy()
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
