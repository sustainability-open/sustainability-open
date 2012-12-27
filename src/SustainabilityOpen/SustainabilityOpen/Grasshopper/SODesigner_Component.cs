using Grasshopper.Kernel;
using SustainabilityOpen.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SustainabilityOpen.Grasshopper
{
    public abstract class SODesigner_Component : GH_Component
    {
        private SODesigner m_Designer;
        public SODesigner_Component(string name, string nickname, string description, SODesigner designer)
            : base(name, 
                   nickname, 
                   description, 
                   SustainabilityOpenFramework.CATEGORY, 
                   SustainabilityOpenFramework.DESIGNER_SUBCATEGORY)
        {
            this.m_Designer = designer;
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.RegisterParam(new SODesigner_GHParam(), "d", "d", "Designer output", GH_ParamAccess.item);
        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            if (this.m_Designer == null) { return; }
            try
            {
                this.m_Designer.RunDesigner();
            }
            catch (Exception)
            {
                return;
            }

            // return the designer data
            SODesigner_GHData data = new SODesigner_GHData(this.m_Designer);
            DA.SetData(0, data);
        }
        public SODesigner Designer
        {
            get { return this.m_Designer; }
        }

    }
}
