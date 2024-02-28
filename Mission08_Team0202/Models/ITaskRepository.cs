namespace Mission08_Team0202.Models
{
    public interface ITaskRepository
    {
        List<Task> Tasks { get; }

        public void AddTask(Task task);
        public void EditTask(Task task);
        public void DeleteTask(int taskId);
    }
}
