int start = int.Parse(Console.ReadLine());
int end = int.Parse(Console.ReadLine());
Random rnd = new Random();
int[] arr = new int[end];
for (int i = start; i < end; arr[i++] = rnd.Next());
foreach (int i in arr)
{
    Console.Write(i + " ");
}