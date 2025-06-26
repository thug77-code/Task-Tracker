public class UpdateTaskCommand : ICommand
{
    // Reference to the task service to handle updating tasks
    private readonly ITaskService _taskService;

    // Constructor: receives the task service to use
    public UpdateTaskCommand(ITaskService taskService)
    {
        _taskService = taskService;
    }

    // Executes the command to update a task
    public void Execute()
    {
        // Ask the user to enter the task ID to update
        Console.WriteLine("Enter task ID to update:");
        // Try to parse the input as an integer
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            // Ask for the new description and status
            Console.Write("Enter new task description: ");
            string? newDescription = Console.ReadLine();
            Console.Write("Enter new task status: ");
            string? newStatus = Console.ReadLine();
            // Check if both fields are not empty
            if (!string.IsNullOrWhiteSpace(newDescription) && !string.IsNullOrWhiteSpace(newStatus))
            {
                // Update the task using the service
                _taskService.UpdateTask(id, newDescription, newStatus);
            }
            else
            {
                // Show an error if fields are empty
                Console.WriteLine("Error: Task description and status cannot be empty.");
            }
        }
        else
        {
            // Show an error if the input is not a valid number
            Console.WriteLine("Invalid task ID.");
        }
    }
}