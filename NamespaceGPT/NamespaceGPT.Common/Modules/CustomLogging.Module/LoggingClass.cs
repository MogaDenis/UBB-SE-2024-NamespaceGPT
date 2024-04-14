namespace NamespaceGPT.Common.Modules.CustomLogging.Module
{
    public static class LoggingClass
    {
        public enum LogType
        {
            INFO,
            WARNINGTYPE,
            ERRORTYPE
        }

        private static string logFilePath = "C:\\UBB\\Sem_4\\ISS\\Lab2\\SE-Lab2\\UnitTests\\Logging.Module.Tests\\testlogfile.txt";
        private static Queue<string> bufferedMessages = new();
        private static object lockObject = new();


        static LoggingClass()
        {
            Thread flushThread = new(FlushBufferedMessages);
            flushThread.IsBackground = true;
            flushThread.Start();
        }

        public static void setFilePath(string filePath)
        {
            logFilePath = filePath; ;
        }

        public static string getFilePath()
        {
            return logFilePath;
        }

        public static Queue<string> getBufferedMessages()
        {
            return bufferedMessages;
        }

        public static void Log(LogType logtype, string message)
        {
            string formattedMessage = $"{DateTime.Now} [{logtype}] {message}";
            if (logtype == LogType.INFO)
            {
                lock (lockObject)
                {
                    bufferedMessages.Enqueue(formattedMessage);
                }
            }
            else
            {
                WriteToFile(formattedMessage);
            }
        }

        private static void FlushBufferedMessages()
        {
            while (true)
            {
                if (bufferedMessages.Count > 0)
                {
                    string[] messages;
                    lock (lockObject)
                    {
                        messages = bufferedMessages.ToArray();
                        bufferedMessages.Clear();
                    }

                    foreach (var message in messages)
                    {
                        WriteToFile(message);
                    }
                }
                else
                {
                    Thread.Sleep(1000);
                }
            }
        }

        private static void WriteToFile(string message)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.Write(message + '\n');
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to log file: {ex.Message}");
            }
        }
    }

}

