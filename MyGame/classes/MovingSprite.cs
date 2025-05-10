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
        protected double speed = 5;
        protected double vx, vy;
        protected Timer timer;
        protected int targetX, targetY;
        

        public MovingSprite(string path, int x, int y, int size, FormGame form) : base(path, x, y, size, form)
        {
            timer = new Timer();
            timer.Interval = 10;
            timer.Tick += MoveTimer_Tick;
        }

        

        public virtual void StartMove(int targetX, int targetY)
        {
            this.targetX = targetX;
            this.targetY = targetY;
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
            X += (int)vx;
            Y += (int)vy;
            if(IsCollide(this, RuleOfCollide))
            {
                X -= (int)vx; Y -= (int)vy;
            }
            if(X<0 ||  Y<0 || X>form.Width || Y>form.Height)
                DeleteSprite();
        }

        public override void DeleteSprite()
        {
            StopMove(); // остановка таймера или логики
            form.Controls.Remove(this); // удаление с формы
            form.mapManager.CollisionSprites.Remove(this);
            this.Dispose(); // освобождение ресурсов
        }
    }
}
