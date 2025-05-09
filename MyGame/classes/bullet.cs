using MyGame.classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGame.classes
{
    public class Bullet : MovingSprite
    {
        public Bullet(string path, int x, int y, Player player, int size, FormGame form) : base(path, player.X,player.Y, size, form)
        {
            X=player.X;
            Y=player.Y;
        }

        public override void StartMove(int targetX, int targetY)
        {
            base.StartMove(targetX, targetY);
        }
        public override void StopMove()
        {
            base.StopMove();
        }

        protected override bool CheckCollide(CollisionSprite current, CollisionSprite other)
        {
            if(other is Player)
                return false;
            return base.CheckCollide(current, other);
        }
    }
}
