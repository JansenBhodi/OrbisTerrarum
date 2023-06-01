using Microsoft.AspNetCore.Mvc;
using LogicLayerOrbis;
using OrbisTerrarum.ViewModels;

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
            model.Users = userContainer.GetUserByCreatorId(id);

            return View();
        }

        public IActionResult Edit(int id) 
        {
            
        }

        public IActionResult Delete(int id) 
        { 
        
        }
        public IActionResult Create() 
        { 
            return View(); 
        }
    }
}
