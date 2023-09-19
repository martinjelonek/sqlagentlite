namespace SAL.Constants.Messages
{
    public static class Msg
    {
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
    use sql auth    => the scheduler will use SQL authentication
    use win auth    => the scheduler will use Windows authentication
    set username    => specify the SQL username for SQL authentication
    set password    => specify the password for SQL authentication
    print log       => display the log file (this file can also be found in the program directory named log.txt)
";
    }
}    