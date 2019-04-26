using MazeCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeCore.Model.Cell
{
    public class StartCell : AnyCell
    {
        public StartCell(int x = 1, int y = 1) : base(x, y, '>')
        {
            CellMessage = "Start!";
        }

        public override bool TryToStep(IMaze maze)
        {
            return true;
        }
    }
}
