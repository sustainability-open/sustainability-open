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

using SustainabilityOpen.Framework.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SustainabilityOpen.Framework
{
    /// <summary>
    /// Assessment entity
    /// </summary>
    public class SOAssessment : SOParametricComponent
    {
        public SOAssessment(string name) : base(name)
        {
        }

        public void ClearAnalysis()
        {
            this.ClearParentsOfType(typeof(SOAnalysis));
        }

        public void AddAnalysis(SOAnalysis analysis)
        {
            this.AddParent(analysis);
        }

        public void ClearAssessments()
        {
            this.ClearParentsOfType(typeof(SOAssessment));
        }

        public void AddAssessment(SOAssessment assessment)
        {
            this.AddParent(assessment);
        }

        public void ClearDesigners()
        {
            this.ClearParentsOfType(typeof(SODesigner));
        }

        public void AddDesigner(SODesigner designer)
        {
            this.AddParent(designer);
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
                foreach (SOParametricComponent component in this.Parents)
                {
                    if (component.GetType().IsSubclassOf(typeof(SOAnalysis)) || (component.GetType() == typeof(SOAnalysis)))
                    {
                        analyses.Add((SOAnalysis)component);
                    }
                }
                return analyses.ToArray();
            }
        }

        public SOAssessment[] Assessments
        {
            get
            {
                List<SOAssessment> assessments = new List<SOAssessment>();
                foreach (SOParametricComponent component in this.Parents)
                {
                    if (component.GetType().IsSubclassOf(typeof(SOAssessment)) || (component.GetType() == typeof(SOAssessment)))
                    {
                        assessments.Add((SOAssessment)component);
                    }
                }
                return assessments.ToArray();
            }
        }

        public SODesigner[] Designers
        {
            get
            {
                List<SODesigner> designers = new List<SODesigner>();
                foreach (SOParametricComponent component in this.Parents)
                {
                    if (component.GetType().IsSubclassOf(typeof(SODesigner)) || (component.GetType() == typeof(SODesigner)))
                    {
                        designers.Add((SODesigner)component);
                    }
                }
                return designers.ToArray();
            }
        }

        /// <summary>
        /// Returns the current design alternative for the designer to use
        /// </summary>
        public SODesignAlternative CurrentDesignAlternative
        {
            get
            {
                return SOController.Instance.Design.CurrentAlternative;
            }
        }

    }
}
