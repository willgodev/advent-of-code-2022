static string getDirectoryString(Stack<string> dirStack)
{
    return String.Join("\\", dirStack.Reverse());
}

string[] fileContents = System.IO.File.ReadAllLines("input.txt");

Stack<string> directoryStack = new Stack<string>();
Dictionary<string, List<string>> directoryTree = new Dictionary<string, List<string>>();
Dictionary<string, int> directorySizes = new Dictionary<string, int>();

int totalDiskSpace = 70000000;
int neededDiskSpace = 30000000;

// TODO - Modify this to handle directories with same name but different path
foreach (string line in fileContents)
{
    string[] termArgs = line.Split();

    // Handle Command
    if (termArgs[0] == "$")
    {
        switch(termArgs[1])
        {
            case "cd":
                string targetDir = termArgs[2];
                if (targetDir == "/")
                {
                    directoryStack.Push(targetDir);
                    directoryTree[targetDir] = new List<string>();
                    string stackString = getDirectoryString(directoryStack);
                    directorySizes[stackString] = 0;
                }
                else if (targetDir == "..")
                {
                    directoryStack.Pop();
                }
                else
                {
                    string curDir = directoryStack.Peek();
                    directoryStack.Push(targetDir);
                    directoryTree[curDir].Add(targetDir);
                    directoryTree[targetDir] = new List<string>();
                    string stackString = getDirectoryString(directoryStack);
                    directorySizes[stackString] = 0;
                }
                break;
            case "ls":
                break;
            default:
                throw new Exception("Parsed unrecognized command");
        }
    }
    // Process Output
    else
    {
        string[] lsOutput = line.Split();
        string curDir = directoryStack.Peek();
        // Handle directory listing
        if (lsOutput[0] == "dir")
        {
            directoryTree[curDir].Add(lsOutput[1]);
        }
        // Handle file listing
        else
        {
            string stackString = getDirectoryString(directoryStack);
            string[] stackPaths = stackString.Split("\\");
            string pathBuilder = "";
            for (int i=0; i < stackPaths.Length; i++)
            {
                if (i == 0)
                {
                    pathBuilder = stackPaths[i];
                }
                else
                {
                    pathBuilder = pathBuilder + "\\" + stackPaths[i];
                }
                directorySizes[pathBuilder] += Int32.Parse(lsOutput[0]);
            }
        }
    }

    // Console.WriteLine($"Current dir: {directoryStack.Peek()}");

    // Console.WriteLine("---Directory Structure---");
    // foreach (var kvp in directoryTree)
    // {
    //     Console.WriteLine($"{kvp.Key}");
    //     foreach (var dir in kvp.Value)
    //     {
    //         Console.WriteLine($"---{dir}");
    //     }
    // }

    // Console.ReadLine();
}

int answer = 0;
foreach (var kvp in directorySizes)
{
    if (kvp.Value <= 100000)
    {
        answer += kvp.Value;
    }
}

Console.WriteLine(answer);

int totalUsedDiskSpace = directorySizes["/"];
int currentUnusedSpace = totalDiskSpace - totalUsedDiskSpace;
int spaceToFree = neededDiskSpace - currentUnusedSpace;

int smallestSize = totalUsedDiskSpace;
foreach (var kvp in directorySizes)
{
    if (kvp.Value >= spaceToFree && kvp.Value < smallestSize)
    {
        smallestSize = kvp.Value;
    }
}
Console.WriteLine(smallestSize);