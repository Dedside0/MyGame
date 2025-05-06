using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGame.classes
{
    internal class Sprite: PictureBox
    {
        public int size;
        public int posX, posY;
        public Sprite(string path, int x,int y, int size)
        {
            posX = x; posY = y;
            this.size = size;

            this.Load(path);
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.BorderStyle = BorderStyle.None;
            this.Width = size;
            this.Height = size;
            this.Top = y;
            this.Left = x;
        }
    }
}
