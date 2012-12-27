using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SustainabilityOpen.Framework
{
    public class SOAnalysis : SOBase
    {
        private List<SODesigner> m_Designers;

        public SOAnalysis(string name) : base(name)
        {
            this.m_Designers = new List<SODesigner>();
        }
        public void ClearDesigners()
        {
            this.m_Designers.Clear();
        }
        public void AddDesigner(SODesigner designer)
        {
            this.m_Designers.Add(designer);
        }

        public virtual void RunAnalysis()
        {
        }

        public SODesigner[] Designers
        {
            get { return this.m_Designers.ToArray(); }
        }
    }
}
