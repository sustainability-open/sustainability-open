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

using SustainabilityOpen.Framework.Design;
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
