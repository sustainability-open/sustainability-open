// This file implements a steel HE200A beam

// Note the inclusion of the framework in the reference
using SustainabilityOpen.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// The namespace can be whatever you want it to be
namespace SimpleComponentsExample
{
    /// <summary>
    /// Class overrides the SOPhysicalObject class
    /// </summary>
    public class Beam_HE200A : SOPhysicalObject
    {
        /// <summary>
        /// Constructor
        /// Note the name of the physical object you will need to pass to the base class.
        /// </summary>
        public Beam_HE200A()
            : base("HE200A")
        {
            // Adding a material quantity to the beam of 1 m3 of the material steel.
            this.AddMaterialQuantity(new SOMaterial("steel"), 1, "m3");
        }

    }
}
