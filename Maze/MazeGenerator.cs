﻿using Maze.Model.Cell;
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
            startCell = maze[1, 1];
            startCell.Visited = true;

            do
            {
                var neighbours = GetNeighbours(maze, startCell, 2);

                if (neighbours.Any())
                {
                    neighbourCell = neighbours[random.Next(0, neighbours.Count)];
                    stackCells.Push(startCell);
                    RemoveWall(startCell, neighbourCell, maze);
                    startCell = neighbourCell;
                    neighbourCell.Visited = true;
                }
                else if(stackCells.Any())
                {
                    startCell = stackCells.Pop();
                }
                else
                {
                    List<AnyCell> unvisitedCells = maze.Cells.Where(cell
                        => (cell is Ground) && (!cell.Visited)).ToList<AnyCell>();
                    startCell = unvisitedCells[random.Next(0, unvisitedCells.Count)];
                }
                
            }
            while (stackCells.Count != 0);
            DropCoin(maze);
            return maze;
        }
        
        private void DropCoin(Maze maze)
        {
            var randomGround = new List<AnyCell>();
            var allGround = maze.Cells.Where(x => x is Ground).ToList();

            for (int i = 0; i < allGround.Count/10; i++)
            {
                randomGround.Add(allGround[random.Next(1, allGround.Count)]);
            }

            for (int i = 0; i < randomGround.Count; i++)
            {
                maze[randomGround[i].X, randomGround[i].Y]
                    = new Coin(randomGround[i].X, randomGround[i].Y);
            }
        }

        private List<AnyCell> GetNeighbours(Maze maze, AnyCell currentCell, int distance)
        {
            var neighbourCells = new List<AnyCell>();

            neighbourCells.Add(maze[currentCell.X, currentCell.Y - distance]);
            neighbourCells.Add(maze[currentCell.X + distance, currentCell.Y]);
            neighbourCells.Add(maze[currentCell.X, currentCell.Y + distance]);
            neighbourCells.Add(maze[currentCell.X - distance, currentCell.Y]);
            
            return neighbourCells.Where(x => x != null && !x.Visited).ToList();
        }

        private void RemoveWall(AnyCell first, AnyCell second, Maze maze)
        {
            int xDiff = second.X - first.X;
            int yDiff = second.Y - first.Y;
            int addX, addY;
            
            addX = (xDiff != 0) ? (xDiff / Math.Abs(xDiff)) : 0;
            addY = (yDiff != 0) ? (yDiff / Math.Abs(yDiff)) : 0;

            maze[first.X + addX, first.Y + addY] = new Ground(first.X + addX, first.Y + addY);
            maze[first.X + addX, first.Y + addY].Visited = true;
        }
    }
}
