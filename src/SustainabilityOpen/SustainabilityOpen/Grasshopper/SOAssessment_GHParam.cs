using Grasshopper.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SustainabilityOpen.Grasshopper
{
    public class SOAssessment_GHParam : GH_Param<SOAssessment_GHData>
    {
        public SOAssessment_GHParam()
            : base(new GH_InstanceDescription("Assessment parameter", "assessment", "Register an Assessment parameter", "", ""))
        {
        }
        public override GH_Exposure Exposure
        {
            get
            {
                return GH_Exposure.hidden;
            }
        }
        public override Guid ComponentGuid
        {
            get { return new Guid("{391336FB-D012-47CE-AC21-F0A10969C45C}"); }
        }
    }
}
