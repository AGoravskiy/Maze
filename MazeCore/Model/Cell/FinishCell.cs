using MazeCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeCore.Model.Cell
{
    public class FinishCell : AnyCell
    {
        public const ConsoleColor FinishCellColor = ConsoleColor.DarkMagenta;

        public FinishCell(int x, int y) : base(x, y, '<', FinishCellColor)
        {
            CellMessage = "Finish!";
        }

        public override bool TryToStep(IMaze maze)
        {
            //maze = new Maze(maze.Width + 2, maze.Height + 2);
            //var gen = new MazeGenerator(maze.Width, maze.Height);
            //maze = gen.GetMaze();
            return true;
        }
    }
}
