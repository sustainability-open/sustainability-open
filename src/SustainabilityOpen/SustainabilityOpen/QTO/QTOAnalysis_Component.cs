using Grasshopper.Kernel;
using SustainabilityOpen.Grasshopper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SustainabilityOpen.QTO
{
    public class QTOAnalysis_Component : SOAnalysis_Component
    {
        public QTOAnalysis_Component()
            : base("QTO", "QTO", "Quantity Take-Off analysis", new QTOAnalysis())
        {
        }
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            base.RegisterInputParams(pManager);
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            base.RegisterOutputParams(pManager);
            pManager.Register_StringParam("t", "t", "Textual output");
        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            if (this.Analysis == null) { return; }

            base.SolveInstance(DA);
            DA.SetData(1, ((QTOAnalysis)this.Analysis).TextualOutput);
        }
        public override Guid ComponentGuid
        {
            get { return new Guid("{840BB01D-3CB9-4328-AC75-8EE375469501}"); }
        }

    }
}
