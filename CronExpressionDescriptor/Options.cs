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
            if (cultureInfo.Equals(new CultureInfo("ru")) //Russian
                || cultureInfo.Equals(new CultureInfo("uk")) //Ukraninian
                || cultureInfo.Equals(new CultureInfo("de")) //German
                || cultureInfo.Equals(new CultureInfo("it")) //Italian
                )
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
