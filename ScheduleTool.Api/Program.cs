using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using ScheduleTool.Api.Utils;

namespace ScheduleTool.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ScheduleRunnerUtil.Start();
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseApplicationInsights()
                .UseUrls("http://*:5010")
                .Build();

            host.Run();
        }
    }
}
