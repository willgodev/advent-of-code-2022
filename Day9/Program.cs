string[] fileContents = System.IO.File.ReadAllLines("input.txt");

int maxSteps = 0;
foreach (string line in fileContents)
{
    // Console.WriteLine(line);
    string[] move = line.Split();
    string direction = move[0];
    int numSteps = int.Parse(move[1]);
    Console.WriteLine($"Direction: {direction}, Steps: {numSteps}");
    maxSteps = Math.Max(maxSteps, numSteps);
}

Console.WriteLine($"Max Steps: {maxSteps}");

string[,] grid = new string[maxSteps+1, maxSteps+1];

for (int i=0; i < maxSteps+1; i++)
{
    for (int j=0; j < maxSteps+1; j++)
    {
        grid[i, j] = ".";
    }
}

for (int i=0; i < maxSteps+1; i++)
{
    for (int j=0; j < maxSteps+1; j++)
    {
        Console.Write(grid[i, j]);
    }
    Console.WriteLine();
}
