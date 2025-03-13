namespace TaskTrackerCLI.Models;

public class FileModel
{
    public int CurrentId { get; set; }
    public List<TaskModel> Tasks { get; set; } = [];
}