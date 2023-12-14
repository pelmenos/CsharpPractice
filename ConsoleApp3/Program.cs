string path = "../../../numsTask3.txt";
int[] nums = File.ReadAllLines(path)[0].Split(',').Select(x => int.Parse(x)).ToArray();
int index = 1;
int min = nums[0];
int max = nums[0];

while (nums[index] != 0 && index != nums.Length - 1)
{
    if (nums[index] > max) max = nums[index];
    if (nums[index] < min) min = nums[index];
    index++;
}

Console.WriteLine(max - min);