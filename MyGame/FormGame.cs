﻿using MyGame.classes;
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
        string skinId="2";
        public Player player;
        public MapManager mapManager;
        Form formMenu;
        Random rand;
        public Timer timerEnemySpawn;

        public FormGame()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle ;
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false; 
            this.MinimizeBox = false; 
        }
        public FormGame(Form form,string skinId) : this()
        {
            formMenu = form;
            this.skinId = skinId;
        }

        private void FormGame_Load(object sender, EventArgs e)
        {   
            timerEnemySpawn = new Timer();
            timerEnemySpawn.Interval = 500;
            timerEnemySpawn.Tick += timerEnemySpawn_Tick;
            timerEnemySpawn.Start();
            rand = new Random();
            mapManager = new MapManager(this);
            this.BackColor = Color.Black;

            mapManager.ClearMap();
            mapManager.LoadMap();
            mapManager.ShowMap();

            player = mapManager.SummonPlayer(skinId);
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
            mapManager.SummonEnemy();
        }

    }
}
