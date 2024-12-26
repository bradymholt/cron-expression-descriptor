using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CronExpressionDescriptor
{
  /// <summary>
  /// Converts a Cron Expression into a human readable string
  /// </summary>
  public class ExpressionDescriptor
  {
    private readonly char[] m_specialCharacters = new char[] { '/', '-', ',', '*' };
    private readonly string[] m_24hourTimeFormatTwoLetterISOLanguageName = new string[] { "ru", "uk", "de", "it", "tr", "pl", "ro", "da", "sl", "fi", "sv", "nb", "hu", "cs" };

    private string m_expression;
    private Options m_options;
    private string[] m_expressionParts;
    private bool m_parsed;
    private bool m_use24HourTimeFormat;
    private CultureInfo m_culture;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExpressionDescriptor"/> class
    /// </summary>
    /// <param name="expression">The cron expression string</param>
    public ExpressionDescriptor(string expression) : this(expression, new Options()) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ExpressionDescriptor"/> class
    /// </summary>
    /// <param name="expression">The cron expression string</param>
    /// <param name="options">Options to control the output description</param>
    public ExpressionDescriptor(string expression, Options options)
    {
      m_expression = expression;
      m_options = options;
      m_expressionParts = new string[7];
      m_parsed = false;

      if (!string.IsNullOrEmpty(options.Locale))
      {
        m_culture = new CultureInfo(options.Locale);
      }
      else
      {
        // If options.Locale not specified...
#if NET_STANDARD_1X
        // .NET Standard 1.* will use English as default
        m_culture = new CultureInfo("en-US");
#else
        // .NET Standard >= 2.0 will use CurrentUICulture as default
        m_culture = System.Threading.Thread.CurrentThread.CurrentUICulture;
#endif
      }

      if (m_options.Use24HourTimeFormat != null)
      {
        // 24HourTimeFormat specified in options so use it
        m_use24HourTimeFormat = m_options.Use24HourTimeFormat.Value;
      }
      else
      {
        // 24HourTimeFormat not specified, default based on m_24hourTimeFormatLocales
        m_use24HourTimeFormat = m_24hourTimeFormatTwoLetterISOLanguageName.Contains(m_culture.TwoLetterISOLanguageName);
      }
    }

    /// <summary>
    /// Generates a human readable string for the Cron Expression
    /// </summary>
    /// <param name="type">Which part(s) of the expression to describe</param>
    /// <returns>The cron expression description</returns>
    public string GetDescription(DescriptionTypeEnum type)
    {
      string description = string.Empty;

      try
      {
        if (!m_parsed)
        {
          ExpressionParser parser = new ExpressionParser(m_expression, m_options);
          m_expressionParts = parser.Parse();
          m_parsed = true;
        }

        switch (type)
        {
          case DescriptionTypeEnum.FULL:
            description = GetFullDescription();
            break;
          case DescriptionTypeEnum.TIMEOFDAY:
            description = GetTimeOfDayDescription();
            break;
          case DescriptionTypeEnum.HOURS:
            description = GetHoursDescription();
            break;
          case DescriptionTypeEnum.MINUTES:
            description = GetMinutesDescription();
            break;
          case DescriptionTypeEnum.SECONDS:
            description = GetSecondsDescription();
            break;
          case DescriptionTypeEnum.DAYOFMONTH:
            description = GetDayOfMonthDescription();
            break;
          case DescriptionTypeEnum.MONTH:
            description = GetMonthDescription();
            break;
          case DescriptionTypeEnum.DAYOFWEEK:
            description = GetDayOfWeekDescription();
            break;
          case DescriptionTypeEnum.YEAR:
            description = GetYearDescription();
            break;
          default:
            description = GetSecondsDescription();
            break;
        }
      }
      catch (Exception ex)
      {
        if (!m_options.ThrowExceptionOnParseError)
        {
          description = ex.Message;
        }
        else
        {
          throw;
        }
      }

      // Uppercase the first letter
      description = string.Concat(m_culture.TextInfo.ToUpper(description[0]), description.Substring(1));

      return description;
    }

    /// <summary>
    /// Generates the FULL description
    /// </summary>
    /// <returns>The FULL description</returns>
    protected string GetFullDescription()
    {
      string description;

      try
      {
        string timeSegment = GetTimeOfDayDescription();
        string dayOfMonthDesc = GetDayOfMonthDescription();
        string monthDesc = GetMonthDescription();
        string dayOfWeekDesc = GetDayOfWeekDescription();
        string yearDesc = GetYearDescription();

        description = string.Format("{0}{1}{2}{3}{4}",
               timeSegment,
               dayOfMonthDesc,
               dayOfWeekDesc,
               monthDesc,
               yearDesc);

        description = TransformVerbosity(description, m_options.Verbose);
      }
      catch (Exception ex)
      {
        description = GetString("AnErrorOccurredWhenGeneratingTheExpressionD");
        if (m_options.ThrowExceptionOnParseError)
        {
          throw new FormatException(description, ex);
        }
      }


      return description;
    }

    /// <summary>
    /// Generates a description for only the TIMEOFDAY portion of the expression
    /// </summary>
    /// <returns>The TIMEOFDAY description</returns>
    protected string GetTimeOfDayDescription()
    {
      string secondsExpression = m_expressionParts[0];
      string minuteExpression = m_expressionParts[1];
      string hourExpression = m_expressionParts[2];

      StringBuilder description = new StringBuilder();

      //handle special cases first
      if (minuteExpression.IndexOfAny(m_specialCharacters) == -1
          && hourExpression.IndexOfAny(m_specialCharacters) == -1
          && secondsExpression.IndexOfAny(m_specialCharacters) == -1)
      {
        //specific time of day (i.e. 10 14)
        description.Append(GetString("AtSpace")).Append(FormatTime(hourExpression, minuteExpression, secondsExpression));
      }
      else if (secondsExpression == "" && minuteExpression.Contains("-")
          && !minuteExpression.Contains(",")
          && hourExpression.IndexOfAny(m_specialCharacters) == -1)
      {
        //minute range in single hour (i.e. 0-10 11)
        string[] minuteParts = minuteExpression.Split('-');
        description.Append(string.Format(GetString("EveryMinuteBetweenX0AndX1"),
            FormatTime(hourExpression, minuteParts[0]),
            FormatTime(hourExpression, minuteParts[1])));
      }
      else if (secondsExpression == "" && hourExpression.Contains(",")
          && hourExpression.IndexOf('-') == -1
          && minuteExpression.IndexOfAny(m_specialCharacters) == -1)
      {
        //hours list with single minute (o.e. 30 6,14,16)
        string[] hourParts = hourExpression.Split(',');
        description.Append(GetString("At"));
        for (int i = 0; i < hourParts.Length; i++)
        {
          description.Append(" ").Append(FormatTime(hourParts[i], minuteExpression));

          if (i < (hourParts.Length - 2))
          {
            description.Append(",");
          }

          if (i == hourParts.Length - 2)
          {
            description.Append(GetString("SpaceAnd"));
          }
        }
      }
      else
      {
        //default time description
        string secondsDescription = GetSecondsDescription();
        string minutesDescription = GetMinutesDescription();
        string hoursDescription = GetHoursDescription();

        description.Append(secondsDescription);

        if (description.Length > 0 && minutesDescription.Length > 0)
        {
          description.Append(", ");
        }

        description.Append(minutesDescription);

        if (description.Length > 0 && hourExpression.Length > 0)
        {
          description.Append(", ");
        }

        description.Append(hoursDescription);
      }


      return description.ToString();
    }

    /// <summary>
    /// Generates a description for only the SECONDS portion of the expression
    /// </summary>
    /// <returns>The SECONDS description</returns>
    protected string GetSecondsDescription()
    {
      string description = GetSegmentDescription(
         m_expressionParts[0],
         GetString("EverySecond"),
         (s => s),
         (s => string.Format(GetString("EveryX0Seconds"), s)),
         (s => GetString("SecondsX0ThroughX1PastTheMinute")),
         (s =>
         {
           int i = 0;
           if (int.TryParse(s, out i))
           {
             return s == "0"
                    ? string.Empty
                    : (i < 20)
                        ? GetString("AtX0SecondsPastTheMinute")
                        : GetString("AtX0SecondsPastTheMinuteGt20") ?? GetString("AtX0SecondsPastTheMinute");

           }
           else
           {
             return GetString("AtX0SecondsPastTheMinute");
           }
         }),
         (s => GetString("ComaMinX0ThroughMinX1") ?? GetString("ComaX0ThroughX1"))
         );

      return description;
    }

    /// <summary>
    /// Generates a description for only the MINUTE portion of the expression
    /// </summary>
    /// <returns>The MINUTE description</returns>
    protected string GetMinutesDescription()
    {
      string secondsExpression = m_expressionParts[0];
      string description = GetSegmentDescription(
          expression: m_expressionParts[1],
          allDescription: GetString("EveryMinute"),
          getSingleItemDescription: (s => s),
          getIntervalDescriptionFormat: (s => string.Format(GetString("EveryX0Minutes"), s)),
          getBetweenDescriptionFormat: (s => GetString("MinutesX0ThroughX1PastTheHour")),
          getDescriptionFormat: (s =>
          {
            int i = 0;
            if (int.TryParse(s, out i))
            {
              return s == "0" && secondsExpression == ""
                      ? string.Empty
                      : (int.Parse(s) < 20)
                          ? GetString("AtX0MinutesPastTheHour")
                          : GetString("AtX0MinutesPastTheHourGt20") ?? GetString("AtX0MinutesPastTheHour");
            }
            else
            {
              return GetString("AtX0MinutesPastTheHour");
            }
          }),
          getRangeFormat: (s => GetString("ComaMinX0ThroughMinX1") ?? GetString("ComaX0ThroughX1"))
      );

      return description;
    }

    /// <summary>
    /// Generates a description for only the HOUR portion of the expression
    /// </summary>
    /// <returns>The HOUR description</returns>
    protected string GetHoursDescription()
    {
      string expression = m_expressionParts[2];
      string description = GetSegmentDescription(expression,
             GetString("EveryHour"),
             (s => FormatTime(s, "0")),
             (s => string.Format(GetString("EveryX0Hours"), s)),
             (s => GetString("BetweenX0AndX1")),
             (s => GetString("AtX0")),
             (s => GetString("ComaMinX0ThroughMinX1") ?? GetString("ComaX0ThroughX1"))
         );

      return description;
    }

    /// <summary>
    /// Generates a description for only the DAYOFWEEK portion of the expression
    /// </summary>
    /// <returns>The DAYOFWEEK description</returns>
    protected string GetDayOfWeekDescription()
    {
      string description = null;

      if (m_expressionParts[5] == "*")
      {
        // DOW is specified as * so we will not generate a description and defer to DOM part.
        // Otherwise, we could get a contradiction like "on day 1 of the month, every day"
        // or a dupe description like "every day, every day".
        description = string.Empty;

      }
      else
      {
        description = GetSegmentDescription(
            m_expressionParts[5],
            GetString("ComaEveryDay"),
            (s =>
            {
              string exp = s.Contains("#")
                          ? s.Remove(s.IndexOf("#"))
                          : s.Contains("L")
                              ? s.Replace("L", string.Empty)
                              : s;

              return m_culture.DateTimeFormat.GetDayName(((DayOfWeek)Convert.ToInt32(exp)));
            }),
            (s => string.Format(GetString("ComaEveryX0DaysOfTheWeek"), s)),
            (s => GetString("ComaX0ThroughX1")),
            (s =>
            {
              string format = null;
              if (s.Contains("#"))
              {
                string dayOfWeekOfMonthNumber = s.Substring(s.IndexOf("#") + 1);
                string dayOfWeekOfMonthDescription = null;
                switch (dayOfWeekOfMonthNumber)
                {
                  case "1":
                    dayOfWeekOfMonthDescription = GetString("First");
                    break;
                  case "2":
                    dayOfWeekOfMonthDescription = GetString("Second");
                    break;
                  case "3":
                    dayOfWeekOfMonthDescription = GetString("Third");
                    break;
                  case "4":
                    dayOfWeekOfMonthDescription = GetString("Fourth");
                    break;
                  case "5":
                    dayOfWeekOfMonthDescription = GetString("Fifth");
                    break;
                }


                format = string.Concat(GetString("ComaOnThe"),
                            dayOfWeekOfMonthDescription, GetString("SpaceX0OfTheMonth"));
              }
              else if (s.Contains("L"))
              {
                format = GetString("ComaOnTheLastX0OfTheMonth");
              }
              else
              {
                format = GetString("ComaOnlyOnX0");
              }

              return format;
            }),
            (s => GetString("ComaX0ThroughX1"))
      );
      }

      return description;
    }

    /// <summary>
    /// Generates a description for only the MONTH portion of the expression
    /// </summary>
    /// <returns>The MONTH description</returns>
    protected string GetMonthDescription()
    {
      string description = GetSegmentDescription(
          m_expressionParts[4],
          string.Empty,
         (s => new DateTime(DateTime.Now.Year, Convert.ToInt32(s), 1).ToString("MMMM", m_culture)),
         (s => string.Format(GetString("ComaEveryX0Months"), s)),
         (s => GetString("ComaMonthX0ThroughMonthX1") ?? GetString("ComaX0ThroughX1")),
         (s => GetString("ComaOnlyInX0")),
         (s => GetString("ComaMonthX0ThroughMonthX1") ?? GetString("ComaX0ThroughX1"))
      );

      return description;
    }

    /// <summary>
    /// Generates a description for only the DAYOFMONTH portion of the expression
    /// </summary>
    /// <returns>The DAYOFMONTH description</returns>
    protected string GetDayOfMonthDescription()
    {
      string description = null;
      string expression = m_expressionParts[3];

      switch (expression)
      {
        case "L":
          description = GetString("ComaOnTheLastDayOfTheMonth");
          break;
        case "WL":
        case "LW":
          description = GetString("ComaOnTheLastWeekdayOfTheMonth");
          break;
        default:
          Regex weekDayNumberMatches = new Regex("(\\d{1,2}W)|(W\\d{1,2})");
          if (weekDayNumberMatches.IsMatch(expression))
          {
            Match m = weekDayNumberMatches.Match(expression);
            int dayNumber = Int32.Parse(m.Value.Replace("W", ""));

            string dayString = dayNumber == 1 ? GetString("FirstWeekday") :
                String.Format(GetString("WeekdayNearestDayX0"), dayNumber);
            description = String.Format(GetString("ComaOnTheX0OfTheMonth"), dayString);

            break;
          }
          else
          {
            // Handle "last day offset" (i.e. L-5:  "5 days before the last day of the month")
            Regex lastDayOffSetMatches = new Regex("L-(\\d{1,2})");
            if (lastDayOffSetMatches.IsMatch(expression))
            {
              Match m = lastDayOffSetMatches.Match(expression);
              string offSetDays = m.Groups[1].Value;
              description = String.Format(GetString("CommaDaysBeforeTheLastDayOfTheMonth"), offSetDays);
              break;
            }
            else if (expression == "*" && m_expressionParts[5] != "*")
            {
              // DOW is specified, but DOM is *, so do not generate DOM description.
              // Otherwise, we could get a contradiction like "every day, on Tuesday"
              description = string.Empty;
              break;
            }
            else
            {
              description = GetSegmentDescription(expression,
                  GetString("ComaEveryDay"),
                  (s => s),
                  (s => s == "1" ? GetString("ComaEveryDay") : GetString("ComaEveryX0Days")),
                  (s => GetString("ComaBetweenDayX0AndX1OfTheMonth")),
                  (s => GetString("ComaOnDayX0OfTheMonth")),
                  (s => GetString("ComaX0ThroughX1"))
              );
              break;
            }
          }
      }

      return description;
    }

    /// <summary>
    /// Generates a description for only the YEAR portion of the expression
    /// </summary>
    /// <returns>The YEAR description</returns>
    private string GetYearDescription()
    {
      string description = GetSegmentDescription(m_expressionParts[6],
          string.Empty,
         (s => Regex.IsMatch(s, @"^\d+$") ?
          new DateTime(Convert.ToInt32(s), 1, 1).ToString("yyyy") : s),
         (s => string.Format(GetString("ComaEveryX0Years"), s)),
         (s => GetString("ComaYearX0ThroughYearX1") ?? GetString("ComaX0ThroughX1")),
         (s => GetString("ComaOnlyInYearX0")),
         (s => GetString("ComaYearX0ThroughYearX1") ?? GetString("ComaX0ThroughX1"))
      );

      return description;
    }

    /// <summary>
    /// Generates the segment description
    /// <remarks>
    /// Range expressions used the 'ComaX0ThroughX1' resource
    /// However Romanian language has different idioms for
    /// 1. 'from number to number' (minutes, seconds, hours, days) => ComaMinX0ThroughMinX1 optional resource
    /// 2. 'from month to month' ComaMonthX0ThroughMonthX1 optional resource
    /// 3. 'from year to year' => ComaYearX0ThroughYearX1 optional resource
    /// therefore <paramref name="getRangeFormat"/> was introduced
    /// </remarks>
    /// </summary>
    /// <param name="expression"></param>
    /// <param name="allDescription"></param>
    /// <param name="getSingleItemDescription"></param>
    /// <param name="getIntervalDescriptionFormat"></param>
    /// <param name="getBetweenDescriptionFormat"></param>
    /// <param name="getDescriptionFormat"></param>
    /// <param name="getRangeFormat">function that formats range expressions depending on cron parts</param>
    /// <returns></returns>
    protected string GetSegmentDescription(string expression,
        string allDescription,
        Func<string, string> getSingleItemDescription,
        Func<string, string> getIntervalDescriptionFormat,
        Func<string, string> getBetweenDescriptionFormat,
        Func<string, string> getDescriptionFormat,
        Func<string, string> getRangeFormat
        )
    {
      string description = null;

      if (string.IsNullOrEmpty(expression))
      {
        description = string.Empty;
      }
      else if (expression == "*")
      {
        description = allDescription;
      }
      else if (expression.IndexOfAny(new char[] { '/', '-', ',' }) == -1)
      {
        description = string.Format(getDescriptionFormat(expression), getSingleItemDescription(expression));
      }
      else if (expression.Contains("/"))
      {
        string[] segments = expression.Split('/');
        description = string.Format(getIntervalDescriptionFormat(segments[1]), getSingleItemDescription(segments[1]));

        //interval contains 'between' piece (i.e. 2-59/3 )
        if (segments[0].Contains("-"))
        {
          string betweenSegmentDescription = GenerateBetweenSegmentDescription(segments[0], getBetweenDescriptionFormat, getSingleItemDescription);

          if (!betweenSegmentDescription.StartsWith(", "))
          {
            description += ", ";
          }

          description += betweenSegmentDescription;
        }
        else if (segments[0].IndexOfAny(new char[] { '*', ',' }) == -1)
        {
          string rangeItemDescription = string.Format(getDescriptionFormat(segments[0]), getSingleItemDescription(segments[0]));
          //remove any leading comma
          rangeItemDescription = rangeItemDescription.Replace(", ", "");

          description += string.Format(GetString("CommaStartingX0"), rangeItemDescription);
        }
      }
      else if (expression.Contains(","))
      {
        string[] segments = expression.Split(',');

        string descriptionContent = string.Empty;
        for (int i = 0; i < segments.Length; i++)
        {
          if (i > 0 && segments.Length > 2)
          {
            descriptionContent += ",";

            if (i < segments.Length - 1)
            {
              descriptionContent += " ";
            }
          }

          if (i > 0 && segments.Length > 1 && (i == segments.Length - 1 || segments.Length == 2))
          {
            descriptionContent += GetString("SpaceAndSpace");
          }

          if (segments[i].Contains("-"))
          {
            string betweenSegmentDescription = GenerateBetweenSegmentDescription(segments[i], getRangeFormat, getSingleItemDescription);

            //remove any leading comma
            betweenSegmentDescription = betweenSegmentDescription.Replace(", ", "");

            descriptionContent += betweenSegmentDescription;
          }
          else
          {
            descriptionContent += getSingleItemDescription(segments[i]);
          }
        }

        description = string.Format(getDescriptionFormat(expression), descriptionContent);
      }
      else if (expression.Contains("-"))
      {
        description = GenerateBetweenSegmentDescription(expression, getBetweenDescriptionFormat, getSingleItemDescription);
      }

      return description;
    }

    /// <summary>
    /// Generates the between segment description
    /// </summary>
    /// <param name="betweenExpression"></param>
    /// <param name="getBetweenDescriptionFormat"></param>
    /// <param name="getSingleItemDescription"></param>
    /// <returns>The between segment description</returns>
    protected string GenerateBetweenSegmentDescription(string betweenExpression, Func<string, string> getBetweenDescriptionFormat, Func<string, string> getSingleItemDescription)
    {
      string description = string.Empty;
      string[] betweenSegments = betweenExpression.Split('-');
      string betweenSegment1Description = getSingleItemDescription(betweenSegments[0]);
      string betweenSegment2Description = getSingleItemDescription(betweenSegments[1]);
      betweenSegment2Description = betweenSegment2Description.Replace(":00", ":59");
      var betweenDescriptionFormat = getBetweenDescriptionFormat(betweenExpression);
      description += string.Format(betweenDescriptionFormat, betweenSegment1Description, betweenSegment2Description);

      return description;
    }

    /// <summary>
    /// Given time parts, will construct a formatted time description
    /// </summary>
    /// <param name="hourExpression">Hours part</param>
    /// <param name="minuteExpression">Minutes part</param>
    /// <returns>Formatted time description</returns>
    protected string FormatTime(string hourExpression, string minuteExpression)
    {
      return FormatTime(hourExpression, minuteExpression, string.Empty);
    }

    /// <summary>
    /// Given time parts, will construct a formatted time description
    /// </summary>
    /// <param name="hourExpression">Hours part</param>
    /// <param name="minuteExpression">Minutes part</param>
    /// <param name="secondExpression">Seconds part</param>
    /// <returns>Formatted time description</returns>
    protected string FormatTime(string hourExpression, string minuteExpression, string secondExpression)
    {
      int hour = Convert.ToInt32(hourExpression);

      string period = string.Empty;
      if (!m_use24HourTimeFormat)
      {
        period = GetString((hour >= 12) ? "PMPeriod" : "AMPeriod");
        if (period.Length > 0)
        {
          // add preceding space
          period = string.Concat(" ", period);
        }

        if (hour > 12)
        {
          hour -= 12;
        }
        if (hour == 0)
        {
          hour = 12;
        }
      }

      string minute = Convert.ToInt32(minuteExpression).ToString();
      string second = string.Empty;
      if (!string.IsNullOrEmpty(secondExpression))
      {
        second = string.Concat(":", Convert.ToInt32(secondExpression).ToString().PadLeft(2, '0'));
      }

      return string.Format("{0}:{1}{2}{3}",
          hour.ToString().PadLeft(2, '0'), minute.PadLeft(2, '0'), second, period);
    }

    /// <summary>
    /// Transforms the verbosity of the expression description by stripping verbosity from original description
    /// </summary>
    /// <param name="description">The description to transform</param>
    /// <param name="isVerbose">If true, will leave description as it, if false, will strip verbose parts</param>
    /// <returns>The transformed description with proper verbosity</returns>
    protected string TransformVerbosity(string description, bool useVerboseFormat)
    {
      if (!useVerboseFormat)
      {
        description = description.Replace(GetString("ComaEveryMinute"), string.Empty);
        description = description.Replace(GetString("ComaEveryHour"), string.Empty);
        description = description.Replace(GetString("ComaEveryDay"), string.Empty);
        description = Regex.Replace(description, @"\, ?$", "");
      }

      return description;
    }

    /// <summary>
    /// Gets a localized string resource
    /// refactored because Resources.ResourceManager.GetString was way too long
    /// </summary>
    /// <param name="resourceName">name of the resource</param>
    /// <returns>translated resource</returns>
    protected string GetString(string resourceName)
    {
      return Resources.ResourceManager.GetString(resourceName, m_culture);
    }

    #region Static
    /// <summary>
    /// Generates a human readable string for the Cron Expression
    /// </summary>
    /// <param name="expression">The cron expression string</param>
    /// <returns>The cron expression description</returns>
    public static string GetDescription(string expression)
    {
      return GetDescription(expression, new Options());
    }

    /// <summary>
    /// Generates a human readable string for the Cron Expression
    /// </summary>
    /// <param name="expression">The cron expression string</param>
    /// <param name="options">Options to control the output description</param>
    /// <returns>The cron expression description</returns>
    public static string GetDescription(string expression, Options options)
    {
      ExpressionDescriptor descriptor = new ExpressionDescriptor(expression, options);
      return descriptor.GetDescription(DescriptionTypeEnum.FULL);
    }
    #endregion
  }




}
