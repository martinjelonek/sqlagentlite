using System.Security;
using SAL.Constants.Messages;

namespace SAL.Config
{
    class ConfigManager
    {
        public static string GetConfigValue(string configName)
        {
            if(!ConfigFile.DoesConfigExist())
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(Msg.CONFIG_FILE_NOT_FOUND_WARNING);
                Console.ResetColor();
                return null;
            }
            
            string[] lines;
            try
            {
                lines = File.ReadAllLines(ConfigFile.GetConfigFileFullPath());
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(Msg.CONFIG_FILE_ERROR_WARNING);
                Console.ResetColor();
                return null;
            }

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                {
                    continue;
                }

                string[] parts = line.Split('=', 2);
                if (parts.Length != 2)
                {
                    continue;
                }

                string key = parts[0].Trim();
                string value = parts[1].Trim();

                if (key.Equals(configName, StringComparison.OrdinalIgnoreCase))
                {
                    return value;
                }
            }

            return null;
        }
    }
}