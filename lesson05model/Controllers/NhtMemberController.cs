using lesson05model.Models.DataModels;
using Microsoft.AspNetCore.Mvc;

namespace lesson05model.Controllers
{
    public class NhtMemberController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult NhtGetMember()
        {
            var NhtMember = new NhtMember ();
                NhtMember.NhtMemberId = Guid.NewGuid().ToString();
                NhtMember.NhtUserName = "nguyenhuutuyen";
                NhtMember.NhtFullName = "nguyen huu tuyen";
                NhtMember.NhtPassword = "123456@";
                NhtMember.NhtEmail = "huutuyen123tc@gmail.com";
            // truyen view qua doi tuong viewbag
            ViewBag.nhtMember = NhtMember;
            return View();
        }
    }
}
