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
    public class Bullet : CollisionSprite
    {
        Point start, end;
        int speed;
        public Bullet(string path, int x, int y, Player player, int size) : base(path, x, y, size)
        {
            end = new Point(x, y);
            X=player.X;
            Y=player.Y;
            speed = 30;

        }

        public new void Move()
        {
            Timer timer = new Timer();
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            X += speed;
            Y += speed;
        }
    }
}
