//***********************************************************************************
//Program:					Lab3 - PolyRel: Shape class
//Description:	            Creates a hierarchy of shapes.
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

namespace Lab3___PolyRel
{
    public interface IRender
    {
        // render instance to the supplied drawer
        void Render(CDrawer dr);
    }
    public interface IAnimate
    {
        // cause per-tick state changes to instance (movement, animation, etc...)
        void Tick();
    }
    public abstract class Shape : IRender
    {
        public PointF pos { get; protected set; } //The shapes current positon
        protected Color color;  //The shapes color
        protected Shape parent { get; set; }    //If the shape has a parent.
        //Constructor to set the three things.
        public Shape(PointF _pos, Color _color, Shape _parent = null)
        {
            pos = _pos;
            color = _color;
            parent = _parent;
        }
        //Render will draw a line from the parent to the shape if it has one.
        public virtual void Render(CDrawer dr)
        {
            if (parent != null)
                dr.AddLine((int)pos.X, (int)pos.Y, (int)parent.pos.X, (int)parent.pos.Y, Color.White);
        }
    }
    //Fixed shape. Uses Shape and only adds shape to render method.
    public class FixedSquare : Shape
    {
        public FixedSquare(PointF _pos, Color _color, Shape _shape)
            : base(_pos, _color, _shape)
        {
        }
        //Draws a rectangle at the position, size 20.
        public override void Render(CDrawer dr)
        {
            dr.AddCenteredRectangle((int)pos.X, (int)pos.Y, 20, 20, color);
            base.Render(dr);
        }
    }

    //Part of shapes with animation, adds 
    //SeqVal - value of the current animation sequence.
    //seqDelta - value the seqVal changes by.
    //Adds tick function which changes the seqValue by seqDelta
    public abstract class AniShape : Shape, IAnimate
    {
        protected double seqVal;
        protected double seqDelta;

        public AniShape(PointF _pos, Color _color, Shape _shape, double _seqVal, double _seqDelta)
            : base(_pos, _color, _shape)
        {
            seqVal = _seqVal;
            seqDelta = _seqDelta;
        }
        public virtual void Tick()
        {
            seqVal += seqDelta;
        }
    }

    //A spinning poly shape.
    //Takes Anishape as well as new sides.
    public class AniPoly : AniShape
    {
        protected int sides;
        public AniPoly(PointF _pos, Color _color, int _sides, Shape _shape, double _seqDelta, double _seqVal=-1)
            : base(_pos, _color, _shape, _seqVal, _seqDelta)
        {
            //Must have 3 sides to render.
            if (_sides < 3)
                throw new ArgumentException("Polygon needs atleast 3 sides!");
            sides = _sides;
        }
        public override void Render(CDrawer dr)
        {
            dr.AddPolygon((int)pos.X, (int)pos.Y, 20, sides, seqVal);
            base.Render(dr);
            Tick();
        }
    }
    //Animated child class. Must have a parent of cannot work.
    //Positioni set to 0,0 in :base constructor and set to parents position.
    public abstract class AniChild : AniShape
    {
        protected double distP { get; set; }
        public AniChild(Color _color, double _dist, Shape _shape, double _seqDelta, double _seqVal = -1)
            : base(new PointF(0,0) , _color, _shape, _seqVal, _seqDelta)
        {
            if (_shape == null)
                throw new ArgumentException("AniChild needs atleast a non null parent!");
            distP = _dist;
            pos = parent.pos;
        }
    }

    //Anihighligh.
    //Highlighs a block by having a ball wobble on the XY plane.
    //Doesnt draw a line from ball to parent.
    public class AniHighlight : AniChild
    {
        public AniHighlight(Color _color, double _dist, Shape _shape, double _seqDelta, double _seqVal = -1) 
            : base( _color, _dist, _shape, _seqVal, _seqDelta)
        {
        }

        public override void Render(CDrawer dr)
        {
            Tick();
            dr.AddCenteredEllipse((int)pos.X, (int)pos.Y, 8, 8, color);
        }

        public override void Tick()
        {
            base.Tick();
            pos = new PointF(parent.pos.X + (float)(Math.Sin(seqVal) * distP), parent.pos.Y + (float)(Math.Sin(seqVal) * distP));
        }
    }

    //AniBall. Update render to call tick for movement on every render.
    //And draws the ball
    public abstract class AniBall : AniChild
    {
        public AniBall(Color _color, double _dist, Shape _shape, double _seqDelta, double _seqVal = -1) : base(_color, _dist, _shape, _seqVal, _seqDelta){}

        public override void Render(CDrawer dr)
        {           
            Tick();
            dr.AddCenteredEllipse((int)pos.X, (int)pos.Y, 20, 20, color);
            base.Render(dr);
        }
    }

    //Sets the tick so the ball animates moving in a vertical wobble
    public class VWobbleBall : AniBall
    {
        public VWobbleBall(Color _color, double _dist, Shape _shape, double _seqDelta, double _seqVal = -1) : base(_color, _dist, _shape, _seqVal, _seqDelta){}

        public override void Tick()
        {
            pos = new PointF(parent.pos.X, parent.pos.Y + (float)(Math.Sin(seqVal)*distP));
            base.Tick();
        }
    }

    //Sets the tick so the ball animates moving in a horizontal wobble
    public class HWobbleBall : AniBall
    {
        public HWobbleBall(Color _color, double _dist, Shape _shape, double _seqDelta, double _seqVal = -1) : base(_color, _dist, _shape, _seqVal, _seqDelta){}

        public override void Tick()
        {
            pos = new PointF(parent.pos.X + (float)(Math.Sin(seqVal) * distP), parent.pos.Y);
            base.Tick();
        }
    }

    //Sets the tick so the ball animates moving in an orbit around its parent
    public class OrbitBall : AniBall
    {
        public OrbitBall(Color _color, double _dist, Shape _shape, double _seqDelta, double _seqVal = -1) : base(_color, _dist, _shape, _seqVal, _seqDelta) { }

        public override void Tick()
        {
            base.Tick();
            pos = new PointF(parent.pos.X + (float)(Math.Cos(seqVal) * distP), parent.pos.Y + (float)(Math.Sin(seqVal) * distP));
        }
    }
}
