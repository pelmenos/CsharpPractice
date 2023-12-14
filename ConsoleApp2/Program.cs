string path = "../../../nums.txt";
List<int> nums = new List<int>();
nums.AddRange(File.ReadAllLines(path)[0].Split(' ').Select(x => int.Parse(x)).ToArray());

for (int i = 0; i < nums.Count; i++)
{
    if (nums[i] % 2 == 0) nums.RemoveAt(i);
}

foreach(int i in nums) Console.WriteLine(i);