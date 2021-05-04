using AdventOfCode.Problems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
  class Program
  {
    static void Main(string[] args)
    {
      Day1 d1 = new Day1();
      var output1 = d1.SolvePart1();
      var output2 = d1.SolvePart2();
      
      Day2 d2 = new Day2();
      var output3 = d2.SolvePart1();
      var output4 = d2.SolvePart2();

      Day3 d3 = new Day3();
      var output5 = d3.SolvePart1();
      var output6 = d3.SolvePart2();

    }
  }
}
