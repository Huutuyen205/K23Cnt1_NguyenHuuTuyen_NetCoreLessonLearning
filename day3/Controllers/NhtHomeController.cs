using day3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace day3.Controllers
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

        public IActionResult NhtAbout()
        {
            ViewBag.about = "Huutuyen";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult NhtProfile()
        {
            return View();
        }
        public IActionResult NhtRazorCode()
        {
            return View();
        }
    }
}
