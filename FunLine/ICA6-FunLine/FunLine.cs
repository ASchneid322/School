using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace ICA6_FunLine
{
    class FunLine:IComparable
    {
        public int length { private set; get; }
        public int width { private set; get; }
        public  bool highlight { set; get; }

        private const int stubbyLimit = 75;

        public FunLine(int _length, int _width)
        {
            length = _length;
            width = _width;
            highlight = false;
        }

        public void render(CDrawer canvas, Point pos)
        {
            if(highlight)
                canvas.AddRectangle(pos.X, pos.Y, width, length, Color.Yellow);
            else
                canvas.AddRectangle(pos.X, pos.Y, width, length, Color.Red);
        }

        public int CompareTo(object oLine) //Sort by length
        {
            if (!(oLine is FunLine))
                throw new ArgumentException("Invalid type on FunLine comparison!");

            FunLine fLine = (FunLine)oLine;
            return (length.CompareTo(fLine.length));
        }

        internal static int DecComp(FunLine A, FunLine B) //Descending Named Function
        {
            return (-1 * A.CompareTo(B));
        }

        internal static int WinHComp(FunLine A, FunLine B) //Width/Height lambda
        {

            int comparing = A.width.CompareTo(B.width);
            if (comparing != 0)
                return comparing;
            return (A.CompareTo(B));
        }

        internal static bool StubbyLine(FunLine A) //Remove stubby as functions
        {
            return (A.length < stubbyLimit);
        }
    }
}
