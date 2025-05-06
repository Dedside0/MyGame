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
        MapManager mapManager;
        public FormGame()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle ; // Убираем рамку
            this.WindowState = FormWindowState.Maximized; // Открываем на весь экран
            this.MaximizeBox = false; // Запрещаем разворачивание (на всякий случай)
            this.MinimizeBox = false; // Запрещаем сворачивание
        }
        public FormGame(Form form) : this()
        {
            formMenu = form;

        }

        private void FormGame_Load(object sender, EventArgs e)
        {
            mapManager = new MapManager(this);

            mapManager.ClearMap();
            mapManager.LoadMap();
            mapManager.ShowMap();

            player = new Player("data/pictures/player1.png", 100, 100, 32);
            this.Controls.Add(player);
            this.Controls.SetChildIndex(player, 0);
        }
         

        private void FormGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            formMenu.Close();
        }

        private void FormGame_ResizeEnd(object sender, EventArgs e)
        {

            mapManager.UpdateSize();
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
            player.Move(e, mapManager);
        }
    }
}
