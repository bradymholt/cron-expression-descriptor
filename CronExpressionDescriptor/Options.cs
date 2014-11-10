using System.Globalization;
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
            // 24 hours format for Russian, Ukrainian
            if (cultureInfo.Equals(new CultureInfo("ru")) || cultureInfo.Equals(new CultureInfo("uk")))
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
