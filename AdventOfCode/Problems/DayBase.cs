using AdventOfCode.Services;
using System;

namespace AdventOfCode.Problems
{
  public abstract class DayBase
  {
    protected IInputReadingService _inputReadingService;
    public DayBase()
    {
      _inputReadingService = new InputReadingService();  //would normally use dependency injection for this sort of thing but it seems overkill for a small simple app designed to solve specifc independant problems
    }
    public abstract Object SolvePart1();  //returning an object to keep this super generic. 
    public abstract Object SolvePart2();
  }
}
