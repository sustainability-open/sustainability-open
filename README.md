sustainability-open
===================
(c) Copyright BEMNext Lab and contributors
Open framework for sustainability assessment and optimisation in the built environment
Version 0.0.1

SustainabilityOpen is an initiative to make the built environment a better place. By providing open-source tooling to the building industry we hope to stimulate that every building and structure will become more sustainable. We are also trying to deploy new and quantitative approaches to assess sustainability in an open-source environment.

By providing you, in case you are representing a company or yourself, with an open-source, free-to-use software framework which you can use to build your own design, analysis and assessment tools for sustainable design, there really is no reason anymore why you shouldn’t design in a sustainable manner, or at least analyse and assess your building. 

The mission is to collaboratively research and build a toolkit that includes many analysis and assessment methods, many components that help with automated design and link to many mainstream software applications, such parametric software applications, BIM applications and geometrical design software.

How does it work?
=================

SustainabilityOpen (or sustainability-open) consists of

 1. The framework
 2. Implemented components

The framework is provided by us for you to use, but it doesn’t do a lot. It only lays the computational infrastructure for others to use. You will need implemented components to use the framework. These components you are either build yourself or download from the internet if they are build by others.

The framework consists of a number of abstract classes, which we call components, which need to be overridden in order to do something. There are three types:

 1. Designers: Designers produce a ‘design’ on which the analysis and assessment components can work.
 2. Analysis components: the analysis components take in a number of design components that aggregated contain the design and perform one or more analyses on the design. The analysis components produce an output for assessment components to use. An example could be an analysis that adds up all materials into their total quantities.
 3. Assessment components: The assessment components take a number of analysis outputs in and perform one or more assessments to produce an assessment result. An example could be an assessment that calculates the total embodied energy in the design from the material quantities.

At the moment there is one special helper component in the framework, the QTOAnalysis, which actually does some work. QTOAnalysis stands for Quantity Take Off Analysis. We have added this component to the framework as we expect that almost any project will use this component. In the future more helper components might be added to the framework.

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

Requirements
============

The framework and components have been designed to be build against Rhinoceros 5.0 and Grasshopper 9. You will need these applications to use the framework.

Installation instructions
=========================

To install the tools, simply download the latest zip file, unzip it in a directory of your choice and point your Grasshopper installation to that directory. The components will become available under the SustainabilityOpen tab in Grasshopper.

Documentation
=============

Documentation can be found in the documentation directory of the repository or on the website: http://www.sustainability-open.com/docs

License
=======
```txt
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
```
