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

/// This file implements a simple designer with input

/// Note the inclusion of the framework in the reference
using SustainabilityOpen.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// The namespace can be whatever you want it to be
namespace ComponentsWithInputExample
{
    /// <summary>
    /// Class overrides from the SODesigner class
    /// </summary>
    public class DesignerWithInputExample : SODesigner
    {
        // Variable to store the number of beams in
        private int m_NumberOfBeams;

        /// <summary>
        /// Constructor
        /// Note the name assessment you will need to pass to the base class.
        /// </summary>
        public DesignerWithInputExample()
            : base("simple_designer_0002")
        {
            this.m_NumberOfBeams = 0;
        }
        /// <summary>
        /// Overriding the RunDesigner method.
        /// This method will be run by the framework to make the design.
        /// </summary>
        public override void RunDesigner()
        {
            for (int i = 0; i < this.m_NumberOfBeams; i++)
            {
                this.AddObject(new Beam_HE300A());
            }
        }

        /// <summary>
        /// Getter and setter for number of beams
        /// </summary>
        public int NumberOfBeams
        {
            get { return this.m_NumberOfBeams; }
            set { this.m_NumberOfBeams = value; }
        }
    }
}
