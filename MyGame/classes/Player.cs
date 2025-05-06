using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGame.classes
{
    public class Player : Entity
    {
        double health = 100;
        int lvl = 1;
        double xp;
        int speed = 5;
        public int Score { get; private set; }


        public Player(string path, int x, int y, int size) : base(path, x, y, size)
        {
        }

        internal new void Move(System.Windows.Forms.KeyEventArgs e, MapManager mapManager)
        {
            if (e.KeyCode == Keys.D)
            {
                this.X += speed;
                this.Load("data/pictures/player1.png");
                if (isCollide(mapManager))
                    this.X -= speed;
            }
            else if (e.KeyCode == Keys.A)
            {
                this.X -= speed;
                this.Load("data/pictures/player2.png");

                if (isCollide(mapManager))
                    this.X += speed;
            }
            else if (e.KeyCode == Keys.W)
            {
                this.Y -= speed;

                if (isCollide(mapManager))
                    this.Y += speed;
            }
            else if (e.KeyCode == Keys.S)
            {
                this.Y += speed;

                if (isCollide(mapManager))
                    this.Y -= speed;
            }
        }
        private bool isCollide(MapManager mapManager)
        {
            foreach (var wall in mapManager.CollisionSprites)
            {
                if (Hitbox.IntersectsWith(wall.Hitbox))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
