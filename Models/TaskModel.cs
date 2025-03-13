namespace TaskTrackerCLI.Models;

public class TaskModel
{
    public int Id { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}, Description: {Description}, Status: {Status}, CreatedAt: {CreatedAt}, UpdatedAt: {UpdatedAt}";
    }
}