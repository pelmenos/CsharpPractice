// See https://aka.ms/new-console-template for more information

Random rnd = new Random();
int[] arr = new int[10];
for (int i = 0; i < 10; i++)
{
    arr[i] = rnd.Next();
}

int min = arr[0];
foreach (int i in arr)
{
    if (min > i) min = i;
}
Console.WriteLine(min);