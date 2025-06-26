using System;
using System.Collections.Generic;

// Program entry point
class Program
{
    static void Main(string[] args)
    {
        // The file where tasks will be saved
        string dataFile = "tasks.json";

        // Create a repository to manage task storage in a JSON file
        IRepository repository = new JsonTaskRepository(dataFile);

        // Create the task service to handle task logic
        ITaskService service = new TaskService(repository);

        // Define available commands and link them to menu options
        var commands = new Dictionary<string, ICommand>
        {
            { "1", new AddTaskCommand(service) },      // Add a new task
            { "2", new UpdateTaskCommand(service) },   // Update an existing task
            { "3", new DeleteTaskCommand(service) },   // Delete a task
            { "4", new ListTasksCommand(service) },    // List all tasks
            { "5", new CompleteTaskCommand(service) }, // Mark a task as completed
            { "6", new ExitCommand() }                 // Exit the program
        };

        // Main loop to show the menu and get user input
        while (true)
        {
            // Display the menu options
            Console.WriteLine("\nTask Tracker CLI");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Update Task");
            Console.WriteLine("3. Delete Task");
            Console.WriteLine("4. List Tasks");
            Console.WriteLine("5. Mark Task as Completed");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");
            var input = Console.ReadLine();

            // Execute the selected command if it exists
            if (commands.TryGetValue(input, out var command))
            {
                command.Execute();
                // If the user chose to exit, break the loop
                if (command is ExitCommand) break;
            }
            else
            {
                // If the user entered an invalid option
                Console.WriteLine("Invalid option.");
            }
        }
    }
}
