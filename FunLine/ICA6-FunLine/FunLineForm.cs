using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDIDrawer;

namespace ICA6_FunLine
{
    public partial class FunLineForm : Form
    {
        private static Random rand = new Random();
        private static CDrawer canvas = new CDrawer();
        private List<FunLine> lines = new List<FunLine>();

        private const int longLimit = 325;

        public FunLineForm()
        {
            InitializeComponent();
            canvas.ContinuousUpdate = false;
        }

        private void UI_Bpopulate_Click(object sender, EventArgs e)
        {
            genLines();
            renderLines();
            setMinMax();
        }

        private void renderLines()
        {
            canvas.Clear();
            int index = 0;
            lines.ForEach((l) => { l.render(canvas, new Point(100 + index * 15, 100)); index++; });
            canvas.Render();
        }

        private void genLines()
        {
            lines= new List<FunLine>();
            for(int i=0; i<40; i++)
            {
                lines.Add(new FunLine(rand.Next(25, 401), rand.Next(1, 10)));
            }
        }

        private void UI_BsortLenA_Click(object sender, EventArgs e)
        {
            lines.Sort();
            renderLines();
        }

        private void UI_BsortLenD_Click(object sender, EventArgs e)
        {
            lines.Sort(FunLine.DecComp);
            renderLines();
        }

        private void UI_BsortWA_Click(object sender, EventArgs e)
        {
            lines.Sort((a, b) => a.width - b.width); //Lambda for Width ascending
            renderLines();
        }

        private void UI_sortWidthHeight_Click(object sender, EventArgs e)
        {
            lines.Sort(FunLine.WinHComp);
            renderLines();
        }

        private void UI_TBlinehighlight_Scroll(object sender, EventArgs e)
        {
            List<FunLine> linesH = new List<FunLine>(); //Lambda for clear and set highlights
            lines.ForEach((l) => l.highlight = false);
            linesH = lines.FindAll((l) => (l.length < UI_TBlinehighlight.Value+5 && l.length > UI_TBlinehighlight.Value-5));
            linesH.ForEach((l) => l.highlight = true);
            renderLines();
        }

        private void UI_BRemoveLongLine_Click(object sender, EventArgs e)
        {
            lines.RemoveAll((l) => l.length > longLimit); //Long lines lambda
            renderLines();
            setMinMax();
        }

        private void UI_Rstubbyline_Click(object sender, EventArgs e)
        {
            lines.RemoveAll(FunLine.StubbyLine);
            renderLines();
            setMinMax();
        }

        private void setMinMax()
        {
            UI_TBlinehighlight.Minimum = lines.Min((l) => l.length);
            UI_TBlinehighlight.Maximum = lines.Max((l) => l.length);
        }
    }
}
