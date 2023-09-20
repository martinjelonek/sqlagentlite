namespace SAL.Constants.Messages
{
    public static class Msg
    {
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