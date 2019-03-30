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

            Drawer.Draw(maze);
            ConsoleKeyInfo key;
            do
            {

                key = Console.ReadKey();
                if (key.Key == ConsoleKey.R)
                {
                    maze = generator.GetMaze();
                    Drawer.Draw(maze);
                }
            }
            while (key.Key != ConsoleKey.Escape);

            Console.Read();
        }
    }
}
