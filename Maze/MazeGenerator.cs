using Maze.Model.Cell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{

    public class MazeGenerator
    {
        private Maze maze;
        private int Width { get; set; } 
        private int Height { get; set; }
        private AnyCell startCell;
        private AnyCell currentCell;
        private AnyCell neighbourCell;
        private Stack<AnyCell> stackCells = new Stack<AnyCell>();
        private static Random random = new Random();

        public MazeGenerator() : this(11, 21)
        {
        }

        public MazeGenerator(int width, int height)
        {
            Width = width;
            Height = height;
        }

        internal Maze GetMaze()
        {
            
            maze = new Maze(Width, Height);
            startCell = maze.Cells.SingleOrDefault(x => (x.X == 1) && (x.Y == 1));
            currentCell = startCell;

            do
            {
                List<AnyCell> neighbours = GetNeighbours(maze, startCell, 2);
                if (neighbours.Count != 0)
                {
                    neighbourCell = neighbours[random.Next(0, neighbours.Count)];
                    stackCells.Push(currentCell);
                    maze = RemoveWall(currentCell, neighbourCell, maze);
                    startCell = neighbourCell;
                    currentCell = neighbourCell;
                    neighbourCell.Visited = true;
                }
                else if(stackCells.Count != 0)
                {
                    startCell = stackCells.Pop();
                }
                else
                {
                    List<AnyCell> unvisitedCells = maze.Cells.Where(cell
                        => (cell.Symbol == '.') && (!cell.Visited)).ToList<AnyCell>();
                    startCell = unvisitedCells[random.Next(0, unvisitedCells.Count)];
                    
                }
            }
            while (stackCells.Count != 0);
            return maze;
        }
        
        

        private List<AnyCell> GetNeighbours(Maze maze, AnyCell c, int distance)
        {
            int i;
            int x = c.X;
            int y = c.Y;

            AnyCell up = maze.Cells.SingleOrDefault(cell => (cell.X == x) && (cell.Y == y - distance));
            AnyCell rt = maze.Cells.SingleOrDefault(cell => (cell.X == x + distance) && (cell.Y == y));
            AnyCell dw = maze.Cells.SingleOrDefault(cell => (cell.X == x) && (cell.Y == y + distance));
            AnyCell lt = maze.Cells.SingleOrDefault(cell => (cell.X == x - distance) && (cell.Y == y));

            AnyCell[] d = new AnyCell[] { dw, rt, up, lt };
            List<AnyCell> cells = new List<AnyCell>();

            for (i = 0; i < d.Length; i++)
            {
                
                if (d[i] != null)
                { 
                    AnyCell mazeCellCurrent = maze.Cells.SingleOrDefault(cell 
                        => (cell.X == d[i].X) && (cell.Y == d[i].Y));
                    AnyCell cellCurrent = d[i];
                    if (mazeCellCurrent.Symbol != '#' && !d[i].Visited)
                    {
                        cells.Add(cellCurrent);
                    }
                }
            }
            return cells;
        }

        private Maze RemoveWall(AnyCell first, AnyCell second, Maze maze)
        {
            int xDiff = second.X - first.X;
            int yDiff = second.Y - first.Y;
            int addX, addY;


            addX = (xDiff != 0) ? (xDiff / Math.Abs(xDiff)) : 0;
            addY = (yDiff != 0) ? (yDiff / Math.Abs(yDiff)) : 0;
            AnyCell target = maze.Cells.SingleOrDefault(cell
                        => (cell.X == first.X + addX) && (cell.Y == first.Y + addY));
            AnyCell cellWall = target;
            cellWall = new Ground(target.X, target.Y);
            maze.Cells.Remove(target);
            maze.Cells.Add(cellWall);
            cellWall.Visited = true;
            return maze;
        }

        
    }
}
