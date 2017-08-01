using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleTool.Api.Model
{
    public enum ScheduleMode
    {
        Initialize,
        Startup,
        Minutely,
        FiveMin,
        HalfHour,
        Hourly,
        SixHours,
        Daily
    }
}
