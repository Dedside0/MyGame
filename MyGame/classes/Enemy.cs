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
        bool canFly;
        ProgressBar HealthBar;
        double health;
        public double Health
        {
            get
            {
                return health;
            }
            set
            {
                if (value <= 0)
                    form.mapManager.KilledSprites.Add(this);
                else
                {
                    HealthBar.Value = (int)value;
                    health = value;
                }
            }
        }
        public double Damage { get; }
        public Enemy(string path, int x, int y, int size, FormGame form) : base(path, x, y, size, form)
        {
            HealthBar = new ProgressBar();
            HealthBar.Width = this.size;
            HealthBar.Height = this.size / 5;
            Health = 30;
            HealthBar.Top = Y - size / 3;
            HealthBar.Left = X;
            HealthBar.Maximum = (int)Health;
            form.Controls.Add(HealthBar);
            form.Controls.SetChildIndex(HealthBar, 0);
            speed = 2;
            Damage = 20;
        }
        public Enemy(int type, int x, int y, int size, FormGame form) : this("data/pictures/enemy" + $"{type}.jpg", x, y, size, form)
        {
            switch (type)
            {
                case 1: canFly = false; break;
                case 2: canFly = true; Health = 15; HealthBar.Maximum = (int)Health; break;
            }
        }

        protected Point PlayerPosition { get => new Point(form.player.X, form.player.Y); }

        protected override void Move()
        {

            HealthBar.Top = Y - size / 3;
            HealthBar.Left = X;
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
                form.mapManager.KilledSprites.Add(this);
        }

        protected override bool RuleOfCollide(CollisionSprite current, CollisionSprite other)
        {
            if (other is Bullet bullet && other.Hitbox.IntersectsWith(current.Hitbox))
            {
                Health -= bullet.Damage;
                form.mapManager.KilledSprites.Add(bullet);
                return true;
            }
            if (other is Player player && other.Hitbox.IntersectsWith(current.Hitbox))
            {
                player.Health -= Damage;
                form.mapManager.KilledSprites.Add(this);
                return true;
            }
            if(canFly && !(other is Enemy) && current.Hitbox.IntersectsWith(current.Hitbox))
            {
                return false;
            }
            return base.RuleOfCollide(current, other);
        }

        public override void DeleteSprite()
        {
            form.Controls.Remove(HealthBar);
            base.DeleteSprite();
        }

        void TakeDamage(double damage)
        {
            Health -= damage;
        }

    }
}
