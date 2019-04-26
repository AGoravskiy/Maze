using MazeCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeCore
{
    public abstract class AnyCell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Symbol { get; set; }
        public string CellMessage { get; set; }
        public Action CallAfterStep;
        public ConsoleColor? CellColor { get; set; }
        public bool Visited { get; set; }

        public AnyCell(int x, int y, char symbol, ConsoleColor? cellColor = null, bool visited = false)
        {
            X = x;
            Y = y;
            Symbol = symbol;
            CellColor = cellColor;
            Visited = visited;
        }

        public abstract bool TryToStep(IMaze maze);
    }
}
