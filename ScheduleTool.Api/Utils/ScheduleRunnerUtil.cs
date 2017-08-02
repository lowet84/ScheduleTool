using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ScheduleTool.Api.Model;

namespace ScheduleTool.Api.Utils
{
    public static class ScheduleRunnerUtil
    {
        public static void Start()
        {
            Initialize();
            RunUtil.RunScheduleTasks(GetTasks(ScheduleMode.Startup));

            var timer = new Timer(Callback, null, 0, 60000);
        }

        private static void Initialize()
        {
            var initTasks = GetTasks(ScheduleMode.Initialize);
            foreach (var task in initTasks)
            {
                if (InitializeUtil.IsInitialized(task.id)) continue;
                RunUtil.RunScheduleTasks(task);
                InitializeUtil.SetInitialized(task.id);
            }
        }

        private static void Callback(object state)
        {
            Initialize();
            foreach (var scheduleTask in GetTasks(
                ScheduleMode.Daily,
                ScheduleMode.SixHours,
                ScheduleMode.Hourly,
                ScheduleMode.HalfHour,
                ScheduleMode.FiveMin,
                ScheduleMode.Minutely))
            {
                switch (scheduleTask.ScheduleMode)
                {
                    case ScheduleMode.Minutely:
                        RunTaskInBackground(scheduleTask);
                        break;
                    case ScheduleMode.FiveMin:
                        if (DateTime.Now.Minute % 5 == 0)
                            RunTaskInBackground(scheduleTask);
                        break;
                    case ScheduleMode.HalfHour:
                        if (DateTime.Now.Minute % 30 == 0)
                            RunTaskInBackground(scheduleTask);
                        break;
                    case ScheduleMode.Hourly:
                        if (DateTime.Now.Minute == 0)
                            RunTaskInBackground(scheduleTask);
                        break;
                    case ScheduleMode.SixHours:
                        if (DateTime.Now.Minute == 0 && DateTime.Now.Hour % 6 == 0)
                            RunTaskInBackground(scheduleTask);
                        break;
                    case ScheduleMode.Daily:
                        if (DateTime.Now.Minute == 0 && DateTime.Now.Hour == 0)
                            RunTaskInBackground(scheduleTask);
                        break;
                }
            }
        }

        private static void RunTaskInBackground(ScheduleTask scheduleTask)
        {
            Console.WriteLine($"Running task {scheduleTask.Name}, {DateTime.Now}");
            var task = new Task(()=>RunUtil.RunScheduleTasks(scheduleTask));
            task.Start();
        }

        private static List<ScheduleTask> GetTasks(params ScheduleMode[] schedulemodes)
        {
            return DatabaseDataUtil.Instance.GetAllScheduleTasks()
                .Where(d => schedulemodes.Contains(d.ScheduleMode))
                .ToList();
        }
    }
}
