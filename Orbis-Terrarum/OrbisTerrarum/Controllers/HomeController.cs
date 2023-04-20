using Microsoft.AspNetCore.Mvc;
using OrbisTerrarum.Logic;
using OrbisTerrarum.Models;
using System.Diagnostics;

namespace OrbisTerrarum.Controllers
{
    public class HomeController : Controller
    {
        private Database _db = new Database();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult WorldButton() 
        {
            World world = new World(1, "test");
            _db.CreateWorld(world);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}