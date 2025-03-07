using Microsoft.AspNetCore.Mvc;
using RentCarApp.Frontend.Models;

namespace RentCarApp.Frontend.Controllers
{
    public class StatusController : Controller
    {
        public StatusController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            return View(new StatusViewModel { Id = id });
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        public async Task<IActionResult> Edit(int id)
        {
            return View(new StatusViewModel { Id = id });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(new StatusViewModel { Id = id });
        }

    }
}
