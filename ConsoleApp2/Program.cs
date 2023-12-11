string path = "../../../nums.txt";
int[] nums = File.ReadAllLines(path)[0].Split(' ').Select(x => int.Parse(x)).ToArray();
int[] ansNum = new int[];
foreach (int num in nums)
{
    
}
foreach(int i in nums) Console.WriteLine(i);