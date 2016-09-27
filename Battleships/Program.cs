using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{

    class Program
    {
        static void Main(string[] args)
        {
            //Main Functions
            board AigameBoard = new board();
            AigameBoard.generateCells();
            AigameBoard.generateShips();
            AigameBoard.writeBoard();
            while (!AigameBoard.allSunk())
             {
                 Console.WriteLine("Enter a square to shoot");
                 string input = Console.ReadLine();
                if (input == "reveal")
                {
                    int x = 0;
                    while(!AigameBoard.allSunk() && x < 10)
                    {
                        int y = 0;
                        while (y < 10)
                        {
                            AigameBoard.hitCell(x, y);
                            y++;
                        }
                        x++;
                    }
                    AigameBoard.writeBoard();
                }
                else
                {
                    try
                        {
                        int x = int.Parse(input.Split(',')[0]);
                        int y = int.Parse(input.Split(',')[1]);
                        AigameBoard.hitCell(x, y);
                        AigameBoard.writeBoard();
                    }
                    catch
                    {

                    }
                }
             }
            Console.WriteLine("Winner!");
            Console.ReadKey();
        }
    }
}
