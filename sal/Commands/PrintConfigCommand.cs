using SAL.Config;
using SAL.Constants.Messages;

namespace SAL.Commands
{
    class PrintConfigCommand
    {
        public static void Run()
        {
            try
            {
                string[] lines = File.ReadAllLines(ConfigFile.GetConfigFileFullPath());
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            catch
            {
                Msg.WriteLineRed(Msg.CONFIG_FILE_READ_ERROR);
            }

            Console.WriteLine(Msg.USER_INPUT_MESSAGE);
        }
    }
}