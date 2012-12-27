using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SustainabilityOpen.Framework
{
    public class SODesigner : SOBase
    {
        private List<SOPhysicalObject> m_ResultingObjects;

        public SODesigner(string name) : base(name)
        {
            this.m_ResultingObjects = new List<SOPhysicalObject>();
        }

        public void AddObject(SOPhysicalObject physicalObject)
        {
            this.m_ResultingObjects.Add(physicalObject);
        }

        /// <summary>
        /// Runs the designer. Override this method to make the designer do some work.
        /// </summary>
        public virtual void RunDesigner()
        {
        }

        public SOPhysicalObject[] PhysicalObjects
        {
            get { return this.m_ResultingObjects.ToArray(); }
        }
    }
}
