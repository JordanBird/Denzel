using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denzel.Logger
{
    public class LoggerFactory
    {
        public Log BuildLogForStartup()
        {
            return BuildLogForInfo("Denzel started.");
        }

        public Log BuildLogForExit()
        {
            return BuildLogForInfo("Denzel exited.");
        }

        public Log BuildLogForInfo(string info)
        {
            return new Log { DateTime = DateTime.Now, Type = "Info", Message = info };
        }

        public Log BuildLogForError(string error)
        {
            return new Log { DateTime = DateTime.Now, Type = "Error", Message = error };
        }

        public string BuildStringForLogFile(Log log)
        {
            return $"{log.DateTime.ToString()}| {log.Type}| {log.Message}";
        }
    }
}