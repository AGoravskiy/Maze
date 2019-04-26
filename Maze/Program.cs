using MazeCore;
using MazeCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameMaze
{
    class Program
    {
        static void Main(string[] args)
        {
            var generator = new MazeGenerator();
            var maze = generator.GetMaze();

            Drawer.Draw(maze);
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        {
                            maze.TryToStep(Direction.Up);
                            break;
                        }
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        {
                            maze.TryToStep(Direction.Right);
                            break;
                        }
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        {
                            maze.TryToStep(Direction.Down);
                            break;
                        }
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        {
                            maze.TryToStep(Direction.Left);
                            break;
                        }
                    case ConsoleKey.R:
                        {
                            maze = generator.GetMaze();
                            break;
                        }
                }

                Drawer.Draw(maze);
            } while (key.Key != ConsoleKey.Escape);
        }
    }
}
