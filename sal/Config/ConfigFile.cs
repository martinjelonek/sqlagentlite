using SAL.Constants.Messages;
using SAL.Constants.Values;

namespace SAL.Config
{
    class ConfigFile
    {
        public static void InitializeConfig()
        {
            if(!DoesConfigExist()) CreateConfigFile(Val.DEFAULT_CONFIG_TEXT);
        }

        public static bool DoesConfigExist()
        {
            return File.Exists(GetConfigFileFullPath());
        }

        public static string GetConfigFileFullPath()
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string configFilePath = Path.Combine(currentDirectory, Val.CONFIG_FILE_NAME);

            return configFilePath;
        }

        private static void CreateConfigFile(string text)
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string configFilePath = Path.Combine(currentDirectory, Val.CONFIG_FILE_NAME);
            
            try
            {
                File.WriteAllText(configFilePath, text);
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(Msg.CONFIG_FILE_NOT_CREATED_WARNING);
                Console.ResetColor();
            }
        }
    }
}