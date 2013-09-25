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
    public class SODesigner : SOParametricComponent
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of the designer</param>
        public SODesigner(string name) : base(name)
        {
        }

        /// <summary>
        /// Clears the attached designers from this designer
        /// </summary>
        public void ClearDesigners()
        {
            this.ClearParentsOfType(typeof(SODesigner));
        }

        /// <summary>
        /// Attaches a designer to this designer
        /// </summary>
        /// <param name="designer">Designer to add</param>
        public void AddDesigner(SODesigner designer)
        {
            this.AddParent(designer);
        }


        /// <summary>
        /// Runs the designer. Override this method to make the designer do some work.
        /// </summary>
        public virtual void RunDesigner()
        {
            if (SOController.Instance.State == SOController.ControllerState.new_solution)
            {
                SOController.Instance.Design.ClearDesign();
                SOController.Instance.SetState(SOController.ControllerState.first_designer_passed);
            }
        }

        /// <summary>
        /// Returns the current design alternative for the designer to use
        /// </summary>
        public SODesignAlternative CurrentDesignAlternative
        {
            get
            {
                return SOController.Instance.Design.CurrentAlternative;
            }
        }
        //public SODesigner[] Designers
        //{
        //    get { return null; }
        //}
    }
}
