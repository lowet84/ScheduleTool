using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleTool.Api.Model
{
    public class ScheduleTask : ModelBase
    {
        public string Name { get; set; }
        public ScheduleMode ScheduleMode { get; set; }
        public List<string> Commands { get; set; }
    }
}
