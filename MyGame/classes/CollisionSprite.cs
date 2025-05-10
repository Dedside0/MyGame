using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.classes
{
    public class CollisionSprite : Sprite
    {
        public Rectangle Hitbox { get => new Rectangle(X, Y, size, size); }

        public CollisionSprite(string path, int x, int y, int size, FormGame form) : base(path, x, y, size, form)
        {
            form.mapManager.CollisionSprites.Add(this);
        }


        protected bool IsCollide(CollisionSprite current, Func<CollisionSprite, CollisionSprite, bool> iscollided)
        {
            foreach (var collisionSprite in form.mapManager.CollisionSprites)
            {
                if (iscollided(current, collisionSprite))
                    return true;
            }
            return false;
        }

        protected virtual bool RuleOfCollide(CollisionSprite current, CollisionSprite other)
        {
            if (current == other)
                return false;
            if (current.GetType() == other.GetType())
                return false;
            if (current.Hitbox.IntersectsWith(other.Hitbox))
                return true;
            return false;
        }
    }
}
