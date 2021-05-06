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
      //the easiest way of looking at this problem is to take the input and convert it to a 2-D boolean array where true means the space contains a tree and false means it doesn't
      _inputFile = _inputReadingService.GetListOfStrings(@"inputs/TreeMap.txt");
      _treeMap = convertInputToArray();
    }
    public override object SolvePart1()
    {
      /*
        Due to the local geology, trees in this area only grow on exact integer coordinates in a grid. You make a map (your puzzle input) of the open squares (.) and trees (#) you can see.
        These aren't the only trees, though; due to something you read about once involving arboreal genetics and biome stability, the same pattern repeats to the right many times:
        You start on the open square (.) in the top-left corner and need to reach the bottom (below the bottom-most row on your map).
        The toboggan can only follow a few specific slopes (you opted for a cheaper model that prefers rational numbers); start by counting all the trees you would encounter for the slope right 3, down 1:
        From your starting position at the top-left, check the position that is right 3 and down 1. Then, check the position that is right 3 and down 1 from there, and so on until you go past the bottom of the map
      */
      return countTreesWithSlope(1, 3);
    }

    public override object SolvePart2()
    {
      /*
       Determine the number of trees you would encounter if, for each of the following slopes, you start at the top-left corner and traverse the map all the way to the bottom:

        Right 1, down 1.
        Right 3, down 1. (This is the slope you already checked.)
        Right 5, down 1.
        Right 7, down 1.
        Right 1, down 2.

      */
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
      //basic algorithm is to check if the current space contains a tree and then move to the next space (down and right)

      int i = 0, j = 0; //starting position
      int numberOfRows = _treeMap.GetLength(0);
      int numberOfColumns = _treeMap.GetLength(1);
      int treeCount = 0;

      while (i < numberOfRows)  
      {
        //check if the current location contains a tree
        if (containsTree(i, j%numberOfColumns))  //the input on the x-axis is 31 characters long and then repeats infinitely.  This means that index 31 = index 0, index 32 = index 1, etc.  Using j = j % 31 will ensure we always stay within the bounds of the array
          treeCount++;

        //move to the next space
        j = j + right;  
        i = i + down;   

      }

      return treeCount;
    }

    private bool[,] convertInputToArray()
    {
      //convert the input file into a 2-D boolean array with 'true' representing a space that contains a tree
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
