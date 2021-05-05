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
      var slope1 = countTreesWithSlope(1, 1);
      var slope2 = countTreesWithSlope(1, 3);
      var slope3 = countTreesWithSlope(1, 5);
      var slope4 = countTreesWithSlope(1, 7);
      var slope5 = countTreesWithSlope(2, 1);

      var answer = slope1 * slope2 * slope3 * slope4 * slope5;

     
      return answer;

    }

   
    private int countTreesWithSlope(int down, int right)
    {

      int i = 0, j = 0; //starting position
      int numberOfRows = _treeMap.GetLength(0);
      int numberOfColumns = _treeMap.GetLength(1);
      int treeCount = 0;

      while (i < numberOfRows)  
      {
        //check if the current location contains a tree
        if (containsTree(i, j%numberOfColumns))
          treeCount++;

        j = j + right;  //move right
        i = i + down;   //move down

        ////check if j is beyond the range of the array and if so, wrap it around to the start
        //if (j > numberOfColumns - 1)
        //  j = j - numberOfColumns;

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
          if (c == '#')
            treeLocations[i,j] = true;
          else 
            treeLocations[i,j] = false;

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
