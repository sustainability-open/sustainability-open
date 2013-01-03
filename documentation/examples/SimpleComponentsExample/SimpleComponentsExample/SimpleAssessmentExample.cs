/// This file implements a simple assessment

/// Note the inclusion of the framework in the reference
using SustainabilityOpen.Framework;

// For this assessment we will be using the quantity take-off.
using SustainabilityOpen.QTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// The namespace can be whatever you want it to be
namespace SimpleComponentsExample
{
    /// <summary>
    /// Class overrides from the SOAssessment class
    /// </summary>
    public class SimpleAssessmentExample : SOAssessment
    {
        private const double EMBODIEDENERGY_CONCRETE = 3.0;
        private const double EMBODIEDENERGY_STEEL = 2.0;

        private double m_EmbodiedEnergy;

        /// <summary>
        /// Constructor
        /// </summary>
        public SimpleAssessmentExample()
            : base("test_assessment_0001")
        {
            this.m_EmbodiedEnergy = 0.0;
        }

        /// <summary>
        /// Overriding the RunAssessment method.
        /// This method will be run by the framework to run the assessment.
        /// </summary>
        public override void RunAssessment()
        {
            this.m_EmbodiedEnergy = 0.0;
            foreach (SOAnalysis item in this.Analyses)
            {
                if (item.GetType().Equals(typeof(QTOAnalysis)))
                {
                    foreach (SOMaterialQuantity quantity in ((QTOAnalysis)item).Quantities)
                    {
                        if (quantity.Material.Name.Equals("concrete")) { this.m_EmbodiedEnergy += quantity.Quantity * EMBODIEDENERGY_CONCRETE; }
                        if (quantity.Material.Name.Equals("steel")) { this.m_EmbodiedEnergy += quantity.Quantity * EMBODIEDENERGY_STEEL; }
                    }
                }
            }
        }
        /// <summary>
        /// Returns the embodied energy
        /// </summary>
        public double EmbodiedEnergy
        {
            get { return this.m_EmbodiedEnergy; }
        }
    }
}
