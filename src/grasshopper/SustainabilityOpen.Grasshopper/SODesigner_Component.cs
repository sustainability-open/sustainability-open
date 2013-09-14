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
    public abstract class SODesigner_Component : GH_Component
    {
        private SODesigner m_Designer;
        public SODesigner_Component(string name, string nickname, string description, SODesigner designer)
            : base(name, 
                   nickname, 
                   description, 
                   GHSustainabilityOpenFramework.CATEGORY, 
                   GHSustainabilityOpenFramework.DESIGNER_SUBCATEGORY)
        {
            this.m_Designer = designer;
            SOGrasshopperController con = SOGrasshopperController.GetInstance(OnPingDocument());
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.RegisterParam(new SODesigner_GHParam(), "d", "d", "Designer output", GH_ParamAccess.item);
        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {
#if DEBUG
            Rhino.RhinoApp.WriteLine("Designer " + this.Name + " is solving");
#endif
            
            // check if the controller is online
            SOGrasshopperController con = SOGrasshopperController.GetInstance(OnPingDocument());
            
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
#if DEBUG
            Rhino.RhinoApp.WriteLine("> Controller state: " + SOController.Instance.State.ToString());
#endif
        }
        public SODesigner Designer
        {
            get { return this.m_Designer; }
        }

    }
}
