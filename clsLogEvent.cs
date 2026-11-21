using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogEventGeneral
{
    public class clsLogEvent
    {
        public string NameApp { get; set; }
        public enum EnTypeWindowsLog { Application, Security,Setup,System};
        public clsLogEvent(string Name)
        {
            this.NameApp = Name;
        }
        public void CreateSourceLog(EnTypeWindowsLog type)
        {
            if (!IsExistsSource())
            {
                EventLog.CreateEventSource(this.NameApp,type.ToString());
            }
        }
        public bool IsExistsSource()
        {
            return EventLog.SourceExists(this.NameApp);
        }
        public void PrintAllEventsLogToApp()
        {
            EventLog eventLog = new EventLog(EnTypeWindowsLog.Application.ToString());

            foreach (EventLogEntry entry in eventLog.Entries)
            {
                if (entry.Source == "clsLogEvent")
                {
                    Console.WriteLine(entry.Message+" | "+entry.EntryType);
                }
            }
        }
        public void WriteLog(string Message,EventLogEntryType type)
        {
            EventLog.WriteEntry(this.NameApp,Message,type);
        }
    }
}
