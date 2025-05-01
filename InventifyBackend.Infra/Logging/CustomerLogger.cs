using Microsoft.Extensions.Logging;

namespace InventifyBackend.Infra.Logging
{
    public class CustomerLogger : ILogger
    {
        private readonly string _loggerName;
        private readonly CustomLoggerProviderConfiguration _loggerConfig;
        private readonly string _logPathFile;

        public CustomerLogger(string name, CustomLoggerProviderConfiguration config)
        {
            _loggerName = name;
            _loggerConfig = config;

            string folderFile = Directory.GetParent(Directory.GetCurrentDirectory()).FullName + @"\Log";

            Directory.CreateDirectory(folderFile);

            _logPathFile = folderFile + @"\log.txt";
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel == _loggerConfig.LogLevel;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            string message = $"{logLevel.ToString()}: {eventId.Id} - {formatter(state, exception)}";

            WriteTextOnFile(message);
        }

        private void WriteTextOnFile(string message)
        {
            using (StreamWriter streamWriter = new StreamWriter(_logPathFile, true))
            {
                try
                {
                    streamWriter.WriteLine(message);
                    streamWriter.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
