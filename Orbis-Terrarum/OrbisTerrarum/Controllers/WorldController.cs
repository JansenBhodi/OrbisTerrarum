using Microsoft.AspNetCore.Mvc;
using LogicLayerOrbis;
using OrbisTerrarum.ViewModels;
using System.ComponentModel;
using System.Net;

namespace OrbisTerrarum.Controllers
{
    public class WorldController : Controller
    {
        public WorldContainer worldContainer = new WorldContainer();
        public UserContainer userContainer = new UserContainer();

        public IActionResult Index()
        {
            return View(worldContainer.GetWorlds());
        }

        public IActionResult Details(int id)
        {
            if(id == null) 
            {
                RedirectToAction("Index");
            }

            WorldCreatorDetailsModel model = new WorldCreatorDetailsModel();

            model.Worlds = worldContainer.GetWorldById(id);
            model.Users = userContainer.GetUserByCreatorId(model.Worlds.CreatorId);

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection collection)
        {
            World result = new World(0, collection["WorldName"].ToString(), DateOnly.FromDateTime(Convert.ToDateTime(collection["WorldCurrentYear"].ToString())), collection["WorldDesc"].ToString(), int.Parse(collection["CreatorId"]));

            if (ModelState.IsValid)
            {
                worldContainer.CreateWorld(result);
                return RedirectToAction("Index");
            }
            return View(result);
        }

        public IActionResult Edit(int id) 
        {
            World world = worldContainer.GetWorldById(id);
            return View(world);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(IFormCollection collection)
        {
            World result = new World(int.Parse(collection["Id"]), collection["WorldName"].ToString(), DateOnly.FromDateTime(Convert.ToDateTime(collection["WorldCurrentYear"].ToString())), collection["WorldDesc"].ToString(), int.Parse(collection["CreatorId"]));
            if (ModelState.IsValid)
            {
                worldContainer.EditWorld(result);
                return RedirectToAction("Index");
            }
            return View(result);
        }

        public IActionResult Delete(int id) 
        {
            World world = worldContainer.GetWorldById(id);
            return View(world);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            World world = worldContainer.GetWorldById(id);
            worldContainer.DeleteWorld(world);
            return RedirectToAction("Index");
        }
    }
}
