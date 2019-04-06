using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    public class Hero : AnyCell
    {
        //public const ConsoleColor HeroColor = ConsoleColor.Red;
        public int Money { get; set; }

        private static Hero hero;
        public static Hero GetHero
        {
            get
            {
                if (hero == null)
                {
                    hero = new Hero();
                }
                return hero;
            }
        }

        private Hero() : base(1, 1, 'x') { }

        public override bool TryToStep(Maze maze)
        {
            throw new NotImplementedException();
        }
    }
}
