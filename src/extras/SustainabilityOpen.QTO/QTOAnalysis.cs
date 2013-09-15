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

using SustainabilityOpen.Framework;
using SustainabilityOpen.Framework.Design;
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

            this.m_TextualOutput = "sustainability-open v" + SOFramework.VERSION + "\n\n";
            this.m_MaterialQuantities.Clear();
            
            foreach (SOComponent component in this.CurrentDesignAlternative.FlattenedLeafComponents)
            {
                foreach (SOPhysicalObject obj in component.Parts)
                {
                    this.m_TextualOutput += "Physical object: " + obj.Name + "\n";
                    SOMaterialQuantity quantity = obj.MaterialQuantity;

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
