using System.Collections;

string[] fileContents = System.IO.File.ReadAllLines("input.txt");

ArrayList stackList = new ArrayList();
ArrayList stackArrayList = new ArrayList();
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

    Console.WriteLine(line);
    if (char.IsDigit(line[1]))
    {
        finishedTable = true;
        skipLine = true;
        continue;
    }
    if (!finishedTable)
    {
        for (int i=0; i < line.Length; i+=4)
        {
            string box = line.Substring(i, 3);
            Console.WriteLine(box);
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
    // Console.ReadLine();
}