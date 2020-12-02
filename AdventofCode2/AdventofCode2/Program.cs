using System;
using System.IO;

namespace AdventofCode2
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputData = File.ReadAllLines(@"C:\Users\olivi\source\repos\AdventofCode2\Adventofcode2.txt");
            int CorrectPasswords = 0;

            foreach (var input in inputData)
            {
                if (isValid(input) == true)
                {
                    CorrectPasswords++;
                }
            }
            Console.WriteLine(CorrectPasswords);
            Console.ReadKey();
        }
        public static bool isValid(string inputData)
        {
            string[] split1 = inputData.Split(' ');
            if (split1.Length != 3) throw new FormatException("Invalid input");

            var numSpan = split1[0].Split('-');
            (var min, var max) = (int.Parse(numSpan[0]), int.Parse(numSpan[1]));

            var forcedLetter = split1[1].Replace(":", "");

            int letters = 0;
            foreach (var letter in split1[2])
            {
                if (letter.ToString() == forcedLetter)
                {
                    letters++;
                }
            }
            return ((split1[2].IndexOf(forcedLetter, min - 1) == min - 1 || split1[2].IndexOf(forcedLetter, max - 1) == max - 1)) &&
                   !((split1[2].IndexOf(forcedLetter, min - 1) == min - 1 && split1[2].IndexOf(forcedLetter, max - 1) == max - 1));
        }
    }
}

