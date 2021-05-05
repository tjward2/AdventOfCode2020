using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
  public class Passport
  {
    private string _input;
    public string Input {
      get { return _input; }
      set
      {
        _input = value;
        UnpackData();
      }
    }

    public string BirthYear { get; set; }
    public string IssueYear { get; set; }
    public string ExpirationYear { get; set; }
    public string Height { get; set; }
    public string HairColor { get; set; }
    public string EyeColor { get; set; }
    public string PassportId { get; set; }
    public string CountryId { get; set; }

    public bool IsValid()
    {
      return !string.IsNullOrEmpty(BirthYear)
        & !string.IsNullOrEmpty(IssueYear)
        & !string.IsNullOrEmpty(ExpirationYear)
        & !string.IsNullOrEmpty(Height)
        & !string.IsNullOrEmpty(HairColor)
        & !string.IsNullOrEmpty(EyeColor)
        & !string.IsNullOrEmpty(PassportId);
      //Country Id is optional
    }

    private void UnpackData()
    {
      //first split on newline, as the input string for the passport might be over 2 lines.  then split each line by ' ' to get the individual tokens.  Finally, each token is split by a ':' to get the data type and value
      string[] newLineTokens = Input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
      foreach (string newLineToken in newLineTokens)
      {
        string[] tokens = newLineToken.Split(new char[] { ' ' });

        foreach (string token in tokens)
        {

          string[] tokensOfToken = token.Split(new char[] { ':' });  //tokenize the token to extract the data 
          string dataType = tokensOfToken[0];
          string value = tokensOfToken[1];

          if (dataType == "byr")
            this.BirthYear = value;
          else  if (dataType == "iyr")
            this.IssueYear = value;
          else if (dataType == "eyr")
            this.ExpirationYear = value;
          else if (dataType == "hgt")
            this.Height = value;
          else if (dataType == "hcl")
            this.HairColor = value;
          else if (dataType == "ecl")
            this.EyeColor = value;
          else if (dataType == "pid")
            this.PassportId = value;
          else if (dataType == "cid")
            this.CountryId = value;
          else
            throw new Exception("invalid Data Type");
        }
      }
    }
  }
}
