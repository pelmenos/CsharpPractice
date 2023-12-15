using JsonManagerLibrary;
namespace LogickLibrary;

public abstract class Command
{
    public static Manager manager = new Manager();
    public abstract string Execute(string title, string description, DateTime deadline);
}


public class AddTaskCommand : Command
{
    public override string Execute(string title, string description, DateTime deadline)
         {
             manager.Add(new TaskModel(title, description, deadline));
             return "Задача добавлена";
         }
}

public class SelectAllTaskCommand : Command
{
    public override string Execute(string title, string description, DateTime deadline)
    {
        List<TaskModel> asd = manager.SelectAll();
        Console.WriteLine();
        return "Задача добавлена";
    }
}