using Microsoft.AspNetCore.Mvc;
using LogicLayerOrbis;

namespace OrbisTerrarum.Controllers
{
    public class WorldController : Controller
    {
        public WorldContainer worldContainer = new WorldContainer();


        public IActionResult Index()
        {
            return View(worldContainer.GetWorlds());
        }
    }
}
