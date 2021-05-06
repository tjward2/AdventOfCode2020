using System;
using System.Collections.Generic;

namespace AdventOfCode.Problems
{
  public class Day1 : ProblemBase
  {
    List<int> _expenseReportlines;
    public Day1() : base()
    {
      _expenseReportlines = _inputReadingService.GetListOfInts(@"inputs/expenseReport.txt");
    }
    public override object SolvePart1()
    {

      /*
       * Find the two entries that sum to 2020 and then multiply those two numbers together.
       */
      if (_expenseReportlines != null)
      {
        Tuple<int, int> result = FindTwoRowsWithSum(_expenseReportlines, 2020);   //find 2 rows that sum to 2020
        
        if (result != null)
          return result.Item1 * result.Item2;  
      }

      return null;
      
    }

    public override object SolvePart2()
    {
      /*
       * Find the three entries that sum to 2020 and multiple them together
       */

      if (_expenseReportlines != null)
      {
        Tuple<int, int, int> result = FindThreeRowsWithSum(_expenseReportlines, 2020);  //find 3 rows that sum to 2020

        if (result != null)
          return result.Item1 * result.Item2 * result.Item3;
      }

      return null;

    }

    private Tuple<int, int> FindTwoRowsWithSum(List<int> expenseReport, int sum)
    {
      //while not the most efficient solution, 2 nested for loops effectively traverses the list of expenses and compares each record against each other.  s
      //Since the dataset is so small, the inefficient way of doing this is not a big concern
      for (int i =0; i< expenseReport.Count; i++)
      {
        for (int j= i + 1; j< expenseReport.Count; j++)  //j can always start 1 index ahead of i
        {
          if (expenseReport[i] + expenseReport[j] == sum)
            return new Tuple<int, int>(expenseReport[i], expenseReport[j]);  //stop as soon as 2 entries summing the 2020 are found.  If the puzzle contained multiple solutions this will end after finding the first one
        }
      }

      return null;
    }


    private Tuple<int, int, int> FindThreeRowsWithSum(List<int> expenseReport, int sum)
    {
      //Continuing the approach from question 1, there are now 3 for-loops. There is cetainly a more efficient way of doing this but the data set is small and the for-loop approach is simple and easy to understand 
      for (int i = 0; i < expenseReport.Count; i++)
      {
        for (int j = i + 1; j < expenseReport.Count; j++)  //j can start at i + 1
        {
          for (int k = j + 1; k < expenseReport.Count; k++) //k can start at j + 1 and we'll still hit every combination of number in the array
          {
            if (expenseReport[i] + expenseReport[j] + expenseReport[k] == sum)
              return new Tuple<int, int, int>(expenseReport[i], expenseReport[j], expenseReport[k]);
          }
        }
      }

      return null;
    }

  }
}
