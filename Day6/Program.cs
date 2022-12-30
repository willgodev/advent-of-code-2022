static void part1()
{
    string[] fileContents = System.IO.File.ReadAllLines("input.txt");
    string buffer = fileContents[0];
    Console.WriteLine(buffer);

    int start = 0;
    int charCount = 0;
    Dictionary<char, int> seenChars = new Dictionary<char, int>();

    while (start < buffer.Length)
    {
        if (seenChars.Keys.Count == 0)
        {
            seenChars[buffer[start]] = start;
            start += 1;
            charCount += 1;
        }
        else
        {
            if (!seenChars.ContainsKey(buffer[start]))
            {
                seenChars[buffer[start]] = start;
                start += 1;
                charCount += 1;
                if (charCount == 4)
                {
                    Console.WriteLine($"Marker found after {start} characters");
                    Console.WriteLine(buffer.Substring(start-4, 4));
                    break;
                }
            }
            else
            {
                start = seenChars[buffer[start]] + 1;
                seenChars = new Dictionary<char, int>();
                charCount = 0;
            }
        }
    }
}

static void part2()
{
    string[] fileContents = System.IO.File.ReadAllLines("input.txt");
    string buffer = fileContents[0];
    Console.WriteLine(buffer);

    int start = 0;
    int charCount = 0;
    Dictionary<char, int> seenChars = new Dictionary<char, int>();

    while (start < buffer.Length)
    {
        if (seenChars.Keys.Count == 0)
        {
            seenChars[buffer[start]] = start;
            start += 1;
            charCount += 1;
        }
        else
        {
            if (!seenChars.ContainsKey(buffer[start]))
            {
                seenChars[buffer[start]] = start;
                start += 1;
                charCount += 1;
                if (charCount == 14)
                {
                    Console.WriteLine($"Marker found after {start} characters");
                    Console.WriteLine(buffer.Substring(start-14, 14));
                    break;
                }
            }
            else
            {
                start = seenChars[buffer[start]] + 1;
                seenChars = new Dictionary<char, int>();
                charCount = 0;
            }
        }
    }
}

part2();