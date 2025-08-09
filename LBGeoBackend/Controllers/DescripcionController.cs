using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LBGeoBackend.Controllers
{
    public class DescripcionController : Controller
    {
        // GET: DescripcionController
        public ActionResult Index()
        {
            return View();
        }

        // GET: DescripcionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DescripcionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DescripcionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: DescripcionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DescripcionController/Edit/5
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

        // GET: DescripcionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DescripcionController/Delete/5
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
