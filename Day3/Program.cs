static void part1()
{
    string[] fileContents = System.IO.File.ReadAllLines("input.txt");

    int upperAsciiDiff = 38;
    int lowerAsciiDiff = 96;

    int totalPriorities = 0;
    foreach (string line in fileContents)
    {
        Console.WriteLine(line);
        string compartmentOne = line.Substring(0, line.Length/2);
        string compartmentTwo = line.Substring(line.Length/2);
        Console.WriteLine(compartmentOne);
        Console.WriteLine(compartmentTwo);
        char sharedChar = string.Join("", compartmentOne.Intersect(compartmentTwo))[0];
        Console.WriteLine(sharedChar);

        if (char.IsUpper(sharedChar))
        {
            Console.WriteLine("Is upper");
            totalPriorities += (int) sharedChar - upperAsciiDiff;
        }
        else
        {
            Console.WriteLine("Is lower");
            totalPriorities += (int) sharedChar - lowerAsciiDiff;
        }

        Console.WriteLine(totalPriorities);
    }
}

static void part2()
{
    string[] fileContents = System.IO.File.ReadAllLines("input.txt");

    int upperAsciiDiff = 38;
    int lowerAsciiDiff = 96;

    int totalPriorities = 0;
    int rucksackCounter = 0;
    string commonSubstring = "";
    char badgeId = ' ';
    foreach (string line in fileContents)
    {
        Console.WriteLine(line);
        if (rucksackCounter < 3)
        {
            if (rucksackCounter == 0)
            {
                commonSubstring = line;
            }
            else
            {
                commonSubstring = string.Join("", commonSubstring.Intersect(line));
                Console.WriteLine(commonSubstring);
            }
            rucksackCounter += 1;
        }
        else
        {
            badgeId = (char) commonSubstring[0];
            if (char.IsUpper(badgeId))
            {
                totalPriorities += (int) badgeId - upperAsciiDiff;
            }
            else
            {
                totalPriorities += (int) badgeId - lowerAsciiDiff;
            }
            commonSubstring = line;
            rucksackCounter = 1;
            badgeId = ' ';
            Console.WriteLine(totalPriorities);
        }
    }

    badgeId = (char) commonSubstring[0];
    if (char.IsUpper(badgeId))
    {
        totalPriorities += (int) badgeId - upperAsciiDiff;
    }
    else
    {
        totalPriorities += (int) badgeId - lowerAsciiDiff;
    }

    Console.WriteLine(totalPriorities);
}

part2();