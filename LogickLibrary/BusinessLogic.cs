using JsonManagerLibrary;
namespace LogickLibrary;

public abstract class Command
{
    public static Manager manager = new Manager();
}

public class AddTaskCommand : Command
{
    public static string Execute(Dictionary<string,string> data)
         {
             manager.Add(new TaskModel(data["title"], data["description"], data["deadline"]));
             return "Задача добавлена";
         }
}

public class DeleteTaskCommand : Command
{
    public static string Execute(int id)
    {
        manager.Delete(id);
        return "Задача удалена";
    }
}

public class UpdateTaskCommand : Command
{
    public static string Execute(int id, Dictionary<string,string> data)
    {
        manager.Update(id, data);
        return "Задача обновлена";
    }
}

public class SelectAllTaskCommand : Command
{
    public static List<TaskModel> Execute()
    {
        List<TaskModel> tasks = manager.SelectAll();
        return tasks;
    }
}

public class SelectToBeAccomplishedTaskCommand : Command
{
    public static List<TaskModel> Execute()
    {
        List<TaskModel> tasks = manager.SelectAll();
        tasks = tasks.Where(x => x.Deadline > DateTime.Now).ToList();
        return tasks;
    }
}

public class SelectPastTaskCommand : Command
{
    public static List<TaskModel> Execute()
    {
        List<TaskModel> tasks = manager.SelectAll();
        tasks = tasks.Where(x => x.Deadline < DateTime.Now).ToList();
        return tasks;
    }
}

public class SelectCertainDayTaskCommand : Command
{
    public static List<TaskModel> Execute(string date)
    {
        List<TaskModel> tasks = manager.SelectAll();
        tasks = tasks.Where(x => x.Deadline == DateTime.Parse(date)).ToList();
        return tasks;
    }
}