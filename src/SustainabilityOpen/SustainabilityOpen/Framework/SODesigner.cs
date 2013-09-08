/// Copyright 2012-2013 Delft University of Technology, BEMNext Lab and contributors
/// 
///    Licensed under the Apache License, Version 2.0 (the "License");
///    you may not use this file except in compliance with the License.
///    You may obtain a copy of the License at
/// 
///        http://www.apache.org/licenses/LICENSE-2.0
/// 
///    Unless required by applicable law or agreed to in writing, software
///    distributed under the License is distributed on an "AS IS" BASIS,
///    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
///    See the License for the specific language governing permissions and
///    limitations under the License.
/// 

using SustainabilityOpen.Framework.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SustainabilityOpen.Framework
{
    /// <summary>
    /// Designer entity
    /// </summary>
    public class SODesigner : SOComponent
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
            if (this.m_ResultingObjects == null) { this.m_ResultingObjects = new List<SOPhysicalObject>(); }

            this.m_ResultingObjects.Add(physicalObject);
        }

        /// <summary>
        /// Clears the physical objects from the designers
        /// </summary>
        public void ClearObjects()
        {
            if (this.m_ResultingObjects == null) { return; }
            this.m_ResultingObjects.Clear();
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
