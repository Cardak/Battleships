using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    class ship
    {
        public int length;
        public int XCoord;
        public int YCoord;
        public int Direction;
        public int hulldamage = 0;
        public bool intersects(ship ship2)
        {
            bool intersects = false;
            List<string> ship1occupied = new List<string>();
            if (this.Direction == 1)
            {
                int startx = this.XCoord;
                int starty = this.YCoord;
                for (int i2 = 0; i2 < this.length; i2++)
                {
                    string coord = (startx + i2).ToString() + "," + starty.ToString();

                    ship1occupied.Add(coord);
                }
            }
            else
            {
                int startx = this.XCoord;
                int starty = this.YCoord;
                for (int i2 = 0; i2 < this.length; i2++)
                {
                    string coord = startx.ToString() + "," + (starty + i2).ToString();

                    ship1occupied.Add(coord);
                }
            }
            List<string> ship2occupied = new List<string>();
            if (this.Direction == 1)
            {
                int startx = ship2.XCoord;
                int starty = ship2.YCoord;
                for (int i2 = 0; i2 < ship2.length; i2++)
                {
                    string coord = (startx + i2).ToString() + "," + starty.ToString();
                    ship2occupied.Add(coord);
                }
            }
            else
            {
                int startx = ship2.XCoord;
                int starty = ship2.YCoord;
                for (int i2 = 0; i2 < ship2.length; i2++)
                {
                    string coord = startx.ToString() + "," + (starty + i2).ToString();
                    ship2occupied.Add(coord);
                }
            }
            for (int i = 0; i < ship1occupied.Count; i++)
            {

                if (ship2occupied.Contains(ship1occupied[i]))
                {
                    intersects = true;
                }
            }
            return intersects;
        }
    }

    partial class Cruiser:ship
    {
        public Cruiser()
        {
            length = 3;
        }
        
    }

    partial class Carrier : ship
    {
        public Carrier()
        {
            length = 5;
        }

    }
    partial class Battleship : ship
    {
        public Battleship()
        {
            length = 4;
        }

    }
    partial class Submarine : ship
    {
        public Submarine()
        {
            length = 3;
        }

    }
    partial class Destroyer : ship
    {
        public Destroyer()
        {
            length = 2;
        }

    }

}
