// <summary>
// This interface defines the contract for a repository that manages tasks.
// It provides methods to get, add, update, and delete tasks.
// </summary>
public interface IRepository
{
    List<Task> GetAllTasks();
    Task GetTaskById(int id);
    void AddTask(Task task);
    void UpdatedTask(Task task);
    void DeleteTask(int id);
}
