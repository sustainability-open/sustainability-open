using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SustainabilityOpen.Framework
{
    public abstract class SOBase
    {
        // Properties
        private string m_Name;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of the component</param>
        public SOBase(string name)
        {
            this.m_Name = name;
        }

        /// <summary>
        /// Returns the name
        /// </summary>
        public string Name
        {
            get { return this.m_Name; }
        }
    }
}
