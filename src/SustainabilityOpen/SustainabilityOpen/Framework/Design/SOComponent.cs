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
    public class SOComponent : SOBaseNamed
    {
        private List<SOComponent> m_Components;
        private List<SOPart> m_Parts;

        /// <summary>
        /// Component
        /// </summary>
        /// <param name="name">Name of the component</param>
        public SOComponent(string name)
            : base(name)
        {
            this.ReInit();
        }

        /// <summary>
        /// Reinitialises the component
        /// </summary>
        private void ReInit()
        {
            this.ReInitSubComponents();
            this.ReInitParts();
        }

        /// <summary>
        /// Reinitialises the subcomponents
        /// </summary>
        private void ReInitSubComponents()
        {
            this.m_Components = new List<SOComponent>();
        }

        /// <summary>
        /// Reinitialises the parts
        /// </summary>
        private void ReInitParts()
        {
            this.m_Parts = new List<SOPart>();
        }

        /// <summary>
        /// Adds a subcomponent to this component
        /// </summary>
        /// <param name="component">Subcomponent to add</param>
        public void AddSubComponent(SOComponent component)
        {
            if (this.m_Components == null) { this.ReInitSubComponents(); }
            this.m_Components.Add(component);
        }

        /// <summary>
        /// Adds a part to this component
        /// </summary>
        /// <param name="part">Part to add to this component</param>
        public void AddPart(SOPart part)
        {
            if (this.m_Parts == null) { this.ReInitParts(); }
            this.m_Parts.Add(part);
        }

        /// <summary>
        /// Clears the subcomponents
        /// </summary>
        public void ClearSubComponents()
        {
            this.ReInitSubComponents();
        }

        /// <summary>
        /// Clears the parts
        /// </summary>
        public void ClearParts()
        {
            this.ReInitParts();
        }

        /// <summary>
        /// Clears the component
        /// </summary>
        public void Clear()
        {
            this.ClearSubComponents();
            this.ClearParts();
        }

        /// <summary>
        /// Passes on all subcomponents in a list
        /// </summary>
        /// <param name="listToAddTo">List to add the subcomponents to</param>
        public void PassOnFlattenedSubComponents(ref List<SOComponent> listToAddTo)
        {
            if (listToAddTo == null) { listToAddTo = new List<SOComponent>(); }
            foreach (SOComponent component in this.m_Components)
            {
                listToAddTo.Add(component);
                component.PassOnFlattenedSubComponents(ref listToAddTo);
            }
        }

        /// <summary>
        /// Passes on all leaf subcomponents in a list
        /// </summary>
        /// <param name="listToAddTo">List to add the subcomponents to</param>
        public void PassOnFlattenedLeafSubComponents(ref List<SOComponent> listToAddTo)
        {
            if (listToAddTo == null) { listToAddTo = new List<SOComponent>(); }
            if (this.m_Components.Count > 0)
            {
                foreach (SOComponent component in this.m_Components)
                {
                    component.PassOnFlattenedLeafSubComponents(ref listToAddTo);
                }
            }
            else
            {
                listToAddTo.Add(this);
            }
        }


        /// <summary>
        /// Sub-components of the component
        /// </summary>
        public SOComponent[] SubComponents
        {
            get
            {
                if (this.m_Components == null) { this.ReInitSubComponents(); }
                return this.m_Components.ToArray();
            }
        }

        /// <summary>
        /// Parts in the component
        /// </summary>
        public SOPart[] Parts
        {
            get
            {
                if (this.m_Parts == null) { this.ReInitParts(); }
                return this.m_Parts.ToArray();
            }
        }
    }
}
