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
