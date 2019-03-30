using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    public class Wall : AnyCell
    {
        public Wall(int x, int y) : base(x, y, '#') { }
    }
}
