using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission08_Team0202.Models;
using System.Diagnostics;
using TaskModel = Mission08_Team0202.Models.Task;

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
            // Get task list, pass to view
            var tasks = _repo.Tasks.Where(x => x.Completed == 0).ToList();

            return View(tasks);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(TaskModel t)
        {
            // Check if new record lines up with the model
            if (ModelState.IsValid)
            {
                // Call _repo method (found in EFTaskRepository.cs)
                _repo.AddTask(t);
            }

            // Get task list to reload home page
            var tasks = _repo.Tasks.Where(x => x.Completed == 0).ToList();

            return View("Index", tasks);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Grab a single task based on task id
            var taskToEdit = _repo.Tasks
                .Single(x => x.TaskId == id);

            return View(taskToEdit);
        }

        //[HttpPost]
        //public IActionResult Edit()
        //{
        //    return View();
        //}

        [HttpPost]
        public IActionResult Delete(int id)
        {
            // Identify target record based on task id
            var taskToDelete = _repo.Tasks.FirstOrDefault(t => t.TaskId == id);
            if (taskToDelete != null)
            {
                // Remove target record
                _repo.DeleteTask(taskToDelete);
            }

            // Grab remaining tasks from database
            var tasks = _repo.Tasks.Where(x => x.Completed == 0).ToList();

            // Send back to home with tasks included
            return RedirectToAction("Index", tasks);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
