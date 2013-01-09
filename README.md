sustainability-open
===================
(c) Copyright BEMNext Lab and contributors
Open framework for sustainability assessment and optimisation in the built environment
Version 0.0.1



Quick example of a framework component
======================================

The example below shows some fragments how a designer component would be implemented in the framework. Note that the (overridden) components of the framework do the actual work. Wrapper components make sure these
components can communicate with the different applications.

```C#
...
    /// <summary>
    /// Class overrides from the SODesigner class
    /// </summary>
    public class SimpleDesignerExample : SODesigner
    {
...
        /// <summary>
        /// Overriding the RunDesigner method.
        /// This method will be run by the framework to make the design.
        /// </summary>
        public override void RunDesigner()
        {
            // Adding two beams with the designer
            this.AddObject(new Beam_HE200A());
            this.AddObject(new Beam_HE200A());
        }
    }
...
```

Quick example of a Grasshopper component
========================================

The framework component is wrapped in a Grasshopper component so that it can be used by Grasshopper, see the example below.

```C#
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
```

License
=======
Please note that LICENSE file in this directory which describes the terms under which this code is released to you. The framework is accompanied by the following license:

Copyright 2012-2013 Delft University of Technology, BEMNext Lab and contributors

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
