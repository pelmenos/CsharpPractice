string path = "../../../numsTask4.txt";
int[] nums = File.ReadAllLines(path)[0].Split(' ').Select(x => int.Parse(x)).ToArray();
int index = 1;
int count = 0;
while (nums[index] != 0 && index != nums.Length - 1)
{
    if (nums[index - 1] == nums[index])
    {
        if (count == 0 || nums[index - 2] != nums[index - 1]) count += 2; //прикол состоит в том, чтобы проверить, числа это новая пара или это уже тройки или более, для этого проверяем элемент до минусового индекса
        else count++;
    }
    index++;
}

Console.WriteLine(count);