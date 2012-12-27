using SustainabilityOpen.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SustainabilityOpen.QTO
{
    public class QTOAnalysis : SOAnalysis
    {
        private string m_TextualOutput;
        private List<SOMaterialQuantity> m_MaterialQuantities;
        public QTOAnalysis()
            : base("Quantity Take-Off")
        {
            this.m_TextualOutput = "";
            this.m_MaterialQuantities = new List<SOMaterialQuantity>();
        }
        public override void RunAnalysis()
        {
            if (this.Designers == null) { return; }

            this.m_TextualOutput = "";
            this.m_MaterialQuantities.Clear();
            foreach (SODesigner designer in this.Designers)
            {
                foreach (SOPhysicalObject obj in designer.PhysicalObjects)
                {
                    if (obj.ContainsMaterialSpecifications)
                    {
                        this.m_TextualOutput += "Physical object: " + obj.Name + "\n";
                        foreach (SOMaterialQuantity quantity in obj.MaterialQuantities)
                        {
                            this.m_TextualOutput += "- " + quantity.Material.Name + ": " + quantity.Quantity.ToString("    0.00") + " " + quantity.Unit + "\n";
                            bool exists = false;
                            foreach (SOMaterialQuantity totalquantity in this.m_MaterialQuantities)
                            {
                                if ((totalquantity.Material.Equals(quantity.Material)) ||
                                    (totalquantity.Material.Name.Equals(quantity.Material.Name)))
                                {
                                    totalquantity.Quantity += quantity.Quantity;
                                    exists = true;
                                    break;
                                }
                            }
                            if (!exists)
                            {
                                this.m_MaterialQuantities.Add(new SOMaterialQuantity(quantity.Material, quantity.Quantity, quantity.Unit));
                            }
                        }
                    }
                }
            }

            this.m_TextualOutput += "\nTotals\n";
            foreach (SOMaterialQuantity quantity in this.m_MaterialQuantities)
            {
                this.m_TextualOutput += "- " + quantity.Material.Name + ": " + quantity.Quantity.ToString("    0.00") + " " + quantity.Unit + "\n";
            }
        }
        public string TextualOutput
        {
            get { return this.m_TextualOutput; }
        }
        public SOMaterialQuantity[] Quantities
        {
            get { return this.m_MaterialQuantities.ToArray(); }
        }

    }
}
