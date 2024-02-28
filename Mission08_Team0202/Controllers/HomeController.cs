using Microsoft.AspNetCore.Mvc;
using Mission08_Team0202.Models;
using System.Diagnostics;

namespace Mission08_Team0202.Controllers
{
    public class HomeController : Controller
    {
        private ITaskRepository _repo; // Database "Instance"
        public HomeController(ITaskRepository temp) // Constructor
        {
            _repo = temp;
        }

        public IActionResult Index()
        {
            var tasks = _repo.Tasks.Where(x => x.Completed == 0).ToList();

            return View(tasks);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Add()
        //{
        //    return View();
        //}

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Edit()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
