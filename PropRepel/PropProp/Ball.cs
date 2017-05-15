using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace PropProp
{
    //Enum to define ball colors.
    public enum bColor { purple, orange};

    //Ball class to hold information for thta bal
    public class Ball
    {
        private PointF pos; //Position of the ball
        private bColor color;   //color of the ball

        private int B_SIZE = 25;    //Size of the balls

        //Constructor that takes PointF for position, bColor for color
        public Ball(PointF _pos, bColor _color)
        {
            pos = _pos;
            color = _color;
        }
        //Getter for ballColor
        public bColor ballColor
        {
            get
            {
                return color;
            }
        }
        //Getter and private setter for ball position.
        public PointF position
        {
            get
            {
                return pos;
            }
            private set
            {
                pos = value;
            }
        }
        //Changes ball trajectory based on love relationship, where opposites attract.
        public Ball love
        {
            set
            {
                pos = new PointF((pos.X - ((pos.X-value.position.X) / 250)), pos.Y + ((value.position.Y-pos.Y)/250));
            }
        }

        //Changes ball trajectory on hate, where same color repels.
        public Ball hate
        {
            set
            {
                pos = new PointF((pos.X + ((pos.X-value.position.X)/250)), pos.Y - ((value.position.Y-pos.Y) / 250));
            }
        }
        //Render the ball with the correct color.
        public void render(CDrawer canvas)
        {
            if (color == bColor.purple)
            {
                canvas.AddCenteredEllipse((int)pos.X, (int)pos.Y, B_SIZE, B_SIZE, Color.Purple, 2, Color.Black);
            }
            else
                canvas.AddCenteredEllipse((int)pos.X, (int)pos.Y, B_SIZE, B_SIZE, Color.Orange, 2, Color.Black);
        }
    }
}
