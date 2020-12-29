using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental
{
    public class FileLogger : ILogger
    {
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            DateTime now = DateTime.Now;
            string severity = logLevel.ToString();
            string logMessage = state.ToString();
            string exceptionMessage = exception?.Message;
            string msgToLog = $"{now}  {severity}  {logMessage}  {exceptionMessage}";
            using StreamWriter writer = new StreamWriter("Log.txt", true);
            writer.WriteLine(msgToLog);

            

        }
        public IDisposable BeginScope<TState>(TState state) { return null; }
        public bool IsEnabled(LogLevel logLevel) { return true; }

    }
}
