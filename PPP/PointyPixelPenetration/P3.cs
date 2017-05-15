//***********************************************************************************
//Program:					Pointy Pixel Penetration
//                          Main form
//Description:	            Creates Shape objects on a windows form and checks collision between them.
//Date:						Feb 10th 2017
//Authors:					Alexander Schneider
//Course:					CMPE2700
//Class:					CNTA02
//***********************************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace PointyPixelPenetration
{
    public partial class P3 : Form
    {
        //LinkedList of all the shapes in the field.
        private LinkedList<ShapeBase> _shapes = new LinkedList<ShapeBase>();
        //LinkedList of all the intersect areas in the field.
        private LinkedList<Region> _intersect = new LinkedList<Region>();
        //Random for the addition of 1000 shapes at once.
        private static Random _rand = new Random();
        public P3()
        {
            InitializeComponent();
        }

        /// /////////////////
        /// If mouse is clicked, add either rocks if shift was held
        /// or triangles if not.
        /// /////////////////
        private void P3_MouseClick(object sender, MouseEventArgs e)
        {
            addShapes(e);
        }

        /// ///////////////////
        /// Timer tick. Function will tick all the shapes in _shapes,
        /// Check distance for possible collision and the check for intersections.
        /// Intersecting shapes are removed. Close shapes are highlighted.
        /// Renders all the shapes and intersections.
        /// //////////////////
        private void UI_Tshape_Tick(object sender, EventArgs e)
        {
            //Graphics to draw on
            Graphics g;
            //LinkedList of all the shapes to test for collision.
            LinkedList<ShapeBase> testShapes;
            //List of all shapes that are in a collision test. To be rendered as a region
            List<ShapeBase> cTest = new List<ShapeBase>();
            //Region to hold information to render.
            Region cReg;
            //Width and height of the shape area
            int width = ClientSize.Width;
            int height = ClientSize.Height;

            g = CreateGraphics();

            //Go through every shape and tick them.
            foreach (ShapeBase shape in _shapes)
            {
                shape.Tick(width, height);
            }
            //Fill testShapes with the list of all shapes.
            testShapes = new LinkedList<ShapeBase>(_shapes);
            //Go through every shape in the new list.
            for (int i = 0; i < testShapes.Count; i++)
            {
                //If any of the shapes are close together, find them excluding itself.
                var close = from n in testShapes
                            where (distance(testShapes.ElementAt(i)._pos, n._pos)) < (ShapeBase._tileSize)
                            where testShapes.ElementAt(i) != n
                            select n;
                //If close has objects in it, time to check for collision.
                if (close.Count() > 0)
                {
                    //Union the list to the list of all current collision checks.
                    cTest = cTest.Union(close.ToList()).ToList();
                    //Add the current shape as it is not in the collection.
                    cTest.Add(testShapes.ElementAt(i));
                    //Check if any of the shapes are intersecting and adds them to a new collection.
                    var intersect = from n in close
                                    where !((intersectRet(n.GetPath(), testShapes.ElementAt(i).GetPath())).IsEmpty(g))
                                    select n;
                    //If intersections were found
                    if (intersect.Count() > 0)
                    {
                        foreach (ShapeBase inter in intersect)
                        {
                            //Add intersections to the list of all intersections
                            _intersect.AddLast(intersectRet(inter.GetPath(), testShapes.ElementAt(i).GetPath()));
                            //Remove the objects colliding from the list of all shapes.
                            _shapes.Remove(inter);
                        }
                        //Remove the current shape as it was intersecting from the list.
                        _shapes.Remove(testShapes.ElementAt(i));
                    }
                }
                //Remove the current shape from the temp list of all shapes.
                if (testShapes.Count > 0)
                    testShapes.RemoveFirst();
                //Sets i to 0 so its basically a while loop??????
                i = 0;
            }

            //Use the BufferedGraphics to render stuff.
            using (BufferedGraphicsContext bgc = new BufferedGraphicsContext())
            {
                using (BufferedGraphics bg = bgc.Allocate(CreateGraphics(), ClientRectangle))
                {
                    
                    //Add all intersections to the draw area.
                    foreach (Region reg in _intersect)
                    {
                        bg.Graphics.FillRegion(new SolidBrush(Color.Yellow), reg);
                    }

                    //Add all shapes to the draw area.
                    foreach (ShapeBase shape in _shapes)
                    {
                        if (shape is Rock)
                            shape.Render(Color.Brown, bg);
                        //Then is a triangle
                        else
                            shape.Render(Color.Green, bg);
                    }

                    //Add regions for the collision checking shapes.
                    foreach(ShapeBase shape in cTest)
                    {
                        cReg = new Region(shape.GetPath());
                        bg.Graphics.FillRegion(new SolidBrush(Color.Goldenrod), cReg);
                    }
                    bg.Render();
                }
            }
        }

        /// /////////////////////
        /// Adds shapes to the list of shapes,
        /// If is left click, one rock where clicked.
        /// Right click is 1000 random shapes.
        /// Normal clicks make triangles.
        /// Shift clicks make rocks.
        /// /////////////////////
        private void addShapes( MouseEventArgs e)
        {
            //Position to add the shapes at
            PointF position;
            //Height and width of the area for random generation
            int width = ClientSize.Width;
            int height = ClientSize.Height;

            //Rightclick+shift = 1000 rocks
            //Rightclick = 1000 triangles
            if (e.Button == MouseButtons.Right)
            {
                if (Control.ModifierKeys == Keys.Shift)
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        position = new PointF((float)_rand.NextDouble() * width, (float)_rand.NextDouble() * height);
                        _shapes.AddLast(new Rock(position));
                    }
                }
                else
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        position = new PointF((float)_rand.NextDouble() * width, (float)_rand.NextDouble() * height);
                        _shapes.AddLast(new Triangle(position));
                    }
                }
            }
            //Rightclick+shift = 1000 rocks
            //Rightclick = 1000 triangles
            else
            {
                if (Control.ModifierKeys == Keys.Shift)
                    _shapes.AddLast(new Rock(e.Location));
                else
                    _shapes.AddLast(new Triangle(e.Location));
            } 
        }
        /// ////////////////
        ///Calculates the distance between two points.
        /// ////////////////
        private float distance(PointF posA, PointF posB)
        {
            return Math.Abs((float)Math.Sqrt((Math.Pow((posA.X - posB.X), 2) + Math.Pow((posA.Y - posB.Y), 2))));
        }  

        /// //////////////////////
        /// Takes two grapicspaths, returns the intersection region of it
        /// //////////////////////
        private Region intersectRet(GraphicsPath firstPath, GraphicsPath secondPath)
        {
            Region reg = new Region(firstPath);
            reg.Intersect(secondPath);
            return reg;
        }
    }
}
