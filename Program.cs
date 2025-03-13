
using TaskTrackerCLI.Models;

namespace TaskTrackerCLI;

internal class Program
{
    private static FileManager _taskManager;
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            return;
        }

        string command = args[0].ToLower();

        _taskManager = new("C:\\TaskTracker\\tasks.json");

        switch (command)
        {
            case "add":
                CreateTask(args);
                break;
            case "list":
                ListTasks(args);
                break;
            case "update":
                UpdateTask(args);
                break;
            case "delete":
                DeleteTask(args);
                break;
            case "mark-in-progress":
                UpdateTaskStatus(args, Constants.TaskStatus.InProgress);
                break;
            case "mark-done":
                UpdateTaskStatus(args, Constants.TaskStatus.Done);
                break;
            case "help":
                PrintCommands();
                break;
            default:
                Console.WriteLine("Comando Invalido");
                break;
        }
    }

    private static void PrintCommands()
    {
        Console.WriteLine("Commands:");
        Console.WriteLine("task-cli add <description>           Add a new task");
        Console.WriteLine("task-cli update <id> <description>   Update a task");
        Console.WriteLine("task-cli delete <id>                 Delete a task");
        Console.WriteLine("task-cli list [status]               List all tasks or tasks by status(todo, in-progress and done)");
        Console.WriteLine("task-cli mark-in-progress <id>       Mark a task as in progress");
        Console.WriteLine("task-cli mark-done <id>              Mark a task as done");
    }

    private static void CreateTask(string[] args)
    {
        if (args.Length == 1)
        {
            Console.WriteLine("Please enter the task description");
            return;
        }

        string description = args[1].Trim();

        if (string.IsNullOrWhiteSpace(description))
        {
            Console.WriteLine("Please enter the task description");
            return;
        }

        TaskModel newTask = _taskManager.Add(description);
        if (newTask != null)
            Console.WriteLine($"Task added successfully (ID: {newTask.Id})");
    }

    private static void ListTasks(string[] args)
    {
        string status = string.Empty;

        if (args.Length > 1)
            status = args[1].ToLower();

        List<TaskModel> tasks = _taskManager.Get(status);

        foreach (var task in tasks)
        {
            Console.WriteLine(task.ToString());
        }
    }

    private static void UpdateTask(string[] args)
    {
        if (args.Length < 3)
        {
            Console.WriteLine("Please enter the task id and description");
            return;
        }


        if (!int.TryParse(args[1], out int id))
        {
            Console.WriteLine("Invalid task id");
            return;
        }

        string description = args[2].Trim();

        if (string.IsNullOrWhiteSpace(description))
        {
            Console.WriteLine("Please enter the task description");
            return;
        }

        TaskModel task = _taskManager.Get(id);
        if (task == null)
        {
            Console.WriteLine("Task not found");
            return;
        }

        if (_taskManager.Update(id, description))
            Console.WriteLine("Task updated successfully");
    }

    private static void DeleteTask(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Please enter the task id");
            return;
        }

        if (!int.TryParse(args[1], out int id))
        {
            Console.WriteLine("Invalid task id");
            return;
        }

        TaskModel task = _taskManager.Get(id);
        if (task == null)
        {
            Console.WriteLine("Task not found");
            return;
        }

        if (_taskManager.Delete(id))
            Console.WriteLine("Task deleted successfully");
    }

    private static void UpdateTaskStatus(string[] args, string status)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Please enter the task id");
            return;
        }

        if (!int.TryParse(args[1], out int id))
        {
            Console.WriteLine("Invalid task id");
            return;
        }

        TaskModel task = _taskManager.Get(id);
        if (task == null)
        {
            Console.WriteLine("Task not found");
            return;
        }

        if (_taskManager.UpdateStats(id, status))
            Console.WriteLine("Task updated successfully");
    }
}
