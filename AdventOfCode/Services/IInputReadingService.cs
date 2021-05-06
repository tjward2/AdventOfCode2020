using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Services
{
  public interface IInputReadingService
  {
    string GetAsString(string path);
    List<int> GetListOfInts(string path);
    List<string> GetListOfStrings(string path);
  }
}
