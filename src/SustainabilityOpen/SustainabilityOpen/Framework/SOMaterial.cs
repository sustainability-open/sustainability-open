using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SustainabilityOpen.Framework
{
    public class SOMaterial
    {
        private string m_Name;

        public SOMaterial(string name)
        {
            this.m_Name = name;
        }
        public string Name
        {
            get { return this.m_Name; }
        }
    }
}
