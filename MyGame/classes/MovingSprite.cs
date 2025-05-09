using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace MyGame.classes
{
    public class MovingSprite : CollisionSprite
    {
        protected int vx = 5, vy = 5;
        protected Timer timer;
        

        public MovingSprite(string path, int x, int y, int size, FormGame form) : base(path, x, y, size, form)
        {
            timer = new Timer();
            timer.Interval = 10;
            timer.Tick += MoveTimer_Tick;
        }

        //этот метод вызываем в главном коде
        public virtual void StartMove(int targetX, int targetY)
        {
            timer.Enabled = true;
        }
        public virtual void StopMove()
        {
            timer.Enabled = false ;
        }

        private void MoveTimer_Tick(object sender, EventArgs e)
        {
            Move();
            Show();
        }

        protected new virtual void Move()
        {
            X += vx;
            Y += vy;
            if (IsCollide(this, CheckCollide))
            {
                X -= vx; Y -= vy;
            }
        }

        public override void DeleteSprite()
        {
            timer.Tick -= MoveTimer_Tick;
            timer.Stop();
            timer.Dispose();
            form.Controls.Remove(this);
        }
    }
}
