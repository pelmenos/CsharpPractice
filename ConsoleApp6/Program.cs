int x1 = 0;
int y1 = 2;
int x2 = -2;
int y2 = -3;
int x3 = 2;
int y3 = -3;
double x0 = double.Parse(Console.ReadLine());
double y0 = double.Parse(Console.ReadLine());

double z = (x1 - x0) * (y2 - y1) - (x2 - x1) * (y1 - y0);
double x = (x2 - x0) * (y3 - y2) - (x3 - x2) * (y2 - y0);
double c = (x3 - x0) * (y1 - y3) - (x1 - x3) * (y3 - y0);

if ((z >= 0 && x >= 0 && c >= 0) || (z <= 0 && x <= 0 && c <= 0)) Console.WriteLine("Принадлежит треугольнику");
else Console.WriteLine("Не принадлежит треугольнику");