using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Denzel.Logger
{
    public class Slogger
    {
        public string Filename { get; set; } = "log.txt";

        public void AddToLog(Log log)
        {
            var logString = new LoggerFactory().BuildStringForLogFile(log);

            CreateIfNotExists();

            File.AppendAllLines(GetLogPath(), new[] { logString });
        }

        public void ClearLog()
        {
            var exists = LogFileExists();

            if (exists)
            {
                return;
            }

            File.WriteAllText(GetLogPath(), "");
        }

        public void DeleteLogFile()
        {
            var exists = LogFileExists();

            if (exists)
            {
                return;
            }

            File.Delete(GetLogPath());
        }

        private void CreateIfNotExists()
        {
            var exists = LogFileExists();

            if (exists)
            {
                return;
            }

            var fs = File.Create(GetLogPath());
            fs.Dispose();
        }

        private bool LogFileExists()
        {
            return File.Exists(GetLogPath());
        }

        private string GetLogPath()
        {
            var directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            return $@"{directory}/{Filename}";
        }
    }
}