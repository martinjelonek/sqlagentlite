using SAL.Constants.Messages;

namespace SAL.Commands
{
    class ExitCommand
    {
        public static void Run()
        {
            Console.WriteLine(Msg.EXIT_MESSAGE);
            Environment.Exit(0);
        }
    }
}