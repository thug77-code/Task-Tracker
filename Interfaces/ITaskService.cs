// <summary>
// This interface defines the contract for a task service that manages tasks.
// It provides methods to add, update, delete, and retrieve tasks.
// </summary>
public interface ITaskService
{
    void AddTask(string description);
    void UpdateTask(int id, string newDescription, string newStatus);
    void DeleteTask(int id);
    void MarkTaskAsCompleted(int id);
    List<Task> GetAllTasks();
    Task GetTaskById(int id);
}
