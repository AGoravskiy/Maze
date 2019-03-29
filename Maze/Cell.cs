using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    public class Cell
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public Entity Entity { get; set; }
        public bool Visited { get; set; }
        

        public Cell(int height, int width, Entity entity, bool visited = false)
        {
            Height = height;
            Width = width;
            Entity = entity;
            Visited = visited;
        }

        public Cell(int height, int width, bool visited = false)
        {
            Height = height;
            Width = width;
            Visited = visited;
        }
    }
}
