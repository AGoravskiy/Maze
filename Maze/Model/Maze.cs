using Maze.Model.Cell;
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
        public List<AnyCell> Cells { get; set; } = new List<AnyCell>();

        public Maze(int width, int height, List<AnyCell> cells)
        {
            Width = width;
            Height = height;
            Cells = cells;
        }

        public Maze(int width, int height)
        {
            Width = width;
            Height = height;

            //for (int y = 0; y < height; y++)
            //{
            //    //Console.WriteLine();
            //    for (int x = 0; x < width; x++)
            //    {
            //        if ((y % 2 != 0 && x % 2 != 0) && 
            //            (y < height - 1 && x < width - 1))
            //        {
            //            var cell = new Ground(x, y);
            //            Cells.Add(cell);
            //            //Console.Write(cell.Symbol);
            //        } 
            //        else
            //        {
            //            var cell = new Wall(x, y);
            //            Cells.Add(cell);
            //            //Console.Write(cell.Symbol);
            //        }      
            //    }
            //}

            for (int x = 0; x < width; x++)
            {
                //Console.WriteLine();
                for (int y = 0; y < height; y++)
                {
                    if ((y % 2 != 0 && x % 2 != 0) &&
                        (y < height - 1 && x < width - 1))
                    {
                        var cell = new Ground(x, y);
                        Cells.Add(cell);
                        //Console.Write(cell.Symbol);
                    }
                    else
                    {
                        var cell = new Wall(x, y);
                        Cells.Add(cell);
                        //Console.Write(cell.Symbol);
                    }
                }
            }
        }
    }

    


}
