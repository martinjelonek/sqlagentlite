namespace SAL.SqlManager
{
    using System;
    using System.IO;
    using SAL.Constants.Messages;
    using SAL.Constants.Values;

    public class SqlCommandHandler
    {
        public string SqlCommand { get; private set; }

        public SqlCommandHandler()
        {
            try
            {
                string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string queryFilePath = Path.Combine(currentDirectory, "query.sql");

                if (File.Exists(queryFilePath))
                {
                    SqlCommand = File.ReadAllText(queryFilePath);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(Msg.SQL_FILE_NOT_FOUND_WARNING);
                    Console.ResetColor();
                    SqlCommand = Val.DEFAULT_SQL_COMMAND;
                }
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(Msg.SQL_FILE_ERROR_WARNING);
                Console.ResetColor();
                SqlCommand = Val.DEFAULT_SQL_COMMAND;
            }
        }
    }
}