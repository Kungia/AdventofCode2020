using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventofCode4
{
    public class Passport
    {
        public int? BirthYear { get; set; } //byr
        public int? IssueYear { get; set; } //iyr
        public int? ExpirationYear { get; set; } //eyr
        public string Height { get; set; } //hgt
        public string Haircolor { get; set; } //hcl
        public string EyeColor { get; set; } //ecl
        public string PassportID { get; set; } //pid
        public string CountryID { get; set; } //cid

        public Passport(string passportdata)
        {
            string[] separators = { Environment.NewLine, " ", "/t" };

            var dataArr = passportdata.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in dataArr)
            {
                string datacheck = item.Substring(0, 3);
                switch (datacheck)
                {
                    case "byr":
                        int year = int.Parse(item.Substring(4));
                        if (year <= 2002 && year >=1920) BirthYear = year;
                        else BirthYear = null;
                        break;

                    case "iyr":
                        year = int.Parse(item.Substring(4));
                        if (year <= 2020 && year >= 2010) IssueYear = year;
                        else IssueYear = null;
                        break;

                    case "eyr":
                        year = int.Parse(item.Substring(4));
                        if (year <= 2030 && year >= 2020) ExpirationYear = year;
                        else ExpirationYear = null;
                        break;

                    case "hgt":
                        string height = item.Replace("hgt:", "");
                        var hCm = 0;
                        var hIn = 0;
                        int.TryParse(height.Replace("cm", ""), out hCm);
                        int.TryParse(height.Replace("in", ""), out hIn);

                        if (hCm >= 150 && hCm <= 193) Height = height;
                        if (hIn >= 59 && hIn <= 76) Height = height;
                        break;
                    
                    case "hcl":
                        string substring = item.Substring(4);
                        Match isValid = Regex.Match(substring.Substring(1), "[0-9a-fA-F]+");
                        if (substring[0] == '#' && isValid.Success && substring.Length == 7) Haircolor = substring;
                        break;
                   
                    case "ecl":
                        var colorList = new List<string>() { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
                        if (colorList.Contains(item.Substring(4))) EyeColor = item.Substring(4);
                            

                            break;
                    case "pid":
                        int pid = 0;
                        bool number = int.TryParse(item.Substring(4), out pid);
                        if (item.Substring(4).Length == 9 && number) PassportID = item.Substring(4);
                        else PassportID = null;                     
                            break;
                  
                    case "cid":
                        break;
                   
                    case "":
                        Console.WriteLine("invalid input");
                        break;
                }
            }
        }
    }
}
