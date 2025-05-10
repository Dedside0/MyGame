using MyGame.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGame
{
    public partial class FormGame : Form
    {

        public Player player;
        Form formMenu;
        public MapManager mapManager;
        public Label HPLabel;
        Random rand;

        public FormGame()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle ;
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false; 
            this.MinimizeBox = false; 
        }
        public FormGame(Form form) : this()
        {
            formMenu = form;
        }

        private void FormGame_Load(object sender, EventArgs e)
        {
            rand = new Random();
            mapManager = new MapManager(this);
            this.BackColor = Color.Black;

            mapManager.ClearMap();
            mapManager.LoadMap();
            mapManager.ShowMap();
            

            player = new Player("data/pictures/player1.png", 100, 100, 50, this);
            player.Show();
            player.mapManager = mapManager;
            this.Controls.Add(player);
            this.Controls.SetChildIndex(player, 0);

            HPLabel = new Label();
            HPLabel.Size = new Size(200, 60);
            //HPLabel.Font = new Font(Font, FontStyle.Bold);
            HPLabel.Font = new Font("Arial", 50);
            HPLabel.TextAlign = ContentAlignment.MiddleCenter;
            HPLabel.BackColor = Color.White;
            HPLabel.Left = this.Width/2 - HPLabel.Width/2;
            HPLabel.Top = this.Height - 2*HPLabel.Height;
            HPLabel.Text = player.Health.ToString();
            this.Controls.Add(HPLabel);

            this.Controls.SetChildIndex(HPLabel, 0);

        }
         

        private void FormGame_ResizeEnd(object sender, EventArgs e)
        {
            mapManager.ClearMap();
            mapManager.LoadMap();
            mapManager.ShowMap();
        }

        private void FormGame_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            player.Move(e);
        }

        private void FormGame_KeyUp(object sender, KeyEventArgs e)
        {
            player.Stop(e);
        }

        private void FormGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            formMenu.Close();
        }

        private void timerEnemySpawn_Tick(object sender, EventArgs e)
        {
            SummonEnemy();
        }

        public void SummonEnemy()
        {
            int x = rand.Next(0, this.Width);
            int y = rand.Next(0, this.Height);
            Enemy enemy = new Enemy("data/pictures/enemy1.jpg", x, y, 64, this);
            this.Controls.Add(enemy);
            this.Controls.SetChildIndex(enemy, 0);
            enemy.StartMove(player.X, player.Y);
        }
    }
}
