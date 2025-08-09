using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LBGeoBackend.Controllers
{
    public class RepuestoController : Controller
    {
        // GET: RepuestoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: RepuestoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RepuestoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RepuestoController/Create
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

        // GET: RepuestoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RepuestoController/Edit/5
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

        // GET: RepuestoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RepuestoController/Delete/5
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
