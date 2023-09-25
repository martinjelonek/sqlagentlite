using SAL.Constants.Messages;

namespace SAL.Commands
{
    class HelpCommand
    {
        public static void Run()
        {
            Console.WriteLine(Msg.LIST_OF_COMMANDS);
            Console.WriteLine(Msg.USER_INPUT_MESSAGE);
        }
    }
}