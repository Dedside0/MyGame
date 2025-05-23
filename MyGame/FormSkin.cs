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
    public partial class FormSkin : Form
    {
        public string SkinID { get;private set; }
        public FormSkin()
        {
            InitializeComponent();
        }

        private void pictureBoxSkin1_Click(object sender, EventArgs e)
        {
            SkinID = "1";
            Close();
        }

        private void pictureBoxSkin2_Click(object sender, EventArgs e)
        {
            SkinID = "2";
            Close();
        }
    }
}
