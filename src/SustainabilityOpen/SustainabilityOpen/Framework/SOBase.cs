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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SustainabilityOpen.Framework
{
    /// <summary>
    /// Base class for sustainability-open entities
    /// </summary>
    public abstract class SOBase
    {
        // Properties
        private string m_Name;
        private SOBase m_Parent;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of the component</param>
        public SOBase(string name)
        {
            this.m_Name = name;
        }

        /// <summary>
        /// Returns the name
        /// </summary>
        public string Name
        {
            get { return this.m_Name; }
        }

        public SOBase Parent;
    }
}
