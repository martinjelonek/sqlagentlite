using SAL.Constants.Messages;
using SAL.SqlManager;

namespace SAL.Commands
{
    class ShowCommand
    {
        public static void Run()
        {
            SqlCommandHandler command = new SqlCommandHandler();
            if(command.IsQueryDefault)
            {
                Console.WriteLine(Msg.SHOW_DEFAULT_QUERY_WARNING);
                Console.WriteLine(Msg.QUERY_PRINT_START);
                Console.WriteLine(command.SqlCommand);
                Console.WriteLine(Msg.QUERY_PRINT_END);
            }
            else
            {
                string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string fullFilePath = Path.Combine(currentDirectory, "query.sql");
                Console.WriteLine(Msg.QUERY_SOURCE_MESSAGE + fullFilePath);
                Console.WriteLine(Msg.QUERY_PRINT_START);
                Console.WriteLine(command.SqlCommand);
                Console.WriteLine(Msg.QUERY_PRINT_END);
            }
            Console.WriteLine(Msg.USER_INPUT_MESSAGE);
        }

    }
}