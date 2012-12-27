using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SustainabilityOpen.Framework
{
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

        public virtual void RunAssessment()
        {
        }

        public SOAnalysis[] Analyses
        {
            get { return this.m_Analyses.ToArray(); }
        }
    }
}
