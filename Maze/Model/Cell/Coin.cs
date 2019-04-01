using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Model.Cell
{
    class Coin : AnyCell
    {
        public Coin(int x, int y) : base(x, y, 'c') { }

        public override bool TryToStep(Maze maze)
        {
            Hero.GetHero.Money++;
            maze[X, Y] = new Ground(X, Y);
            return true;
        }
    }
}
