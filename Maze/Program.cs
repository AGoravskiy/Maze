using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    class Program
    {
        static void Main(string[] args)
        {
            var generator = new MazeGenerator();
            var maze = generator.GetMaze();
            var hero = Hero.GetHero;

            //for (int y = 0; y < maze.Height; y++)
            //{
            //    Console.WriteLine();
            //    for (int x = 0; x < maze.Width; x++)
            //    {
            //        var currentCell = maze.Cells.SingleOrDefault(cell => cell.X == x && cell.Y == y);

            //        if (hero.X == x && hero.Y == y)
            //        {
            //            Console.Write(hero.Symbol);
            //        }
            //        else
            //        {
            //            Console.Write(currentCell.Symbol);
            //        }
            //    }
            //}
            //Console.WriteLine();

            for (int x = 0; x < maze.Width; x++)
            {
                Console.WriteLine();
                for (int y = 0; y < maze.Height; y++)
                {
                    var currentCell = maze.Cells.SingleOrDefault(cell => cell.X == x && cell.Y == y);

                    if (hero.X == x && hero.Y == y)
                    {
                        Console.Write(hero.Symbol);
                    }
                    else
                    {
                        Console.Write(currentCell.Symbol);
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
