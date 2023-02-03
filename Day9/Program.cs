static void printGrid(string[,] grid, (int, int) start, (int, int) head, (int, int) tail, HashSet<(int, int)> spacesVisitedByTail, List<(int, int)>? innerKnotPositions = default)
{
    Console.WriteLine();
    for (int i=0; i < grid.GetLength(0); i++)
    {
        for (int j=0; j < grid.GetLength(1); j++)
        {
            if (i == head.Item1 && j == head.Item2)
            {
                Console.Write("H");
            }
            else if (i == tail.Item1 && j == tail.Item2)
            {
                Console.Write("T");
            }
            else if (spacesVisitedByTail.Contains((i, j)))
            {
                Console.Write("#");
            }
            else if (i == start.Item1 && j == start.Item2)
            {
                Console.Write("s");
            }
            else if (innerKnotPositions != null && innerKnotPositions.Contains((i, j)))
            {
                Console.Write((innerKnotPositions.IndexOf((i, j))+1).ToString());
            }
            else
            {
                Console.Write(grid[i, j]);
            }
        }
        Console.WriteLine();
    }
}

static (int, int) calculateNextMove((int, int) currentPosition, (int, int) targetPosition)
{
    (int, int) targetDirection = (0, 0);

    // targetDirection = calculateTailDirection(currentPosition, targetPosition);
    targetDirection = calculateTailDirection(targetPosition, currentPosition);

    if (targetDirection.Item1 != 0)
    {
        if (currentPosition.Item2 - targetPosition.Item2 == 1)
        {
            targetDirection.Item2 = 1;
        }
        else if (currentPosition.Item2 - targetPosition.Item2 == -1)
        {
            targetDirection.Item2 = -1;
        }
    }
    else if (targetDirection.Item2 != 0)
    {
        if (currentPosition.Item1 - targetPosition.Item1 == 1)
        {
            targetDirection.Item1 = 1;
        }
        else if (currentPosition.Item1 - targetPosition.Item1 == -1)
        {
            targetDirection.Item1 = -1;
        }
    }

    return targetDirection;
}

static (int, int) calculateTailDirection((int, int) head, (int, int) tail)
{
    (int, int) targetDirection = (0, 0);

    // Head and Tail are close enough, so don't move tail
    if (Math.Abs(head.Item1 - tail.Item1) <= 1 && 
        Math.Abs(head.Item2 - tail.Item2) <= 1)
    {
        return targetDirection;
    }

    // Row Check
    if (head.Item1 - tail.Item1 >= 2)
    {
        // Move Tail down
        return (1, 0);
    }
    else if (head.Item1 - tail.Item1 <= -2)
    {
        // Move Tail up
        return (-1, 0);
    }
    // Column Check
    else if (head.Item2 - tail.Item2 >= 2)
    {
        // Move Tail right
        return (0, 1);
    }
    else if (head.Item2 - tail.Item2 <= -2)
    {
        // Move Tail left
        return (0, -1);
    }

    return targetDirection;
}

static void part1()
{
    string[] fileContents = System.IO.File.ReadAllLines("input.txt");
    // string[] fileContents = System.IO.File.ReadAllLines("smol.txt");

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

    HashSet<(int, int)> spacesVisitedByTail = new HashSet<(int, int)>();
    spacesVisitedByTail.Add(start);
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

        (int, int) new_tail;
        (int, int) tail_direction = calculateTailDirection(head, tail);
        if (tail_direction.Item1 != 0)
        {
            int numTailSteps = Math.Abs(head.Item1 - tail.Item1) - 1;
            for (int i=0; i < numTailSteps; i++)
            {
                new_tail.Item1 = tail.Item1 + tail_direction.Item1;
                if (head.Item2 - tail.Item2 == 1)
                {
                    new_tail.Item2 = tail.Item2 + 1;
                }
                else if (head.Item2 - tail.Item2 == -1)
                {
                    new_tail.Item2 = tail.Item2 - 1;
                }
                else
                {
                    new_tail.Item2 = tail.Item2;
                }
                tail = new_tail;
                spacesVisitedByTail.Add(tail);
            }
        }
        else if (tail_direction.Item2 != 0)
        {
            int numTailSteps = Math.Abs(head.Item2 - tail.Item2) - 1;
            for (int i=0; i < numTailSteps; i++)
            {
                new_tail.Item2 = tail.Item2 + tail_direction.Item2;
                if (head.Item1 - tail.Item1 == 1)
                {
                    new_tail.Item1 = tail.Item1 + 1;
                }
                else if (head.Item1 - tail.Item1 == -1)
                {
                    new_tail.Item1 = tail.Item1 - 1;
                }
                else
                {
                    new_tail.Item1 = tail.Item1;
                }
                tail = new_tail;
                spacesVisitedByTail.Add(tail);
            }
        }

        // Console.WriteLine(spacesVisitedByTail.Count);

        // printGrid(grid, start, head, tail, spacesVisitedByTail);

        // foreach (var space in spacesVisitedByTail)
        // {
        //     Console.Write(space);
        //     Console.Write(", ");
        // }
        // Console.WriteLine();
        // Console.WriteLine(spacesVisitedByTail.Count);

        // Console.ReadLine();
    }

    Console.WriteLine(spacesVisitedByTail.Count);
}

