using SAL.Config;
using SAL.Constants.Messages;
using SAL.Constants.Values;

namespace SAL.Commands
{
    public static class SetScheduleAutostartCommand
    {
        public static void Run()
        {
            string? autorun = ConfigManager.GetConfigValue(Val.PARAM_SCHEDULE_AUTORUN);
            if(autorun=="on")
            {
                ConfigManager.AddOrUpdateConfigValue(Val.PARAM_SCHEDULE_AUTORUN, "off");
                Console.WriteLine("The scheduler autostart is disebled.");
            }
            else
            {
                ConfigManager.AddOrUpdateConfigValue(Val.PARAM_SCHEDULE_AUTORUN, "on");
                Console.WriteLine("The scheduler autostart is enabled.");
            }
            Console.WriteLine(Msg.USER_INPUT_MESSAGE);  
        }
    }
}