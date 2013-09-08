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
    public abstract class SOParametricComponent : SOBaseNamed
    {
        private List<SOParametricComponent> m_Parents;
        private List<SOParametricComponent> m_Children;
        private string m_GUID;

        /// <summary>
        /// Constructor
        /// </summary>
        public SOParametricComponent(string name) : base(name)
        {
            this.ReInit();
        }

        private void ReInit()
        {
            this.m_Parents = new List<SOParametricComponent>();
            this.m_Children = new List<SOParametricComponent>();
            this.m_GUID = "";
        }

        public void AddParent(SOParametricComponent parent)
        {
            if (this.m_Parents == null) { this.ReInit(); }
            this.m_Parents.Add(parent);
        }

        public void AddChild(SOParametricComponent child)
        {
            if (this.m_Children == null) { this.ReInit(); }
            this.m_Children.Add(child);
        }

        public void ClearParents()
        {
            if (this.m_Parents == null) { this.ReInit(); }
            this.m_Parents.Clear();
        }

        public void ClearChildren()
        {
            if (this.m_Children == null) { this.ReInit(); }
            this.m_Children.Clear();
        }

        public SOParametricComponent[] Parents
        {
            get
            {
                if (this.m_Parents == null) { this.ReInit(); }
                return this.m_Parents.ToArray();
            }

        }
        public SOParametricComponent[] Children
        {
            get
            {
                if (this.m_Children == null) { this.ReInit(); }
                return this.m_Children.ToArray();
            }
        }
        public string GUID
        {
            get { return this.m_GUID; }
            set { this.m_GUID = value; }
        }
    }
}
