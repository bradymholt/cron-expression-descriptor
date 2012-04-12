using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CronExpressionDescriptor
{
    public class Options
    {
        public Options()
        {
            this.ThrowExceptionOnParseError = true;
            this.CasingType = CasingTypeEnum.Sentence;
            this.Verbose = false;
            this.DayOfWeekStartIndexZero = true;
        }

        public bool ThrowExceptionOnParseError { get; set; }
        public CasingTypeEnum CasingType { get; set; }
        public bool Verbose { get; set; }
        public bool DayOfWeekStartIndexZero { get; set; }
    }
}
