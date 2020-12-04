using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventofCode3
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputData = File.ReadAllLines(@"C:\Users\olivi\source\repos\AdventofCode3\AdventofCode3\AdventofCode3.txt");
            var mapArray = CreateMap(inputData);
            var toboggan1 = new Peppas_Toboggan() { Xposition = 0, Yposition = 0, TreeCount = 0 };
            var toboggan2 = new Peppas_Toboggan() { Xposition = 0, Yposition = 0, TreeCount = 0 };
            var toboggan3 = new Peppas_Toboggan() { Xposition = 0, Yposition = 0, TreeCount = 0 };
            var toboggan4 = new Peppas_Toboggan() { Xposition = 0, Yposition = 0, TreeCount = 0 };
            var toboggan5 = new Peppas_Toboggan() { Xposition = 0, Yposition = 0, TreeCount = 0 };
            foreach (var line in mapArray)
	        {
                if (IsTreeHugger(toboggan1, mapArray, 1, 1)) toboggan1.TreeCount++;
                if (IsTreeHugger(toboggan2, mapArray, 1, 3)) toboggan2.TreeCount++;
                if (IsTreeHugger(toboggan3, mapArray, 1, 5)) toboggan3.TreeCount++;
                if (IsTreeHugger(toboggan4, mapArray, 1, 7)) toboggan4.TreeCount++;
                if (IsTreeHugger(toboggan5, mapArray, 2, 1)) toboggan5.TreeCount++;
            }

            var part1 = toboggan2.TreeCount;
            var part2 = toboggan1.TreeCount * toboggan2.TreeCount * toboggan3.TreeCount * toboggan4.TreeCount * toboggan5.TreeCount;
            Console.WriteLine(part1);
            Console.WriteLine(part2);
            Console.ReadKey();
        }

        
        static bool IsTreeHugger (Peppas_Toboggan sled, string [][] map, int yMovement, int xMovement)
        {
            sled.Yposition += yMovement;
            sled.Xposition += xMovement;

            if (sled.Xposition >= map[0].Length) sled.Xposition -= (map[0].Length);

            try
            {
                return map[sled.Yposition][sled.Xposition] == "#";
            }
            catch
            {
                return false;
            }
        }

        static string [][] CreateMap(string[] inputData)
        {
            var datalist = new List<string[]>();
            foreach (var item in inputData)
            {
                char[] temp = item.ToCharArray();
                datalist.Add(temp.Select(i => i.ToString()).ToArray());
            }
            return datalist.ToArray();
        }
    }
}
