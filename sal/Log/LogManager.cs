using SAL.Constants.Messages;

namespace SAL.Log
{
    class LogManager
    {
        public static void AddLogEntry(string entry)
        {
            try
            {
                DateTime currentDateTime = DateTime.Now;
                string formattedDateTime = currentDateTime.ToString("yyyy-MM-dd HH:mm");
                string fullEntry = formattedDateTime + " " + entry + Environment.NewLine;
                File.AppendAllText(GetLogFileFullPath(), fullEntry);
            }
            catch
            {
                Msg.WriteLineYellow(Msg.ADD_LOG_ERROR_WARNING);
            }
        }

        private static string GetLogFileFullPath()
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string logFilePath = Path.Combine(currentDirectory, "log.txt");
            return logFilePath;
        }
    }
}