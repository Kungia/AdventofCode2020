using System.Collections.Generic;
using System;
using System.IO;

namespace AdventofCode4
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = File.ReadAllText(@"C:\Users\olivi\source\repos\AdventofCode2020\AdventofCode4\AdventofCode4\Adventofcode4.txt");
            var passportArray = data.Split(Environment.NewLine + Environment.NewLine);
            List<Passport> passportlist = new List<Passport>();
            foreach (var item in passportArray)
            {
                passportlist.Add(new Passport(item));
            }
            int validpassports = 0;
            foreach (var passport in passportlist)
            {
                if (passport.BirthYear != null &&
                    passport.IssueYear != null &&
                    passport.ExpirationYear != null &&
                    passport.Height != null &&
                    passport.Haircolor != null &&
                    passport.EyeColor != null &&
                    passport.PassportID != null
                    ) validpassports++;
            }
            System.Console.WriteLine(validpassports);
            Console.ReadKey();
        }

    }
}

