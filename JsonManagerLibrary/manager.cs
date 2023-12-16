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
        
        using (FileStream fs = File.Create(_filePath))
        { }

    }
    
    private void _saveList(List<TaskModel> tasks)
    {
        string serializer = JsonConvert.SerializeObject(tasks);
        File.WriteAllText(_filePath, serializer);
    }

    public void Add(TaskModel task)
    {
        List<TaskModel> allTasks = SelectAll();
        int lastId;
        if (allTasks.Count == 0) lastId = 0;
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

    public void Update(int id, Dictionary<string, string> data)
    {
        List<TaskModel> allTasks = SelectAll();
        TaskModel? task = allTasks.FirstOrDefault(x => x.Id == id);
        if (task != null)
        {
            int index = allTasks.IndexOf(task);
            task.SetData(data);
            allTasks[index] = task;
            _saveList(allTasks);
        }

    }

    public List<TaskModel> SelectAll()
    {
        string json = File.ReadAllText(_filePath);
        List<TaskModel> allTasks = JsonConvert.DeserializeObject<List<TaskModel>>(json);
        if (allTasks == null) allTasks = new List<TaskModel>();
        return allTasks;


    }
}

public class TaskModel
{
    public int Id { get; set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public DateTime Deadline { get; private set; }

    public TaskModel(string title, string description, string deadline)
    {
        this.Title = title;
        this.Description = description;
        this.Deadline = DateTime.Parse(deadline);
    }

    public void SetId(int id)
    {
        this.Id = id;
    }
    
    public void SetData(Dictionary<string,string> data)
    {
        if (data.ContainsKey("title")) this.Title = data["title"];
        if (data.ContainsKey("description")) this.Description = data["description"];
        if (data.ContainsKey("deadline")) this.Deadline = DateTime.Parse(data["deadline"]);
    }

    public override string ToString()
    {
        return $"{Id}: {Title}\n{Description}\nДо {Deadline}";
    }
}
