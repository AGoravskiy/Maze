using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Model.Cell
{
    class Ground : AnyCell
    {
        public Ground(int x, int y) : base(x, y, '.') { }

        public override bool TryToStep(Maze maze)
        {
            return true;
        }
    }
}
