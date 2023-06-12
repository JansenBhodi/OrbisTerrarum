using LogicLayerOrbis;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrbisTerrarum.ViewModels;

namespace OrbisTerrarum.Controllers
{
    public class CharacterController : Controller
    {
        CharacterContainer container = new CharacterContainer();
        EventContainer eventContainer = new EventContainer();
        public int LastWorld;


        // GET: CharacterController
        public ActionResult Index(int id)
        {
            try
            {
                return View(container.GetCharactersByWorld(id));
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: CharacterController/Details/5
        public ActionResult Details(int id)
        {
            CharacterEventsDetailsModel model = new CharacterEventsDetailsModel();

            try
            {
                model.Characters = container.GetCharacterById(id);
            }
            catch (Exception)
            {

                throw;
            }
            try
            {
                model.Events = eventContainer.GetEventsByCharacter(id);
            }
            catch (Exception)
            {

                throw;
            }

            return View(model);
        }

        // GET: CharacterController/Create
        public ActionResult Create(int id)
        {
            Character character = new Character(0, id, null, 0, null, 0);
            return View(character);
        }

        // POST: CharacterController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                if(ModelState.IsValid) 
                {
                    Character result = new Character(0, int.Parse(collection["WorldId"]), collection["CharacterName"].ToString(), int.Parse(collection["CharacterAge"]), collection["CharacterDesc"].ToString(), 0);
                    container.CreateCharacter(result);
                    return RedirectToAction("Index", "Character", new { id = int.Parse(collection["WorldId"]) });
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: CharacterController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                Character input = container.GetCharacterById(id);
                return View(input);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST: CharacterController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid) 
                {
                    Character result = new Character(int.Parse(collection["Id"]), int.Parse(collection["WorldId"]), collection["CharacterName"].ToString(), int.Parse(collection["CharacterAge"]), collection["CharacterDesc"].ToString(), int.Parse(collection["CharacterAlignment"]));
                    container.UpdateCharacter(result);
                    return RedirectToAction("Index", "Character", new { id = int.Parse(collection["WorldId"]) });
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: CharacterController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                Character character = container.GetCharacterById(id);
                return View(character);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST: CharacterController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Character getWorldId = container.GetCharacterById(id);
                container.DeleteCharacter(id);
                return RedirectToAction("Index", "Character", new { id = getWorldId.WorldId });
            }
            catch
            {
                return View();
            }
            return View();
        }
    }
}
