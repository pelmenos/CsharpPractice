using System.Collections.Generic;

List<string> strs = new List<string>();
string str = Console.ReadLine();
string min = str;
string max = str;
while (str != "")
{
    if (min.Length > str.Length) min = str;
    if (max.Length < str.Length) max = str;
    strs.Add(str);
    str = Console.ReadLine();
}

Console.WriteLine("Min is " + min);
Console.WriteLine("Max is " + max);