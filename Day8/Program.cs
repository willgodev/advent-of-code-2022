string[] fileContents = System.IO.File.ReadAllLines("input.txt");
// string[] fileContents = System.IO.File.ReadAllLines("smol.txt");

int numRows = fileContents.Length;
Console.WriteLine(numRows);
int numCols = fileContents[0].Length;
Console.WriteLine(numCols);
int visibleTrees = (numCols * 2) + (2 * (numRows-2));
// Console.WriteLine(visibleTrees);
double[,] treeHeights = new double[numRows, numCols];
bool[,] visibleTreesMap = new bool[numRows, numCols];
(int, int)[] steps = new[] {
    (0, 1), // Right
    (0, -1), //Left
    (1, 0), // Down
    (-1, 0) // Up
}; 

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

for (int i=0; i < numRows; i++)
{
    for (int j=0; j < numCols; j++)
    {
        Console.Write(treeHeights[i, j]);
    }
    Console.WriteLine();
}

for (int i=0; i < numRows; i++)
{
    for (int j=0; j < numCols; j++)
    {
        if (i==0 || i==numRows-1)
        {
            visibleTreesMap[i, j] = true;
        }
        else if (j==0 || j==numCols-1)
        {
            visibleTreesMap[i, j] = true;
        }
    }
}

for (int i=1; i < numRows-1; i++)
{
    for (int j=1; j < numCols-1; j++)
    {
        visibleTreesMap[i, j] = isVisible(i, j, numRows, numCols, treeHeights);
        if (visibleTreesMap[i, j])
        {
            visibleTrees++;
        }
    }
}

for (int i=0; i < numRows; i++)
{
    for (int j=0; j < numCols; j++)
    {
        Console.Write(visibleTreesMap[i, j] + ",");
        // Console.Write(isInGrid(i, j, numRows, numCols).ToString() + ",");
    }
    Console.WriteLine();
}

Console.WriteLine(visibleTrees);

// static bool isInGrid(int row, int col)
// {
//     if (row >= 0 && row < numRows && col >= 0 && col <= numCols)
//     {
//         return true;
//     }
//     return false;
// }

static bool isVisible(int row, int col, int numRows, int numCols, double[,] treeHeights)
{
    return isVisibleLeft(row, col, treeHeights) ||
    isVisibleRight(row, col, numCols, treeHeights) ||
    isVisibleTop(row, col, treeHeights)||
    isVisibleBottom(row, col, numRows, treeHeights);
}

static bool isVisibleLeft(int row, int col, double[,] treeHeights)
{
    for (int i=col-1; i >= 0; i--)
    {
        if (treeHeights[row, i] >= treeHeights[row, col])
        {
            return false;
        }
    }
    return true;
}

static bool isVisibleRight(int row, int col, int numCols, double[,] treeHeights)
{
    for (int i=col+1; i < numCols; i++)
    {
        if (treeHeights[row, i] >= treeHeights[row, col])
        {
            return false;
        }
    }
    return true;
}

static bool isVisibleTop(int row, int col, double[,] treeHeights)
{
    for (int i=row-1; i >= 0; i--)
    {
        if (treeHeights[i, col] >= treeHeights[row, col])
        {
            return false;
        }
    }
    return true;
}

static bool isVisibleBottom(int row, int col, int numRows, double[,] treeHeights)
{
    for (int i=row+1; i < numRows; i++)
    {
        if (treeHeights[i, col] >= treeHeights[row, col])
        {
            return false;
        }
    }
    return true;
}