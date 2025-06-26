public class AddTaskCommand : ICommand
{
    // Reference to the task service to handle adding tasks
    private readonly ITaskService _taskService;

    // Constructor: receives the task service to use
    public AddTaskCommand(ITaskService taskService)
    {
        _taskService = taskService;
    }

    // Executes the command to add a new task
    public void Execute()
    {
        // Ask the user to enter a task description
        Console.Write("Enter task description: ");
        string? description = Console.ReadLine();

        // Check if the description is not empty or whitespace
        if (!string.IsNullOrWhiteSpace(description))
        {
            // Add the task using the service
            _taskService.AddTask(description);
        }
        else
        {
            // Show an error if the description is empty
            Console.WriteLine("Error: Task description cannot be empty.");
        }
    }
}