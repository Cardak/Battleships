using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    class cell
    {
        public char value = '~';
        public bool hit;
        public bool containsShip;
        public ship attachedShip;
    }
}
