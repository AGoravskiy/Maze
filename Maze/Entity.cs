using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    public class Entity
    {
        private Entity(string value) { Value = value; }

        public string Value { get; set; }

        public static Entity Wall { get { return new Entity("#"); } }
        public static Entity Ground { get { return new Entity("."); } }
        public static Entity Coint { get { return new Entity("c"); } }
    }
}
