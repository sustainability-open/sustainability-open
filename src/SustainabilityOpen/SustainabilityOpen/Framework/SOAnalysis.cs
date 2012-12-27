using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SustainabilityOpen.Framework
{
    /// <summary>
    /// Analysis entity
    /// </summary>
    public class SOAnalysis : SOBase
    {
        // Properties
        private List<SODesigner> m_Designers;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of the analysis</param>
        public SOAnalysis(string name) : base(name)
        {
            this.m_Designers = new List<SODesigner>();
        }

        /// <summary>
        /// Clears the attached designers from this analysis
        /// </summary>
        public void ClearDesigners()
        {
            this.m_Designers.Clear();
        }

        /// <summary>
        /// Attaches a designer to this analysis
        /// </summary>
        /// <param name="designer"></param>
        public void AddDesigner(SODesigner designer)
        {
            this.m_Designers.Add(designer);
        }

        /// <summary>
        /// Runs the analysis. Override this method to make the analysis do some work.
        /// </summary>
        public virtual void RunAnalysis()
        {
        }

        /// <summary>
        /// Returns the attached designers
        /// </summary>
        public SODesigner[] Designers
        {
            get { return this.m_Designers.ToArray(); }
        }
    }
}
