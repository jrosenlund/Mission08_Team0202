namespace Mission08_Team0202.Models
{
    public interface ITaskRepository
    {
        List<Tasks> Tasks { get; }
        List<Categories> Categories { get; }

        public void AddTask(Tasks task);
        public void EditTask(Tasks task);
        public void DeleteTask(int taskId);
    }
}
