string path = "../../../input.txt";
string outputPath = "../../../output.txt";
string[] arr = File.ReadAllLines(path);


int[] winNum = arr[0].Split(' ').Select(x => int.Parse(x)).ToArray();
int countTicket = int.Parse(arr[1]);
int[][] tickets = new int[countTicket][];
int index = 0;
for (int i = 2; i < arr.Length; i++)
{
    tickets[index] = arr[i].Split(' ').Select(x => int.Parse(x)).ToArray();
    index++;
}

File.WriteAllText(outputPath, "");
foreach (int[] ticket in tickets)
{
    var result = winNum.Intersect(ticket);
    if (result.Count() >= 3)
    {
        File.AppendAllText(outputPath, "Lucky \n");
    }
    else
    {
        File.AppendAllText(outputPath, "UnLucky \n");
    }
}



