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
      this.Verbose = false;
      this.DayOfWeekStartIndexZero = true;
    }

    /// <summary>
    /// Whether to throw when the expression can't be described, or return the error message as the description (Default: true)
    /// </summary>
    public bool ThrowExceptionOnParseError { get; set; }

    /// <summary>
    /// Whether to keep parts like ", every minute" that only restate the default (Default: false)
    /// </summary>
    public bool Verbose { get; set; }

    /// <summary>
    /// Whether day of week 0 is Sunday (true) or 1 is Sunday (false) (Default: true)
    /// </summary>
    public bool DayOfWeekStartIndexZero { get; set; }

    /// <summary>
    /// Whether to use a 24-hour clock; when null, the locale decides
    /// </summary>
    public bool? Use24HourTimeFormat { get; set; }

    /// <summary>
    /// The locale to describe the expression in (e.g. "de"); when null, Thread.CurrentUICulture is used
    /// </summary>
    public string Locale { get; set; }
  }
}
