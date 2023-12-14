int n = 5;
int m = 6;
int[,] a = new int[n,m + 1];

Random rnd = new Random();

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        a[i, j] = rnd.Next(0, 2);
    }
}

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        Console.Write($"{a[i, j]} \t");
    }
    Console.WriteLine();
}

Console.WriteLine("------------------------------------");

for (int i = 0; i < n; i++)
{
    int sum = 0;
    for (int j = 0; j < m; j++)
    {
        sum += a[i, j];
    }

    if (sum % 2 == 0) a[i, m] = 0;
    else a[i, m] = 1;
}

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m + 1; j++)
    {
        Console.Write($"{a[i, j]} \t");
    }
    Console.WriteLine();
}