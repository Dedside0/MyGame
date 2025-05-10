using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace MyGame.classes
{
    internal class Enemy : MovingSprite
    {
        private double damage = 12;
        public Enemy(string path, int x, int y, int size, FormGame form) : base(path, x, y, size, form)
        {
            speed = 2;
        }

        protected Point PlayerPosition { get => new Point(form.player.X, form.player.Y); }

        protected override void Move()
        {
            double dx = PlayerPosition.X - X;
            double dy = PlayerPosition.Y - Y;

            double angle = Math.Atan2(dy, dx); // угол от объекта к игроку
            vx = speed * Math.Cos(angle);
            vy = speed * Math.Sin(angle);

            X += (int)vx;
            Y += (int)vy;

            this.Location = new Point(X, Y);
            if (IsCollide(this, RuleOfCollide))
            {
                X -= (int)vx;
                Y -= (int)vy;
            }
            if (X < 0 || Y < 0 || X > form.Width || Y > form.Height)
                DeleteSprite();
        }

        protected override bool RuleOfCollide(CollisionSprite current, CollisionSprite other)
        {
            if(other is Player && other.Hitbox.IntersectsWith(current.Hitbox))
            {
                DeleteSprite();
                ((Player)other).Health -= damage;
            }
            return base.RuleOfCollide(current, other);
        }

    }
}
