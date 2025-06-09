using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreMVCLAB5_Day08.Models;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;

namespace NetCoreMVCLAB5_Day08.Controllers
{
    public class NhtAccountController : Controller
    {
        private static List<NhtAccount> accounts = new List<NhtAccount>()
    {
    new NhtAccount
    {
        NhtId = 1,
        NhtFullName = "Nguyễn Văn A",
        NhtEmail = "vana@example.com",
        NhtPhone = "0986421127",
        NhtAddress = "Hà Nội",
        NhtAvatar = "avatar1.png",
        NhtBirthday = new DateTime(1990, 5, 20),
        NhtGender = "Nam",
        NhtPassword = "password1",
        NhtFacebook = "https://facebook.com/vana"
    },
    new NhtAccount
    {
        NhtId = 2,
        NhtFullName = "Trần Thị B",
        NhtEmail = "thib@example.com",
        NhtPhone = "0981234567",
        NhtAddress = "Đà Nẵng",
        NhtAvatar = "avatar2.png",
        NhtBirthday = new DateTime(1995, 10, 10),
        NhtGender = "Nữ",
        NhtPassword = "password2",
        NhtFacebook = "https://facebook.com/thib"
    },
    new NhtAccount
    {
        NhtId = 3,
        NhtFullName = "Lê Văn C",
        NhtEmail = "vanc@example.com",
        NhtPhone = "0977654321",
        NhtAddress = "TP.HCM",
        NhtAvatar = "avatar3.png",
        NhtBirthday = new DateTime(1988, 3, 15),
        NhtGender = "Nam",
        NhtPassword = "password3",
        NhtFacebook = "https://facebook.com/vanc"
    }
};
        // GET: NhtAccountController
        public ActionResult NhtIndex()
        {
           
            return View(accounts);

        }

        // GET: NhtAccountController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NhtAccountController/Create
        public ActionResult Create()
        {
            NhtAccount Nhtmodel = new NhtAccount();  
            return View(Nhtmodel);
        }

        // POST: NhtAccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NhtAccount Nhtmodel)
        {
            try
            {
                if (Nhtmodel.NhtId==0)
                {
                    Nhtmodel.NhtId = accounts.Max(e => e.NhtId) +1;
                }    
                accounts.Add(Nhtmodel);
                return RedirectToAction(nameof(NhtIndex));
            }
            catch
            {
                return View();
            }
        }

        // GET: NhtAccountController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NhtAccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NhtAccountController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NhtAccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
