using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LBGeoBackend.Controllers
{
    public class EquivalenciaController : Controller
    {
        // GET: EquivalenciaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: EquivalenciaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EquivalenciaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EquivalenciaController/Create
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

        // GET: EquivalenciaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EquivalenciaController/Edit/5
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

        // GET: EquivalenciaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EquivalenciaController/Delete/5
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
