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
      Console.WriteLine((int)d1.SolvePart1());
      Console.WriteLine((int)d1.SolvePart2());

      Day2 d2 = new Day2();
      Console.WriteLine((int)d2.SolvePart1());
      Console.WriteLine((int)d2.SolvePart2());

      Day3 d3 = new Day3();
      Console.WriteLine((int)d3.SolvePart1());
      Console.WriteLine((int)d3.SolvePart2());

      Day4 d4 = new Day4();
      Console.WriteLine((int)d4.SolvePart1());

      Console.Write("Press any key to exit");
      Console.ReadKey();

    }
  }
}
