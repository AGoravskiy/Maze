using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Model.Cell
{
    class FinishCell : AnyCell
    {
        public const ConsoleColor FinishCellColor = ConsoleColor.DarkMagenta;

        public FinishCell(int x, int y) : base(x, y, '<', FinishCellColor)
        {
        }

        public override bool TryToStep(Maze maze)
        {
            maze = new Maze(maze.Width + 2, maze.Height + 2);
            var gen = new MazeGenerator(maze.Width, maze.Height);
            maze = gen.GetMaze();
            return true;
        }
    }
}
