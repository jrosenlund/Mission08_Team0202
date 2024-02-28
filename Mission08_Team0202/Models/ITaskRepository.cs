namespace Mission08_Team0202.Models
{
    public interface ITaskRepository
    {
        List<Task> Tasks { get; }

        public void AddTask(Task task);
        void EditTask(Task task);
        void DeleteTask(int taskId);
    }
}
