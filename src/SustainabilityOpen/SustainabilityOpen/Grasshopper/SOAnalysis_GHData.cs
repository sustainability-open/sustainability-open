using Grasshopper.Kernel.Types;
using SustainabilityOpen.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SustainabilityOpen.Grasshopper
{
    public class SOAnalysis_GHData : GH_Goo<SOAnalysis>
    {
        public SOAnalysis_GHData() { }
        public SOAnalysis_GHData(SOAnalysis analysis)
            : base(analysis)
        {
        }
        public override IGH_Goo Duplicate()
        {
            return new SOAnalysis_GHData();
        }
        public override bool IsValid
        {
            get { return true; }
        }
        public override string ToString()
        {
            return "SustainabilityOpen Analysis parameter";
        }
        public override string TypeDescription
        {
            get { return "Holds the information of an analysis"; }
        }
        public override string TypeName
        {
            get { return "Analysis"; }
        }

    }
}
