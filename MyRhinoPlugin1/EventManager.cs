using System;
using Rhino;
using Rhino.DocObjects;

namespace MyRhinoPlugin1
{
    internal class EventManager
    {
        private Guid lastDeletedId { get; set; } = Guid.Empty;
        public EventManager()
        {
            RhinoDoc.AddRhinoObject += RhinoDoc_AddRhinoObject;
            RhinoDoc.DeleteRhinoObject += RhinoDoc_DeleteRhinoObject;
        }

        private void RhinoDoc_DeleteRhinoObject(object sender, RhinoObjectEventArgs e)
        {
            if (e.TheObject is MyCurveObject)
                lastDeletedId = e.ObjectId;
        }

        private void RhinoDoc_AddRhinoObject(object sender, RhinoObjectEventArgs e)
        {
            if (lastDeletedId == Guid.Empty ||
                e.TheObject is MyCurveObject)
            {
                // Do nothing
            }
            else if (e.ObjectId == lastDeletedId && e.TheObject is CurveObject curveObject)
            {
                MyCurveObject myCurveObject = new MyCurveObject(curveObject);
                ObjRef objRef = new ObjRef(RhinoDoc.ActiveDoc, e.ObjectId);
                RhinoDoc.ActiveDoc.Objects.Replace(objRef, myCurveObject);
            }

            lastDeletedId = Guid.Empty;
        }
    }
}
