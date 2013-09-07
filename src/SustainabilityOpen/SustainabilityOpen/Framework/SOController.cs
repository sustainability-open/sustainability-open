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
    /// <summary>
    /// Singleton class that will controll the solution of the sustainability-open framework
    /// </summary>
    public sealed class SOController
    {
        private static volatile SOController m_Instance;
        private static object m_SyncRoot = new Object();
        private List<SOBase> m_Entities;

        /// <summary>
        /// Constructor
        /// </summary>
        public SOController()
        {
            this.ReInit();
        }

        /// <summary>
        /// Reinitialise the controller
        /// </summary>
        public void ReInit()
        {
            if (this.m_Entities == null) { this.m_Entities = new List<SOBase>(); }
        }

        /// <summary>
        /// Returns the different entities in the controller
        /// </summary>
        public SOBase[] Entities
        {
            get
            {
                this.ReInit();
                return this.m_Entities.ToArray();
            }
        }

        /// <summary>
        /// Add an entity to the controller
        /// </summary>
        /// <param name="entity">Entity to add</param>
        public void AddEntity(SOBase entity)
        {
            this.ReInit();
            this.m_Entities.Add(entity);
        }

        /// <summary>
        /// Clears the entities in the controller
        /// </summary>
        public void ClearEntities()
        {
            this.ReInit();
            this.m_Entities.Clear();
        }

        /// <summary>
        /// Solves the entities
        /// </summary>
        public void Solve()
        {
        }

        /// <summary>
        /// Singleton
        /// </summary>
        public static SOController Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    lock (m_SyncRoot)
                    {
                        if (m_Instance == null)
                        {
                            m_Instance = new SOController();
                        }
                    }
                }
                return m_Instance;
            }
        }

    }
}
