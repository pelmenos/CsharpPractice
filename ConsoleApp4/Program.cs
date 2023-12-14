int a = 4;
int sum = 0;
int num = int.Parse(Console.ReadLine());
while (num >= 0)
{
    if (num % a == 0) sum += num;
    num = int.Parse(Console.ReadLine());
}

Console.WriteLine(sum);