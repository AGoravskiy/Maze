using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeCore;
using MazeCore.Model.Cell;

namespace GameMaze
{
    class Drawer
    {
        public static void Draw(Maze maze)
        {
            Console.Clear();

            var hero = Hero.GetHero;
            Console.WriteLine($"Press R to restart");

            var oldColor = Console.ForegroundColor;
            Console.ForegroundColor = Coin.CoinColor;
            Console.ForegroundColor = oldColor;
            Console.WriteLine($"Coins: {hero.Money}");
            Console.WriteLine(maze.DescLastAction);
            

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
                        oldColor = Console.ForegroundColor;
                        Console.ForegroundColor = currentCell.CellColor ?? oldColor;
                        Console.Write(currentCell.Symbol);
                        Console.ForegroundColor = oldColor;
                    }
                }
            }
            
            Console.WriteLine();
            Console.WriteLine($"Press Esc to exit");
        }
        
    }
}
