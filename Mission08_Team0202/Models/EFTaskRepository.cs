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

        public List<Task> Tasks => _context.Tasks.ToList();

        public void AddTask(Task task)
        {
            _context.Add(task);
            _context.SaveChanges();
        }
        public void EditTask(Task task)
        {
            _context.Entry(task).State = EntityState.Modified;
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
