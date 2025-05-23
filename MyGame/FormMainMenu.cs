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
    public partial class FormMainMenu : Form
    {
        string skinId = "1";
        public FormMainMenu()
        {
            InitializeComponent();
        }

        private void FormMainMenu_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            FormGame formGame = new FormGame(this,skinId);
            this.Hide();
            formGame.Show();

        }

        private void buttonSkins_Click(object sender, EventArgs e)
        {
            FormSkin formSkin = new FormSkin();
            formSkin.ShowDialog();
            skinId = formSkin.SkinID;
        }
    }
}
