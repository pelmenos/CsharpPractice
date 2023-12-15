using Newtonsoft.Json;

namespace JsonManagerLibrary;

public class Manager
{
    private readonly  string _filePath;

    public Manager()
    { 
        string fileName = "data.json";
        string fileFolder = Path.GetTempPath();
        this._filePath = fileFolder + fileName;
        FileInfo fileInfo = new FileInfo(_filePath);
        if (!fileInfo.Exists) fileInfo.Create();

    }
    
    private void _saveList(List<TaskModel> tasks)
    {
        string serializer = JsonConvert.SerializeObject(tasks);
        File.WriteAllText(_filePath, serializer);
    }

    public void Add(TaskModel task)
    {
        List<TaskModel>? allTasks = SelectAll();
        int lastId;
        if (allTasks == null)
        {
            lastId = 0;
            allTasks = new List<TaskModel>();
        }
        else lastId = allTasks.Last().Id;
        task.SetId(lastId + 1);
        allTasks.Add(task);
        _saveList(allTasks);
    }

    public void Delete(int id)
    {
        List<TaskModel> allTasks = SelectAll();
        TaskModel? task = allTasks.FirstOrDefault(x => x.Id == id);
        if (task != null)
        {
            allTasks.Remove(task);
            _saveList(allTasks);
        }
    }

    public List<TaskModel>? SelectAll()
    {
        string json = File.ReadAllText(_filePath);
        List<TaskModel> allTasks = new List<TaskModel>();
        try
        {
            allTasks = JsonConvert.DeserializeObject<List<TaskModel>>(json);
        }
        catch (InvalidOperationException e)
        {
            allTasks = new List<TaskModel>();
        }
        return allTasks;


    }
}

public class TaskModel
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public DateTime Deadline { get; private set; }

    public TaskModel(string title, string description, DateTime deadline)
    {
        this.Title = title;
        this.Description = description;
        this.Deadline = deadline;
    }

    public void SetId(int id)
    {
        this.Id = id;
    }
}
