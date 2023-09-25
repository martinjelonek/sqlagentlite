using SAL.Constants.Messages;
using SAL.Scheduler;

namespace SAL.Commands
{
    class StartCommand
    {
        public static void Run()
        {
            SchedulerManager.StartScheduler();
            Msg.WriteLineBlue("The scheduler has been started.");
            Console.WriteLine(Msg.USER_INPUT_MESSAGE);
        }
    }
}