using System;
using System.Collections.Generic;
using Rhino;
using Rhino.Commands;
using Rhino.Geometry;
using Rhino.Input;
using Rhino.Input.Custom;

namespace MyRhinoPlugin1
{
    public class MyRhinoPlugin1Command : Command
    {
        public MyRhinoPlugin1Command()
        {
            // Rhino only creates one instance of each command class defined in a
            // plug-in, so it is safe to store a refence in a static property.
            Instance = this;
        }

        ///<summary>The only instance of this command.</summary>
        public static MyRhinoPlugin1Command Instance { get; private set; }

        ///<returns>The command name as it appears on the Rhino command line.</returns>
        public override string EnglishName => "MyRhinoPlugin1Command";

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            RhinoGet.GetLine(out Line line);

            var lineCurve = new LineCurve(line);
            var myCurveObject = new MyCurveObject(lineCurve);
            doc.Objects.AddRhinoObject(myCurveObject, lineCurve);

            return Result.Success;
        }
    }
}
