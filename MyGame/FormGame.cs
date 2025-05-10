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
        public ProgressBar HPBar;
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

            HPBar = new ProgressBar();
            HPBar.Value = (int)player.Health ;
            HPBar.Size = new Size(200, 60);
            HPBar.BackColor = Color.White;
            HPBar.Left = this.Width/2 - HPBar.Width/2;
            HPBar.Top = this.Height - 2*HPBar.Height;
            this.Controls.Add(HPBar);

            this.Controls.SetChildIndex(HPBar, 0);

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
            mapManager.SummonEnemy(rand);
        }

    }
}
