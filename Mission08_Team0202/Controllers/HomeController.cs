using Microsoft.AspNetCore.Mvc;
using Mission08_Team0202.Models;
using System.Diagnostics;

namespace Mission08_Team0202.Controllers
{
    public class HomeController : Controller
    {
        private TaskContext _context; // Database "Instance"
        public HomeController(TaskContext temp) // Constructor
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            

            return View(/* Give four objects representing each quadrant (quad1, quad2, quad3, quad4) */);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
