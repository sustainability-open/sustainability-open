﻿/// Copyright 2012-2013 Delft University of Technology, BEMNext Lab and contributors
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

using SustainabilityOpen.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SustainabilityOpen.Framework.Design
{
    /// <summary>
    /// SODesign
    /// </summary>
    public class SODesign : SOBaseNamed
    {
        public const string DEFAULT_ALTERNATIVE_NAME = "default";
        private List<SODesignAlternative> m_Alternatives;
        private int m_CurrentIndex = 0;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of the design</param>
        public SODesign(string name)
            : base(name)
        {
            this.ReInit();
        }

        /// <summary>
        /// Reinitialises the design
        /// </summary>
        private void ReInit()
        {
            this.m_Alternatives = new List<SODesignAlternative>();
            this.m_Alternatives.Add(new SODesignAlternative(SODesign.DEFAULT_ALTERNATIVE_NAME));
            this.m_CurrentIndex = 0;
        }

        /// <summary>
        /// Adds an alternative to the design
        /// </summary>
        /// <param name="alternative">Alternative to add</param>
        public void AddAlternative(SODesignAlternative alternative)
        {
            if (this.m_Alternatives == null) { this.ReInit(); }
            this.m_Alternatives.Add(alternative);
            this.m_CurrentIndex = this.m_Alternatives.Count - 1;
        }

        /// <summary>
        /// Clears the design
        /// </summary>
        public void ClearDesign()
        {
            this.ReInit();
        }

        /// <summary>
        /// Returns the design alternatives part of this design
        /// </summary>
        public SODesignAlternative[] Alternatives
        {
            get
            {
                if (this.m_Alternatives == null) { this.ReInit(); }
                return this.m_Alternatives.ToArray();
            }
        }


        /// <summary>
        /// Returns the current design alternative
        /// </summary>
        public SODesignAlternative CurrentAlternative
        {
            get
            {
                if (this.m_Alternatives == null) { this.ReInit(); }
                if (this.m_CurrentIndex < 0) { this.m_CurrentIndex = 0; }
                if (this.m_CurrentIndex > this.m_Alternatives.Count - 1) { this.m_CurrentIndex = this.m_Alternatives.Count - 1; }
                return this.m_Alternatives[this.m_CurrentIndex];
            }
        }
    }
}
