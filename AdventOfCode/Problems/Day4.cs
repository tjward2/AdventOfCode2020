using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Problems
{
 
  public class Day4 : ProblemBase
  {
    List<string> _inputFile;
    string _input;
    public Day4()
    {
      //_inputFile = _inputReader.GetListOfStrings(@"inputs/PassportList.txt");
      _input = _inputReader.GetAsString(@"inputs/PassportList.txt");
    }

    public override object SolvePart1()
    {
      return GetPassportListFromInputString().Count(x => x.IsValid());
      return GetPassportListFromInput().Count(x => x.IsValid());
      
    }

    public override object SolvePart2()
    {
      throw new NotImplementedException();
    }

    private List<Passport> GetPassportListFromInput()
    {
      List<Passport> passportsInFile = new List<Passport>();
      StringBuilder sb = new StringBuilder();
      Passport current = new Passport();

      foreach (string s in _inputFile)
      {
        if (s == String.Empty)
        {
          current.Input = sb.ToString();
          passportsInFile.Add(current);
          current = new Passport();
          sb.Clear();
        }
        else
        {
          sb.AppendLine(s);
        }
      }

      return passportsInFile;
    }

    private List<Passport> GetPassportListFromInputString()
    {
      List<Passport> passportsInFile = new List<Passport>();

      string[] passportTokens = Regex.Split(_input, Environment.NewLine + Environment.NewLine );
      foreach (string passportdata in passportTokens)
      {
        passportsInFile.Add(new Passport() { Input = passportdata });
      }
      
      return passportsInFile;
    }
  }
}
