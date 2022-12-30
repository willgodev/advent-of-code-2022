using System.Collections;


static void part1()
{
    string[] fileContents = System.IO.File.ReadAllLines("input.txt");

    List<Stack<char>> stackList = new List<Stack<char>>();
    List<string> stackArrayList = new List<string>();
    bool finishedTable = false;
    bool skipLine = false;
    bool isFirstPass = true;
    foreach (string line in fileContents)
    {
        if (skipLine)
        {
            skipLine = false;
            continue;
        }

        if (char.IsDigit(line[1]))
        {
            finishedTable = true;
            skipLine = true;

            foreach (string stackString in stackArrayList)
            {
                string strippedString = stackString.Trim();
                Stack<char> newStack = new Stack<char>();
                for (int i=strippedString.Length-1; i > 0; i-=3)
                {
                    newStack.Push(strippedString[i-1]);
                }
                stackList.Add(newStack);
            }

            continue;
        }

        if (!finishedTable)
        {
            for (int i=0; i < line.Length; i+=4)
            {
                string box = line.Substring(i, 3);
                if (isFirstPass)
                {
                    stackArrayList.Add(box);
                }
                else
                {
                    stackArrayList[i / 4] += box;
                }
            }
            isFirstPass = false;
        }
        else
        {
            string[] instructions = line.Split();
            int numToMove = Int32.Parse(instructions[1]);
            int locStack = Int32.Parse(instructions[3]);
            int destStack = Int32.Parse(instructions[5]);

            for (int i=0; i < numToMove; i++)
            {
                char popped = stackList[locStack-1].Pop();
                stackList[destStack-1].Push(popped);
            }
        }
    }

    string topOfEachStack = "";
    foreach (var stack in stackList)
    {
        topOfEachStack += stack.Peek();
    }
    Console.WriteLine(topOfEachStack);
}

static void part2()
{
    string[] fileContents = System.IO.File.ReadAllLines("input.txt");

    List<string> stackList = new List<string>();
    List<string> stackArrayList = new List<string>();
    bool finishedTable = false;
    bool skipLine = false;
    bool isFirstPass = true;
    foreach (string line in fileContents)
    {
        if (skipLine)
        {
            skipLine = false;
            continue;
        }

        if (char.IsDigit(line[1]))
        {
            finishedTable = true;
            skipLine = true;

            foreach (string stackString in stackArrayList)
            {
                string strippedString = stackString.Trim();
                string newStack = "";
                for (int i=strippedString.Length-1; i > 0; i-=3)
                {
                    newStack += strippedString[i-1];
                }
                stackList.Add(newStack);
            }

            continue;
        }

        if (!finishedTable)
        {
            for (int i=0; i < line.Length; i+=4)
            {
                string box = line.Substring(i, 3);
                if (isFirstPass)
                {
                    stackArrayList.Add(box);
                }
                else
                {
                    stackArrayList[i / 4] += box;
                }
            }
            isFirstPass = false;
        }
        else
        {
            string[] instructions = line.Split();
            int numToMove = Int32.Parse(instructions[1]);
            int locStack = Int32.Parse(instructions[3]);
            int destStack = Int32.Parse(instructions[5]);

            Console.WriteLine($"How many: {numToMove}");
            Console.WriteLine($"From where: {locStack}");
            Console.WriteLine($"To where: {destStack}");

            string sourceString = stackList[locStack-1];
            string destString = stackList[destStack-1];

            Console.WriteLine($"Source string: {sourceString}");
            Console.WriteLine($"Destination string: {destString}");

            string newSource = sourceString.Substring(0, sourceString.Length-numToMove);
            string newDest = destString + sourceString.Substring(sourceString.Length-numToMove);

            stackList[locStack-1] = newSource;
            stackList[destStack-1] = newDest;
            Console.WriteLine("Resulting strings");
            Console.WriteLine($"Source: {stackList[locStack-1]}");
            Console.WriteLine($"Destination: {stackList[destStack-1]}");

            Console.WriteLine("Full Results");
            foreach (var stack in stackList)
            {
                Console.WriteLine(stack);
            }
            Console.WriteLine();
        }
    }

    string topOfEachStack = "";
    foreach (var stack in stackList)
    {
        topOfEachStack += stack[^1];
    }
    Console.WriteLine(topOfEachStack);
}

part2();