static void printGrid(string[,] grid, (int, int) start, (int, int) head, (int, int) tail)
{
    Console.WriteLine();
    for (int i=0; i < grid.GetLength(0); i++)
    {
        for (int j=0; j < grid.GetLength(1); j++)
        {
            if (i == start.Item1 && j == start.Item2)
            {
                Console.Write("s");
            }
            else if (i == head.Item1 && j == head.Item2)
            {
                Console.Write("H");
            }
            else if (i == tail.Item1 && j == tail.Item2)
            {
                Console.Write("T");
            }
            else
            {
                Console.Write(grid[i, j]);
            }
        }
        Console.WriteLine();
    }
}

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

int gridDimension = maxSteps*2 + 1;
Console.WriteLine(gridDimension);
string[,] grid = new string[gridDimension, gridDimension];

for (int i=0; i < gridDimension; i++)
{
    for (int j=0; j < gridDimension; j++)
    {
        grid[i, j] = ".";
    }
}

int halfMaxSteps = gridDimension / 2;
Console.WriteLine(halfMaxSteps);
(int, int) start = (halfMaxSteps, halfMaxSteps);
(int, int) head = (halfMaxSteps, halfMaxSteps);
(int, int) tail = (halfMaxSteps, halfMaxSteps);

printGrid(grid, start, head, tail);