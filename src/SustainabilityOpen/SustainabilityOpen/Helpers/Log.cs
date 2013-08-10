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
using System.IO;
using System.Linq;
using System.Text;

namespace SustainabilityOpen.Helpers
{
    /// <summary>
    /// Log singleton
    /// </summary>
    public sealed class Log
    {
        private static volatile Log m_Instance;
        private static object m_SyncRoot = new Object();
        private string m_LogFile = "";
        private FileStream m_Fs;
        private TextWriter m_Tw;

        /// <summary>
        /// Starts the log
        /// </summary>
        /// <param name="logfile">Log filename</param>
        public static void StartLog(string logfile)
        {
            Log log = Log.LogInstance;
            log.LogFile = logfile;

            // register an event handler that loads as soon as the domain unloads to close the log file
            AppDomain domain = AppDomain.CurrentDomain;
            domain.DomainUnload += new EventHandler(domain_DomainUnload);

            // set up the filestream and streamwriter for the log
            log.m_Fs = new FileStream(logfile, FileMode.Create);
            log.m_Tw = new StreamWriter(log.m_Fs);
        }

        /// <summary>
        /// Stops the logging
        /// </summary>
        public static void StopLog()
        {
            Log.LogInstance.closeAllStreams();
            Log.LogInstance.m_LogFile = "";
        }

        /// <summary>
        /// Closes all streams
        /// </summary>
        private void closeAllStreams()
        {
            if (Log.LogInstance != null)
            {
                if (Log.LogInstance.m_Tw != null)
                {
                    Log.LogInstance.m_Tw.Close();
                    Log.LogInstance.m_Tw = null;
                }
                if (Log.LogInstance.m_Fs != null)
                {
                    Log.LogInstance.m_Fs.Close();
                    Log.LogInstance.m_Fs = null;
                }
            }
        }

        /// <summary>
        /// Event handler to close down the log file
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Arguments</param>
        private static void domain_DomainUnload(object sender, EventArgs e)
        {
            Log.LogInstance.closeAllStreams();
        }

        /// <summary>
        /// Singleton
        /// </summary>
        public static Log LogInstance
        {
            get
            {
                if (m_Instance == null)
                {
                    lock (m_SyncRoot)
                    {
                        if (m_Instance == null)
                        {
                            m_Instance = new Log();
                        }
                    }
                }
                return m_Instance;
            }
        }

        /// <summary>
        /// Log filename
        /// </summary>
        public string LogFile
        {
            get { return m_LogFile; }
            set
            {
                if ((value != this.m_LogFile) && (this.m_LogFile != ""))
                {
                    throw new Exception("Log filename cannot be reset");
                }
                this.m_LogFile = value;
            }
        }

        /// <summary>
        /// Returns if the log is active or not
        /// </summary>
        public bool Active
        {
            get
            {
                bool active = true;
                if (Log.LogInstance.m_Fs == null) { active = false; }
                if (Log.LogInstance.m_Tw == null) { active = false; }
                return active;
            }
        }
    }
}
