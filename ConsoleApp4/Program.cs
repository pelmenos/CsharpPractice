string path = "../../../numsTask4.txt";
int[] nums = File.ReadAllLines(path)[0].Split(' ').Select(x => int.Parse(x)).ToArray();
int sum = 0;
int max = nums[0];

for (int i = 0; i < nums.Length; i++)
{
    if (nums[i] >= max)
    {
        max = nums[i];
    }
}

for (int i = 0; i < nums.Length; i++)
{
    if (nums[i] == max - 1) sum += nums[i];
}

Console.WriteLine(sum);