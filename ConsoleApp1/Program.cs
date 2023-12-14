int n = int.Parse(Console.ReadLine());
int mult = 1;
for (int i = 1; i < n; i++)
{
    if (i % 3 == 0) mult *= i;
}

Console.WriteLine(mult);