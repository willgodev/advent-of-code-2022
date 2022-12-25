using System.Collections;

string[] fileContents = System.IO.File.ReadAllLines("input.txt");

// ArrayList stackList = new ArrayList();
// ArrayList stackArrayList = new ArrayList();
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

    // Console.WriteLine(line);
    if (char.IsDigit(line[1]))
    {
        finishedTable = true;
        skipLine = true;

        foreach (string stackString in stackArrayList)
        {
            // Console.WriteLine(stackString);
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
            // Console.WriteLine(box);
            if (isFirstPass)
            {
                stackArrayList.Add(box);
            }
            else
            {
                stackArrayList[i / 4] += box;
            }
            // Console.ReadLine();
        }
        isFirstPass = false;
    }
    else
    {
        // foreach (var stack in stackList)
        // {
        //     foreach(var ch in stack)
        //     {
        //         Console.Write(ch);
        //     }
        //     Console.WriteLine();
        // }

        string[] instructions = line.Split();
        int numToMove = Int32.Parse(instructions[1]);
        int locStack = Int32.Parse(instructions[3]);
        int destStack = Int32.Parse(instructions[5]);

        // Console.WriteLine($"How many: {numToMove}");
        // Console.WriteLine($"From where: {locStack}");
        // Console.WriteLine($"To where: {destStack}");

        for (int i=0; i < numToMove; i++)
        {
            char popped = stackList[locStack-1].Pop();
            stackList[destStack-1].Push(popped);
        }

        // foreach (var stack in stackList)
        // {
        //     foreach(var ch in stack)
        //     {
        //         Console.Write(ch);
        //     }
        //     Console.WriteLine();
        // }

        // Console.ReadLine();
    }
    // Console.ReadLine();
}

string topOfEachStack = "";
foreach (var stack in stackList)
{
    topOfEachStack += stack.Peek();
}
Console.WriteLine(topOfEachStack);