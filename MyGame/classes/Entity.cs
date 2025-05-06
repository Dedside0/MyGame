using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace MyGame.classes
{
    internal class Entity : CollisionSprite
    {
        public string Name { get; set; }

        public Entity(string path, int x, int y, int size) : base(path, x, y, size)
        {
        }
    }
}
