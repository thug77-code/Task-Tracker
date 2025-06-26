public class ListTasksCommand : ICommand
{
    // Reference to the task service to get all tasks
    private readonly ITaskService _taskService;

    // Constructor: receives the task service to use
    public ListTasksCommand(ITaskService taskService)
    {
        _taskService = taskService;
    }

    // Executes the command to list all tasks
    public void Execute()
    {
        // Get all tasks from the service
        var tasks = _taskService.GetAllTasks();
        // Check if there are no tasks
        if (tasks == null || !tasks.Any())
        {
            Console.WriteLine("No tasks found.");
            return;
        }

        // Print all tasks in a formatted way
        Console.WriteLine("Tasks:");
        Console.WriteLine("--------------------------------------------------");
        foreach (var task in tasks)
        {
            Console.WriteLine($"ID: {task.Id}, Description: {task.Description}, Status: {task.Status}");
        }
        Console.WriteLine("--------------------------------------------------");
    }
}