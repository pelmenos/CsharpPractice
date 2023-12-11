// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;

List<int> nums = new List<int>();
int mult = 1;
int sum = 0;
int num = int.Parse(Console.ReadLine());
while (num != 0)
{
    nums.Add(num);
    num = int.Parse(Console.ReadLine());
}

for (int i = 0; i < nums.Count; sum += nums[i++]);
for (int i = 0; i < nums.Count; mult *= nums[i++]);

Console.WriteLine(sum);
Console.WriteLine(mult);