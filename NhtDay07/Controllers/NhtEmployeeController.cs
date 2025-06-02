using Microsoft.AspNetCore.Mvc;
using NhtDay07.Models;

namespace NhtDay07.Controllers

{
  
    public class NhtEmployeeController : Controller
    {
        private static List<NhtEmployee> nhtListEmployees = new List<NhtEmployee>
        {
            new NhtEmployee { NhtId = 230001122, NhtName = "Huutuyen", NhtBirthDay = new DateTime(1979, 5, 25), NhtEmail = "huutuyen123@gmail.com", NhtPhone = "0941033632", NhtSalary = 12000000, NhtStatus = true },
            new NhtEmployee { NhtId = 2, NhtName = "Trần Thị B", NhtBirthDay = new DateTime(1992, 5, 15), NhtEmail = "b@example.com", NhtPhone = "0912233445", NhtSalary = 15000000, NhtStatus = true },
            new NhtEmployee { NhtId = 3, NhtName = "Lê Văn C", NhtBirthDay = new DateTime(1988, 9, 20), NhtEmail = "c@example.com", NhtPhone = "0922123456", NhtSalary = 11000000, NhtStatus = false },
            new NhtEmployee { NhtId = 4, NhtName = "Phạm Thị D", NhtBirthDay = new DateTime(1995, 3, 10), NhtEmail = "d@example.com", NhtPhone = "0933445566", NhtSalary = 13000000, NhtStatus = true },
            new NhtEmployee { NhtId = 5, NhtName = "Đỗ Văn E", NhtBirthDay = new DateTime(1991, 7, 25), NhtEmail = "e@example.com", NhtPhone = "0944567890", NhtSalary = 10000000, NhtStatus = false }
        };
        public IActionResult NhtIndex1()
        {
            
            return View(nhtListEmployees);
        }
        // GET: /NhtEmployee/NhtCreate
        public IActionResult NhtCreate()
        {
            var nhtModel = new NhtEmployee();
            return View(nhtModel);
        }

        // POST: /NhtEmployee/NhtCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NhtCreate(NhtEmployee nhtModel)
        {
            try
            {
                // Tự động sinh mã nếu cần
                if (nhtModel.NhtId == 0)
                {
                    nhtModel.NhtId = nhtListEmployees.Max(e => e.NhtId) + 1;
                }
                nhtListEmployees.Add(nhtModel);
                return RedirectToAction(nameof(NhtIndex1));
            }
            catch
            {
                return View();
            }
        }


        //  GET: /NhtEmployee/NhtEdit/5
        public IActionResult NhtEdit(int id)
        {
            var nhtModel = nhtListEmployees.FirstOrDefault(x => x.NhtId == id);
            return View(nhtModel);
        }
        // POST: NhtEmployee/NhtEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NhtEdit(int id, NhtEmployee nhtModel)
        {
            try
            {
                // cập nhật model vào danh sách 
                for (int i = 0; i < nhtListEmployees.Count; i++)
                {
                    if (nhtListEmployees[i].NhtId == id)
                    {
                        nhtListEmployees[i] = nhtModel;
                        break;
                    }
                }
                return RedirectToAction(nameof(NhtIndex1));
            }
            catch
            {
                return View();
            }
        }

        // GET: NhtEmployee/NhtDetails/5
        public ActionResult NhtDetails(int id)
        {
            var nhtModel = nhtListEmployees.FirstOrDefault(x => x.NhtId == id);
            return View(nhtModel);
        }


        // GET: NhtEmployee/NhtDelete/5
        public ActionResult NhtDelete(int id)
        {
            var nhtModel = nhtListEmployees.FirstOrDefault(x => x.NhtId == id);
            if (nhtModel == null)
            {
                return View(nhtListEmployees);
            }
            return View(nhtModel);
        }

        // POST: NhtEmployee/NhtDelete/5
        [HttpPost, ActionName("NhtDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult NhtDeleteConfirmed(int id)
        {
            try
            {
                var nhtModel = nhtListEmployees.FirstOrDefault(x => x.NhtId == id);
                if (nhtModel != null)
                {
                    nhtListEmployees.Remove(nhtModel);
                }
                return RedirectToAction(nameof(NhtIndex1));
            }
            catch
            {
                return View();
            }
        }

    }
}
    

