using System;
using System.IO;
using System.Linq;

namespace AdventofCode6
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputData = File.ReadAllText(@"C:\Users\olivi\source\repos\AdventofCode2020\AdventofCode6\AdventofCode6\AdventofCode6.txt").Split(Environment.NewLine + Environment.NewLine); ;
            var AnswersArray = inputData.Select(i => i.Split(Environment.NewLine));

            var puzzleOne = AnswersArray
                .Select(group => group
                    .SelectMany(answers => answers)
                    .Distinct()
                    .Count())
                .Sum();

            var puzzleTwo = AnswersArray
                .Select(group => group
                    .SelectMany(answers => answers)
                    .Distinct()
                    .Where(letter => group
                        .All(person => person
                        .Contains(letter)))
                    .Count())
                .Sum();

            Console.WriteLine($"Part 1; {puzzleOne} \nPart 2; {puzzleTwo} ");
        }
    }
}
