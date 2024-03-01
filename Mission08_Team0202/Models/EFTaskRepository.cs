using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0202.Models
{
    public class EFTaskRepository : ITaskRepository
    {
        private TaskContext _context;

        public EFTaskRepository(TaskContext temp)
        {
            _context = temp;
        }

        public List<Tasks> Tasks => _context.Tasks
                                 .Include(t => t.Category) // Include Categories data
                                 .ToList();

        public List<Categories> Categories => _context.Categories.ToList();
        public void AddTask(Tasks task)
        {
            _context.Add(task);
            _context.SaveChanges();
        }
        public void EditTask(Tasks task)
        {
            _context.Update(task); 
            _context.SaveChanges();
        }

        public void DeleteTask(int taskId)
        {
            var task = _context.Tasks.Find(taskId);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
        }
    }
}
