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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SustainabilityOpen.Framework
{
    /// <summary>
    /// Assessment entity
    /// </summary>
    public class SOAssessment : SOComponent
    {
        public SOAssessment(string name) : base(name)
        {
        }

        public void ClearAnalysis()
        {
            this.ClearParents();
        }

        public void AddAnalysis(SOAnalysis analysis)
        {
            this.AddParent(analysis);
        }

        /// <summary>
        /// Runs the assessment. Override this method to make the assessment do some work.
        /// </summary>
        public virtual void RunAssessment()
        {
        }

        public SOAnalysis[] Analyses
        {
            get
            {
                List<SOAnalysis> analyses = new List<SOAnalysis>();
                foreach (SOComponent component in this.Parents)
                {
                    if (component.GetType().IsSubclassOf(typeof(SOAnalysis)) || (component.GetType() == typeof(SOAnalysis)))
                    {
                        analyses.Add((SOAnalysis)component);
                    }
                }
                return analyses.ToArray();
            }

        }
    }
}
