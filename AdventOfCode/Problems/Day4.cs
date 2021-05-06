using AdventOfCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Problems
{
 
  public class Day4 : ProblemBase
  {
    string _input;
    public Day4()
    {
      //for this problem it's easiest to treat the entire input as 1 long string
      _input = _inputReadingService.GetAsString(@"inputs/PassportList.txt");
    }

    public override object SolvePart1()
    {
      /*
        The automatic passport scanners are slow because they're having trouble detecting which passports have all required fields. The expected fields are as follows:

        byr (Birth Year)
        iyr (Issue Year)
        eyr (Expiration Year)
        hgt (Height)
        hcl (Hair Color)
        ecl (Eye Color)
        pid (Passport ID)
        cid (Country ID)

        Passport data is validated in batch files (your puzzle input). Each passport is represented as a sequence of key:value pairs separated by spaces or newlines. Passports are separated by blank lines.

        Count the number of valid passports - those that have all required fields. Treat cid as optional.
       */
      return GetPassportListFromInputString().Count(x => x.IsValid());  //count the number of passports where passport.IsValid() == true
      
    }

    public override object SolvePart2()
    {
      throw new NotImplementedException();
    }

    private List<Passport> GetPassportListFromInputString()
    {
      List<Passport> passportsInFile = new List<Passport>();

      string[] passportTokens = Regex.Split(_input, Environment.NewLine + Environment.NewLine ); //tke the input string and break it into tokens based on the RegEx \r\n\r\n to get the input string for each individual passport
      foreach (string passportdata in passportTokens)
      {
        passportsInFile.Add(new Passport() { Input = passportdata });  //create a Passport object and set the input string, which will be unpacked into each individual property when 'Input'  is assigned
      }
      
      return passportsInFile;
    }
  }
}
