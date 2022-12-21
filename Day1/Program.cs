using System.Collections.Generic;

string[] fileContents = System.IO.File.ReadAllLines("input.txt");

int elfCalories = 0;
PriorityQueue<int, int> elfQueue = new PriorityQueue<int, int>();
foreach (string line in fileContents)
{
    if (!string.IsNullOrWhiteSpace(line))
    {
        elfCalories += Int32.Parse(line);
    }
    else
    {
        elfQueue.Enqueue(elfCalories, elfCalories * -1);
        elfCalories = 0;
    }
}
elfQueue.Enqueue(elfCalories, elfCalories * -1);

Console.WriteLine(elfQueue.Peek());

int top3CaloriesSum = 0;
for (int i=0; i < 3; i++)
{
    top3CaloriesSum += elfQueue.Dequeue();
}

Console.WriteLine(top3CaloriesSum);