using JsonManagerLibrary;
using LogickLibrary;

class Visual
{
    
    static bool CorrectChoice(char choice, Dictionary<char,string> options)
    {
        return options.ContainsKey(Char.ToUpper(choice));
    }

    static string GetUserInput(string label, bool required=true)
    {
        Console.Write(label + ": ");
        string? answer = Console.ReadLine();
        while (required && answer == "")
        {
            Console.Write(label + ": ");
            answer = Console.ReadLine();
        }

        return answer;
    }

    static string GetDateInput(string label)
    {
        string strDate = "";
        DateTime? date = null;
        
        while (date == null)
        {
            try
            {
                strDate = GetUserInput(label);
                date = DateTime.Parse(strDate);
            }
            catch (FormatException)
            {
                Console.WriteLine("Неверный формат даты");
            } 
        }

        return strDate;
    }

    static Dictionary<string, string> GetNewTaskData()
    {
        return new Dictionary<string, string>()
        {
            {"title", GetUserInput("Название")},
            {"description", GetUserInput("Описание")},
            {"deadline", GetDateInput("Дата(YYYY-MM-DD)")}
        };
    }

    static int GetIdForDelete()
    {
        return int.Parse(GetUserInput("Введите id закладки"));
    }

    static (int, Dictionary<string, string>) GetDataForUpdate()
    {
        Dictionary<string, string> data = new Dictionary<string, string>();
        int id = int.Parse(GetUserInput("Введите id закладки"));
        string column = GetUserInput("-title\n-description\n-deadline\nЧто нужно изменить?");
        string value = column != "deadline" ? GetUserInput("Новое значение") : GetDateInput("Новая дата");
        data[column] = value;
        
        column = GetUserInput("Изменить что-то ещё(Enter если нет)");
        while (column != "")
        {
            value = column != "deadline" ? GetUserInput("Новое значение") : GetDateInput("Новая дата");
            data[column] = value;
            column = GetUserInput("Изменить что-то ещё(Enter если нет)");
        }

        return (id, data);
    }

    static char GetOptionChoice(Dictionary<char, string> options)
    {
        Console.Write("Выберите действие: ");
        char choice = Char.Parse(Console.ReadLine());
        while (!CorrectChoice(choice, options))
        {
            Console.WriteLine("Недопустимый вариант");
            Console.Write("Выберите действие: ");
            choice = Char.Parse(Console.ReadLine());
        }

        return Char.ToUpper(choice);

    }

    static void PrintOptions(Dictionary<char, string> options)
    {
        foreach(var item in options)
        {
            Console.WriteLine($"({item.Key}) ({item.Value})");
        }
    }

    static void PrintTaskList(List<TaskModel> tasks)
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("Здесь пусто");
            Console.WriteLine();
            return;
        }
        
        foreach (var task in tasks)
        {
            Console.WriteLine(task.ToString());
            Console.WriteLine();
        }
    }

    static void DoOption(char choice)
    {
        int id;
        string answer;
        Dictionary<string, string> data;
        
        switch (choice)
        {
            case 'A':
                Console.WriteLine(AddTaskCommand.Execute(GetNewTaskData()));
                break;
            
            case 'D':
                Console.WriteLine(DeleteTaskCommand.Execute(GetIdForDelete()));
                break;
            
            case 'U':
                (id, data) = GetDataForUpdate();
                Console.WriteLine(UpdateTaskCommand.Execute(id, data));
                break;
            
            case 'S':
                PrintTaskList(SelectAllTaskCommand.Execute());
                break;
            
            case 'T':
                PrintTaskList(SelectToBeAccomplishedTaskCommand.Execute());
                break;
            
            case 'P':
                PrintTaskList(SelectPastTaskCommand.Execute());
                break;
            
            case 'C':
                PrintTaskList(SelectCertainDayTaskCommand.Execute(GetDateInput("Дата(YYYY-MM-DD)")));
                break;
            
            case 'Q':
                Environment.Exit(0);
                break;
        }
    }

    static void Loop()
    {
        Dictionary<char, string> option = new Dictionary<char, string>()
        {
            { 'A', "Добавить задачу" },
            { 'D', "Удалить задачу" },
            { 'U', "Редактировать задачу" },
            { 'S', "Вывести все задачи" },
            { 'T', "Вывести задачи которые предстоит выполнить" },
            { 'P', "Вывести задачи которые уже прошли" },
            { 'C', "Вывести задачи для определённого числа" },
            { 'Q', "Выйти"}
        };
        
        Console.Clear();
        PrintOptions(option);
        char choice = GetOptionChoice(option);
        Console.Clear();
        DoOption(choice);
        Console.Write("Нажмите Enter для возврата в меню.");
        
        string _ = Console.ReadLine();
    }

    static void Main(string[] args)
    {
        while(true)
        {
            Loop();
        }
    }
}


