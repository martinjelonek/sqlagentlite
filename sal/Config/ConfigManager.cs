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
                if (string.IsNullOrWhiteSpace(line))
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

        public static void AddOrUpdateConfigValue(string configName, string value)
        {
            List<string> lines = new List<string>();
            bool found = false;

            if(!ConfigFile.DoesConfigExist())
            {
                Msg.WriteLineYellow(Msg.CONFIG_FILE_NOT_FOUND_AND_VALUE_NOT_ADDED_WARNING);
            }
            
            try
            {
                lines.AddRange(File.ReadAllLines(ConfigFile.GetConfigFileFullPath()));

                for (int i = 0; i < lines.Count; i++)
                {
                    string line = lines[i];
                    
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        continue;
                    }

                    string[] parts = line.Split('=', 2);
                    if (parts.Length != 2)
                    {
                        continue;
                    }

                    string key = parts[0].Trim();
                    string configValue = parts[1].Trim();

                    if (key.Equals(configName, StringComparison.OrdinalIgnoreCase))
                    {
                        lines[i] = $"{key} = {value}";
                        found = true;
                        break;
                    }
                    
                    if (!found)
                    {
                        lines.Add($"{configName} = {value}");
                    }
                    
                    File.WriteAllLines(ConfigFile.GetConfigFileFullPath(), lines);
                }
            }
            catch
            {
                Msg.WriteLineYellow(Msg.CONFIG_FILE_ERROR_AND_VALUE_NOT_ADDED_WARNING);
            }
        }
    }
}