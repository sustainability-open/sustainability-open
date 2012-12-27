using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SustainabilityOpen.Framework
{
    public abstract class SOPhysicalObject
    {
        private string m_Name;
        private List<SOMaterialQuantity> m_MaterialQuantities;

        public SOPhysicalObject(string name)
        {
            this.m_Name = name;
            this.m_MaterialQuantities = new List<SOMaterialQuantity>();
        }
        public void AddMaterialQuantity(SOMaterial material, double quantity, string unit)
        {
            this.m_MaterialQuantities.Add(new SOMaterialQuantity(material, quantity, unit));
        }
        public bool ContainsMaterialSpecifications
        {
            get { return this.m_MaterialQuantities.Count > 0; }
        }
        public SOMaterialQuantity[] MaterialQuantities
        {
            get { return this.m_MaterialQuantities.ToArray(); }
        }
        public string Name
        {
            get { return this.m_Name; }
        }
    }
}
