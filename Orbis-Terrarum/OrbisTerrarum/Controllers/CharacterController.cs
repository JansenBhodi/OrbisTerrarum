using LogicLayerOrbis;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrbisTerrarum.Controllers
{
    public class CharacterController : Controller
    {
        CharacterContainer container = new CharacterContainer();
        // GET: CharacterController
        public ActionResult Index(int id)
        {
            return View(container.GetCharactersByWorld(id));
        }

        // GET: CharacterController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CharacterController/Create
        public ActionResult Create(int id)
        {
            return View();
        }

        // POST: CharacterController/Create
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

        // GET: CharacterController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CharacterController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IFormCollection collection)
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

        // GET: CharacterController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CharacterController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
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
