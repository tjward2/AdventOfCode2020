using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
  public class InputReader
  {

    public string GetAsString(string path)
    {
      using (TextReader textReader = File.OpenText(path))
      {
        return textReader.ReadToEnd();
      }
    }
    public List<int> GetListOfInts(string path)
    {
      List<string> inputAsString = GetListOfStrings(path);
      return inputAsString.Select(x => int.Parse(x)).ToList();
    }

    public List<string> GetListOfStrings(string path)
    {
      List<string> inputFileContents = new List<string>();
      try
      {
        using (TextReader textReader = File.OpenText(path))
        {
          string lineValue = null;
          while ((lineValue = textReader.ReadLine()) != null)
          {
            inputFileContents.Add(lineValue);
          }
        }

        return inputFileContents;
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
        return null;
      }
    }
  }
}
