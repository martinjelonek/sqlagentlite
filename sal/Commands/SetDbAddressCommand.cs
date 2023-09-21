using SAL.Config;
using SAL.Constants.Messages;
using SAL.Constants.Values;

namespace SAL.Commands
{
    class SetDbAddressCommand
    {
        public static void Run()
        {
            Console.WriteLine();

            string? value = Console.ReadLine();
            if(value is null || value=="")
            {
                Msg.WriteLineYellow(Msg.NO_VALUE_ENTERED_MESSAGE);
            }
            else
            {
                ConfigManager.AddOrUpdateConfigValue(Val.PARAM_NAME_DB_ADDRESS, value);
            }
            Console.WriteLine(Msg.USER_INPUT_MESSAGE);
        }
    }
}