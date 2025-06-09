using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NetCoreMVCLAB5_Day08.Models;

namespace NetCoreMVCLAB5_Day08.Controllers
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
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
