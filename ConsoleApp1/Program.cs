string path = "../../../numsTask1.txt";
int[] nums = File.ReadAllLines(path)[0].Split(' ').Select(x => int.Parse(x)).ToArray();
int mult = 1;
int min = nums[0];
int indexMin = 0;

for (int i = 0; i < nums.Length; i++)
{
    if (nums[i] <= min)
    {
        min = nums[i];
        indexMin = i;
    }
}
for (int i = indexMin; i < nums.Length; mult *= nums[i++]);

Console.WriteLine(mult);