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

static (int, int) calculateTailDirection((int, int) head, (int, int) tail)
{
    (int, int) targetDirection = (0, 0);

    if (Math.Abs(head.Item1 - tail.Item1) <= 1 && 
        Math.Abs(head.Item2 - tail.Item2) <= 1)
    {
        return targetDirection;
    }

    return targetDirection;
}

string[] fileContents = System.IO.File.ReadAllLines("input.txt");

Dictionary<string, (int, int)> directionMap = new Dictionary<string, (int, int)>
{
    { "U", (-1, 0) },
    { "D", (1, 0) },
    { "L", (0, -1) },
    { "R", (0, 1) }
};

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

// printGrid(grid, start, head, tail);

foreach (string line in fileContents)
{
    // Console.WriteLine(line);
    string[] move = line.Split();
    string direction = move[0];
    int numSteps = int.Parse(move[1]);
    Console.WriteLine($"Direction: {direction}, Steps: {numSteps}");

    (int, int) new_head;
    (int, int) head_direction = directionMap[direction];
    head_direction.Item1 *= numSteps;
    head_direction.Item2 *= numSteps;
    new_head.Item1 = head.Item1 + head_direction.Item1;
    new_head.Item2 = head.Item2 + head_direction.Item2;
    head = new_head;

    printGrid(grid, start, head, tail);

    // Console.Read();
}