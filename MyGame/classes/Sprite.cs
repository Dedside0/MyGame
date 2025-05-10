using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGame.classes
{
    public class Sprite : PictureBox
    {
        Stopwatch reloadTimer = new Stopwatch();
        bool isReload
        {
            get
            {
                if(reloadTimer.ElapsedMilliseconds >= 500)
                {
                    reloadTimer.Restart();
                    return true;
                }
                return false;
            }
        }
        protected FormGame form;
        protected int size;
        public int X { get; set; }
        public int Y { get; set; }

        public Sprite(string path, int x, int y, int size, FormGame form)
        {
            reloadTimer = new Stopwatch();
            reloadTimer.Start();
            X = x; Y = y;
            this.size = size;
            this.form = form;

            this.Load(path);
            this.Top = y;
            this.Left = x;
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.BorderStyle = BorderStyle.None;
            this.Width = size;
            this.Height = size;
            this.MouseClick += Sprite_MouseClick;
        }

        private void Sprite_MouseClick(object sender, MouseEventArgs e)
        {
            if (isReload)
            {

                Point mouse = form.PointToClient(Cursor.Position);
                Bullet bullet = new Bullet("data/pictures/wall1.jpg", form.player.X, form.player.Y, 30, form);

                form.Controls.Add(bullet);
                form.Controls.SetChildIndex(bullet, 0);
                bullet.StartMove(mouse.X, mouse.Y);
            }
        }

        public new virtual void Show()
        {
            this.Top = Y;
            this.Left = X;
        }

        public virtual void DeleteSprite()
        {
            form.Controls.Remove(this);
            this.Dispose();
        }

        int CountOfBullets()
        {
            int cnt = 0;
            foreach (var sprite in form.mapManager.CollisionSprites)
            {
                if (sprite is Bullet)
                    cnt++;
            }
            return cnt;
        }
    }
}
