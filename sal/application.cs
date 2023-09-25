using SAL.Commands;
using SAL.Config;
using SAL.Constants.Messages;
using SAL.Constants.Values;
using SAL.Scheduler;

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
            ConfigFile.InitializeConfig();
            SchedulerManager.InitializeScheduler();
            if(ConfigManager.GetConfigValue(Val.PARAM_SCHEDULE_AUTORUN)=="on")
            {
                SchedulerManager.KeepRunning=true;
                Msg.WriteLineBlue("The scheduler started automaticlly.");
            }
        }

        private static void ReadInput()
        {
            string? inputText = Console.ReadLine();
            if(inputText is null) return;
            inputText = inputText.ToLower();
            
            if(inputText=="help") 
            {
                HelpCommand.Run();
                return;
            }

            if(inputText=="show")
            {
                ShowCommand.Run();
                return;
            }

            if(inputText=="execute")
            {
                ExecuteCommand.Run(true);
                return;
            }

            if(inputText=="start")
            {
                StartCommand.Run();
                return;
            }

            if(inputText=="stop")
            {
                StopCommand.Run();
                return;
            }

            if(inputText=="set db address")
            {
                SetConfigValueCommand.Run(Val.PARAM_NAME_DB_ADDRESS);
                return;
            }

            if(inputText=="set db name")
            {
                SetConfigValueCommand.Run(Val.PARAM_NAME_DB_NAME);
                return;
            }

            if(inputText=="set cert trust")
            {
                SetConfigValueCommand.Run(Val.PARAM_NAME_CERT_TRUST);
                return;
            }

            if(inputText=="set time")
            {
                SetTimeCommand.Run();
                return;                
            }

            if(inputText=="toggle autostart")
            {
                SetScheduleAutostartCommand.Run();
                return;
            }

            if(inputText=="print config")
            {
                PrintConfigCommand.Run();
                return;
            }

            if(inputText=="exit") ExitCommand.Run();  //This command close the app if executed

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