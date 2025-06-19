using MyGame.classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace MyGame.classes
{
    public class Bullet : MovingSprite
    {
        public double Damage { get; }
        public Bullet(string path, int x, int y, int size, FormGame form) : base(path, x, y, size, form)
        {
            Damage = 20;
            speed = 15;
            double dx = targetX - X;
            double dy = targetY - X;
            double angle = Math.Atan2(dy, dx);

            
            this.vx = speed * Math.Cos(angle);
            this.vy = speed * Math.Sin(angle);
        }
        public override void StartMove(int targetX, int targetY)
        {
            double dx = targetX - X;
            double dy = targetY - Y;

            double angle = Math.Atan2(dy,dx);
            this.vx = speed*Math.Cos(angle);
            this.vy=speed*Math.Sin(angle);
            moveTimer.Enabled = true;
        }

        protected override void Move()
        {
            X += (int)vx;
            Y += (int)vy;
            if (IsCollide(this, RuleOfCollide))
            {
                form.mapManager.KilledSprites.Add(this);
            }
            if (X < 0 || Y < 0 || X > form.Width || Y > form.Height)
                form.mapManager.KilledSprites.Add(this);
        }

        protected override bool RuleOfCollide(CollisionSprite current, CollisionSprite other)
        {
            if(other is Player || other is Enemy)
                return false;
            return base.RuleOfCollide(current, other);
        }

       
    }
}
