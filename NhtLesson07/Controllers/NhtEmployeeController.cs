using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NhtLesson07.Models;

namespace NhtLesson07.Controllers
{
    public class NhtEmployeeController : Controller
    {
        // GET: NhtEmployeeController
        public ActionResult NhtIndex()
        {
            return View();
        }

        // GET: NhtEmployeeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NhtEmployeeController/Create
        public ActionResult NhtCreate()
        {
            var nhtEmployee = new NhtEmployee(); 
            return View();
        }

        // POST: NhtEmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NhtCreate(NhtEmployee nhtModel)
        {
            try
            {
                

                return RedirectToAction(nameof(NhtIndex));
            }
            catch
            {
                return View();
            }
        }

        // GET: NhtEmployeeController/Edit/5
        public ActionResult NhtEdit(int id)
        {
           
            return View();
        }

        // POST: NhtEmployeeController/Edit/5
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

        // GET: NhtEmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NhtEmployeeController/Delete/5
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
