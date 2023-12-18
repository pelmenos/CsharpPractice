using System.Text;

namespace Default;

public class DefaultManager
{
    private static string filePath = Path.GetTempPath() + "whetherCity.txt";
    public static async void SetDefaultCity(string city)
    {
        using (FileStream fs = File.Create(filePath))
        {
            byte[] buffer = Encoding.Default.GetBytes(city);
            await fs.WriteAsync(buffer, 0, buffer.Length);
            Console.WriteLine("Город установлен");
        }
    }
    
    public static string GetDefaultCity()
    {
        using (FileStream fstream = File.OpenRead(filePath))
        {
            byte[] buffer = new byte[fstream.Length];
            fstream.Read(buffer, 0, buffer.Length);
            string textFromFile = Encoding.Default.GetString(buffer);
            return textFromFile;
        }
    }
}