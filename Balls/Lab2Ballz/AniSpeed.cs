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
    public partial class AniSpeed : Form
    {
        public delegate void delVoidVoid();
        public delegate void delVoidInt(int delay);
        public delVoidInt DELfreqchanged = null;
        public delVoidVoid DELformclosed = null;

        public AniSpeed()
        {
            InitializeComponent();
        }

        private void UI_TBspeed_Scroll(object sender, EventArgs e)
        {
            DELfreqchanged(UI_TBspeed.Value);
        }

        private void AniSpeed_FormClosing(object sender, FormClosingEventArgs e)
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
