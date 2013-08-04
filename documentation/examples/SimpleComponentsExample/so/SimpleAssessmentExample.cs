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

/// This file implements a simple assessment
/// Please note that this component does not perform a real embodied energy assessment
/// as the factors are not real factors. The example is just a numerical example.

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
        // Please note that these factors are dummies and not real factors.
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
