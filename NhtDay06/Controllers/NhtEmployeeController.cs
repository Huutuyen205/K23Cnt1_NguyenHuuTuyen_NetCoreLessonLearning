using Microsoft.AspNetCore.Mvc;
using NhtLab06.Models;

namespace NhtLab06.Controllers
{
    public class NhtEmployeeController : Controller
    {
        public static readonly List<NhtEmployee> nhtEmployee = new List<NhtEmployee>()
        {
            new NhtEmployee { NhtId = Guid.NewGuid().ToString(), NhtName = "tuyen", NhtBirthDay = new DateTime(2005, 10, 2), NhtEmail = "nguyenhuutuyen02@gmail.com", NhtPhone = "0941033632", NhtSalary = "1000", NhtStatus = 1 },
            new NhtEmployee { NhtId = Guid.NewGuid().ToString(), NhtName = "tuyen2", NhtBirthDay = new DateTime(2005, 10, 2), NhtEmail = "nguyenhuutuyen03@gmail.com", NhtPhone = "0941033632", NhtSalary = "1000", NhtStatus = 2 },
            new NhtEmployee { NhtId = Guid.NewGuid().ToString(), NhtName = "tuyen3", NhtBirthDay = new DateTime(2005, 10, 2), NhtEmail = "nguyenhuutuyen04@gmail.com", NhtPhone = "0941033632", NhtSalary = "1000", NhtStatus = 1 },
            new NhtEmployee { NhtId = Guid.NewGuid().ToString(), NhtName = "tuyen4", NhtBirthDay = new DateTime(2005, 10, 2), NhtEmail = "nguyenhuutuyen05@gmail.com", NhtPhone = "0941033632", NhtSalary = "1000", NhtStatus = 1 },
            new NhtEmployee { NhtId = Guid.NewGuid().ToString(), NhtName = "tuyen5", NhtBirthDay = new DateTime(2005, 10, 2), NhtEmail = "nguyenhuutuyen06@gmail.com", NhtPhone = "0941033632", NhtSalary = "1000", NhtStatus = 2 }
        };

        public IActionResult NhtIndex()
        {
            ViewBag.nhtEmployee = nhtEmployee;
            return View();
        }

        [HttpGet]
        public IActionResult NhtCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NhtCreateSubmit(NhtEmployee employee)
        {
            employee.NhtId = Guid.NewGuid().ToString();
            nhtEmployee.Add(employee);
            return RedirectToAction("NhtIndex");
        }
    }
}
