using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGame.classes
{
    public class Sprite : PictureBox
    {
        protected FormGame form;
        protected int size;
        public int X { get; set; }
        public int Y { get; set; }

        public Sprite(string path, int x, int y, int size, FormGame form)
        {
            X = x; Y = y;
            this.size = size;
            this.form = form;

            this.Load(path);
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.BorderStyle = BorderStyle.None;
            this.Width = size;
            this.Height = size;
            this.MouseClick += Sprite_MouseClick;
        }

        private void Sprite_MouseClick(object sender, MouseEventArgs e)
        {
            Point mouse = form.PointToClient(Cursor.Position);
            Bullet bullet = new Bullet("data/pictures/wall1.jpg", form.player.X,form.player.Y, 30, form);

            form.Controls.Add(bullet);
            form.Controls.SetChildIndex(bullet, 0);
            bullet.StartMove(mouse.X,mouse.Y);
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
    }
}
