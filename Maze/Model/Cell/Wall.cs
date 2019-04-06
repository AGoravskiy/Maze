using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    public class Wall : AnyCell
    {
        public const ConsoleColor WallColor = ConsoleColor.DarkGreen;

        public Wall(int x, int y) : base(x, y, '#', WallColor) { }

        public override bool TryToStep(Maze maze)
        {
            return false;
        }
    }
}
