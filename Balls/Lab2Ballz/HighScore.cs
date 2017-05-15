using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2Ballz
{
    public partial class HighScore : Form
    {
        public HighScore()
        {
            InitializeComponent();
        }

        public string name
        {
            get
            {
                return UI_TBname.Text;
            }
        }

        private void UI_Bok_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void UI_Bcan_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
