string[] fileContents = System.IO.File.ReadAllLines("input.txt");

int numRows = fileContents.Length;
int numCols = fileContents[0].Length;
int visibleTrees = (numCols * 2) + (2 * (numRows-2));
double[,] treeHeights = new double[numRows, numCols];

int row = 0;
foreach (string line in fileContents)
{
    int col = 0;
    foreach (char num in line)
    {
        treeHeights[row, col] = Char.GetNumericValue(num);
        col += 1;
    }
    row += 1;
}

for (int i = 0; i < numRows; i++)
{
    for (int j = 0; j < numCols; j++)
    {
        Console.Write(treeHeights[i, j]);
    }
    Console.WriteLine();
}