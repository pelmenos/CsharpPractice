int x1 = -1;
int x2 = 3;
int y1 = -2;
int y2 = 4;
double a = double.Parse(Console.ReadLine());
double b = double.Parse(Console.ReadLine());
if (y1 <= a && a <= y2 && x1 <= a && a <= x2 && y1 <= b && b <= y2 && x1 <= b && b <= x2)
{
    Console.WriteLine("Принадлежит");
} else Console.WriteLine("Не принадлежит");
