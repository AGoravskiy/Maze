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
            int height = 11;
            int width = 31;
            
            string[,] maze = new string[height, width];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if ((i % 2 != 0 && j % 2 != 0) && //если ячейка нечетная по x и y, 
                        (i < height - 1 && j < width - 1))
                    {  //и при этом нах одится в пределах стен лабиринта
                        maze[i, j] = ".";
                    }       //то это КЛЕТКА
                    else { maze[i, j] = "#"; }          //в остальных случаях это СТЕНА.
                }
            }

            var generator = new MazeGenerator();
            maze = generator.GetMaze(maze);

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write( maze[i,j]);       //в остальных случаях это СТЕНА.
                }
                Console.WriteLine();
            }
        }
    }
}
