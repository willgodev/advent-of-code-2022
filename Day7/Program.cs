string[] fileContents = System.IO.File.ReadAllLines("input.txt");

Stack<string> directoryStack = new Stack<string>();
Dictionary<string, List<string>> directoryTree = new Dictionary<string, List<string>>();

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
                directoryStack.Push(targetDir);
                if (targetDir != "/")
                {
                    string curDir = directoryStack.Peek();
                    directoryTree[curDir].Append(targetDir);
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

    }

    Console.ReadLine();
}