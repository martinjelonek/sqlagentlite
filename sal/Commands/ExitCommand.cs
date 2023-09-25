using SAL.Constants.Messages;
using SAL.Log;

namespace SAL.Commands
{
    class ExitCommand
    {
        public static void Run()
        {
            Console.WriteLine(Msg.EXIT_MESSAGE);
            LogManager.AddLogEntry("Program close.");
            Environment.Exit(0);
        }
    }
}