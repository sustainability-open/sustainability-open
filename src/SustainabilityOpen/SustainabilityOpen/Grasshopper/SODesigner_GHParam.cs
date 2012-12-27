using Grasshopper.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SustainabilityOpen.Grasshopper
{
    public class SODesigner_GHParam : GH_Param<SODesigner_GHData>
    {
        public SODesigner_GHParam()
            : base(new GH_InstanceDescription("Designer parameter", "designer", "Register a Designer parameter", 
                   SustainabilityOpenFramework.CATEGORY,
                   SustainabilityOpenFramework.DESIGNER_SUBCATEGORY))
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
            get { return new Guid("{44A9BFDA-8ED0-4FF2-9ED5-E55B498F7089}"); }
        }
    }
}
