using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Display;
using Rhino.DocObjects;
using Rhino.DocObjects.Custom;
using Rhino.Geometry;

namespace MyRhinoPlugin1
{
    internal class MyCurveObject : CustomCurveObject
    {
        public MyCurveObject()
        {
        }

        public MyCurveObject(Curve curve) : base(curve)
        {
        }

        public MyCurveObject(CurveObject curveObject) : this(curveObject.CurveGeometry)
        {

        }

        protected override void OnDraw(DrawEventArgs e)
        {
            Color color = GenerateRandomColor();
            e.Display.DrawCurve(CurveGeometry, color, 2);
            e.Display.DrawPoint(CurveGeometry.PointAtStart, PointStyle.X, 10, color);
            //base.OnDraw(e);
        }

        public static Color GenerateRandomColor()
        {
            var random = new Random();

            int red = random.Next(0, 255);
            int green = random.Next(0, 255);
            int blue = random.Next(0, 255);

            return Color.FromArgb(red, green, blue);
        }
    }
}
