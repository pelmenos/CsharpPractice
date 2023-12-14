string path = "../../../numsTask3.txt";
int[] nums = File.ReadAllLines(path)[0].Split(' ').Select(x => int.Parse(x)).ToArray();
int avarage = 0;
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

for (int i = indexMin; i < nums.Length; avarage += nums[i++]);
avarage = avarage / (nums.Length - 1 - indexMin);

Console.WriteLine(avarage);