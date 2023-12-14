double[] arr = new double[3] {4.2, 1.7, -8.9};
double[] plus = arr.Where(x => x > 0).ToArray();
double[] minus = arr.Where(x => x < 0).ToArray();;

foreach (double i in plus) Console.WriteLine(i);
Console.WriteLine();
foreach (double i in minus) Console.WriteLine(i);