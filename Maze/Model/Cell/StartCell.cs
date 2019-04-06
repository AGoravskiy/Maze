using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Model.Cell
{
    class StartCell : AnyCell
    {
        public StartCell(int x = 1, int y = 1) : base(x, y, '>') { }

        public override bool TryToStep(Maze maze)
        {
            return true;
        }
    }
}
