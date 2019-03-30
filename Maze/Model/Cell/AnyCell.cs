using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    public class AnyCell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Symbol { get; set; }
        public bool Visited { get; set; }

        public AnyCell(int x, int y, char symbol, bool visited = false)
        {
            X = x;
            Y = y;
            Symbol = symbol;
            Visited = visited;
        }
    }
}
