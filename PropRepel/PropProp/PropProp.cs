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

namespace PropProp
{
    public partial class PropProp : Form
    {

        private CDrawer canvas = new CDrawer();     //Canvas for drawing.
        private List<Ball> balls = new List<Ball>();  //List of all balls on screen.

        public PropProp()
        {
            InitializeComponent();
        }

        //Set GDI to continuous update on launch.
        private void PropProp_Load(object sender, EventArgs e)
        {
            canvas.ContinuousUpdate = false;
        }

        /*Timer has to
        1. Check for new clicks to add new balls, left click orange, right click purple.
        2. Check each balls love or hate on all the other balls, but not itself.
        3. Remove balls that have left the screen.
        4. Render the balls at the end.*/
        private void UI_Btimer_Tick(object sender, EventArgs e)
        {
            Point ballPoint;
            canvas.Clear();
            //Check mouse clicks for right and left to add balls.
            if (canvas.GetLastMouseLeftClick(out ballPoint))
            {
                balls.Add(new Ball(ballPoint, bColor.orange));
            }
            if (canvas.GetLastMouseRightClick(out ballPoint))
            {
                balls.Add(new Ball(ballPoint, bColor.purple));
            }
            //Double loop to check every ball for love/hate relationship.
            for(int mainBall=0; mainBall < balls.Count; mainBall++)
            {
                for (int  altBall= 0; altBall < balls.Count; altBall++)
                {
                    //If the mainball and altball are not the same ball.
                    if (mainBall != altBall)
                    {
                        //If colors are equal, hate relationship to push away.
                        if (balls[mainBall].ballColor == balls[altBall].ballColor)
                        {
                            balls[mainBall].hate = balls[altBall];
                        }
                        //Else love relationship, drawn together.
                        else
                        {
                            balls[mainBall].love = balls[altBall];
                        }
                    }
                }
                //If the thing has left the screen, remove from list.
                if (balls[mainBall].position.X > 799 || balls[mainBall].position.X<0 || balls[mainBall].position.Y>599 || balls[mainBall].position.Y < 0)
                {
                    balls.RemoveAt(mainBall);
                    mainBall--;
                }
            }
            //Render balls
            foreach (Ball ball in balls)
            {
                ball.render(canvas);
            }
            canvas.Render();
        }
    }
}
