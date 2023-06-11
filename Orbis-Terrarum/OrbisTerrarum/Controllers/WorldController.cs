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
            List<World> worldList = new List<World>();

            try
            {
                worldList = worldContainer.GetWorlds();
            }
            catch (Exception)
            {

                throw;
            }

            return View(worldList);
        }

        public IActionResult Details(int id)
        {

            if(id == null) 
            {
                RedirectToAction("Index");
            }

            WorldCreatorDetailsModel model = new WorldCreatorDetailsModel();
            try
            {
                model.Worlds = worldContainer.GetWorldById(id);
                model.Users = userContainer.GetUserByCreatorId(model.Worlds.CreatorId);
            }
            catch (Exception)
            {

                throw;
            }

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
            try
            {
                World result = new World(0, collection["WorldName"].ToString(), DateOnly.FromDateTime(Convert.ToDateTime(collection["WorldCurrentYear"].ToString())), collection["WorldDesc"].ToString(), int.Parse(collection["CreatorId"]));
            
            
                if (ModelState.IsValid)
                {
                    try
                    {
                        worldContainer.CreateWorld(result);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    return RedirectToAction("Index");
                }
                return View(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IActionResult Edit(int id) 
        {
            try
            {
                World world = worldContainer.GetWorldById(id);
                return View(world);
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(IFormCollection collection)
        {
            try
            {
                World result = new World(int.Parse(collection["Id"]), collection["WorldName"].ToString(), DateOnly.FromDateTime(Convert.ToDateTime(collection["WorldCurrentYear"].ToString())), collection["WorldDesc"].ToString(), int.Parse(collection["CreatorId"]));
                if (!ModelState.IsValid)
                {
                    worldContainer.EditWorld(result);
                    return RedirectToAction("Index");
                }
                return View(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IActionResult Delete(int id) 
        {
            try
            {
                World world = worldContainer.GetWorldById(id);
                return View(world);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                World world = worldContainer.GetWorldById(id);
                worldContainer.DeleteWorld(world);
            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("Index");
        }
    }
}
