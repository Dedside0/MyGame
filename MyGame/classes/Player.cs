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
        string skinID;
        string rootPathofSkins = "data/pictures/players/";
        Timer timer; Label labelScore; ProgressBar HealthBar; MapManager mapManager;
        int score;
        double health = 100;
        int speed;
        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
                labelScore.Text = score.ToString();
            }
        }
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


        public Player(string skinID, int x, int y, int size, FormGame form) : base($"data/pictures/players/player{skinID}_1.jpg", x, y, size, form)
        {
           HealthBar = new ProgressBar();
            HealthBar.Value = (int)Health;
            HealthBar.Size = new Size(200, 60);
            HealthBar.BackColor = Color.White;
            HealthBar.Left = form.Width / 2 - HealthBar.Width / 2;
            HealthBar.Top = form.Height - 2 * HealthBar.Height;
            form.Controls.Add(HealthBar);
            form.Controls.SetChildIndex(HealthBar, 0);

            labelScore = new Label();
            labelScore.Text = "0";
            labelScore.Size = new Size(150, 70);
            labelScore.Location = new Point(form.Width - labelScore.Width, 0);
            labelScore.BackColor = Color.White;
            labelScore.Font = new Font("Arial", 50);
            labelScore.TextAlign = ContentAlignment.MiddleCenter;
            form.Controls.Add(labelScore);
            form.Controls.SetChildIndex(labelScore, 0);
            this.skinID = skinID;
            speed = 5;
            mapManager = form.mapManager;

            timer = new Timer();
            timer.Interval = 10;
            timer.Tick += MovementTimer_Tick;
            timer.Start();
        }

        public new void Move(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D && !right)
            {
                this.Load($"{rootPathofSkins}player{skinID}_1.jpg");
                left = false;
                right = true;
            }
            if (e.KeyCode == Keys.A && !left)
            {
                this.Load($"{rootPathofSkins}player{skinID}_2.jpg");
                right = false;
                left = true;
            }
            if (e.KeyCode == Keys.S && !down)
            {
                up = false;
                down = true;
            }
            if (e.KeyCode == Keys.W && !up)
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
            if (other is Bullet)
                return false;
            return base.RuleOfCollide(current, other);
        }
    }
}
