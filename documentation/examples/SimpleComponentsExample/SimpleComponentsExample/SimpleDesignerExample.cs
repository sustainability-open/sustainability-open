/// This file implements a simple designer

/// Note the inclusion of the framework in the reference
using SustainabilityOpen.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// The namespace can be whatever you want it to be
namespace SimpleComponentsExample
{
    /// <summary>
    /// Class overrides from the SODesigner class
    /// </summary>
    public class SimpleDesignerExample : SODesigner
    {
        /// <summary>
        /// Constructor
        /// Note the name assessment you will need to pass to the base class.
        /// </summary>
        public SimpleDesignerExample()
            : base("simple_designer_0001")
        {
        }
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
}
