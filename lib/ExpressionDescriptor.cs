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
    private static readonly Regex WeekdayNumberRegex = new Regex(@"(\d{1,2}W)|(W\d{1,2})");
    private static readonly Regex LastDayOffsetRegex = new Regex(@"L-(\d{1,2})");

    private readonly string[] m_24hourTimeFormatTwoLetterISOLanguageName = new string[] { "ru", "uk", "de", "it", "tr", "pl", "ro", "da", "sl", "fi", "sv", "nb", "hu", "cs", "ky", "fr", "nl", "pt" };

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
        m_culture = System.Threading.Thread.CurrentThread.CurrentUICulture;
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
            throw new ArgumentOutOfRangeException(nameof(type));
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

      // the seconds when 0 are replaced during parsing with ""
      // same value returns in turn then GetSecondsDescription
      if (description.Length > 0)
      {
        // Uppercase the first letter
        description = string.Concat(m_culture.TextInfo.ToUpper(description[0]), description.Substring(1));
      }

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
         (s => GetString("CommaMinX0ThroughMinX1") ?? GetString("CommaX0ThroughX1"))
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
                      : (i < 20)
                          ? GetString("AtX0MinutesPastTheHour")
                          : GetString("AtX0MinutesPastTheHourGt20") ?? GetString("AtX0MinutesPastTheHour");
            }
            else
            {
              return GetString("AtX0MinutesPastTheHour");
            }
          }),
          getRangeFormat: (s => GetString("CommaMinX0ThroughMinX1") ?? GetString("CommaX0ThroughX1"))
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
             (s => GetString("CommaMinX0ThroughMinX1") ?? GetString("CommaX0ThroughX1"))
         );

      return description;
    }

    /// <summary>
    /// Generates a description for only the DAYOFWEEK portion of the expression
    /// </summary>
    /// <returns>The DAYOFWEEK description</returns>
    protected string GetDayOfWeekDescription()
    {
      return GetDayOfWeekDescription(m_expressionParts[5]);
    }

    private string GetDayOfWeekDescription(string dowExpression)
    {
      if (dowExpression == "*")
      {
        // DOW is specified as * so we will not generate a description and defer to DOM part.
        // Otherwise, we could get a contradiction like "on day 1 of the month, every day"
        // or a dupe description like "every day, every day".
        return string.Empty;
      }

      return GetWeeklyIntervalDescription(dowExpression)
          ?? GetMixedDayGroupsDescription(dowExpression)
          ?? GetNthDayListDescription(dowExpression)
          ?? GetSegmentDescription(
              dowExpression,
              GetString("CommaEveryDay"),
              GetSingleDayName,
              (s => string.Format(GetString("CommaEveryX0DaysOfTheWeek"), s)),
              (s => GetString("CommaX0ThroughX1")),
              GetDayOfWeekFormat,
              (s => GetString("CommaX0ThroughX1")));
    }

    private string GetSingleDayName(string dayExpression)
    {
      string exp = dayExpression.Contains("#")
                  ? dayExpression.Remove(dayExpression.IndexOf("#"))
                  : dayExpression.Replace("L", string.Empty);

      return m_culture.DateTimeFormat.GetDayName((DayOfWeek)Convert.ToInt32(exp));
    }

    private string GetOrdinalDescription(string ordinal)
    {
      switch (ordinal)
      {
        case "1": return GetString("First");
        case "2": return GetString("Second");
        case "3": return GetString("Third");
        case "4": return GetString("Fourth");
        case "5": return GetString("Fifth");
        default: return null;
      }
    }

    private string GetDayOfWeekFormat(string dowExpression)
    {
      if (dowExpression.Contains("#"))
      {
        Match hashMatch = Regex.Match(dowExpression, @"#(\d+)");
        string ordinal = hashMatch.Success ? hashMatch.Groups[1].Value : string.Empty;
        return string.Concat(GetString("CommaOnThe"), GetOrdinalDescription(ordinal), GetString("SpaceX0OfTheMonth"));
      }

      if (dowExpression.Contains("L"))
      {
        return GetString("CommaOnTheLastX0OfTheMonth");
      }

      // Standard cron fires when either DOM or DOW condition is met (OR logic).
      // If DOM is also specified (non-wildcard, non-?), use "or on" to reflect
      // the OR logic. Otherwise use "only on" when only DOW is constraining the schedule.
      bool isDomSpecified = m_expressionParts[3] != "*" && m_expressionParts[3] != "?";
      return isDomSpecified ? GetString("CommaOrOnX0") : GetString("CommaOnlyOnX0");
    }

    // A DOW step with a specific (non-wildcard) base describes a weekly recurrence (e.g. "every 2 weeks,
    // only on Friday") rather than a within-week one (e.g. "every 2 days of the week, Monday through
    // Friday") when the base is a list, or a range no larger than the step.
    private string GetWeeklyIntervalDescription(string dowExpression)
    {
      if (!dowExpression.Contains("/"))
      {
        return null;
      }

      string[] slashParts = dowExpression.Split('/');
      string basePart = slashParts[0];
      string stepPart = slashParts[1];

      if (basePart == "*")
      {
        return null;
      }

      string intervalDesc = string.Format(GetString("CommaEveryX0Weeks"), stepPart);

      if (basePart.Contains(","))
      {
        string daysContent = GetListDescription(basePart.Split(',')
            .Select(item => item.Contains("-")
                ? GenerateBetweenSegmentDescription(item, s => GetString("CommaX0ThroughX1"), GetSingleDayName).TrimStart(',').TrimStart()
                : GetSingleDayName(item))
            .ToArray());

        return intervalDesc + string.Format(GetString("CommaOnlyOnX0"), daysContent);
      }

      if (!basePart.Contains("-"))
      {
        return null;
      }

      string[] rangeParts = basePart.Split('-');
      int rangeStart = int.Parse(rangeParts[0]);
      int rangeEnd = int.Parse(rangeParts[1]);
      if (int.Parse(stepPart) < rangeEnd - rangeStart + 1)
      {
        return null;
      }

      // A range ending on Saturday was produced by normalizing a single DOW value (e.g. FRI/2 -> 5-6/2),
      // so it reads "only on <startDay>" rather than "<startDay> through Saturday".
      string dayDesc = rangeEnd == 6
          ? string.Format(GetString("CommaOnlyOnX0"), GetSingleDayName(rangeParts[0]))
          : GenerateBetweenSegmentDescription(basePart, s => GetString("CommaX0ThroughX1"), GetSingleDayName);

      return intervalDesc + dayDesc;
    }

    // A list that mixes plain days with # or L days (e.g. 1,3#2 or 5L,1) is described one group at a
    // time: plain days first, then # days, then L days. Otherwise the # or L wording ends up applied
    // to every day in the list (e.g. "on the second Monday and Wednesday of the month" for 1,3#2).
    private string GetMixedDayGroupsDescription(string dowExpression)
    {
      if (!dowExpression.Contains(",") || dowExpression.Contains("/"))
      {
        return null;
      }

      string[] dowSegments = dowExpression.Split(',');
      var groups = new[]
      {
        dowSegments.Where(s => !s.Contains("#") && !s.Contains("L")).ToArray(),
        dowSegments.Where(s => s.Contains("#")).ToArray(),
        dowSegments.Where(s => !s.Contains("#") && s.Contains("L")).ToArray()
      }
      .Where(g => g.Length > 0)
      .ToArray();

      if (groups.Length < 2)
      {
        return null;
      }

      string[] groupDescriptions = groups
          .Select((g, i) =>
          {
            string groupDescription = GetDayOfWeekDescription(string.Join(",", g));
            return i == 0 ? groupDescription : groupDescription.TrimStart(',').TrimStart();
          })
          .ToArray();

      // Three or more groups read as a comma list ("A, B, and C"). Two groups get the comma too when
      // either group already has its own "and" (e.g. "only on Monday and Tuesday, and on the second
      // Wednesday of the month"), so the "and"s don't stack up.
      if (groups.Length == 2 && groups.Any(g => g.Length > 1))
      {
        return string.Concat(groupDescriptions[0], ",", GetString("SpaceAndSpace"), groupDescriptions[1]);
      }

      return GetListDescription(groupDescriptions);
    }

    private string GetNthDayListDescription(string dowExpression)
    {
      if (!dowExpression.Contains(",") || !dowExpression.Contains("#"))
      {
        return null;
      }

      string[] dowSegments = dowExpression.Split(',');
      var hashParts = dowSegments
          .Select(s => Regex.Match(s, @"^([^,]+)#(\d+)$"))
          .ToArray();

      if (!hashParts.All(m => m.Success))
      {
        return null;
      }

      var parsedParts = hashParts
          .Select(m => new
          {
            Day = m.Groups[1].Value,
            Ordinal = GetOrdinalDescription(m.Groups[2].Value)
          })
          .Where(p => !string.IsNullOrEmpty(p.Ordinal))
          .ToArray();

      if (parsedParts.Length != dowSegments.Length)
      {
        return null;
      }

      string dayOfWeekDescription;
      if (parsedParts.Select(p => p.Day).Distinct().Count() == 1)
      {
        string ordinalList = GetListDescription(parsedParts.Select(p => p.Ordinal).ToArray());
        dayOfWeekDescription = string.Format("{0} {1}", ordinalList, GetSingleDayName(parsedParts[0].Day));
      }
      else
      {
        dayOfWeekDescription = GetListDescription(parsedParts
            .Select(p => string.Format("{0} {1}", p.Ordinal, GetSingleDayName(p.Day)))
            .ToArray());
      }

      string monthSuffix = GetString("SpaceX0OfTheMonth").Replace(" {0}", string.Empty).Replace("{0}", string.Empty);
      return string.Concat(GetString("CommaOnThe"), dayOfWeekDescription, monthSuffix);
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
         (s => string.Format(GetString("CommaEveryX0Months"), s)),
         (s => GetString("CommaMonthX0ThroughMonthX1") ?? GetString("CommaX0ThroughX1")),
         (s => GetString("CommaOnlyInX0")),
         (s => GetString("CommaMonthX0ThroughMonthX1") ?? GetString("CommaX0ThroughX1"))
      );

      return description;
    }

    /// <summary>
    /// Generates a description for only the DAYOFMONTH portion of the expression
    /// </summary>
    /// <returns>The DAYOFMONTH description</returns>
    protected string GetDayOfMonthDescription()
    {
      return GetDayOfMonthDescription(m_expressionParts[3]);
    }

    private static bool IsLastDayOffset(string dayOfMonthItem)
    {
      return Regex.IsMatch(dayOfMonthItem, @"^L-\d{1,2}$");
    }

    private string GetDayOfMonthDescription(string expression)
    {
      string description = null;

      // A list with L-n items (e.g. 1,L-3) runs on each of them, so describe the L-n items on their own.
      // Otherwise the L-n match below takes the whole list and the other items are lost.
      string[] dayOfMonthItems = expression.Split(',');
      string[] lastDayOffsetItems = dayOfMonthItems.Where(IsLastDayOffset).ToArray();
      if (dayOfMonthItems.Length > 1 && lastDayOffsetItems.Length > 0)
      {
        string[] otherItems = dayOfMonthItems.Where(s => !IsLastDayOffset(s)).ToArray();
        string[] parts = (otherItems.Length > 0 ? new[] { string.Join(",", otherItems) } : new string[0])
            .Concat(lastDayOffsetItems)
            .Select(GetDayOfMonthDescription)
            .Where(s => !string.IsNullOrEmpty(s))
            .Select((s, i) => i == 0 ? s : GetString("SpaceAndSpace") + s.TrimStart(',').TrimStart())
            .ToArray();

        return string.Concat(parts);
      }

      switch (expression)
      {
        case "L":
          description = GetString("CommaOnTheLastDayOfTheMonth");
          break;
        case "WL":
        case "LW":
          description = GetString("CommaOnTheLastWeekdayOfTheMonth");
          break;
        default:
          Match m = WeekdayNumberRegex.Match(expression);
          if (m.Success)
          {
            int dayNumber = Int32.Parse(m.Value.Replace("W", ""));

            string dayString = dayNumber == 1 ? GetString("FirstWeekday") :
                String.Format(GetString("WeekdayNearestDayX0"), dayNumber);
            description = String.Format(GetString("CommaOnTheX0OfTheMonth"), dayString);

            break;
          }
          else
          {
            // Handle "last day offset" (i.e. L-5:  "5 days before the last day of the month")
            Match lastDayOffsetMatch = LastDayOffsetRegex.Match(expression);
            if (lastDayOffsetMatch.Success)
            {
              string offSetDays = lastDayOffsetMatch.Groups[1].Value;
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
                  GetString("CommaEveryDay"),
                  (s => s),
                  (s => s == "1" ? GetString("CommaEveryDay") : GetString("CommaEveryX0Days")),
                  (s => GetString("CommaBetweenDayX0AndX1OfTheMonth")),
                  (s => GetString("CommaOnDayX0OfTheMonth")),
                  (s => GetString("CommaX0ThroughX1"))
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
         (s => string.Format(GetString("CommaEveryX0Years"), s)),
         (s => GetString("CommaYearX0ThroughYearX1") ?? GetString("CommaX0ThroughX1")),
         (s => GetString("CommaOnlyInYearX0")),
         (s => GetString("CommaYearX0ThroughYearX1") ?? GetString("CommaX0ThroughX1"))
      );

      return description;
    }

    /// <summary>
    /// Generates the segment description
    /// <remarks>
    /// Range expressions used the 'CommaX0ThroughX1' resource
    /// However Romanian language has different idioms for
    /// 1. 'from number to number' (minutes, seconds, hours, days) => CommaMinX0ThroughMinX1 optional resource
    /// 2. 'from month to month' CommaMonthX0ThroughMonthX1 optional resource
    /// 3. 'from year to year' => CommaYearX0ThroughYearX1 optional resource
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
        description = string.Format(getIntervalDescriptionFormat(segments[1]), segments[1]);

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
        string descriptionContent = GetListDescription(expression.Split(',')
            .Select(segment => segment.Contains("-")
                ? GenerateBetweenSegmentDescription(segment, getRangeFormat, getSingleItemDescription).Replace(", ", "")
                : getSingleItemDescription(segment))
            .ToArray());

        description = string.Format(getDescriptionFormat(expression), descriptionContent);
      }
      else if (expression.Contains("-"))
      {
        description = GenerateBetweenSegmentDescription(expression, getBetweenDescriptionFormat, getSingleItemDescription);
      }

      return description;
    }

    private string GetListDescription(string[] items)
    {
      var description = new StringBuilder();

      for (int i = 0; i < items.Length; i++)
      {
        if (i > 0 && items.Length > 2)
        {
          description.Append(",");
          if (i < items.Length - 1)
          {
            description.Append(" ");
          }
        }

        if (i > 0 && (i == items.Length - 1 || items.Length == 2))
        {
          description.Append(GetString("SpaceAndSpace"));
        }

        description.Append(items[i]);
      }

      return description.ToString();
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
        description = description.Replace(GetString("CommaEveryMinute"), string.Empty);
        description = description.Replace(GetString("CommaEveryHour"), string.Empty);
        description = description.Replace(GetString("CommaEveryDay"), string.Empty);
        description = Regex.Replace(description, @"\, ?$", "");
      }

      return description;
    }

    /// <summary>
    /// Gets a localized string resource
    /// </summary>
    /// <param name="resourceName">name of the resource</param>
    /// <returns>translated resource</returns>
    protected string GetString(string resourceName)
    {
      return Resources.ResourceManager.GetString(resourceName, m_culture);
    }

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
  }
}
