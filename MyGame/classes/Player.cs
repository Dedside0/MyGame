using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.classes
{
    internal class Player : Entity
    {
        double health=100;
        int lvl=1;
        double xp;
        public int Score { get; private set; }

        
        public Player(string path, int x, int y, int size) : base(path, x, y, size)
        {
        }
    }
}
