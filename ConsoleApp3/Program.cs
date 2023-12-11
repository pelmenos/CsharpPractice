int n = int.Parse(Console.ReadLine());
int[,] matrix = new int[n, n];
for (int i = 0; i < n; i++)
{
    matrix[0, i] = 1;
    matrix[i, 0] = 1;
}


int rows = matrix.GetUpperBound(0) + 1;    // количество строк
int columns = matrix.Length / rows; 
for (int i = 1; i < rows; i++)
{
    for (int j = 1; j < columns; j++)
    {
        matrix[i, j] = matrix[i - 1, j] + matrix[i, j - 1];
    }
}

 
for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < columns; j++)
    {
        Console.Write($"{matrix[i, j]} \t");
    }
    Console.WriteLine();
}