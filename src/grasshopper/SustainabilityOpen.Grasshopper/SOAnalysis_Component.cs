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
    public abstract class SOAnalysis_Component : GH_Component
    {
        private SOAnalysis m_Analysis;
        public SOAnalysis_Component(string name, string nickname, string description, SOAnalysis analysis)
            : base(name, 
                   nickname, 
                   description, 
                   GHSustainabilityOpenFramework.CATEGORY, 
                   GHSustainabilityOpenFramework.ANALYSIS_SUBCATEGORY)
        {
            this.m_Analysis = analysis;
        }
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            IGH_Param param1 = new SODesigner_GHParam();
            param1.Optional = true;
            pManager.AddParameter(param1, "Designers", "d", "Register a designer output (or more than one) as input", GH_ParamAccess.list);

            IGH_Param param2 = new SOAnalysis_GHParam();
            param2.Optional = true;
            pManager.AddParameter(param2, "Analysis", "a", "Register an analysis output (or more than one) as input", GH_ParamAccess.list);
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddParameter(new SOAnalysis_GHParam(), "Analysis", "a", "Analysis output", GH_ParamAccess.item);
        }
 
        protected override void SolveInstance(IGH_DataAccess DA)
        {
#if DEBUG
            Rhino.RhinoApp.WriteLine("Analysis " + this.Name + " is solving");
#endif

            // check dependencies
            if (this.m_Analysis == null) { return; }

            // check if the controller is online
            SOGrasshopperController con = SOGrasshopperController.GetInstance(OnPingDocument());

            List<SODesigner_GHData> designerList = new List<SODesigner_GHData>();
            DA.GetDataList<SODesigner_GHData>(0, designerList);
            this.m_Analysis.ClearDesigners();
            foreach (SODesigner_GHData data in designerList)
            {
                this.m_Analysis.AddDesigner(data.Value);
            }

            List<SOAnalysis_GHData> analysisList = new List<SOAnalysis_GHData>();
            DA.GetDataList<SOAnalysis_GHData>(1, analysisList);
            this.m_Analysis.ClearAnalyses();
            foreach (SOAnalysis_GHData data in analysisList)
            {
                this.m_Analysis.AddAnalysis(data.Value);
            }


            // run the assessment
            try
            {
                this.m_Analysis.RunAnalysis();
            }
            catch (Exception)
            {
                return;
            }

            SOAnalysis_GHData analysis = new SOAnalysis_GHData(this.m_Analysis);
            DA.SetData(0, analysis);
        }
        public SOAnalysis Analysis
        {
            get { return this.m_Analysis; }
        }

    }
}
