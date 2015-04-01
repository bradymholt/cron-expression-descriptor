using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CronExpressionDescriptor
{
    /// <summary>
    /// Enum to define the description "parts" of a Cron Expression  
    /// </summary>
    public enum DescriptionTypeEnum
    {
        FULL,
        TIMEOFDAY,
        SECONDS,
        MINUTES,
        HOURS,
        DAYOFWEEK,
        MONTH,
        DAYOFMONTH,
        YEAR
    }
}
