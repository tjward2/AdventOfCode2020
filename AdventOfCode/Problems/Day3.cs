using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Problems
{
  public class Day3 : ProblemBase
  {
    List<string> _inputFile;
    bool[,] _treeMap;
    public Day3()
    {
      _inputFile = _inputReader.GetListOfStrings(@"inputs/TreeMap.txt");
      _treeMap = convertInputToArray();
    }
    public override object SolvePart1()
    {
      return countTreesWithSlope(1, 3);
    }

    public override object SolvePart2()
    {
      return (countTreesWithSlope(1, 1)
        * countTreesWithSlope(1, 3)
        * countTreesWithSlope(1, 5)
        * countTreesWithSlope(1, 7)
        * countTreesWithSlope(2, 1)
        );
    }

    private int countTreesWithSlope(int down, int right)
    {
      //_treeMap only contains the input file, when we reach the end it has to wrap around to the beginning again
      int i = 0, j = 0; //starting position
      int numberOfRows = _treeMap.GetLength(0);
      int numberOfColumns = _treeMap.GetLength(1);
      int treeCount = 0;

      while (i < numberOfRows - down)  //don't go out of bounds passed the end of the slope, we're looking a few rows ahead
      {
        j = j + right;
        i = i + down; ;
        //check if j is beyond the range of the array and if so, wrap it around to the start
        if (j > numberOfColumns - 1)
          j = j - numberOfColumns;

        if (containsTree(i, j))
          treeCount++;

      }

      return treeCount;
    }

    private bool[,] convertInputToArray()
    {
      //convert the input file into a 2-D boolean array with true representing a space that contains a tree
      int i = 0;
      int rows = _inputFile.Count;
      int cols = _inputFile[0].Length;

      bool[,] treeLocations = new bool[rows,cols]; 

      foreach (string s in _inputFile)
      {
        int j = 0;
        foreach (char c in s)
        {
          if (c == '.')
            treeLocations[i,j] = false;
          else
            treeLocations[i,j] = true;

          j++;
        }
        i++;
      }

      return treeLocations;
    }

    private bool containsTree(int i, int j)
    {
      return _treeMap[i, j];
    }
  }
}
