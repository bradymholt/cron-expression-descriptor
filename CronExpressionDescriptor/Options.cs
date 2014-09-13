using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

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
            this.Use24HourTimeFormat = false;

            //culture specific default options
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentUICulture;
            if (cultureInfo.Equals(new CultureInfo("ru"))) //Russian
            {
                this.Use24HourTimeFormat = true;
            }
        }

        public bool ThrowExceptionOnParseError { get; set; }
        public CasingTypeEnum CasingType { get; set; }
        public bool Verbose { get; set; }
        public bool DayOfWeekStartIndexZero { get; set; }
        public bool Use24HourTimeFormat { get; set; }
    }
}
