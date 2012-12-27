using Grasshopper.Kernel;
using SustainabilityOpen.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SustainabilityOpen.Grasshopper
{
    public abstract class SOAssessment_Component : GH_Component
    {
        private SOAssessment m_Assessment;
        public SOAssessment_Component(string name, string nickname, string description, SOAssessment assessment)
            : base(name, 
                   nickname, 
                   description, 
                   SustainabilityOpenFramework.CATEGORY, 
                   SustainabilityOpenFramework.ASSESSMENT_SUBCATEGORY)
        {
            this.m_Assessment = assessment;
        }
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddParameter(new SOAnalysis_GHParam(), "Analyses", "a", "Register an analysis (or more)", GH_ParamAccess.list);
        }
 
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // check dependencies
            if (this.m_Assessment == null) { return; }

            List<SOAnalysis_GHData> analysisList = new List<SOAnalysis_GHData>();
            DA.GetDataList<SOAnalysis_GHData>(0, analysisList);
            this.m_Assessment.ClearAnalysis();
            foreach (SOAnalysis_GHData data in analysisList)
            {
                this.m_Assessment.AddAnalysis(data.Value);
            }

            // run the assessment
            try
            {
                this.m_Assessment.RunAssessment();
            }
            catch (Exception)
            {
                return;
            }
        }
        public SOAssessment Assessment
        {
            get { return this.m_Assessment; }
        }

    }
}
