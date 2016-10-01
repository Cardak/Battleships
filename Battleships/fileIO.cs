using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Battleships
{
    class fileIO
    {
        StreamReader readsave;
        StreamWriter writesave;
        string path;
        public fileIO(string path)
        {
            this.path = path;
            
            
        }

        public void WriteBoard(board gameboard)
        {
            writesave = new StreamWriter(path);

            using (writesave)
            {
                writesave.WriteLine(genString(gameboard.getShips(),gameboard.hitCells()));
            }
        }

        public board LoadBoard()
        {
            board temp = new board();
            temp.generateCells();
            List<ship> ships = new List<ship>();
            readsave = new StreamReader(path);
            string input = readsave.ReadToEnd();
            string hits = input.Split('/')[1];
            string[] stringships = input.Split('/')[0].Split(',');
            string[] arrayuseable = new string[hits.Length / 2];
            for (int i = 0; i < stringships.Length; i++)
            {
                ship atemp = new ship();
                atemp.length = stringships[i].Length / 2;
                atemp.XCoord = (((byte)(stringships[i][0]) - 65));
                atemp.YCoord = int.Parse(stringships[i][1].ToString());
                if (stringships[i][0] == stringships[i][3])
                {
                    atemp.Direction = 0;
                }
                else
                {
                    atemp.Direction = 1;
                }
                ships.Add(atemp);
            }
            temp.setShips(ships);
            temp.addShips();
            for (int i = 0;i < hits.Length - 1;i = i + 2)
            {
                try
                {
                    arrayuseable[i / 2] = ((byte)hits[i] - 65).ToString() + hits[i + 1].ToString();
                    temp.hitCell((((byte)(hits[i]) - 65)), int.Parse(hits[i + 1].ToString()));
                }
                catch
                {

                }

            }
            return temp;
            


        }

        private string genString(List<ship> ships, string hitcells)
        {
            string[,] shipoccupied = new string[ships.Count, 5];
            for (int i = 0; i < ships.Count; i++)
            {
                if (ships[i].Direction == 1)
                {
                    int startx = ships[i].XCoord;
                    int starty = ships[i].YCoord;
                    for (int i2 = 0; i2 < ships[i].length; i2++)
                    {
                        string coord = ((char)(65 + startx + i2)).ToString()  + starty.ToString();

                        shipoccupied[i, i2] = coord;
                    }
                }
                else
                {
                    int startx = ships[i].XCoord;
                    int starty = ships[i].YCoord;
                    for (int i2 = 0; i2 < ships[i].length; i2++)
                    {
                        string coord = ((char)(65 + startx)).ToString() + (starty + i2).ToString();

                        shipoccupied[i, i2] = coord;
                    }
                }
            }
            string temp = "";
            for(int i = 0;i < shipoccupied.GetLength(0) - 1;i++)
            {
                for(int i2 = 0; i2 < shipoccupied.GetLength(1);i2++)
                {
                    temp = temp + shipoccupied[i, i2];
                }
                temp = temp + ",";
            }
            for (int i2 = 0; i2 < shipoccupied.GetLength(1) - 1; i2++)
            {
                temp = temp + shipoccupied[shipoccupied.GetLength(0) - 1, i2];
            }
            temp = temp + shipoccupied[shipoccupied.GetLength(1) - 1,shipoccupied.GetLength(1) - 1] + "/";
            temp = temp + hitcells;
            return temp;
        }
    }
}
