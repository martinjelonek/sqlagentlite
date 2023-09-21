namespace SAL.Constants.Values
{
    public static class Val
    {
        public const string CONFIG_FILE_NAME = "config.txt";
        public const string DEFAULT_SQL_COMMAND = "SELECT CONVERT(nvarchar, GETDATE()) + '  - exampple sql command executed.';";
        public const string DEFAULT_CONFIG_TEXT = @"scheduler_time = 00:00
db_address = localhost
db_name =
cert_trust = false
";
    } 
}