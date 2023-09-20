using SAL.Commands;
using SAL.Constants.Messages;
using SAL.Config;

namespace SAL
{
    public class Application
    {
        public static void Run()
        {
            InitialPrint();
            Initialize();
            while(true) ReadInput();
        }

        private static void Initialize()
        {
            Config.ConfigFile.InitializeConfig();
        }

        private static void ReadInput()
        {
            string? inputText;

            inputText = Console.ReadLine();
            
            if(inputText is null) return;
            
            if(inputText.ToLower()=="help") 
            {
                HelpCommand.Run();
                return;
            }

            if(inputText.ToLower()=="show")
            {
                ShowCommand.Run();
                return;
            }

            if(inputText.ToLower()=="exit") ExitCommand.Run();  //This command close app if executed

            Console.WriteLine(Msg.UNKNOWN_COMMAND_MESSAGE); //No command found for inputText
            Console.WriteLine(Msg.USER_INPUT_MESSAGE);
        }

        private static void InitialPrint()
        {
            Console.WriteLine(Msg.WELCOME_MESSAGE);
            Console.WriteLine(Msg.LIST_OF_COMMANDS);
            Console.WriteLine(Msg.USER_INPUT_MESSAGE);
        }
    }
}