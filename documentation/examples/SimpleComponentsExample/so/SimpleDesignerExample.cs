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
