string path = "../../../numsTask2.txt";
string[] strs = File.ReadAllLines(path).Select(x => x.Trim()).ToArray();

Console.WriteLine(String.Join(' ', strs));
