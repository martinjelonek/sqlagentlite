namespace SAL.Constants.Values
{
    public static class Val
    {
        public const string PARAM_LAST_SCHEDULE_DATE = "last_schedule_date"; 
        public const string PARAM_NAME_SCHEDULER_TIME = "scheduler_time";
        public const string PARAM_NAME_CERT_TRUST = "cert_trust";
        public const string PARAM_NAME_DB_NAME = "db_name";
        public const string PARAM_NAME_DB_ADDRESS = "db_address";
        public const string CONFIG_FILE_NAME = "config.txt";
        public const string DEFAULT_SQL_COMMAND = "SELECT CONVERT(nvarchar, GETDATE()) + '  - exampple sql command executed.';";
        public const string DEFAULT_CONFIG_TEXT = @"scheduler_time = 00:00
db_address = localhost
db_name =
cert_trust = false
";
    } 
}