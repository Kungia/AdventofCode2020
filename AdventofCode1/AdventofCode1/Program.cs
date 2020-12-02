using System;
using System.IO;
using System.Linq;

namespace AdventofCode1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Uppgift: Hitta två tal i listan som tillsammans blir 2020. Multiplicera båda talen och ange summan i AdventOfCode
            var inputData = File.ReadAllLines(@"C:\Users\olivi\source\repos\AdventofCode1\AdventofCode1\adventofcode.txt");
            int[] numArr = Enumerable.Range(0, inputData.Length).Select(i => int.Parse(inputData[i].Trim())).ToArray();

            foreach (var num1 in numArr)
            {
                foreach (var num2 in numArr)
                {
                    foreach (var num3 in numArr)
                    {
                        if (num1 + num2 + num3 == 2020 && 
                            num1 != num2 && num1 != num3 && num2 != num3)
                        {
                            int total = num1 * num2 * num3;
                            Console.WriteLine(total);
                            Console.ReadKey();
                            return;
                           
                        }
                    }
                }
            }
        }
    }
}
