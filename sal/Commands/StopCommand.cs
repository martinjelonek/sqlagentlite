using SAL.Constants.Messages;
using SAL.Scheduler;

namespace SAL.Commands
{
    class StopCommand
    {
        public static void Run()
        {
            SchedulerManager.StopScheduler();
            Console.WriteLine(Msg.USER_INPUT_MESSAGE);
        }
    }
}