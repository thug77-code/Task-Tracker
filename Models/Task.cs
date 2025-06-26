public class Task
{
    // Unique identifier for the task
    public int Id { get; set; }

    // Description of the task
    public string Description { get; set; }

    // Status of the task (e.g., "Pending", "Completed")
    public string Status { get; set; }

    // Date and time when the task was created
    public DateTime CreatedAt { get; set; }

    // Date and time when the task was last updated
    public DateTime UpdatedAt { get; set; }
}
