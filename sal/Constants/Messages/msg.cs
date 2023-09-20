namespace SAL.Constants.Messages
{
    public static class Msg
    {
        public const string SQL_FILE_ERROR_WARNING = "Warning: There was an issue accessing the 'query.sql' file. Some functionalities might not work as expected.";
        public const string SQL_FILE_NOT_FOUND_WARNING = "Warning: The 'query.sql' file was not found. Some functionalities might not work as expected.";
        public const string EXECUTE_START_MESSAGE = "Executing SQL query...";
        public const string UNKNOWN_COMMAND_MESSAGE = "Entered command not recognized. Try again.";
        public const string EXIT_MESSAGE = "Closing application...";
        public const string USER_INPUT_MESSAGE = "Please enter a command:";
        public const string WELCOME_MESSAGE = @"
***************************
* SQL AGENT LITE - v. 0.1 *
***************************
This program executes SQL queries once per day.
";

        public const string LIST_OF_COMMANDS = @"
List of commands:
    help            => display this list of commands
    execute         => run the SQL query immediately
    start           => start the scheduler
    stop            => stop the scheduler
    set time        => specify the time to execute the SQL query
    print log       => display the log file (this file can also be found in the program directory named log.txt)
    exit            => close the application
";
    }
}