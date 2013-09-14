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

#define DEBUG

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
                   GHSustainabilityOpenFramework.CATEGORY, 
                   GHSustainabilityOpenFramework.ASSESSMENT_SUBCATEGORY)
        {
            this.m_Assessment = assessment;
        }
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddParameter(new SOAnalysis_GHParam(), "Analyses", "a", "Register an analysis (or more)", GH_ParamAccess.list);
        }
 
        protected override void SolveInstance(IGH_DataAccess DA)
        {
#if DEBUG
            Rhino.RhinoApp.WriteLine("Assessment " + this.Name + " is solving");
#endif
            
            // check dependencies
            if (this.m_Assessment == null) { return; }

            // check if the controller is online
            SOGrasshopperController con = SOGrasshopperController.GetInstance(OnPingDocument());

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
