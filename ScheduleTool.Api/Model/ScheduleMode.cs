using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleTool.Api.Model
{
    public enum ScheduleMode
    {
        Initialize,
        Minutely,
        FiveMin,
        HalfHour,
        Hourly,
        FiveHours,
        TwicePerDay,
        Daily
    }
}
