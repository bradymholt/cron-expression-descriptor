using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CronExpressionDescriptor
{
    public enum ExpressionTypeEnum
    {
        /// <summary>
        /// Minutes Hours DOM Month DOW (Year)
        /// </summary>
        Crontab,

        /// <summary>
        /// Seconds Minutes Hours DOM Month DOW (Year)
        /// </summary>
        Quartz
    }
}
