using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Text.RegularExpressions;
using System.Resources;
using System.Globalization;

namespace CronExpressionDescriptor
{
    /// <summary>
    /// Converts a Cron Expression into a human readable string
    /// </summary>
    public class ExpressionDescriptor
    {
        private static string s_defaultLocale;
        public static void SetDefaultLocale(string locale)
        {
            s_defaultLocale = locale;
        }

        private readonly char[] m_specialCharacters = new char[] { '/', '-', ',', '*' };
        private readonly string[] m_24hourTimeFormatLocales = new string[] { "ru-RU", "uk-UA", "de-DE", "it-IT", "tr-TR", "pl-PL" };

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

            var locale = options.Locale ?? s_defaultLocale ?? "en";
            m_culture = new CultureInfo(locale);

            if (m_options.Use24HourTimeFormat != null)
            {
                // 24HourTimeFormat specified in options so use it
                m_use24HourTimeFormat = m_options.Use24HourTimeFormat.Value;
            }
            else
            {
                // 24HourTimeFormat not specified, default based on m_24hourTimeFormatLocales
                m_use24HourTimeFormat = m_24hourTimeFormatLocales.Contains(locale);
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
                description = Resources.ResourceManager.GetString("AnErrorOccuredWhenGeneratingTheExpressionD", m_culture);
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
                description.Append(Resources.ResourceManager.GetString("AtSpace", m_culture)).Append(FormatTime(hourExpression, minuteExpression, secondsExpression));
            }
            else if (minuteExpression.Contains("-")
                && !minuteExpression.Contains(",")
                && hourExpression.IndexOfAny(m_specialCharacters) == -1)
            {
                //minute range in single hour (i.e. 0-10 11)
                string[] minuteParts = minuteExpression.Split('-');
                description.Append(string.Format(Resources.ResourceManager.GetString("EveryMinuteBetweenX0AndX1", m_culture),
                    FormatTime(hourExpression, minuteParts[0]),
                    FormatTime(hourExpression, minuteParts[1])));
            }
            else if (hourExpression.Contains(",")
                && hourExpression.IndexOf('-') == -1
                && minuteExpression.IndexOfAny(m_specialCharacters) == -1)
            {
                //hours list with single minute (o.e. 30 6,14,16)
                string[] hourParts = hourExpression.Split(',');
                description.Append(Resources.ResourceManager.GetString("At", m_culture));
                for (int i = 0; i < hourParts.Length; i++)
                {
                    description.Append(" ").Append(FormatTime(hourParts[i], minuteExpression));

                    if (i < (hourParts.Length - 2))
                    {
                        description.Append(",");
                    }

                    if (i == hourParts.Length - 2)
                    {
                        description.Append(Resources.ResourceManager.GetString("SpaceAnd", m_culture));
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

                if (description.Length > 0)
                {
                    description.Append(", ");
                }

                description.Append(minutesDescription);

                if (description.Length > 0)
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
            string description = GetSegmentDescription(m_expressionParts[0],
                 Resources.ResourceManager.GetString("EverySecond", m_culture),
               (s => s),
               (s => string.Format(Resources.ResourceManager.GetString("EveryX0Seconds", m_culture), s)),
               (s => Resources.ResourceManager.GetString("SecondsX0ThroughX1PastTheMinute", m_culture)),
               (s => { try {
                        return s == "0"
                    ? string.Empty
                            : (int.Parse(s) < 20)
                        ? Resources.ResourceManager.GetString("AtX0SecondsPastTheMinute", m_culture)
                        : Resources.ResourceManager.GetString("AtX0SecondsPastTheMinuteGt20", m_culture) ?? Resources.ResourceManager.GetString("AtX0SecondsPastTheMinute", m_culture)

                   }
                   catch { return CronExpressionDescriptor.Resources.AtX0SecondsPastTheMinute; }} ));

            return description;
        }

        /// <summary>
        /// Generates a description for only the MINUTE portion of the expression
        /// </summary>
        /// <returns>The MINUTE description</returns>
        protected string GetMinutesDescription()
        {
            string description = GetSegmentDescription(m_expressionParts[1],
                Resources.ResourceManager.GetString("EveryMinute", m_culture),
                (s => s),
                (s => string.Format(Resources.ResourceManager.GetString("EveryX0Minutes", m_culture), s)),
                (s => Resources.ResourceManager.GetString("MinutesX0ThroughX1PastTheHour", m_culture)),
                (s =>
                {
                    try
                    {
                        return s == "0"
                          ? string.Empty
                          : (int.Parse(s) < 20)
                              ? Resources.ResourceManager.GetString("AtX0MinutesPastTheHour", m_culture)
                              : Resources.ResourceManager.GetString("AtX0MinutesPastTheHourGt20", m_culture) ?? Resources.ResourceManager.GetString("AtX0MinutesPastTheHour", m_culture);
                    }
                    catch { return Resources.ResourceManager.GetString("AtX0MinutesPastTheHour", m_culture); }
                }));

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
                 Resources.ResourceManager.GetString("EveryHour", m_culture),
               (s => FormatTime(s, "0")),
               (s => string.Format(Resources.ResourceManager.GetString("EveryX0Hours", m_culture), s)),
               (s => Resources.ResourceManager.GetString("BetweenX0AndX1", m_culture)),
               (s => Resources.ResourceManager.GetString("AtX0", m_culture)));

            return description;
        }

        /// <summary>
        /// Generates a description for only the DAYOFWEEK portion of the expression
        /// </summary>
        /// <returns>The DAYOFWEEK description</returns>
        protected string GetDayOfWeekDescription()
        {
            string description = null;

            if (m_expressionParts[5] == "*" && m_expressionParts[3] != "*")
            {
                // DOM is specified and DOW is * so to prevent contradiction like "on day 1 of the month, every day"
                // we will not specified a DOW description.
                description = string.Empty;

            } else {
                description = GetSegmentDescription(m_expressionParts[5],
                Resources.ResourceManager.GetString("ComaEveryDay", m_culture),
              (s =>
              {
                  string exp = s;
                  if (s.Contains("#"))
                  {
                      exp = s.Remove(s.IndexOf("#"));
                  }
                  else if (s.Contains("L"))
                  {
                      exp = exp.Replace("L", string.Empty);
                  }

                  return m_culture.DateTimeFormat.GetDayName(((DayOfWeek)Convert.ToInt32(exp)));
              }),
              (s => string.Format(Resources.ResourceManager.GetString("ComaEveryX0DaysOfTheWeek", m_culture), s)),
              (s => Resources.ResourceManager.GetString("ComaX0ThroughX1", m_culture)),
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
                              dayOfWeekOfMonthDescription = Resources.ResourceManager.GetString("First", m_culture);
                              break;
                          case "2":
                              dayOfWeekOfMonthDescription = Resources.ResourceManager.GetString("Second", m_culture);
                              break;
                          case "3":
                              dayOfWeekOfMonthDescription = Resources.ResourceManager.GetString("Third", m_culture);
                              break;
                          case "4":
                              dayOfWeekOfMonthDescription = Resources.ResourceManager.GetString("Forth", m_culture);
                              break;
                          case "5":
                              dayOfWeekOfMonthDescription = Resources.ResourceManager.GetString("Fifth", m_culture);
                              break;
                      }


                      format = string.Concat(Resources.ResourceManager.GetString("ComaOnThe", m_culture),
                          dayOfWeekOfMonthDescription, Resources.ResourceManager.GetString("SpaceX0OfTheMonth", m_culture));
                  }
                  else if (s.Contains("L"))
                  {
                      format = Resources.ResourceManager.GetString("ComaOnTheLastX0OfTheMonth", m_culture);
                  }
                  else
                  {
                      format = Resources.ResourceManager.GetString("ComaOnlyOnX0", m_culture);
                  }

                  return format;
              }));
            }

            return description;
        }

        /// <summary>
        /// Generates a description for only the MONTH portion of the expression
        /// </summary>
        /// <returns>The MONTH description</returns>
        protected string GetMonthDescription()
        {
            string description = GetSegmentDescription(m_expressionParts[4],
                string.Empty,
               (s => new DateTime(DateTime.Now.Year, Convert.ToInt32(s), 1).ToString("MMMM", m_culture)),
               (s => string.Format(Resources.ResourceManager.GetString("ComaEveryX0Months", m_culture), s)),
               (s => Resources.ResourceManager.GetString("ComaMonthX0ThroughMonthX1", m_culture) ?? Resources.ResourceManager.GetString("ComaX0ThroughX1", m_culture)),
               (s => Resources.ResourceManager.GetString("ComaOnlyInX0", m_culture)));

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
                    description = Resources.ResourceManager.GetString("ComaOnTheLastDayOfTheMonth", m_culture);
                    break;
                case "WL":
                case "LW":
                    description = Resources.ResourceManager.GetString("ComaOnTheLastWeekdayOfTheMonth", m_culture);
                    break;
                default:
                    Regex regex = new Regex("(\\d{1,2}W)|(W\\d{1,2})");
                    if (regex.IsMatch(expression))
                    {
                        Match m = regex.Match(expression);
                        int dayNumber = Int32.Parse(m.Value.Replace("W", ""));

                        string dayString = dayNumber == 1 ? Resources.ResourceManager.GetString("FirstWeekday", m_culture) :
                            String.Format(Resources.ResourceManager.GetString("WeekdayNearestDayX0", m_culture), dayNumber);
                        description = String.Format(Resources.ResourceManager.GetString("ComaOnTheX0OfTheMonth", m_culture), dayString);

                        break;
                    }
                    else
                    {
                        description = GetSegmentDescription(expression,
                            Resources.ResourceManager.GetString("ComaEveryDay", m_culture),
                            (s => s),
                            (s => s == "1" ? Resources.ResourceManager.GetString("ComaEveryDay", m_culture) :
                                Resources.ResourceManager.GetString("ComaEveryX0Days", m_culture)),
                            (s => Resources.ResourceManager.GetString("ComaBetweenDayX0AndX1OfTheMonth", m_culture)),
                            (s => Resources.ResourceManager.GetString("ComaOnDayX0OfTheMonth", m_culture)));
                        break;
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
               (s => string.Format(Resources.ResourceManager.GetString("ComaEveryX0Years", m_culture), s)),
               (s => Resources.ResourceManager.GetString("ComaYearX0ThroughYearX1", m_culture) ?? Resources.ResourceManager.GetString("ComaX0ThroughX1", m_culture)),
               (s => Resources.ResourceManager.GetString("ComaOnlyInX0", m_culture)));

            return description;
        }

        /// <summary>
        /// Generates the segment description
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="allDescription"></param>
        /// <param name="getSingleItemDescription"></param>
        /// <param name="getIntervalDescriptionFormat"></param>
        /// <param name="getBetweenDescriptionFormat"></param>
        /// <param name="getDescriptionFormat"></param>
        /// <returns></returns>
        protected string GetSegmentDescription(string expression,
            string allDescription,
            Func<string, string> getSingleItemDescription,
            Func<string, string> getIntervalDescriptionFormat,
            Func<string, string> getBetweenDescriptionFormat,
            Func<string, string> getDescriptionFormat
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

                    description += string.Format(Resources.ResourceManager.GetString("CommaStartingX0", m_culture), rangeItemDescription);
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
                        descriptionContent += Resources.ResourceManager.GetString("SpaceAndSpace", m_culture);
                    }

                    if (segments[i].Contains("-"))
                    {
                        string betweenSegmentDescription = GenerateBetweenSegmentDescription(segments[i],
                        (s => Resources.ResourceManager.GetString("ComaX0ThroughX1", m_culture)), getSingleItemDescription);

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
        /// Given time parts, will contruct a formatted time description
        /// </summary>
        /// <param name="hourExpression">Hours part</param>
        /// <param name="minuteExpression">Minutes part</param>
        /// <returns>Formatted time description</returns>
        protected string FormatTime(string hourExpression, string minuteExpression)
        {
            return FormatTime(hourExpression, minuteExpression, string.Empty);
        }

        /// <summary>
        /// Given time parts, will contruct a formatted time description
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
                period = Resources.ResourceManager.GetString((hour >= 12) ? "PMPeriod" : "AMPeriod", m_culture);
                if (period.Length > 0)
                {
                    // add preceeding space
                    period = string.Concat(" ", period);
                }

                if (hour > 12)
                {
                    hour -= 12;
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
                description = description.Replace(Resources.ResourceManager.GetString("ComaEveryMinute", m_culture), string.Empty);
                description = description.Replace(Resources.ResourceManager.GetString("ComaEveryHour", m_culture), string.Empty);
                description = description.Replace(Resources.ResourceManager.GetString("ComaEveryDay", m_culture), string.Empty);
            }

            return description;
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
            ExpressionDescriptor descripter = new ExpressionDescriptor(expression, options);
            return descripter.GetDescription(DescriptionTypeEnum.FULL);
        }
        #endregion
    }




}