int[,] temperature = new int[12,30];
int[] avarage = new int[12];
int rows = temperature.GetUpperBound(0) + 1;    // количество строк
int columns = temperature.Length / rows;
Random rnd = new Random();

for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < columns; j++)
    {
        temperature[i, j] = rnd.Next(-5, 30);
    }
}

for (int i = 0; i < rows; i++)
{
    int avarTemp = 0;
    for (int j = 0; j < columns; j++)
    {
        avarTemp += temperature[i, j];
    }

    avarage[i] = avarTemp / 30;
} 


foreach (int i in avarage)
{
    Console.WriteLine(i);
}
