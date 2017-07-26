using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleTool.Api.Model
{
    public class LogItem : ModelBase
    {
        public string TaskId { get; set; }
        public DateTime Time { get; set; }
        public string Result { get; set; }
    }
}
