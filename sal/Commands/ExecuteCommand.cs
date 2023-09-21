using SAL.Constants.Messages;
using SAL.SqlManager;

namespace SAL.Commands
{
    class ExecuteCommand
    {
        public static void Run()
        {
            Console.WriteLine(Msg.EXECUTE_START_MESSAGE);
            SqlCommandHandler query = new();
            DatabaseConnector db = new("KLER_APS", true, query.SqlCommand);
            db.ConnectAndQuery();
            Console.WriteLine(Msg.USER_INPUT_MESSAGE);
        }
    }
}