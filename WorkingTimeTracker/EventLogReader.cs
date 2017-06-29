using System;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace WorkingTimeTracker
{
    public class EventLogReader
    {
        public void readEvents()
        {

            // Auslesen von Einträgen aus einem Ereignisprotokoll

            // Name des Ereignisprotokolls
            string logname = "Application";

            // Anzahl der auszugebenden Einträge
            long anzahl = 10;

            long count = 0;

            // -- Zugriff auf das Ereignisprotokoll
            EventLog log = new EventLog(logname);

            Console.WriteLine("Letzte " + anzahl.ToString() + " Einträge von " + log.Entries.Count +
            " Einträgen aus dem Protokoll " + log.Log + " auf dem Computer " + log.MachineName);

            // Schleife über alle Einträge
            foreach (EventLogEntry eintrag in log.Entries)
            {
                count += 1;
                if (count > log.Entries.Count - anzahl)
                {
                    Console.WriteLine(eintrag.EntryType + ":" +
                    eintrag.EventID + ":" +
                    eintrag.Category + ":" +
                    eintrag.Message + ":" +
                    eintrag.Source + ":" +
                    eintrag.TimeGenerated + ":" +
                    eintrag.TimeWritten + ":" +
                    eintrag.UserName + ":");
                }
            }
        }
    }
}
