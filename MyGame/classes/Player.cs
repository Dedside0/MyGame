using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGame.classes
{
    public class Player : CollisionSprite
    {
        Timer timer;
        double health = 100;
        public ProgressBar HealthBar;
        int lvl = 1;
        double xp;
        int speed;
        public int Score { get; private set; }
        public MapManager mapManager;
        public EventHandler EventHandler;
        public double Health
        {
            get
            {
                return health;
            }
            set
            {
                if (value <= 0)
                {

                    HealthBar.Value = 0;
                    mapManager.GameOver(this);
                }
                else
                {
                    HealthBar.Value = (int)value;
                    health = value;
                }
            }
        }

        bool up, down, left, right;


        public Player(string path, int x, int y, int size, FormGame form) : base(path, x, y, size, form)
        {

            HealthBar = new ProgressBar();
            HealthBar.Value = (int)Health;
            HealthBar.Size = new Size(200, 60);
            HealthBar.BackColor = Color.White;
            HealthBar.Left = form.Width / 2 - HealthBar.Width / 2;
            HealthBar.Top = form.Height - 2 * HealthBar.Height;
            form.Controls.Add(HealthBar);
            form.Controls.SetChildIndex(HealthBar, 0);

            speed = 5;
            mapManager = form.mapManager;

            timer = new Timer();
            timer.Interval = 1;
            timer.Tick += MovementTimer_Tick;
            timer.Start();
        }

        public new void Move(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D)
            {
                this.Load("data/pictures/player1.png");
                left = false;
                right = true;
            }
            if (e.KeyCode == Keys.A)
            {
                this.Load("data/pictures/player2.png");
                right = false;
                left = true;
            }
            if (e.KeyCode == Keys.S)
            {
                up = false;
                down = true;
            }
            if (e.KeyCode == Keys.W)
            {
                down = false;
                up = true;
            }

        }

        public void Stop(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D)
                right = false;
            if (e.KeyCode == Keys.A)
                left = false;
            if (e.KeyCode == Keys.S)
                down = false;
            if (e.KeyCode == Keys.W)
                up = false;
        }


        private void MovementTimer_Tick(object sender, EventArgs e)
        {
            if (up)
            {
                this.Y -= speed;
                while (IsCollide(this, RuleOfCollide))
                    this.Y += 1;
            }
            if (down)
            {
                this.Y += speed;
                while (IsCollide(this, RuleOfCollide))
                    this.Y -= 1;
            }
            if (left)
            {
                this.X -= speed;
                while (IsCollide(this, RuleOfCollide))
                    this.X += 1;
            }
            if (right)
            {
                this.X += speed;
                while (IsCollide(this, RuleOfCollide))
                    this.X -= 1;
            }
            Show();
        }


        protected override bool RuleOfCollide(CollisionSprite current, CollisionSprite other)
        {
                //if (other is Enemy && other.Hitbox.IntersectsWith(current.Hitbox))
                //{
                //    this.Health -= ((Enemy)other).Damage;
                //    other.DeleteSprite();
                //}
            if (other is Bullet)
                return false;
            return base.RuleOfCollide(current, other);
        }
    }
}
