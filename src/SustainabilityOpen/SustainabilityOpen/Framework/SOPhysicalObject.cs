using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SustainabilityOpen.Framework
{
    /// <summary>
    /// Physical object
    /// </summary>
    public abstract class SOPhysicalObject
    {
        // Properties
        private string m_Name;
        private List<SOMaterialQuantity> m_MaterialQuantities;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of the object</param>
        public SOPhysicalObject(string name)
        {
            this.m_Name = name;
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

        /// <summary>
        /// Returns the name
        /// </summary>
        public string Name
        {
            get { return this.m_Name; }
        }
    }
}
