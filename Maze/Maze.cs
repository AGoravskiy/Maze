using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    class Maze
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        List<Cell> cells = new List<Cell>();

        public Maze(int width, int height, List<Cell> cells)
        {
            Width = width;
            Height = height;
            this.cells = cells;
        }

    }

    


}
