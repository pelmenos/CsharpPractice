string path = "../../../numsTask5.txt";
int[] nums = File.ReadAllLines(path)[0].Split(' ').Select(x => int.Parse(x)).ToArray();
int avarage = 0;
int max = nums[0];
int min = nums[0];
int indexMin = 0;
int indexMax = 0;

for (int i = 0; i < nums.Length; i++)
{
    if (nums[i] >= max)
    {
        max = nums[i];
        indexMax = i;
    }
    if (nums[i] <= min)
    {
        min = nums[i];
        indexMin = i;
    }
}

if (indexMin > indexMax)
{
    int a = indexMax;
    indexMax = indexMin;
    indexMin = a;
}

for (int i = indexMin + 1; i < indexMax; avarage += nums[i++]) ;
if (indexMax == indexMin) avarage = max;
else avarage = avarage / (indexMax - indexMin);

Console.WriteLine(avarage);