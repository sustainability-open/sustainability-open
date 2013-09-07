using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SustainabilityOpen.Grasshopper
{
    public sealed class SOGrasshopperController
    {
        private static volatile SOGrasshopperController m_Instance;
        private static object m_SyncRoot = new Object();

        /// <summary>
        /// Singleton
        /// </summary>
        public static SOGrasshopperController Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    lock (m_SyncRoot)
                    {
                        if (m_Instance == null)
                        {
                            m_Instance = new SOGrasshopperController();
                        }
                    }
                }
                return m_Instance;
            }
        }

    }
}
