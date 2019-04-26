using MazeCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeCore.Model.Cell
{
    public class Coin : AnyCell
    {
        public const ConsoleColor CoinColor = ConsoleColor.Yellow;

        public Coin(int x, int y) : base(x, y, 'c', CoinColor)
        {
            CellMessage = "Opa, coin!";
        }

        public override bool TryToStep(IMaze maze)
        {
            Hero.GetHero.Money++;
            maze[X, Y] = new Ground(X, Y);
            return true;
        }
    }
}
