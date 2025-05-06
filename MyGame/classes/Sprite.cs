using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGame.classes
{
    public class Sprite: PictureBox
    {
        public int size;
        private int x, y;


        public int X
        {
            get => x;
            set
            {
                this.Left = value;
                this.x = value;
            }
        }
        public int Y
        {
            get => y;
            set
            {
                this.Top = value;
                this.y = value;
            }
        }

        public Sprite(string path, int x,int y, int size)
        {
            X = x; Y = y;
            this.size = size;

            this.Load(path);
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.BorderStyle = BorderStyle.None;
            this.Width = size;
            this.Height = size;
            this.MouseClick += Sprite_MouseClick;
        }

        private void Sprite_MouseClick(object sender, MouseEventArgs e)
        {
            var form= this.FindForm() as FormGame;
            Bullet bullet = new Bullet("data/pictures/wall1.jpg", e.X, e.Y,form.player, 15);
            
            form.Controls.Add(bullet);
            form.Controls.SetChildIndex(bullet, 0);
            bullet.Move();
        }
    }
}
