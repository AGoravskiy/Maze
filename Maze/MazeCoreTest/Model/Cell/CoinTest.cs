using MazeCore.Model.Cell;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using MazeCore;
using MazeCore.Interface;

namespace MazeCoreTest.Model.Cell
{
    class CoinTest
    {
        private Maze maze { get; set; }
        private MazeGenerator mazeGenerator { get; set; }

        [SetUp]
        public void Setup()
        {
            mazeGenerator = new MazeGenerator();
        }

        [Test]
        public void TryToStep_ChangeType()
        {
            maze = mazeGenerator.GetMaze();
            var coin = new Coin(1, 1);
            coin.TryToStep(maze);

            Assert.IsTrue(maze[1, 1] is Ground);
        }

        [Test]
        public void TryToStep_AddMoney()
        {
            maze = mazeGenerator.GetMaze();
            var money = Hero.GetHero.Money;
            var coin = new Coin(1, 1);
            coin.TryToStep(maze);

            Assert.AreEqual(money + 1, Hero.GetHero.Money);
        }

        [Test]
        public void TryToStep_AvailableToStep()
        {
            maze = mazeGenerator.GetMaze();
            var coin = new Coin(1, 1);

            var avalibleToStep = coin.TryToStep(maze);

            Assert.IsTrue(avalibleToStep);
        }
    }
}
