using System.Net;
using API;
using Default;


class Visual
{
    
    static bool CorrectChoice(char choice, Dictionary<char,string> options)
    {
        return options.ContainsKey(Char.ToUpper(choice));
    }
    
    static string GetUserInput(string label)
    {
        Console.Write(label + ": ");
        string? answer = Console.ReadLine();
        while (answer == "")
        {
            Console.Write(label + ": ");
            answer = Console.ReadLine();
        }

        return answer;
    }
    
    static string GetCityInput(string label, bool defVal=false)
    {
        Console.Write(label + ": ");
        string? answer = Console.ReadLine();
        if (answer == "" && defVal) return DefaultManager.GetDefaultCity();
        while (answer == "")
        {
            Console.Write(label + ": ");
            answer = Console.ReadLine();
        }

        return answer;
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
    
    static void DoOption(char choice)
    {
        string city;
        switch (choice)
        {
            case 'A':
                city = GetCityInput("Введите название города", true);
                try
                {
                    double temp = ApiManager.GetTemperature(city);
                    Console.WriteLine($"Температура в {city} на сегодняшний день {temp}");
                }
                catch (WebException) {
                    Console.WriteLine("Город указан неправильно");
                }
                break;
            
            case 'D':
                city = GetCityInput("Введите название города");
                DefaultManager.SetDefaultCity(city);
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
            { 'A', "Узнать погоду в городе" },
            { 'D', "Установить город по умолчанию" },
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