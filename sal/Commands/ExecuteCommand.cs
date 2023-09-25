using SAL.Config;
using SAL.Constants.Messages;
using SAL.Constants.Values;
using SAL.Log;
using SAL.SqlManager;

namespace SAL.Commands
{
    class ExecuteCommand
    {
        public static void Run(bool runByUser)
        {
            OpeningMessage(runByUser);

            // Set db name
            string? dbName = ConfigManager.GetConfigValue(Val.PARAM_NAME_DB_NAME);
            if(dbName is null || dbName =="")
            {
                Msg.WriteLineRed("Query execute failed! Given DB name is empty.");
                LogManager.AddLogEntry("Query execute failed! Given DB name is empty.");
                return;
            }

            // Set certificate trust
            string? certTrust = ConfigManager.GetConfigValue(Val.PARAM_NAME_CERT_TRUST);
            bool certTrustValue = false;
            if(certTrust is not null)
            {
                if(certTrust.ToLower()=="true") certTrustValue = true;
            }

            // Execute query
            SqlCommandHandler query = new();
            DatabaseConnector db = new(dbName, certTrustValue, query.SqlCommand);   
            if(db.ConnectAndQuery()) ClosingMessage(runByUser);
            Console.WriteLine(Msg.USER_INPUT_MESSAGE);
        }

        private static void OpeningMessage(bool runByUser)
        {
            if(runByUser)
            { 
                Console.WriteLine(Msg.EXECUTE_START_MESSAGE);
                LogManager.AddLogEntry("Query execute started by the user.");
            }
            else
            {
                Msg.WriteLineBlue(DateTime.Now.ToString() + ": Query execute started by the scheduler...");
                LogManager.AddLogEntry("Query execute started by the scheduler.");
            }
        }

        private static void ClosingMessage(bool runByUser)
        {
            if(runByUser)
            {
                Console.WriteLine("Query executed successfuly.");
            }
            else
            {
                Msg.WriteLineBlue(DateTime.Now + ": Query executed successfuly.");
            }
            LogManager.AddLogEntry("Query executed successfuly.");
        }
    }
}