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
    public partial class Select : Form
    {
        public Select()
        {
            InitializeComponent();
        }

        public Difficulty diff
        {
            get
            {
                if (UI_Rhard.Checked)
                    return Difficulty.hard;
                else if (UI_Rmed.Checked)
                    return Difficulty.medium;
                return Difficulty.easy;
            }
        }

        private void UI_Bok_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void UI_Bcancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
