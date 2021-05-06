using AdventOfCode.Services;
using System;

namespace AdventOfCode.Problems
{
  public abstract class ProblemBase
  {
    protected InputReadingService _inputReadingService;
    public ProblemBase()
    {
      _inputReadingService = new InputReadingService();  //would normally use dependency injection for this sort of thing but it seems overkill for a small simple app designed to solve specifc independant problems
    }
    public abstract Object SolvePart1();
    public abstract Object SolvePart2();
  }
}
