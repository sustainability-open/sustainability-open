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

/// This file implements the Grasshopper component for the simple assessment

/// Note the inclusion of the Grasshopper framework in the reference
using SustainabilityOpen.Grasshopper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// The namespace can be whatever you want it to be
namespace SimpleComponentsExample
{
    /// <summary>
    /// The component class implements the SOAssessment_Component class
    /// </summary>
    public class SimpleAssessmentExample_Component : SOAssessment_Component
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public SimpleAssessmentExample_Component()
            : base("AssessmentExample", "AssessmentExample", "Register an example assessment", new SimpleAssessmentExample())
        {
        }
        /// <summary>
        /// You will need to override this method to register the inputs for the designer.
        /// </summary>
        /// <param name="pManager">Grasshopper's input parameter manager</param>
        protected override void RegisterInputParams(Grasshopper.Kernel.GH_Component.GH_InputParamManager pManager)
        {
            // Note that you will need to call the RegisterInputParams method of the base class to register the default input parameters.
            base.RegisterInputParams(pManager);
        }
        /// <summary>
        /// You will need to override this method to register the outputs for the designer.
        /// </summary>
        /// <param name="pManager">Grasshopper's output parameter manager</param>
        protected override void RegisterOutputParams(Grasshopper.Kernel.GH_Component.GH_OutputParamManager pManager)
        {
            pManager.Register_DoubleParam("quantity", "q", "Material Quantity");
            pManager.Register_StringParam("textoutput", "t", "Textual Output");
        }
        /// <summary>
        /// You will need to override this method to solve the component.
        /// </summary>
        /// <param name="DA">Grasshopper's DataAccess interface</param>
        protected override void SolveInstance(Grasshopper.Kernel.IGH_DataAccess DA)
        {
            /// Note that you will need to call the SolveInstance method of the base class to process the default parameters and connect them to the framework.
            base.SolveInstance(DA);           
            
            DA.SetData(0, ((SimpleAssessmentExample)this.Assessment).EmbodiedEnergy);
            DA.SetData(1, "Embodied energy: " + ((SimpleAssessmentExample)this.Assessment).EmbodiedEnergy.ToString("0.00"));
        }
        /// <summary>
        /// You will need to override this Guid with an unique identifier for each class.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("{38D04219-C98E-4350-B074-B267B34ABFF4}"); }
        }
    }
}
