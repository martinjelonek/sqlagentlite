namespace SAL.Scheduler
{
    class SchedulerManager
    {
        public static bool queryInProgress = false;
        private static bool _keepRunning = false;
        private static bool _schedulerInitialized = false;
        public static bool KeepRunning
        {
            get { return _keepRunning; }
        }
        
        private static Thread schedulerThread = new(CheckSchedule);

        public static void InitializeScheduler()
        {
            if(!_schedulerInitialized)
            {
                schedulerThread.Start();
                _schedulerInitialized = true;
            }
        }

        public static void StartScheduler()
        {
            _keepRunning = true;
        }

        public static void StopScheduler()
        {
            _keepRunning = false;
        }

        private static void CheckSchedule()
        {
            while(true) 
            {
                if(_keepRunning) Console.WriteLine("Check schedule test...");
                Thread.Sleep(5000);
            }
        }
    }
}