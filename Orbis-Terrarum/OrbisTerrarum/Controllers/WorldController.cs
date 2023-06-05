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
        public IActionResult Create([Bind("WorldName, WorldCurrentyear, WorldDesc, CreatorId")] World world)
        {
            if (ModelState.IsValid)
            {
                worldContainer.CreateWorld(world);
                return RedirectToAction("Index");
            }
            return View(world);
        }

        public IActionResult Edit(int id) 
        {
            World world = worldContainer.GetWorldById(id);
            return View(world);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id, WorldName, WorldCurrentyear, WorldDesc, CreatorId")] World world)
        {
            if (ModelState.IsValid)
            {
                worldContainer.EditWorld(world);
                return RedirectToAction("Index");
            }
            return View(world);
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
