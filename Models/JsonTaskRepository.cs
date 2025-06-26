using System.Text.Json;
using System.IO;
using System.Linq;
using System.Collections.Generic;

// This class handles saving and loading tasks from a JSON file
public class JsonTaskRepository : IRepository
{
    // Path to the JSON file
    private readonly string _filePath;
    // List to store all tasks in memory
    private List<Task> _tasks;

    // Constructor: initializes the repository and loads tasks from file
    public JsonTaskRepository(string filePath)
    {
        _filePath = filePath;
        _tasks = LoadTasksFromFile();
    }

    // Loads tasks from a JSON file when the repository is initialized
    private List<Task> LoadTasksFromFile()
    {
        if (File.Exists(_filePath) && new FileInfo(_filePath).Length > 0)
        {
            try
            {
                string jsonString = File.ReadAllText(_filePath);
                return JsonSerializer.Deserialize<List<Task>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<Task>();
            }
            catch (JsonException ex)
            {
                // Handle JSON errors and start with an empty list
                Console.WriteLine($"Error reading tasks from JSON file: {ex.Message}. Starting with an empty list.");
                return new List<Task>();
            }
            catch (IOException ex)
            {
                // Handle file access errors and start with an empty list
                Console.WriteLine($"Error accessing JSON file: {ex.Message}. Starting with an empty list.");
                return new List<Task>();
            }
        }
        // If file does not exist, return an empty list
        return new List<Task>();
    }

    // Saves the current list of tasks to the JSON file
    private void SaveTasksToFile()
    {
        string jsonString = JsonSerializer.Serialize(_tasks, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_filePath, jsonString);
    }

    // Returns all tasks
    public List<Task> GetAllTasks()
    {
        return _tasks;
    }

    // Returns a single task by its ID
    public Task GetTaskById(int id)
    {
        return _tasks.FirstOrDefault(t => t.Id == id);
    }

    // Adds a new task and saves to file
    public void AddTask(Task task)
    {
        if (task.Id == 0)
        {
            // Assign a new ID if not set
            task.Id = _tasks.Any() ? _tasks.Max(t => t.Id) + 1 : 1;
        }
        task.CreatedAt = DateTime.Now;
        task.UpdatedAt = DateTime.Now;
        _tasks.Add(task);
        SaveTasksToFile();
    }

    // Updates an existing task and saves to file
    public void UpdatedTask(Task updatedTask)
    {
        var existingTask = _tasks.FirstOrDefault(t => t.Id == updatedTask.Id);
        if (existingTask != null)
        {
            existingTask.Description = updatedTask.Description;
            existingTask.Status = updatedTask.Status;
            existingTask.UpdatedAt = DateTime.Now;
            SaveTasksToFile();
        }
    }

    // Deletes a task by its ID and saves to file
    public void DeleteTask(int id)
    {
        int removedCount = _tasks.RemoveAll(t => t.Id == id);
        if (removedCount > 0)
        {
            SaveTasksToFile();
        }
    }
}
