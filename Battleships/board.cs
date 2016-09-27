using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    class board
    {
        cell[,] grid = new cell[10, 10];
        List<ship> ships = new List<ship>();

        private void addShips()
        {
            for (int i = 0; i < ships.Count; i++)
            {

                if (ships[i].Direction == 1)
                {
                    int startx = ships[i].XCoord;
                    int starty = ships[i].YCoord;
                    for (int i2 = 0; i2 < ships[i].length; i2++)
                    {
                        grid[startx + i2, starty].containsShip = true;
                        grid[startx + i2, starty].attachedShip = ships[i];
                    }
                }
                else
                {
                    int startx = ships[i].XCoord;
                    int starty = ships[i].YCoord;
                    for (int i2 = 0; i2 < ships[i].length; i2++)
                    {
                        grid[startx, starty + i2].containsShip = true;
                        grid[startx, starty + i2].attachedShip = ships[i];
                    }
                }
            }
        }

        public void generateShips()
        {
            //ships
            ship Carrier = new Carrier();
            ship Battleship = new Battleship();
            ship Cruiser = new Cruiser();
            ship Submarine = new Submarine();
            ship Destroyer = new Destroyer();
            List<ship> temp = new List<ship>();
            temp.Add(Carrier);
            temp.Add(Battleship);
            temp.Add(Cruiser);
            temp.Add(Submarine);
            temp.Add(Destroyer);
            for (int i = 0; i < temp.Count; i++)
            {
                bool valid = false;
                while (!valid)
                {
                    Random rnd = new Random();
                    temp[i].Direction = rnd.Next(0, 2);
                    if (temp[i].Direction == 1)
                    {
                        temp[i].XCoord = rnd.Next(0, grid.GetLength(0) - temp[i].length);
                        temp[i].YCoord = rnd.Next(0, grid.GetLength(0));
                    }
                    else
                    {
                        temp[i].XCoord = rnd.Next(0, grid.Length);
                        temp[i].YCoord = rnd.Next(0, grid.Length - temp[i].length);
                    }
                    valid = true;
                    if (temp[i].XCoord > grid.GetLength(0) - temp[i].length)
                    {
                        valid = false;
                    }
                    if (temp[i].YCoord > grid.GetLength(0) - temp[i].length)
                    {
                        valid = false;
                    }
                    for (int i2 = 0; i2 < ships.Count; i2++)
                    {
                        if (temp[i].intersects(ships[i2]))
                        {
                            valid = false;
                        }
                    }
                }
                ships.Add(temp[i]);
            }
            this.addShips();
        }

        public bool allSunk()
        {
            bool temp = true;
            for (int i = 0; i < ships.Count; i++)
            {
                if (ships[i].hulldamage != ships[i].length)
                {
                    temp = false;
                }
            }
            return temp;

        }

        public void hitCell(int x, int y)
        {
            grid[x, y].hit = true;
            if (grid[x, y].containsShip)
            {
                grid[x, y].value = 'X';
                grid[x, y].attachedShip.hulldamage++;
                if (grid[x, y].attachedShip.hulldamage == grid[x, y].attachedShip.length)
                {
                    Console.WriteLine("Sunk");
                }
                else
                {
                    Console.WriteLine("hit");
                }
            }
            else
            {
                grid[x, y].value = 'X';
                Console.WriteLine("Miss");
            }
        }

        public void generateCells()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int i2 = 0; i2 < 10; i2++)
                {
                    grid[i, i2] = new cell();
                }
            }
        }

        public void writeBoard()
        {
            Console.Write("= ");
            for (int i = 0;i < grid.GetLength(0);i++)
            {
                
                Console.Write(i);
            }
            Console.WriteLine();
            Console.WriteLine(" ===========");
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                Console.Write(i);
                Console.Write("=");
                for (int i2 = 0; i2 < grid.GetLength(1); i2++)
                {
                    if (grid[i2, i].hit)
                    {
                        if (grid[i2, i].containsShip)
                        {
                            ConsoleColor old = Console.ForegroundColor;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(grid[i2, i].value);
                            Console.ForegroundColor = old;
                        }
                        else
                        {
                            ConsoleColor old = Console.ForegroundColor;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(grid[i2, i].value);
                            Console.ForegroundColor = old;
                        }
                    }
                    else
                    {
                        Console.Write(grid[i2, i].value);
                    }
                }
                Console.Write("=");
                Console.WriteLine();
            }
            Console.WriteLine("============");
        }
    }
}
