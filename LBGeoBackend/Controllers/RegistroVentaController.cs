using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LBGeoBackend.Controllers
{
    public class RegistroVentaController : Controller
    {
        // GET: RegistroVentaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: RegistroVentaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RegistroVentaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegistroVentaController/Create
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

        // GET: RegistroVentaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RegistroVentaController/Edit/5
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

        // GET: RegistroVentaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RegistroVentaController/Delete/5
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
