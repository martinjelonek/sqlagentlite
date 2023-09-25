using SAL.Commands;
using SAL.Config;
using SAL.Constants.Messages;
using SAL.Constants.Values;

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
                Thread.Sleep(5000);
                
                if(_keepRunning)
                {
                    //Check time
                    string? time = ConfigManager.GetConfigValue(Val.PARAM_NAME_SCHEDULER_TIME);
                    if(time is null) continue;
                    if(!DataValidator.IsValidTimeFormat(time)) continue;
                    TimeSpan scheduleTime = TimeSpan.Parse(time);
                    if(scheduleTime > DateTime.Now.TimeOfDay)
                    {
                        continue;
                    }

                    //Check day
                    string? date = ConfigManager.GetConfigValue(Val.PARAM_LAST_SCHEDULE_DATE);
                    if(date is not null && DataValidator.IsValidDateFormat(date))
                    {
                        DateTime lastScheduleDate = DateTime.Parse(date);
                        if(lastScheduleDate >= DateTime.Now.Date) continue;
                    }

                    //Execute schedule
                    ExecuteCommand.Run(false);

                    //Update last schedule date
                    ConfigManager.AddOrUpdateConfigValue(Val.PARAM_LAST_SCHEDULE_DATE, DateTime.Now.Date.ToString("yyyy-MM-dd"));
                }
            }
        }
    }
}