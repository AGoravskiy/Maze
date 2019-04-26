using MazeCore.Model;
using MazeCore.Model.Cell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeCore.Interface
{
    public interface IMaze
    {
        List<AnyCell> Cells { get; set; }

        AnyCell this[int x, int y] { get; set; }

        void TryToStep(Direction direction);
    }
}
