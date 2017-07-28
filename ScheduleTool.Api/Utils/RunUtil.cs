using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ScheduleTool.Api.Model;

namespace ScheduleTool.Api.Utils
{
    public static class RunUtil
    {
        public static string Run(RunCommand command)
        {
            var process = new Process();
            var startInfo = new ProcessStartInfo
            {
                FileName = command.Application,
                Arguments = command.Arguments,
                CreateNoWindow = true,
                RedirectStandardOutput = true
            };
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            var output = process.StandardOutput.ReadToEnd();
            return output;
        }

        public static void RunScheduleTasks(IList<ScheduleTask> tasks)
        {
            RunScheduleTasks(tasks.ToArray());
        }

        public static void RunScheduleTasks(params ScheduleTask[] tasks)
        {
            foreach (var task in tasks)
            {
                RunScheduleTask(task);
            }
        }

        private static void RunScheduleTask(ScheduleTask task)
        {
            var commands = task.Commands.Select(commandId => DatabaseDataUtil.Instance.GetCommand(commandId)).ToList();
            foreach (var runCommand in commands)
            {
                var result = Run(runCommand);
                DatabaseDataUtil.Instance.Log(new LogItem { Result = result, TaskId = task.id, Time = DateTime.Now });
            }
        }
    }
}
