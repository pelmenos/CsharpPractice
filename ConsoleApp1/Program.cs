string path = "../../../numsTask1.txt";
string[] strs = File.ReadAllLines(path)[0].Split(' ');
foreach (string str in strs)
{
    if(str.Length % 2 != 0) Console.WriteLine(str);
}