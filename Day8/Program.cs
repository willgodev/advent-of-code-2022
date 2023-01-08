string[] fileContents = System.IO.File.ReadAllLines("input.txt");

int visibleTrees = (fileContents[0].Length * 2) + (2 * (fileContents.Length-2));
Console.WriteLine(visibleTrees);

foreach (string line in fileContents)
{
    // Console.WriteLine(line);
    if (line == fileContents[0])
    {
        Console.WriteLine(line.Length);
        Console.WriteLine(fileContents.Length);
    }
}