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

/// This file implements the Grasshopper component for the designer with input

/// Note the inclusion of the Grasshopper framework in the reference
using SustainabilityOpen.Grasshopper;
using GH = Grasshopper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// The namespace can be whatever you want it to be
namespace ComponentsWithInputExample.Grasshopper
{
    /// <summary>
    /// The component class implements the SODesigner_Component class
    /// </summary>
    public class DesignerWithInputExample_Component : SODesigner_Component
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public DesignerWithInputExample_Component()
            : base("DesignerWithInput", "DesignerWithInput", "Register a simple designer", new DesignerWithInputExample())
        {
        }
        /// <summary>
        /// You will need to override this method to register the inputs for the designer.
        /// </summary>
        /// <param name="pManager">Grasshopper's input parameter manager</param>
        protected override void RegisterInputParams(GH.Kernel.GH_Component.GH_InputParamManager pManager)
        {
            base.RegisterInputParams(pManager);
            pManager.AddIntegerParameter("n", "n", "number of beams", GH.Kernel.GH_ParamAccess.item);
        }
        /// <summary>
        /// You will need to override this method to register the outputs for the designer.
        /// </summary>
        /// <param name="pManager">Grasshopper's output parameter manager</param>
        protected override void RegisterOutputParams(GH.Kernel.GH_Component.GH_OutputParamManager pManager)
        {
            // Note that you will need to call the RegisterOutputParams method of the base class to register the default output parameters.
            base.RegisterOutputParams(pManager);
        }
        /// <summary>
        /// You will need to override this method to solve the component.
        /// </summary>
        /// <param name="DA">Grasshopper's DataAccess interface</param>
        protected override void SolveInstance(GH.Kernel.IGH_DataAccess DA)
        {
            // first set the properties in the SODesigner
            int n = 0;
            if (DA.GetData<int>(1, ref n))
            {
                ((DesignerWithInputExample)this.Designer).NumberOfBeams = n;
            }

            /// Note that you will need to call the SolveInstance method of the base class to process the default parameters and connect them to the framework.
            base.SolveInstance(DA);        
        }
        /// <summary>
        /// You will need to override this Guid with an unique identifier for each class.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("{EC4F4CA8-D068-4636-A335-FB375894077E}"); }
        }

    }
}
