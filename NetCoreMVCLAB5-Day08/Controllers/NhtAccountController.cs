using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using NetCoreMVCLAB5_Day08.Models;
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

        // GET: NhtAccount/NhtIndex
        public IActionResult NhtIndex()
        {
            return View(accounts);
        }

        // GET: NhtAccount/Details/5
        public IActionResult Details(int id)
        {
            var account = accounts.FirstOrDefault(a => a.NhtId == id);
            if (account == null) return NotFound();
            return View(account);
        }

        // GET: NhtAccount/Create
        public IActionResult Create()
        {
            return View(new NhtAccount());
        }

        // POST: NhtAccount/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(NhtAccount model)
        {
            try
            {
                model.NhtId = accounts.Max(a => a.NhtId) + 1;
                accounts.Add(model);
                return RedirectToAction(nameof(NhtIndex));
            }
            catch
            {
                return View(model);
            }
        }

        // GET: NhtAccount/Edit/5
        public IActionResult Edit(int id)
        {
            var account = accounts.FirstOrDefault(a => a.NhtId == id);
            if (account == null) return NotFound();
            return View(account);
        }

        // POST: NhtAccount/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, NhtAccount updatedAccount)
        {
            var account = accounts.FirstOrDefault(a => a.NhtId == id);
            if (account == null) return NotFound();

            account.NhtFullName = updatedAccount.NhtFullName;
            account.NhtEmail = updatedAccount.NhtEmail;
            account.NhtPhone = updatedAccount.NhtPhone;
            account.NhtAddress = updatedAccount.NhtAddress;
            account.NhtAvatar = updatedAccount.NhtAvatar;
            account.NhtBirthday = updatedAccount.NhtBirthday;
            account.NhtGender = updatedAccount.NhtGender;
            account.NhtPassword = updatedAccount.NhtPassword;
            account.NhtFacebook = updatedAccount.NhtFacebook;

            return RedirectToAction(nameof(NhtIndex));
        }

        
        public ActionResult NhtDelete(int id) // Đổi tên action và kiểu trả về
        {
            var account = accounts.FirstOrDefault(a => a.NhtId == id);
            if (account == null) return NotFound();
            return View(account); // Mặc định tìm Views/NhtAccount/Delete.cshtml
        }
        [HttpPost, ActionName("NhtDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var account = accounts.FirstOrDefault(a => a.NhtId == id);
            if (account == null) return NotFound();

            accounts.Remove(account);

            // Chuyển hướng về action index đúng tên
            return RedirectToAction("NhtIndex");  // hoặc tên action đúng trong controller của bạn
        }




    }
}
