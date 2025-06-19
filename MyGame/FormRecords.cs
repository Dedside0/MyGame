using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGame
{
    public partial class FormRecords : Form
    {
        List<Record> records;
        public FormRecords()
        {
            InitializeComponent();
            records = new List<Record>();
        }

        private void Records_Load(object sender, EventArgs e)
        {
            string json = File.ReadAllText("Records.json");
            records = JsonConvert.DeserializeObject<List<Record>>(json);
            if (records == null)
                records = new List<Record>();
            ShowRecords();
        }

        void ShowRecords()
        {
            foreach (Record record in records)
            {
                listBoxRecords.Items.Add(record);
            }
        }
    }
}
