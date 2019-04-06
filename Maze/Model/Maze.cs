using Maze.Model;
using Maze.Model.Cell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    public class Maze
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

        public AnyCell this[int x, int y]
        {
            get
            {
                return Cells.SingleOrDefault(cell => cell.X == x && cell.Y == y);
            }
            set
            {
                var cellToRemove = this[value.X, value.Y];

                if (cellToRemove != null)
                {
                    Cells.Remove(cellToRemove);
                }

                Cells.Add(value);
            }
        }

        public Maze(int width, int height)
        {
            Width = width;
            Height = height;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if ((y % 2 != 0 && x % 2 != 0) &&
                        (y < height - 1 && x < width - 1)) 
                    {
                        var cell = new Ground(x, y);
                        Cells.Add(cell);
                    }
                    else
                    {
                        var cell = new Wall(x, y);
                        Cells.Add(cell);
                    }
                }
            }
        }

        public void TryToStep(Direction direction)
        {
            AnyCell cell = null;
            var hero = Hero.GetHero;

            switch (direction)
            {
                case Direction.Up:
                    cell = this[hero.X - 1, hero.Y];
                    break;
                case Direction.Right:
                    cell = this[hero.X, hero.Y + 1];
                    break;
                case Direction.Down:
                    cell = this[hero.X + 1, hero.Y];
                    break;
                case Direction.Left:
                    cell = this[hero.X, hero.Y - 1];
                    break;
            }

            if (cell?.TryToStep(this) ?? false)
            {
                hero.X = cell.X;
                hero.Y = cell.Y;
            }
        }
    }
}
