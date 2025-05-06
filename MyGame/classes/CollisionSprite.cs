using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.classes
{
    internal class CollisionSprite : Sprite
    {
        public Rectangle Hitbox { get => new Rectangle(posX,posY,size,size); }

        public CollisionSprite(string path, int x, int y, int size) : base(path, x, y, size)
        {
            
        }
    }
}
