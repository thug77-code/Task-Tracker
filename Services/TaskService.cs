public class TaskService : ITaskService
{
    // Reference to the repository that handles data storage
    private readonly IRepository _repository;

    // Constructor: receives a repository to use for data operations
    public TaskService(IRepository repository)
    {
        _repository = repository;
    }

    // Add a new task with the given description and default status "Pending"
    public void AddTask(string description)
    {
        var newTask = new Task
        {
            Description = description,
            Status = "Pending"
        };
        _repository.AddTask(newTask);
        Console.WriteLine($"Task '{description}' added successfully.");
    }

    // Update an existing task's description and status by its ID
    public void UpdateTask(int id, string newDescription, string newStatus)
    {
        var taskToUpdate = _repository.GetTaskById(id);
        if (taskToUpdate != null)
        {
            taskToUpdate.Description = newDescription;
            taskToUpdate.Status = newStatus;

            _repository.UpdatedTask(taskToUpdate);
            Console.WriteLine($"Task {id} updated successfully.");
        }
        else
        {
            Console.WriteLine($"Error: Task {id} not found for update.");
        }
    }

    // Delete a task by its ID
    public void DeleteTask(int id)
    {
        var taskToDelete = _repository.GetTaskById(id);
        if (taskToDelete != null)
        {
            _repository.DeleteTask(id);
            Console.WriteLine($"Task {id} deleted successfully.");
        }
        else
        {
            Console.WriteLine($"Error: Task {id} not found for deletion.");
        }
    }

    // Get a list of all tasks
    public List<Task> GetAllTasks()
    {
        return _repository.GetAllTasks();
    }

    // Get a single task by its ID
    public Task GetTaskById(int id)
    {
        return _repository.GetTaskById(id);
    }

    // Mark a task as completed by its ID
    public void MarkTaskAsCompleted(int id)
    {
        var taskToMark = _repository.GetTaskById(id);
        if (taskToMark != null)
        {
            taskToMark.Status = "Completed";
            _repository.UpdatedTask(taskToMark);
            Console.WriteLine($"Task {id} marked as completed.");
        }
    }
}