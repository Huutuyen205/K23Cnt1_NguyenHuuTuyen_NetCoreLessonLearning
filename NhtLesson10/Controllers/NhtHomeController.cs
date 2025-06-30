using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NhtLesson10.Models;

namespace NhtLesson10.Controllers
{
    public class NhtHomeController : Controller
    {
        private readonly ILogger<NhtHomeController> _logger;

        public NhtHomeController(ILogger<NhtHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult NhtIndex()
        {
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
