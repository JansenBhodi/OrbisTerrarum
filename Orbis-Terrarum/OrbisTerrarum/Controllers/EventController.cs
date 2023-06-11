using LogicLayerOrbis;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrbisTerrarum.ViewModels;

namespace OrbisTerrarum.Controllers
{
    public class EventController : Controller
    {
        EventContainer container = new EventContainer();
        CharacterContainer characterContainer = new CharacterContainer();
        // GET: EventController
        public ActionResult Index(int id)
        {
            try
            {
                return View(container.GetEventsByWorld(id));
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: EventController/Details/5
        public ActionResult Details(int id)
        {
            eventCharactersDetailsModel model = new eventCharactersDetailsModel();

            try
            {
                model.Characters = characterContainer.GetCharactersByEvent(id);
            }
            catch (Exception)
            {

                throw;
            }
            try
            {
                model.Events = container.GetEventById(id);
            }
            catch (Exception)
            {

                throw;
            }

            return View(model);
        }

        // GET: EventController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: EventController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Event result = new Event(0, int.Parse(collection["WorldId"]), collection["EventName"].ToString(), collection["EventDesc"].ToString(), Convert.ToBoolean(collection["EventResolved"]), DateOnly.Parse(collection["EventStart"]), DateOnly.Parse(collection["EventEnd"]));
                    container.CreateEvent(result);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: EventController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                Event input = container.GetEventById(id);
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST: EventController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Event result = new Event(0, int.Parse(collection["WorldId"]), collection["EventName"].ToString(), collection["EventDesc"].ToString(), Convert.ToBoolean(collection["EventResolved"]), DateOnly.Parse(collection["EventStart"]), DateOnly.Parse(collection["EventEnd"]));
                    container.EditEvent(result);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: EventController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                Event input = container.GetEventById(id);
                return View(input);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST: EventController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                container.DeleteEvent(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
