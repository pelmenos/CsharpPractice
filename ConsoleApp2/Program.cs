string path = "../../../numsTask2.txt";
double[] nums = File.ReadAllLines(path)[0].Split(';').Select(x => double.Parse(x)).ToArray();
int index = 0;
double sum = 0;

while (nums[index] != 0.0 && index != nums.Length - 1)
{
    if (nums[index] > 0) sum += nums[index];
    index++;
}

Console.WriteLine(sum);