using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SustainabilityOpen.Framework
{
    /// <summary>
    /// Assessment entity
    /// </summary>
    public class SOAssessment : SOBase 
    {
        private List<SOAnalysis> m_Analyses;

        public SOAssessment(string name) : base(name)
        {
            this.m_Analyses = new List<SOAnalysis>();
        }

        public void ClearAnalysis()
        {
            this.m_Analyses.Clear();
        }

        public void AddAnalysis(SOAnalysis analysis)
        {
            this.m_Analyses.Add(analysis);
        }

        /// <summary>
        /// Runs the assessment. Override this method to make the assessment do some work.
        /// </summary>
        public virtual void RunAssessment()
        {
        }

        public SOAnalysis[] Analyses
        {
            get { return this.m_Analyses.ToArray(); }
        }
    }
}
