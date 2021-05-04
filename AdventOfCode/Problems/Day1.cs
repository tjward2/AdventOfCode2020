using System;
using System.Collections.Generic;

namespace AdventOfCode.Problems
{
  public class Day1 : ProblemBase
  {
    List<int> _expenseReportlines;
    public Day1() : base()
    {
      _expenseReportlines = _inputReader.GetListOfInts(@"inputs/expenseReport.txt");
    }
    public override object SolvePart1()
    {
      
      if (_expenseReportlines != null)
      {
        Tuple<int, int> result = FindTwoRowsWithSum(_expenseReportlines, 2020);  
        
        if (result != null)
          return result.Item1 * result.Item2;  
      }

      return null;
      
    }

    public override object SolvePart2()
    {
      if (_expenseReportlines != null)
      {
        Tuple<int, int, int> result = FindThreeRowsWithSum(_expenseReportlines, 2020);

        if (result != null)
          return result.Item1 * result.Item2 * result.Item3;
      }

      return null;

    }

    private Tuple<int, int> FindTwoRowsWithSum(List<int> expenseReport, int sum)
    {
      //while not the most efficient solution in the world, 2 nested for loops effectively tranverses the list of expenses and compares each record against each other.  since the dataset is so small
      //I'm not concerned by the inefficient way of doing this
      for (int i =0; i< expenseReport.Count; i++)
      {
        for (int j= i + 1; j< expenseReport.Count; j++)  //j can always start 1 index ahead of i
        {
          if (expenseReport[i] + expenseReport[j] == sum)
            return new Tuple<int, int>(expenseReport[i], expenseReport[j]);
        }
      }

      return null;
    }


    private Tuple<int, int, int> FindThreeRowsWithSum(List<int> expenseReport, int sum)
    {
      //oh boy...  continuing my approach from question 1 I now have 3 for loops, we're getting into serious inefficient territory here.  
      //It's still a small data set though...  22ms to execute vs 2ms on problem 1. 
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
