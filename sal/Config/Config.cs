using SAL.Constants.Values;

namespace SAL.Config
{
    class ConfigFile
    {
        public static void InitializeConfig()
        {
            if(!DoesConfigExist()) CreateConfigFile(Val.DEFAULT_CONFIG_TEXT);
        }

        private static void CreateConfigFile(string text)
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string configFilePath = Path.Combine(currentDirectory, "config.txt");
            
            try
            {
                File.WriteAllText(configFilePath, text);
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Warning: Failed to create the configuration file. This may disable some of the application's features.");
                Console.ResetColor();
            }
        }

        private static bool DoesConfigExist()
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string configFilePath = Path.Combine(currentDirectory, "config.txt");

            return File.Exists(configFilePath);
        }
    }
}