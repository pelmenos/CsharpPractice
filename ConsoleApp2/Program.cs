int[] arr = new int[100];
int num = 1;
for (int i = 0; i < arr.Length; i++)
{
    while (num % 2 == 0) num++;
    arr[i] = num;
    num++;
}

foreach (int i in arr)
{
    Console.WriteLine(i);
}