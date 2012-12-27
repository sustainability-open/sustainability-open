using Grasshopper.Kernel.Types;
using SustainabilityOpen.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SustainabilityOpen.Grasshopper
{
    public class SODesigner_GHData : GH_Goo<SODesigner>
    {
        public SODesigner_GHData() { }
        public SODesigner_GHData(SODesigner designer)
            : base(designer)
        {
        }
        public override IGH_Goo Duplicate()
        {
            return new SODesigner_GHData(new SODesigner(""));
        }
        public override bool IsValid
        {
            get { return true; }
        }
        public override string ToString()
        {
            return "Designer parameter";
        }
        public override string TypeDescription
        {
            get { return "Holds the information of the designer"; }
        }
        public override string TypeName
        {
            get { return "Designer"; }
        }
    }
}
