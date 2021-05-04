using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Problems
{
  public abstract class ProblemBase
  {
    protected InputReader _inputReader;
    public ProblemBase()
    {
      _inputReader = new InputReader();  //would normally use dependency injection for this sort of thing but it seems overkill for a small simple app designed to solve specifc independant problems
    }
    public abstract Object SolvePart1();
    public abstract Object SolvePart2();
  }
}
