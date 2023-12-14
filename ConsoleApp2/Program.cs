using System.Text;

string path = "../../../numsTask2.txt";
double[] nums = File.ReadAllLines(path)[0].Split(';').Select(x => double.Parse(x)).ToArray();

for (int i = 0; i < nums.Length; i++)
{
    for (int j = 0; j < nums.Length - 1; j++)
    {
        if (nums[j] > nums[j + 1])
        {
            double s = nums[j];
            nums[j] = nums[j + 1];
            nums[j + 1] = s;
        }
    }
}

File.WriteAllText(path, String.Join(';', nums));
