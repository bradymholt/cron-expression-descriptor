using System.Globalization;
using System.Threading;

namespace CronExpressionDescriptor
{
    /// <summary>
    /// Options for parsing and describing a Cron Expression
    /// </summary>
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
            if (cultureInfo.Equals(new CultureInfo("ru-RU")) //Russian
                || cultureInfo.Equals(new CultureInfo("uk-UA")) //Ukraninian
                || cultureInfo.Equals(new CultureInfo("de-DE")) //German
                || cultureInfo.Equals(new CultureInfo("it-IT")) //Italian
                || cultureInfo.Equals(new CultureInfo("tr-TR")) //Turkish
                || cultureInfo.Equals(new CultureInfo("pl-PL")) //Polish
                || cultureInfo.Equals(new CultureInfo("ro-RO")) //Romanian                
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
