using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventofCode5
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputData = File.ReadAllLines(@"C:\Users\olivi\source\repos\AdventofCode2020\AdventofCode5\AdventofCode5\AdventofCode5.txt");
            List<BoardingPass> passes = new List<BoardingPass>();

            foreach (var item in inputData)
            {
                passes.Add(new BoardingPass(item));
            }
            int highestID = 0;

            List<int> seats = new List<int>();

            foreach (var pass in passes)
            {
                if (pass.SeatID > highestID)
                {
                    highestID = pass.SeatID;
                }
                seats.Add(pass.SeatID);
            }
            seats = seats.OrderBy(x => x).ToList();

            int comfyChair = 0;

            for (int i = 1; i < seats.Count(); i++)
            {
                if (seats[i - 1] != seats[i] - 1) comfyChair = seats[i - 1] + 1;
            }
            Console.WriteLine($"Part 1; {highestID} \n Part 2; {comfyChair}");
        }
    }

    public class BoardingPass // part 1
    {
        public int SeatID { get; set; }
        public BoardingPass(string BoardingPassData)
        {
            var BoardingData = BoardingPassData.ToCharArray();

            int rowDivider = 64;
            int row = 0;
            int columnDivider = 4;
            int column = 0;    

            for (int i = 0; i < BoardingData.Length; i++)
            {
                 switch (BoardingData[i])
                 {
                    case 'F':
                        rowDivider /= 2;
                        break;

                    case 'B':
                        row += rowDivider;
                        rowDivider /= 2;
                        break;

                    case 'L':
                        columnDivider /= 2;
                        break;

                    case 'R': // upper half

                        column += columnDivider;
                        columnDivider /= 2;
                        break;
                 }
            }
            SeatID = row * 8 + column;
        }
    }
}

