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

#define DEBUG

using GH = Grasshopper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SustainabilityOpen.Grasshopper
{
    /// <summary>
    /// Grasshopper controller
    /// </summary>
    public sealed class SOGrasshopperController
    {
        private static volatile SOGrasshopperController m_Instance;
        private static object m_SyncRoot = new Object();
        private bool m_Registered = false;

        /// <summary>
        /// Singleton
        /// </summary>
        public static SOGrasshopperController GetInstance(GH.Kernel.GH_Document ghDocument)
        {
#if DEBUG
            Rhino.RhinoApp.Write("Trying to make controlller... ");
#endif
            if (m_Instance == null)
            {
                lock (m_SyncRoot)
                {
                    if (m_Instance == null)
                    {
                        m_Instance = new SOGrasshopperController();
#if DEBUG
                        Rhino.RhinoApp.Write("new... ");
#endif
                    }
                }
            }
#if DEBUG
            Rhino.RhinoApp.WriteLine("done");
#endif
            if (ghDocument != null)
            {
                if (!m_Instance.m_Registered)
                {
                    ghDocument.RaiseEvents = true;
                    ghDocument.SolutionStart += new GH.Kernel.GH_Document.SolutionStartEventHandler(ghDocument_SolutionStart);
                    ghDocument.SolutionEnd += new GH.Kernel.GH_Document.SolutionEndEventHandler(ghDocument_SolutionEnd);
                    ghDocument.ObjectsAdded += new GH.Kernel.GH_Document.ObjectsAddedEventHandler(ghDocument_ObjectsAdded);
                    ghDocument.ObjectsDeleted += new GH.Kernel.GH_Document.ObjectsDeletedEventHandler(ghDocument_ObjectsDeleted);
                    m_Instance.m_Registered = true;
                    Rhino.RhinoApp.WriteLine("Events registered");
                }
            }
            return m_Instance;
        }
        public static void DocumentOverview(GH.Kernel.GH_Document doc)
        {
            if (doc != null)
            {
                foreach (GH.Kernel.GH_DocumentObject obj in doc.Objects)
                {
                    string name = obj.Name;
                    string uid = obj.InstanceGuid.ToString();
                    Rhino.RhinoApp.WriteLine("- " + name + " (" + uid + ")");
                }
            }
        }


        static void ghDocument_ObjectsDeleted(object sender, GH.Kernel.GH_DocObjectEventArgs e)
        {
#if DEBUG
            Rhino.RhinoApp.WriteLine("Objects deleted event");
            DocumentOverview((GH.Kernel.GH_Document)sender);
#endif
        }

        static void ghDocument_ObjectsAdded(object sender, GH.Kernel.GH_DocObjectEventArgs e)
        {
#if DEBUG
            Rhino.RhinoApp.WriteLine("Objects added event");
            DocumentOverview((GH.Kernel.GH_Document)sender);
#endif
        }

        static void ghDocument_SolutionEnd(object sender, GH.Kernel.GH_SolutionEventArgs e)
        {
#if DEBUG
            Rhino.RhinoApp.WriteLine("Solution end event");
#endif
        }

        static void ghDocument_SolutionStart(object sender, GH.Kernel.GH_SolutionEventArgs e)
        {
#if DEBUG            
            Rhino.RhinoApp.WriteLine("Solution start event");
#endif
        }

    }
}
