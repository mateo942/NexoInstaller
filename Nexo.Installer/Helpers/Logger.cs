using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexo.Installer.Helpers
{
    public interface ILogger
    {
        void Info(string message);
        void Error(string message);
        void Debug(string message);
    }

    public class Logger : ILogger
    {
        private readonly object _sync = new object();

        private enum EventLevel
        {
            Debug,
            Info,
            Error,
        }

        private ConsoleColor GetColor(EventLevel level)
        {
            switch (level)
            {
                case EventLevel.Debug:
                    return ConsoleColor.Gray;
                case EventLevel.Info:
                    return ConsoleColor.Yellow;
                case EventLevel.Error:
                    return ConsoleColor.Red;
            }

            return ConsoleColor.White;
        }

        private void Write(EventLevel level, string message)
        {
            lock (_sync)
            {
                try
                {
                    Console.ForegroundColor = GetColor(level);
                    Console.WriteLine($"{DateTime.Now:G} {level} {message}");
                }
                finally
                {
                    Console.ResetColor();
                }
            }
        }

        public void Debug(string message)
        {
            Write(EventLevel.Debug, message);
        }

        public void Error(string message)
        {
            Write(EventLevel.Error, message);
        }

        public void Info(string message)
        {
            Write(EventLevel.Info, message);
        }
    }
}
