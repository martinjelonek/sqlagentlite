using SAL.Config;
using SAL.Constants.Messages;

namespace SAL.Commands
{
    class SetConfigValueCommand
    {
        public static void Run(string paramName)
        {
            Console.WriteLine(Msg.USER_INPUT_VALUE_SET_MESSAGE);

            string? value = Console.ReadLine();
            if(value is null || value=="")
            {
                Msg.WriteLineYellow(Msg.NO_VALUE_ENTERED_MESSAGE);
            }
            else
            {
                ConfigManager.AddOrUpdateConfigValue(paramName, value);
            }
            Console.WriteLine(Msg.USER_INPUT_MESSAGE);
        }
    }
}