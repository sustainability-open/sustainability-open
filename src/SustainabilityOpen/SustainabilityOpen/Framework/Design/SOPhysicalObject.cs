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

namespace SustainabilityOpen.Framework.Design
{
    /// <summary>
    /// Physical object
    /// </summary>
    public abstract class SOPhysicalObject : SOBaseNamed
    {
        // Properties
        private List<SOMaterialQuantity> m_MaterialQuantities;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of the object</param>
        public SOPhysicalObject(string name) : base(name)
        {
            this.m_MaterialQuantities = new List<SOMaterialQuantity>();
        }

        /// <summary>
        /// Add a material quantity to the object
        /// </summary>
        /// <param name="material">Material definition</param>
        /// <param name="quantity">Quantity of the material</param>
        /// <param name="unit">Unit of the quantity</param>
        public void AddMaterialQuantity(SOMaterial material, double quantity, string unit)
        {
            this.m_MaterialQuantities.Add(new SOMaterialQuantity(material, quantity, unit));
        }
        
        /// <summary>
        /// Returns if the object contains material specifications or not
        /// </summary>
        public bool ContainsMaterialSpecifications
        {
            get { return this.m_MaterialQuantities.Count > 0; }
        }

        /// <summary>
        /// Returns the material quantities
        /// </summary>
        public SOMaterialQuantity[] MaterialQuantities
        {
            get { return this.m_MaterialQuantities.ToArray(); }
        }
    }
}
