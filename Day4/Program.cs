static void part1()
{
    string[] fileContents = System.IO.File.ReadAllLines("input.txt");

    int numOverlappingPairs = 0;
    foreach (string line in fileContents)
    {
        Console.WriteLine(line);
        string[] assignments = line.Split(",");
        string assignmentOne = assignments[0];
        string assignmentTwo = assignments[1];

        string[] assignmentOneSections = assignmentOne.Split("-");
        int assignmentOne_One = int.Parse(assignmentOneSections[0]);
        int assignmentOne_Two = int.Parse(assignmentOneSections[1]);

        string[] assignmentTwoSections = assignmentTwo.Split("-");
        int assignmentTwo_One = int.Parse(assignmentTwoSections[0]);
        int assignmentTwo_Two = int.Parse(assignmentTwoSections[1]);

        if (assignmentOne_One >= assignmentTwo_One && assignmentOne_Two <= assignmentTwo_Two)
        {
            numOverlappingPairs += 1;
        }
        else if (assignmentTwo_One >= assignmentOne_One && assignmentTwo_Two <= assignmentOne_Two)
        {
            numOverlappingPairs += 1;
        }
    }

    Console.WriteLine(numOverlappingPairs);
}

static void part2()
{
    string[] fileContents = System.IO.File.ReadAllLines("input.txt");

    int numOverlappingPairs = 0;
    foreach (string line in fileContents)
    {
        string[] assignments = line.Split(",");
        string assignmentOne = assignments[0];
        string assignmentTwo = assignments[1];

        string[] assignmentOneSections = assignmentOne.Split("-");
        int assignmentOne_One = int.Parse(assignmentOneSections[0]);
        int assignmentOne_Two = int.Parse(assignmentOneSections[1]);

        string[] assignmentTwoSections = assignmentTwo.Split("-");
        int assignmentTwo_One = int.Parse(assignmentTwoSections[0]);
        int assignmentTwo_Two = int.Parse(assignmentTwoSections[1]);

        if (assignmentOne_One >= assignmentTwo_One && assignmentOne_One <= assignmentTwo_Two)
        {
            numOverlappingPairs += 1;
        }
        else if (assignmentOne_Two >= assignmentTwo_One && assignmentOne_Two <= assignmentTwo_Two)
        {
            numOverlappingPairs += 1;
        }
        else if (assignmentTwo_One >= assignmentOne_One && assignmentTwo_One <= assignmentOne_Two)
        {
            numOverlappingPairs += 1;
        }
    }

    Console.WriteLine(numOverlappingPairs);
}

part2();