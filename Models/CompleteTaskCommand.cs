public class CompleteTaskCommand : ICommand
{
    // Reference to the task service to handle marking tasks as completed
    private readonly ITaskService _taskService;

    // Constructor: receives the task service to use
    public CompleteTaskCommand(ITaskService taskService)
    {
        _taskService = taskService;
    }

    // Executes the command to mark a task as completed
    public void Execute()
    {
        // Ask the user to enter the task ID
        Console.Write("Enter task ID to mark as completed: ");
        // Try to parse the input as an integer
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            // Mark the task as completed using the service
            _taskService.MarkTaskAsCompleted(id);
        }
        else
        {
            // Show an error if the input is not a valid number
            Console.WriteLine("Invalid task ID.");
        }
    }
}