using System.Globalization;

Dictionary<string, int[]> temperature = new Dictionary<string, int[]>();
Dictionary<string, int> averageTemperature = new Dictionary<string, int>();
string[] months = DateTimeFormatInfo.CurrentInfo.MonthNames.Take(12).ToArray();
Random rnd = new Random();

foreach (string month in months)
{
    int[] avarTemp = new int[30];
    for (int i = 0; i < avarTemp.Length; avarTemp[i++] = rnd.Next(-5, 30));
    temperature[month] = avarTemp;
}

foreach(var item in temperature)
{
    int average = 0;
    for (int i = 0; i < item.Value.Length; average += item.Value[i++]);
    averageTemperature[item.Key] = average / 30;
}

foreach(var item in averageTemperature)
{
    Console.WriteLine($"month: {item.Key};  average temperature: {item.Value}");
}

