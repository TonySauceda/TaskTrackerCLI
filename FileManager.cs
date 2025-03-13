using System.Text.Json;
using TaskTrackerCLI.Models;

namespace TaskTrackerCLI;

public class FileManager
{
    private readonly FileModel _fileModel;
    private readonly string _filePath;

    public FileManager(string filePath)
    {
        _filePath = filePath;
        _fileModel = Load();
    }

    public TaskModel Add(string description)
    {
        TaskModel task = new()
        {
            Id = GetId(),
            Description = description,
            Status = Constants.TaskStatus.ToDo,
            CreatedAt = DateTime.Now
        };

        _fileModel.Tasks.Add(task);

        Save();

        return task;
    }

    private int GetId() => ++_fileModel.CurrentId;

    private void Save()
    {
        if (!Directory.Exists(Path.GetDirectoryName(_filePath)))
            Directory.CreateDirectory(Path.GetDirectoryName(_filePath));

        string json = JsonSerializer.Serialize(_fileModel);
        File.WriteAllText(_filePath, json);
    }

    private FileModel Load()
    {
        if (File.Exists(_filePath))
        {
            string json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<FileModel>(json);
        }

        return new FileModel();
    }

    public List<TaskModel> Get(string status)
    {
        return [.. _fileModel.Tasks.Where(x => string.IsNullOrWhiteSpace(status) || x.Status == status)];
    }

    public TaskModel Get(int id)
    {
        return _fileModel.Tasks.FirstOrDefault(x => x.Id == id);
    }

    public bool Update(int id, string description)
    {
        TaskModel task = Get(id);

        if (task == null)
            return false;

        task.Description = description;
        task.UpdatedAt = DateTime.Now;

        Save();

        return true;
    }

    public bool Delete(int id)
    {
        TaskModel task = Get(id);

        if (task == null)
            return false;

        _fileModel.Tasks.Remove(task);

        Save();

        return true;
    }

    public bool UpdateStats(int id, string status)
    {
        TaskModel task = Get(id);

        if (task == null)
            return false;

        task.Status = status;
        task.UpdatedAt = DateTime.Now;

        Save();

        return true;
    }
}