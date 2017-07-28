using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ScheduleTool.Api.Model;

namespace ScheduleTool.Api.Utils
{
    public static class ScheduleRunnerUtil
    {
        public static void Start()
        {
            var initTasks = GetTasks(ScheduleMode.Initialize);
            foreach (var task in initTasks)
            {
                if (InitializeUtil.IsInitialized(task.id)) continue;
                RunUtil.RunScheduleTasks(task);
                InitializeUtil.SetInitialized(task.id);
            }

            RunUtil.RunScheduleTasks(GetTasks(ScheduleMode.Startup));
        }

        private static List<ScheduleTask> GetTasks(params ScheduleMode[] schedulemodes)
        {
            return DatabaseDataUtil.Instance.GetAllScheduleTasks()
                .Where(d => schedulemodes.Contains(d.ScheduleMode))
                .ToList();
        }
    }
}
