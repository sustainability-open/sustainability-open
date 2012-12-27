using Grasshopper.Kernel.Types;
using SustainabilityOpen.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SustainabilityOpen.Grasshopper
{
    public class SOAssessment_GHData : GH_Goo<SOAssessment>
    {
        public SOAssessment_GHData() { }
        public SOAssessment_GHData(SOAssessment assessment)
            : base(assessment)
        {
        }
        public override IGH_Goo Duplicate()
        {
            SOAssessment assessment = new SOAssessment("");
            return new SOAssessment_GHData(assessment);
        }
        public override bool IsValid
        {
            get { return true; }
        }
        public override string ToString()
        {
            return "SustainabilityOpen Assessment parameter";
        }
        public override string TypeDescription
        {
            get { return "Holds the information of an assessment"; }
        }
        public override string TypeName
        {
            get { return "Assessment"; }
        }
    }
}
