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
    public partial class FormAddRecord : Form
    {
        public string UserName { get; private set; }
        public FormAddRecord()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if(textBoxInputName.Text == "")
            {
                MessageBox.Show("Введите имя");
            }
            else
            {
                UserName = textBoxInputName.Text;
                this.Close();
            }
        }
    }
}
