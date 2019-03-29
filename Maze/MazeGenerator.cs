using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    class MazeGenerator
    {
        public string[,] GetMaze(string[,] maze)
        {
            Cell startCell = new Cell(1, 1);
            Cell currentCell = startCell;
            Cell neighbourCell;
            Stack<Cell> stackCells= new Stack<Cell>();
            Random random = new Random();
            int num = 20;

            do
            {
                List<Cell> neighbours = GetNeighbours(startCell.Height, startCell.Width, maze, startCell, 2);
                if (neighbours.Count != 0)
                {
                    neighbourCell = neighbours[random.Next(0, neighbours.Count - 1)];
                    stackCells.Push(currentCell);
                    maze = RemoveWall(currentCell, neighbourCell, maze);
                    currentCell = neighbourCell;
                    neighbourCell.Visited = true;
                }
                else
                {
                    startCell = stackCells.Pop();
                }
                num--;
            }
            while (num > 0);
            return maze;
        }
        
        

        public List<Cell> GetNeighbours(int width, int height, string[,] maze, Cell c, int distance)
        {
            int i;
            int x = c.Height;
            int y = c.Width;
            Cell up = new Cell(x, y - distance);
            Cell rt = new Cell(x + distance, y);
            Cell dw = new Cell(x, y + distance);
            Cell lt = new Cell(x - distance, y);
            Cell[] d = new Cell[] { dw, rt, up, lt };
            List<Cell> cells = new List<Cell>();

            for (i = 0; i < 4; i++)
            { //для каждого направдения
                if (d[i].Width > 0 && d[i].Width < width && d[i].Height > 0 && d[i].Height < height)
                { //если не выходит за границы лабиринта
                    string mazeCellCurrent = maze[d[i].Height, d[i].Width];
                    Cell cellCurrent = d[i];
                    if (mazeCellCurrent != "#" && !d[i].Visited)
                    { //и не посещена\является стеной
                        cells.Add(cellCurrent); //записать в массив;
                    }
                }
            }
            return cells;
        }

        public string[,] RemoveWall(Cell first, Cell second, string[,] maze)
        {
            int xDiff = second.Height - first.Height;
            int yDiff = second.Width - first.Width;
            int addX, addY;


            addX = (xDiff != 0) ? (xDiff / Math.Abs(xDiff)) : 0;
            addY = (yDiff != 0) ? (yDiff / Math.Abs(yDiff)) : 0;
            Cell target = new Cell(first.Height + addX, first.Width + addY);

            maze[target.Height, target.Width] = ".";
            target.Visited = true;
            return maze;
        }

        
    }
}
