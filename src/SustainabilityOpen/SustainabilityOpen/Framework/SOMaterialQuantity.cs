using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SustainabilityOpen.Framework
{
    public class SOMaterialQuantity
    {
        private SOMaterial m_Material;
        private double m_Quantity;
        private string m_Unit;

        public SOMaterialQuantity(SOMaterial material, double quantity, string unit)
        {
            this.m_Material = material;
            this.m_Quantity = quantity;
            this.m_Unit = unit;
        }
        public SOMaterial Material
        {
            get { return this.m_Material; }
        }
        public double Quantity
        {
            get { return this.m_Quantity; }
            set { this.m_Quantity = value; }
        }
        public string Unit
        {
            get { return this.m_Unit; }
        }
    }
}
