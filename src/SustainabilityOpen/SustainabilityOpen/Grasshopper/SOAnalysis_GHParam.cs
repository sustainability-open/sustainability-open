using Grasshopper.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SustainabilityOpen.Grasshopper
{
    public class SOAnalysis_GHParam : GH_Param<SOAnalysis_GHData>
    {
        public SOAnalysis_GHParam()
            : base(new GH_InstanceDescription("Analysis parameter", "analysis", "Register an Analysis parameter", "", ""))
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
            get { return new Guid("{3AE77833-7435-439F-837C-785449ECF15E}"); }
        }
    }
}
