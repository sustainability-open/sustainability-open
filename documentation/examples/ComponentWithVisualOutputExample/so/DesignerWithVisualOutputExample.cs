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

/// This file implements a simple designer with a visual output

/// Note the inclusion of the framework in the reference
using SustainabilityOpen.Framework;
using SustainabilityOpen.Framework.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// The namespace can be whatever you want it to be
namespace ComponentWithVisualOutputExample
{
    /// <summary>
    /// Class overrides from the SODesigner class
    /// </summary>
    public class DesignerWithVisualOutputExample : SODesigner
    {
        public double Height = 1.0;
        public double Span = 10.0;
        public SOPoint3d basePoint = new SOPoint3d(0, 0, 0);
        private SOPoint3d point1;
        private SOPoint3d point2;
        private SOPoint3d point3;
        private SOPoint3d point4;

        /// <summary>
        /// Constructor
        /// Note the name assessment you will need to pass to the base class.
        /// </summary>
        public DesignerWithVisualOutputExample()
            : base("designer_with_visualoutput_0001")
        {
        }
        /// <summary>
        /// Overriding the RunDesigner method.
        /// This method will be run by the framework to make the design.
        /// </summary>
        public override void RunDesigner()
        {
            // It is important that you run the base designer
            base.RunDesigner();

            // Set up the points
            point1 = basePoint;
            point2 = new SOPoint3d(basePoint.X, basePoint.Y, basePoint.Z + Height);
            point3 = new SOPoint3d(basePoint.X, basePoint.Y + Span, basePoint.Z);
            point4 = new SOPoint3d(basePoint.X, basePoint.Y + Span, basePoint.Z + Height);

            // Adding a structure and two beams with the designer
            SOComponent structure = new SOComponent("structure");
            this.CurrentDesignAlternative.AddComponent(structure);

            // Adding a beam layer to the structure
            SOComponent beam = new SOComponent("beam_001");
            structure.AddSubComponent(beam);

            // Adding a beam to the beam layer
            beam.AddPart(new Beam_HE400A(point2, point4));

            // Adding a set of columns to the structure
            SOComponent columns = new SOComponent("columns_001");
            structure.AddSubComponent(columns);

            // Adding two columns to the column set
            columns.AddPart(new Beam_HE320A(point1, point2));
            columns.AddPart(new Beam_HE320A(point3, point4));
        }
        public SOPoint3d Point1
        {
            get { return this.point1; }
        }
        public SOPoint3d Point2
        {
            get { return this.point2; }
        }
        public SOPoint3d Point3
        {
            get { return this.point3; }
        }
        public SOPoint3d Point4
        {
            get { return this.point4; }
        }
    }
}
