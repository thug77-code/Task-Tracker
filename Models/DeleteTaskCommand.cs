public class DeleteTaskCommand : ICommand
{
    // Reference to the task service to handle deleting tasks
    private readonly ITaskService _taskService;

    // Constructor: receives the task service to use
    public DeleteTaskCommand(ITaskService taskService)
    {
        _taskService = taskService;
    }

    // Executes the command to delete a task
    public void Execute()
    {
        // Ask the user to enter the task ID to delete
        Console.Write("Enter task ID to delete: ");
        // Try to parse the input as an integer
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            // Delete the task using the service
            _taskService.DeleteTask(id);
        }
        else
        {
            // Show an error if the input is not a valid number
            Console.WriteLine("Error: Invalid task ID.");
        }
    }
}