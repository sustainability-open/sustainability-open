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

/// This file implements the Grasshopper component for the designer with a visual output

/// Note the inclusion of the Grasshopper framework in the reference
using SustainabilityOpen.Grasshopper;
using GH = Grasshopper;
using Rhino.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// The namespace can be whatever you want it to be
namespace ComponentWithVisualOutputExample.Grasshopper
{
    /// <summary>
    /// The component class implements the SODesigner_Component class
    /// </summary>
    public class DesignerWithVisualOutputExample_Component : SODesigner_Component
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public DesignerWithVisualOutputExample_Component()
            : base(
                "DesignerWithVisualOutput", 
                "DesignerWithVisualOutput", 
                "Register a designer with visual output", 
                new DesignerWithVisualOutputExample()
                )
        {
        }
        /// <summary>
        /// You will need to override this method to register the inputs for the designer.
        /// </summary>
        /// <param name="pManager">Grasshopper's input parameter manager</param>
        protected override void RegisterInputParams(GH.Kernel.GH_Component.GH_InputParamManager pManager)
        {
            base.RegisterInputParams(pManager);
            pManager.AddPointParameter("p", "p", "Base point", GH.Kernel.GH_ParamAccess.item);
            pManager.AddNumberParameter("s", "s", "Span", GH.Kernel.GH_ParamAccess.item, 10.0);
            pManager.AddNumberParameter("h", "h", "Height", GH.Kernel.GH_ParamAccess.item, 1.0);
            pManager.AddIntegerParameter("n", "n", "Number of frames", GH.Kernel.GH_ParamAccess.item, 1);
            pManager.AddNumberParameter("sp", "sp", "Spacing", GH.Kernel.GH_ParamAccess.item, 1.0);
        }
        /// <summary>
        /// You will need to override this method to register the outputs for the designer.
        /// </summary>
        /// <param name="pManager">Grasshopper's output parameter manager</param>
        protected override void RegisterOutputParams(GH.Kernel.GH_Component.GH_OutputParamManager pManager)
        {
            // Note that you will need to call the RegisterOutputParams method of the base class to register the default output parameters.
            base.RegisterOutputParams(pManager);
            pManager.AddLineParameter("l", "l", "l", GH.Kernel.GH_ParamAccess.list);
        }
        /// <summary>
        /// You will need to override this method to solve the component.
        /// </summary>
        /// <param name="DA">Grasshopper's DataAccess interface</param>
        protected override void SolveInstance(GH.Kernel.IGH_DataAccess DA)
        {
            // Retrieve the data and pass it to the designer component
            Point3d point = new Point3d(0, 0, 0);
            double span = 10.0;
            double height = 1.0;
            int n = 1;
            double spacing = 1.0;
            if (DA.GetData<Point3d>(1, ref point))
            {
                ((DesignerWithVisualOutputExample)this.Designer).basePoint = new SOPoint3d(
                    point.X,
                    point.Y,
                    point.Z);
            }
            if (DA.GetData<double>(2, ref span)) 
            {
                ((DesignerWithVisualOutputExample)this.Designer).Span = span;
            }
            if (DA.GetData<double>(3, ref height))
            {
                ((DesignerWithVisualOutputExample)this.Designer).Height = height;
            }
            if (DA.GetData<int>(4, ref n))
            {
                ((DesignerWithVisualOutputExample)this.Designer).NumberOfFrames = n;
            }
            if (DA.GetData<double>(5, ref spacing))
            {
                ((DesignerWithVisualOutputExample)this.Designer).Spacing = spacing;
            }

            /// Note that you will need to call the SolveInstance method of the base class to process the default parameters and connect them to the framework.
            base.SolveInstance(DA);

            DesignerWithVisualOutputExample dsn = (DesignerWithVisualOutputExample)this.Designer;

            List<Line> lines = new List<Line>();
            for (int i = 0; i < dsn.NumberOfFrames; i++)
            {
                lines.Add(new Line(dsn.Points2[i].X, dsn.Points2[i].Y, dsn.Points2[i].Z, dsn.Points4[i].X, dsn.Points4[i].Y, dsn.Points4[i].Z));
                lines.Add(new Line(dsn.Points1[i].X, dsn.Points1[i].Y, dsn.Points1[i].Z, dsn.Points2[i].X, dsn.Points2[i].Y, dsn.Points2[i].Z));
                lines.Add(new Line(dsn.Points3[i].X, dsn.Points3[i].Y, dsn.Points3[i].Z, dsn.Points4[i].X, dsn.Points4[i].Y, dsn.Points4[i].Z));
            }
            DA.SetDataList(1, lines);
        }
        /// <summary>
        /// You will need to override this Guid with an unique identifier for each class.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("{5CC1185E-34D3-4AD2-A017-AE5171839BAB}"); }
        }

    }
}
