/// This file implements the Grasshopper component for the simple designer

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
    /// The component class implements the SODesigner_Component class
    /// </summary>
    public class SimpleDesignerExample_Component : SODesigner_Component
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public SimpleDesignerExample_Component()
            : base("SimpleDesigner", "SimpleDesigner", "Register a simple designer", new SimpleDesignerExample())
        {
        }
        /// <summary>
        /// You will need to override this method to register the inputs for the designer.
        /// </summary>
        /// <param name="pManager">Grasshopper's input parameter manager</param>
        protected override void RegisterInputParams(Grasshopper.Kernel.GH_Component.GH_InputParamManager pManager)
        {
            // does nothing
        }
        /// <summary>
        /// You will need to override this method to register the outputs for the designer.
        /// </summary>
        /// <param name="pManager">Grasshopper's output parameter manager</param>
        protected override void RegisterOutputParams(Grasshopper.Kernel.GH_Component.GH_OutputParamManager pManager)
        {
            // Note that you will need to call the RegisterOutputParams method of the base class to register the default output parameters.
            base.RegisterOutputParams(pManager);   
        }
        /// <summary>
        /// You will need to override this method to solve the component.
        /// </summary>
        /// <param name="DA">Grasshopper's DataAccess interface</param>
        protected override void SolveInstance(Grasshopper.Kernel.IGH_DataAccess DA)
        {
            /// Note that you will need to call the SolveInstance method of the base class to process the default parameters and connect them to the framework.
            base.SolveInstance(DA);
        }
        /// <summary>
        /// You will need to override this Guid with an unique identifier for each class.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("{303EAE03-EAFF-4379-ACFD-9ABAE9289E6D}"); }
        }

    }
}
