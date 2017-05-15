//***********************************************************************************
//Program:					Lab3 - PolyRel: Virus class
//Description:	            Creates a fungus/virus in the background that moves to positions close by not visited often.
//Date:						Dec 9th
//Authors:					Alexander Schneider
//Course:					CMPE2300
//Class:					CNTA01
//***********************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;
using System.Threading;

namespace Lab3___PolyRel
{
    class Virus
    {
        static Random rand = new Random(); //Static random for all the virus to use.
        public enum color { Red, Blue, Green }; //Enum for which color is being used
        private color vColor;   //Enum for each virus.
        private Dictionary<Point, int> points = new Dictionary<Point, int>(); //Hols all the points visited and their values
        private CDrawer dr; //Drawer to draw on
        private Point curPos;   //Position of the virus currently
        private Thread T;   //Thread to start the virus
        
        //Constructor takes a tart point, drawer and a color
        public Virus(Point _start, CDrawer _dr, color _color)
        {
            curPos = _start;
            dr = _dr;
            vColor = _color;

            T = new Thread(multiply);
            T.IsBackground = true;
            T.Start();
        }

        //Multiply.
        //Gets a list of points that are valid, shuffles them to go randomly
        //Finds the least visited out of the points and goes that direction.
        private void multiply()
        {
            List<Point> newPoints; //List for the new points
            Dictionary<Point, int> dicPoints;   //Dictionary for the points with their color values
            //Thread to loop forever for virus life.
            while(true){
                newPoints = findPoints(); //Finds valid points
                newPoints = shufflePoints(newPoints);   //Shuffles list of points
                //Convert list to dictionary. If virus dic contains point, get value else set to 0.
                dicPoints = newPoints.ToDictionary((o) => (o), (o) => (points.ContainsKey(o) ? points[o] : 0));
                //Order by to find lowest visited points by value.
                dicPoints = dicPoints.OrderBy((o) => o.Value).ToDictionary(o => o.Key, (o => o.Value));
                //Set position to first point.
                curPos = dicPoints.First().Key;
                //If point is in visited points, add 16
                //else add new point at 32
                if (points.ContainsKey(curPos))
                {
                    if (points[curPos] < 225) {
                        points[curPos] += 16;
                    }
                }
                else
                {
                    points.Add(curPos, 32);
                }
                //Depending on virus color, add pixel to background buffer of drawer.
                if (vColor == color.Red)
                    dr.SetBBPixel(curPos.X, curPos.Y, Color.FromArgb(points[curPos], 0, 0));
                else if (vColor == color.Green)
                    dr.SetBBPixel(curPos.X, curPos.Y, Color.FromArgb(0, points[curPos], 0));
                else
                    dr.SetBBPixel(curPos.X, curPos.Y, Color.FromArgb(0, 0, points[curPos]));
                //Sleep for a small amount.
                Thread.Sleep(0);
            }
        }
        //Find points.
        //Takes a point and finds the 8 points around it
        //Removes ones that  leave the drawer.
        public List<Point> findPoints()
        {
            List<Point> newPoints = new List<Point>();
            for(int x=-1; x<2; x++)
            {
                for (int y=-1; y<2; y++)
                {
                    if (!(x==0 && y == 0))
                    {
                        newPoints.Add(new Point(curPos.X+x, curPos.Y+y));
                    }
                }
            }
            newPoints.RemoveAll((o) => o.X < 0 || o.Y < 0 || o.X > 999 || o.Y > 999);
            return newPoints;
        }

        //Shuffle the list of points with a Fisher-Yates shuffle
        public List<Point> shufflePoints(List<Point> points)
        {
            int rnd;
            Point temp;
            for (int i=points.Count()-1; i>0; i--)
            {
                //Lock RAND to prevent multiple virus getting same value.
                lock (rand)
                {
                    rnd = rand.Next(0, i+1);
                }
                temp = points[i];
                points[i] = points[rnd];
                points[rnd] = temp;
            }
            return points;
        }
    }
}
