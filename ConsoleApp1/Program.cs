int[] nums = new int[100];
int num = 1000;
for (int i = 0; i < nums.Length; i++)
{
    nums[i] = num;
    num -= 3;
}

foreach (int i in nums)
{
    Console.WriteLine(i);
}