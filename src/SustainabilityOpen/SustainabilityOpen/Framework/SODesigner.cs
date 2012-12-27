using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SustainabilityOpen.Framework
{
    /// <summary>
    /// Designer entity
    /// </summary>
    public class SODesigner : SOBase
    {
        // Properties
        private List<SOPhysicalObject> m_ResultingObjects;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of the designer</param>
        public SODesigner(string name) : base(name)
        {
            this.m_ResultingObjects = new List<SOPhysicalObject>();
        }

        /// <summary>
        /// Add a physical object to the design solution
        /// </summary>
        /// <param name="physicalObject">Physical object to add</param>
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

        /// <summary>
        /// Returns all physical objects part of this designer
        /// </summary>
        public SOPhysicalObject[] PhysicalObjects
        {
            get { return this.m_ResultingObjects.ToArray(); }
        }
    }
}
