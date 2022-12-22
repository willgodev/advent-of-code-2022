using System.Collections.Generic;

// Opponent Moves
// A = Rock
// B = Paper
// C = Scissors

// Your Moves
// X = Rock
// Y = Paper
// Z = Scissors

// Move Points
// Rock = 1
// Paper = 2
// Scissors = 3

// Result Points
// Lose = 0
// Draw = 3
// Win = 6

static void part1()
{
    Dictionary<string, string> opponentMoveMap = new Dictionary<string, string>()
    {
        { "A", "Rock" },
        { "B", "Paper" },
        { "C", "Scissors" }
    };

    Dictionary<string, string> myMoveMap = new Dictionary<string, string>()
    {
        { "X", "Rock" },
        { "Y", "Paper" },
        { "Z", "Scissors" }
    };

    Dictionary<string, int> moveScores = new Dictionary<string, int>()
    {
        { "X", 1 },
        { "Y", 2 },
        { "Z", 3 }
    };

    Dictionary<string, int> resultScores = new Dictionary<string, int>()
    {
        { "Lose", 0 },
        { "Draw", 3 },
        { "Win", 6 }
    };

    string[] fileContents = System.IO.File.ReadAllLines("input.txt");

    int myScore = 0;
    foreach (string line in fileContents)
    {
        string[] moves = line.Split();
        string opponentMove = moves[0];
        string myMove = moves[1];

        if (string.Equals(opponentMoveMap[moves[0]], myMoveMap[moves[1]]))
        {
            myScore += 3;
        }
        else
        {
            switch(opponentMove)
            {
                case "A":
                    if (myMove == "Y")
                        myScore += 6;
                    break;
                case "B":
                    if (myMove == "Z")
                        myScore += 6;
                    break;
                case "C":
                    if (myMove == "X")
                        myScore += 6;
                    break;
                default:
                    break;
            }
        }

        myScore += moveScores[myMove];
        // Console.WriteLine($"Opponent: {opponentMoveMap[opponentMove]}, You: {myMoveMap[myMove]}");
        // Console.WriteLine(myScore);
        // Console.ReadLine();
    }

    Console.WriteLine(myScore);
}

// Game Results
// X = You Need to Lose
// Y = You Need to Draw
// Z = You Need to Win

static void part2()
{
    Dictionary<string, string> opponentMoveMap = new Dictionary<string, string>()
    {
        { "A", "Rock" },
        { "B", "Paper" },
        { "C", "Scissors" }
    };

    Dictionary<string, string> myMoveMap = new Dictionary<string, string>()
    {
        { "X", "Rock" },
        { "Y", "Paper" },
        { "Z", "Scissors" }
    };

    Dictionary<string, string> winningMoveMap = new Dictionary<string, string>()
    {
        { "A", "Y" },
        { "B", "Z" },
        { "C", "X" }
    };

    Dictionary<string, string> losingMoveMap = new Dictionary<string, string>()
    {
        { "A", "Z" },
        { "B", "X" },
        { "C", "Y" }
    };

    Dictionary<string, int> moveScores = new Dictionary<string, int>()
    {
        { "X", 1 },
        { "Y", 2 },
        { "Z", 3 },
        { "A", 1 },
        { "B", 2 },
        { "C", 3 }
    };

    Dictionary<string, int> resultScores = new Dictionary<string, int>()
    {
        { "Lose", 0 },
        { "Draw", 3 },
        { "Win", 6 }
    };

    string[] fileContents = System.IO.File.ReadAllLines("input.txt");

    int myScore = 0;
    foreach (string line in fileContents)
    {
        string[] moves = line.Split();
        string opponentMove = moves[0];
        string result = moves[1];

        switch(result)
        {
            case "Y":
                myScore += 3;
                myScore += moveScores[opponentMove];
                break;
            case "X":
                myScore += moveScores[losingMoveMap[opponentMove]];
                break;
            case "Z":
                myScore += 6;
                myScore += moveScores[winningMoveMap[opponentMove]];
                break;
            default:
                break;
        }

        // Console.WriteLine($"Opponent: {opponentMoveMap[opponentMove]}, Result: {result}");
        // Console.WriteLine(myScore);
        // Console.ReadLine();
    }

    Console.WriteLine(myScore);
}

part2();