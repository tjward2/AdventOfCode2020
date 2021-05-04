using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Problems
{
  public class Day2 : ProblemBase
  {
    List<string> _inputList;

    public Day2()
    {
      _inputList = _inputReader.GetListOfStrings(@"inputs/passwordpolicy.txt");
    }
    public override object SolvePart1()
    {
      int validPasswordCount = 0;
      foreach (string s in _inputList)
      {
        if (isValidPart1(s))
          validPasswordCount++;
      }

      return validPasswordCount;
    }

    public override object SolvePart2()
    {
      int validPasswordCount = 0;
      foreach (string s in _inputList)
      {
        if (isValidPart2(s))
          validPasswordCount++;
      }

      return validPasswordCount;

    }

    private void parseInputLine(string input, out int x, out int y, out char letter, out string password)
    {
      string[] inputParts = input.Split(new char[] { ' ' });  //tokenize input string
      string minMax = inputParts[0];
      letter = inputParts[1][0]; //drop the ':' and just record the first character 
      password = inputParts[2];

      string[] minMaxParts = minMax.Split(new char[] { '-' });  //further tokenize the min/max number part of the input and convert to integers
      x = int.Parse(minMaxParts[0]);
      y = int.Parse(minMaxParts[1]);
    }

    private bool isValidPart1(string input)
    {
      int min, max;
      char letter;
      string password;

      parseInputLine(input, out min, out max, out letter, out password);

      //check the string for the number of occurrences of the character we're looking for
      int numberOfOccurrencesOfChar = password.Count(x => x == letter);

      if ((min <= numberOfOccurrencesOfChar) && (numberOfOccurrencesOfChar <= max))
        return true;

      return false;
        
     }

    private bool isValidPart2(string input)
    {
      int pos1, pos2;
      char letter;
      string password;

      parseInputLine(input, out pos1, out pos2, out letter, out password);

      bool inPos1 = password[pos1 - 1] == letter;  //not indexed at 0 so check at index x - 1
      bool inPos2 = password[pos2 - 1] == letter;

      return ((inPos1 || inPos2) && !(inPos1 && inPos2));  //in position 1 or 2 and not in both

    }
  }
}