static void part2()
{
    string[] fileContents = System.IO.File.ReadAllLines("input.txt");
    // string[] fileContents = System.IO.File.ReadAllLines("smol.txt");

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
        // Console.WriteLine($"Direction: {direction}, Steps: {numSteps}");
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

    List<(int, int)> knotPositions = new List<(int, int)>();
    // knotPositions.Add(start);
    for (int i=0; i < 8; i++)
    {
        (int, int) knot = (halfMaxSteps, halfMaxSteps);
        knotPositions.Add(knot);
    }
    // knotPositions.Add(tail);

    Console.WriteLine($"Number of Knots: {knotPositions.Count}");

    // printGrid(grid, start, head, tail);

    // END OF INITIALIZATION

    HashSet<(int, int)> spacesVisitedByTail = new HashSet<(int, int)>();
    spacesVisitedByTail.Add(start);
    foreach (string line in fileContents)
    {
        // Console.WriteLine(line);
        string[] move = line.Split();
        string direction = move[0];
        int numSteps = int.Parse(move[1]);
        Console.WriteLine($"Direction: {direction}, Steps: {numSteps}");

        // (int, int) new_head;
        // (int, int) head_direction = directionMap[direction];
        // head_direction.Item1 *= numSteps;
        // head_direction.Item2 *= numSteps;
        // new_head.Item1 = head.Item1 + head_direction.Item1;
        // new_head.Item2 = head.Item2 + head_direction.Item2;
        // head = new_head;

        for (int i=0; i < numSteps; i++)
        {
            (int, int) new_head;
            (int, int) head_direction = directionMap[direction];
            new_head.Item1 = head.Item1 + head_direction.Item1;
            new_head.Item2 = head.Item2 + head_direction.Item2;
            head = new_head;

            (int, int) leadingKnot = head;
            for (int j=0; j < knotPositions.Count; j++)
            {
                (int, int) currentKnot = knotPositions[j];
                (int, int) newKnotPosition = calculateNextMove(currentKnot, leadingKnot);
                currentKnot = (currentKnot.Item1 + newKnotPosition.Item1, currentKnot.Item2 + newKnotPosition.Item2);
                knotPositions[j] = currentKnot;
                leadingKnot = knotPositions[j];
            }

            (int, int) new_tail;
            (int, int) tail_direction = calculateNextMove(tail, leadingKnot);
            new_tail.Item1 = tail.Item1 + tail_direction.Item1;
            new_tail.Item2 = tail.Item2 + tail_direction.Item2;
            tail = new_tail;

            printGrid(grid, start, head, tail, spacesVisitedByTail, knotPositions);

            foreach (var space in spacesVisitedByTail)
            {
                Console.Write(space);
                Console.Write(", ");
            }

            Console.WriteLine();
            Console.WriteLine(spacesVisitedByTail.Count);

            Console.ReadLine();
        }

        // (int, int) new_tail;
        // (int, int) tail_direction = calculateTailDirection(head, tail);
        // if (tail_direction.Item1 != 0)
        // {
        //     int numTailSteps = Math.Abs(head.Item1 - tail.Item1) - 1;
        //     for (int i=0; i < numTailSteps; i++)
        //     {
        //         new_tail.Item1 = tail.Item1 + tail_direction.Item1;
        //         if (head.Item2 - tail.Item2 == 1)
        //         {
        //             new_tail.Item2 = tail.Item2 + 1;
        //         }
        //         else if (head.Item2 - tail.Item2 == -1)
        //         {
        //             new_tail.Item2 = tail.Item2 - 1;
        //         }
        //         else
        //         {
        //             new_tail.Item2 = tail.Item2;
        //         }
        //         tail = new_tail;
        //         spacesVisitedByTail.Add(tail);
        //     }
        // }
        // else if (tail_direction.Item2 != 0)
        // {
        //     int numTailSteps = Math.Abs(head.Item2 - tail.Item2) - 1;
        //     for (int i=0; i < numTailSteps; i++)
        //     {
        //         new_tail.Item2 = tail.Item2 + tail_direction.Item2;
        //         if (head.Item1 - tail.Item1 == 1)
        //         {
        //             new_tail.Item1 = tail.Item1 + 1;
        //         }
        //         else if (head.Item1 - tail.Item1 == -1)
        //         {
        //             new_tail.Item1 = tail.Item1 - 1;
        //         }
        //         else
        //         {
        //             new_tail.Item1 = tail.Item1;
        //         }
        //         tail = new_tail;
        //         spacesVisitedByTail.Add(tail);
        //     }
        // }

        // Console.WriteLine(spacesVisitedByTail.Count);

    }

    Console.WriteLine(spacesVisitedByTail.Count);
}

part2();