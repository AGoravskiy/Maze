using MazeCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeCore
{
    public class Wall : AnyCell
    {
        public const ConsoleColor WallColor = ConsoleColor.DarkGreen;

        public Wall(int x, int y) : base(x, y, '#', WallColor)
        {
            CellMessage = "You shall not pass! Here is a wall!";
        }

        public override bool TryToStep(IMaze maze)
        {
            return false;
        }
    }
}
