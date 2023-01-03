string[] fileContents = System.IO.File.ReadAllLines("input.txt");

Stack<string> directoryStack = new Stack<string>();
Dictionary<string, List<string>> directoryTree = new Dictionary<string, List<string>>();
Dictionary<string, int> directorySizes = new Dictionary<string, int>();

foreach (string line in fileContents)
{
    Console.WriteLine(line);

    string[] termArgs = line.Split();

    // Handle Command
    if (termArgs[0] == "$")
    {
        switch(termArgs[1])
        {
            case "cd":
                Console.WriteLine("Handle cd");
                string targetDir = termArgs[2];
                if (targetDir == "/")
                {
                    directoryStack.Push(targetDir);
                    directoryTree[targetDir] = new List<string>();
                    directorySizes[targetDir] = 0;
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
                    directorySizes[targetDir] = 0;
                }
                break;
            case "ls":
                Console.WriteLine("Handle ls");
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
            directorySizes[curDir] += Int32.Parse(lsOutput[0]);
        }
    }

    Console.WriteLine($"Current dir: {directoryStack.Peek()}");

    Console.WriteLine("---Directory Structure---");
    foreach (var kvp in directoryTree)
    {
        Console.WriteLine($"{kvp.Key}");
        foreach (var dir in kvp.Value)
        {
            Console.WriteLine($"---{dir}");
        }
    }

    Console.WriteLine("---Directory Sizes---");
    foreach (var kvp in directorySizes)
    {
        Console.WriteLine($"{kvp.Key}: {kvp.Value}");
    }

    Console.ReadLine();
}