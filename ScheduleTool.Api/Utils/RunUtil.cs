﻿using System.Diagnostics;
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
    }
}
