using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mission08_Team0202.Models;
using System.Diagnostics;
using TaskModel = Mission08_Team0202.Models.Tasks;

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
            var tasks = _repo.Tasks.Where(x => x.Completed == false).ToList();

            return View(tasks);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var categories = _repo.Categories.Select(c => new SelectListItem
            {
                Value = c.CategoryId.ToString(),
                Text = c.Category
            }
            ).ToList();

            ViewBag.Categories = categories;

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
            var tasks = _repo.Tasks.Where(x => x.Completed == false).ToList();

            return View("Index", tasks);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Find the task by ID
            var taskToEdit = _repo.Tasks.FirstOrDefault(x => x.TaskId == id);
            if (taskToEdit == null)
            {
                // Handle the case where the task is not found
                return NotFound();
            }

            // Convert categories to SelectListItems for the ViewBag
            ViewBag.Categories = _repo.Categories
                .OrderBy(x => x.Category)
                .Select(c => new SelectListItem
                {
                    Value = c.CategoryId.ToString(),
                    Text = c.Category
                })
                .ToList();

            // Return the Edit view with the task to edit
            return View(taskToEdit);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public IActionResult Edit(TaskModel taskToUpdate)
        {
            // Check if the model state is valid
            if (ModelState.IsValid)
            {
                // Update the task using the repository
                _repo.EditTask(taskToUpdate);

                // Redirect to the Index action to show the updated task list
                return RedirectToAction(nameof(Index));
            }

            // If the model state is not valid, re-populate the categories and return the same view
            ViewBag.Categories = _repo.Categories
                .OrderBy(x => x.Category)
                .Select(c => new SelectListItem
                {
                    Value = c.CategoryId.ToString(),
                    Text = c.Category
                })
                .ToList();

            // Return the view with the task to edit
            return View(taskToUpdate);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            // Identify target record based on task id
            var taskToDelete = _repo.Tasks.FirstOrDefault(t => t.TaskId == id);
            if (taskToDelete != null)
            {
                // Remove target record based on id
                _repo.DeleteTask(taskToDelete.TaskId);
            }

            // Grab remaining tasks from database
            var tasks = _repo.Tasks.Where(x => x.Completed == false).ToList();

            // Send back to home with tasks included
            return RedirectToAction("Index", tasks);
        }

        [HttpPost]
        public IActionResult MarkComplete(int id)
        {
            // Grab task
            var taskToEdit = _repo.Tasks
                .Single(x => x.TaskId == id);

            // Set completed to true
            taskToEdit.Completed = true;

            // Pass task to edit method
            _repo.EditTask(taskToEdit);

            // Grab remaining tasks from database
            var tasks = _repo.Tasks.Where(x => x.Completed == false).ToList();

            return RedirectToAction("Index", tasks);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
