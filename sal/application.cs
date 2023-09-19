using SAL.Commands;
using SAL.Constants.Messages;

namespace SAL
{
    public class Application
    {
        public static void Run()
        {
            InitialPrint();
            ReadInput();
        }

        private static void ReadInput()
        {
            string? inputText;

            Console.WriteLine(Msg.USER_INPUT_MESSAGE);
            inputText = Console.ReadLine();
            
            if(inputText is null) return;
            
            if(inputText.ToLower()=="help") 
            {
                HelpCommand.Run();
                return;
            }

            if(inputText.ToLower()=="exit") ExitCommand.Run();
        }

        private static void InitialPrint()
        {
            Console.WriteLine(Msg.WELCOME_MESSAGE);
            Console.WriteLine(Msg.LIST_OF_COMMANDS);
        }
    }
}