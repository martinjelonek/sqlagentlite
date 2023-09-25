using SAL.Config;
using SAL.Constants.Messages;
using SAL.Constants.Values;
using SAL.Scheduler;

namespace SAL.Commands
{
    class SetTimeCommand
    {
        public static void Run()
        {
            // Abort operation if scheduler is running
            if(SchedulerManager.KeepRunning)
            {
                Msg.WriteLineYellow(Msg.SCHEDULER_IS_RUNNING_MESSAGE);
                Console.WriteLine(Msg.USER_INPUT_MESSAGE);
                return;
            }

            Console.WriteLine(Msg.SCHEDULER_TIME_INPUT_MESSAGE);
            string? value = Console.ReadLine();
            
            //Abort operation if entered value is null or empty
            if(value is null || value == "")
            {
                Msg.WriteLineYellow(Msg.NO_VALUE_ENTERED_MESSAGE);
                Console.WriteLine(Msg.USER_INPUT_MESSAGE);
                return;
            }

            //Abort operation if entered value format is incorrect
            if(!DataValidator.IsValidTimeFormat(value))
            {
                Msg.WriteLineYellow("Entered value '" + value + "' has incorrect format!");
                Console.WriteLine(Msg.USER_INPUT_MESSAGE);
                return;
            }

            ConfigManager.AddOrUpdateConfigValue(Val.PARAM_NAME_SCHEDULER_TIME, value);
            Console.WriteLine(Msg.USER_INPUT_MESSAGE);
        }
    }
}