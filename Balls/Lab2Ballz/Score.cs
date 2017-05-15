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
    public partial class Score : Form
    {
        public delegate void delVoidVoid();
        public delVoidVoid DELformclosed = null;

        public Score()
        {
            InitializeComponent();
        }

        public int score
        {
            set
            {
                UI_Lscore.Text = String.Format("{0:D12}", value);
            }
        }

        private void Score_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DELformclosed();
                e.Cancel = true;
                Hide();
            }
        }
    }
}
