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
        public enum ControllerState
        {
            unsolved,
            new_solution,
            first_designer_passed
        }
        
        private static volatile SOController m_Instance;
        private static object m_SyncRoot = new Object();
        private List<SOParametricComponent> m_Entities;
        private ControllerState m_State;

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
            if (this.m_Entities == null) { this.m_Entities = new List<SOParametricComponent>(); }
            this.m_State = ControllerState.unsolved;
        }

        /// <summary>
        /// Returns the different entities in the controller
        /// </summary>
        public SOParametricComponent[] Entities
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
        public void AddEntity(SOParametricComponent entity)
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
        /// Sets the controller state to a new state value
        /// </summary>
        /// <param name="stateToSet">State to set the controller state to</param>
        public void SetState(ControllerState stateToSet)
        {
            this.m_State = stateToSet;
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

        /// <summary>
        /// State of the controller
        /// </summary>
        public ControllerState State
        {
            get { return this.m_State; }
        }

    }
}
