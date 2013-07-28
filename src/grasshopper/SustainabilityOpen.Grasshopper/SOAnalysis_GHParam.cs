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
    public class SOAnalysis_GHParam : GH_Param<SOAnalysis_GHData>
    {
        public SOAnalysis_GHParam()
            : base(new GH_InstanceDescription("Analysis parameter", "analysis", "Register an Analysis parameter", "", ""))
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
            get { return new Guid("{3AE77833-7435-439F-837C-785449ECF15E}"); }
        }
    }
}
