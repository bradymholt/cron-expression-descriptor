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
    /// Converts cron expressions into human readable strings.
    /// </summary>
    public class ExpressionDescriptor
    {
        private readonly char[] m_specialCharacters = new char[] { '/', '-', ',', '*' };
        private string m_expression;
        private Options m_options;
        private string[] m_expressionParts;
        private bool m_parsed;
        private CultureInfo m_culture;

        public ExpressionDescriptor(string expression) : this(expression, new Options()) { }
        public ExpressionDescriptor(string expression, Options options)
        {
            m_expression = expression;
            m_options = options;
            m_expressionParts = new string[7];
            m_parsed = false;
            m_culture = Thread.CurrentThread.CurrentUICulture;
        }

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

            return description;
        }


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

                description = string.Format("{0}{1}{2}{3}",
                    timeSegment,
                    (m_expressionParts[3] == "*" ? dayOfWeekDesc : dayOfMonthDesc),
                    monthDesc,
                    yearDesc);

                description = TransformVerbosity(description);
                description = TransformCase(description);
            }
            catch (Exception ex)
            {
                description = CronExpressionDescriptor.Resources.AnErrorOccuredWhenGeneratingTheExpressionD;
                if (m_options.ThrowExceptionOnParseError)
                {
                    throw new FormatException(description, ex);
                }
            }


            return description;
        }

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
                description.Append(CronExpressionDescriptor.Resources.AtSpace).Append(FormatTime(hourExpression, minuteExpression, secondsExpression));
            }
            else if (minuteExpression.Contains("-") && hourExpression.IndexOfAny(m_specialCharacters) == -1)
            {
                //minute range in single hour (i.e. 0-10 11)
                string[] minuteParts = minuteExpression.Split('-');
                description.Append(string.Format(CronExpressionDescriptor.Resources.EveryMinuteBetweenX0AndX1,
                    FormatTime(hourExpression, minuteParts[0]),
                    FormatTime(hourExpression, minuteParts[1])));
            }
            else if (hourExpression.Contains(",") && minuteExpression.IndexOfAny(m_specialCharacters) == -1)
            {
                //hours list with single minute (o.e. 30 6,14,16)
                string[] hourParts = hourExpression.Split(',');
                description.Append(CronExpressionDescriptor.Resources.At);
                for (int i = 0; i < hourParts.Length; i++)
                {
                    description.Append(" ").Append(FormatTime(hourParts[i], minuteExpression));

                    if (i < (hourParts.Length - 2))
                    {
                        description.Append(",");
                    }

                    if (i == hourParts.Length - 2)
                    {
                        description.Append(CronExpressionDescriptor.Resources.SpaceAnd);
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

        protected string GetSecondsDescription()
        {
            string description = GetSegmentDescription(m_expressionParts[0],
                 CronExpressionDescriptor.Resources.EverySecond,
               (s => s.PadLeft(2, '0')),
               (s => string.Format(CronExpressionDescriptor.Resources.EveryX0Seconds, s)),
               (s => CronExpressionDescriptor.Resources.SecondsX0ThroughX1PastTheMinute),
               (s => CronExpressionDescriptor.Resources.AtX0SecondsPastTheMinute));

            return description;
        }

        protected string GetMinutesDescription()
        {
            string description = GetSegmentDescription(m_expressionParts[1],
                  CronExpressionDescriptor.Resources.EveryMinute,
                (s => s.PadLeft(2, '0')),
                (s => string.Format(CronExpressionDescriptor.Resources.EveryX0Minutes, s.PadLeft(2, '0'))),
                (s => CronExpressionDescriptor.Resources.MinutesX0ThroughX1PastTheHour),
                (s => s == "0" ? string.Empty : CronExpressionDescriptor.Resources.AtX0MinutesPastTheHour));

            return description;
        }

        protected string GetHoursDescription()
        {
            string expression = m_expressionParts[2];

            //For between (-) hour expressions, add one hour to the ending portion to 
            //more accurately describe the ending hour.  for example: 8-9 should read
            //"between 8:00 AM and 10:00 AM".

            int nextBetweenIndex = expression.IndexOf("-");
            while(nextBetweenIndex > -1)
            {
                int nextBetweenStartIndex = nextBetweenIndex + 1;
                int nextBetweenEndIndex = expression.IndexOf(",", nextBetweenIndex);
                if (nextBetweenEndIndex == -1)
                {
                   nextBetweenEndIndex = expression.Length;
                }

                int betweenToNumeric;
                if (int.TryParse(expression.Substring(nextBetweenStartIndex, nextBetweenEndIndex - nextBetweenStartIndex), out betweenToNumeric))
                {
                    expression = expression.Remove(nextBetweenStartIndex, nextBetweenEndIndex - nextBetweenStartIndex);
                    expression = expression.Insert(nextBetweenStartIndex, (betweenToNumeric + 1).ToString());
                }

                nextBetweenIndex = expression.IndexOf("-", nextBetweenIndex + 1);
            }

            string description = GetSegmentDescription(expression,
                 CronExpressionDescriptor.Resources.EveryHour,
               (s => FormatTime(s, "0")),
               (s => string.Format(CronExpressionDescriptor.Resources.EveryX0Hours, s.PadLeft(2, '0'))),
               (s => CronExpressionDescriptor.Resources.BetweenX0AndX1),
               (s => CronExpressionDescriptor.Resources.AtX0));

            return description;
        }

        protected string GetDayOfWeekDescription()
        {
            string description = GetSegmentDescription(m_expressionParts[5],
                CronExpressionDescriptor.Resources.ComaEveryDay,
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
              (s => string.Format(CronExpressionDescriptor.Resources.ComaEveryX0DaysOfTheWeek, s)),
              (s => CronExpressionDescriptor.Resources.ComaX0ThroughX1),
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
                              dayOfWeekOfMonthDescription = CronExpressionDescriptor.Resources.First;
                              break;
                          case "2":
                              dayOfWeekOfMonthDescription = CronExpressionDescriptor.Resources.Second;
                              break;
                          case "3":
                              dayOfWeekOfMonthDescription = CronExpressionDescriptor.Resources.Third;
                              break;
                          case "4":
                              dayOfWeekOfMonthDescription = CronExpressionDescriptor.Resources.Forth;
                              break;
                          case "5":
                              dayOfWeekOfMonthDescription = CronExpressionDescriptor.Resources.Fifth;
                              break;
                      }


                      format = string.Concat(CronExpressionDescriptor.Resources.ComaOnThe, 
                          dayOfWeekOfMonthDescription, CronExpressionDescriptor.Resources.SpaceX0OfTheMonth);
                  }
                  else if (s.Contains("L"))
                  {
                      format = CronExpressionDescriptor.Resources.ComaOnTheLastX0OfTheMonth;
                  }
                  else
                  {
                      format = CronExpressionDescriptor.Resources.ComaOnlyOnX0;
                  }

                  return format;
              }));

            return description;
        }

        protected string GetMonthDescription()
        {
            string description = GetSegmentDescription(m_expressionParts[4],
                string.Empty,
               (s => new DateTime(DateTime.Now.Year, Convert.ToInt32(s), 1).ToString("MMMM")),
               (s => string.Format(CronExpressionDescriptor.Resources.ComaEveryX0Months, s)),
               (s => CronExpressionDescriptor.Resources.ComaX0ThroughX1),
               (s => CronExpressionDescriptor.Resources.ComaOnlyInX0));

            return description;
        }

        protected string GetDayOfMonthDescription()
        {
            string description = null;
            string expression = m_expressionParts[3];
            expression = expression.Replace("?", "*");

            switch (expression)
            {
                case "L":
                    description = CronExpressionDescriptor.Resources.ComaOnTheLastDayOfTheMonth;
                    break;
                case "WL":
                case "LW":
                    description = CronExpressionDescriptor.Resources.ComaOnTheLastWeekdayOfTheMonth;
                    break;
                default:
                    Regex regex = new Regex("(\\dW)|(W\\d)");
                    if (regex.IsMatch(expression))
                    {
                        Match m = regex.Match(expression);
                        int dayNumber = Int32.Parse(m.Value.Replace("W", ""));

                        string dayString = dayNumber == 1 ? CronExpressionDescriptor.Resources.FirstWeekday : 
                            String.Format(CronExpressionDescriptor.Resources.WeekdayNearestDayX0, dayNumber);
                        description = String.Format(CronExpressionDescriptor.Resources.ComaOnTheX0OfTheMonth, dayString);

                        break;
                    }
                    else
                    {
                        description = GetSegmentDescription(expression,
                            CronExpressionDescriptor.Resources.ComaEveryDay,
                            (s => s),
                            (s => s == "1" ? CronExpressionDescriptor.Resources.ComaEveryDay :
                                CronExpressionDescriptor.Resources.ComaEveryX0Days),
                            (s => CronExpressionDescriptor.Resources.ComaBetweenDayX0AndX1OfTheMonth),
                            (s => CronExpressionDescriptor.Resources.ComaOnDayX0OfTheMonth));
                        break;
                    }
            }

            return description;
        }

        private string GetYearDescription()
        {
            string description = GetSegmentDescription(m_expressionParts[6],
                string.Empty,
               (s => new DateTime(Convert.ToInt32(s), 1, 1).ToString("yyyy")),
               (s => string.Format(CronExpressionDescriptor.Resources.ComaEveryX0Years, s)),
               (s => CronExpressionDescriptor.Resources.ComaX0ThroughX1),
               (s => CronExpressionDescriptor.Resources.ComaOnlyInX0));
			
            return description;
		}

        protected string GetSegmentDescription(string expression,
            string allDescription,
            Func<string, string> getSingleItemDescription,
            Func<string, string> getIntervalDescriptionFormat,
            Func<string, string> getBetweenDescriptionFormat,
            Func<string, string> getDescriptionFormat)
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
                    string betweenSegmentOfInterval = segments[0];
                    string[] betweenSegements = betweenSegmentOfInterval.Split('-');
                    description += ", " + string.Format(getBetweenDescriptionFormat(betweenSegmentOfInterval), getSingleItemDescription(betweenSegements[0]), getSingleItemDescription(betweenSegements[1]));
                }
            }
            else if (expression.Contains("-"))
            {
                string[] segments = expression.Split('-');
                string segment1 = segments[0];
                string segment2 = segments[1];
           
                description = string.Format(getBetweenDescriptionFormat(expression), getSingleItemDescription(segment1), getSingleItemDescription(segment2));
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
                        descriptionContent += CronExpressionDescriptor.Resources.SpaceAndSpace;
                    }

                    descriptionContent += getSingleItemDescription(segments[i]);
                }

                description = string.Format(getDescriptionFormat(expression), descriptionContent);
            }

            return description;
        }

        protected string FormatTime(string hourExpression, string minuteExpression)
        {
            return FormatTime(hourExpression, minuteExpression, string.Empty);
        }

        protected string FormatTime(string hourExpression, string minuteExpression, string secondExpression)
        {
            int hour = Convert.ToInt32(hourExpression);
            string amPM = hour >= 12 ? "PM" : "AM";
            if (hour > 12) { hour -= 12; }
            string minute = Convert.ToInt32(minuteExpression).ToString();
            string second = string.Empty;
            if (!string.IsNullOrEmpty(secondExpression))
            {
                second = string.Concat(":", Convert.ToInt32(secondExpression).ToString().PadLeft(2, '0'));
            }

            return string.Format("{0}:{1}{2} {3}",
                hour.ToString().PadLeft(2, '0'), minute.PadLeft(2, '0'), second, amPM);
        }

        protected string TransformVerbosity(string description)
        {
            if (!m_options.Verbose)
            {
                description = description.Replace(CronExpressionDescriptor.Resources.ComaEveryMinute, string.Empty);
                description = description.Replace(CronExpressionDescriptor.Resources.ComaEveryHour, string.Empty);
                description = description.Replace(CronExpressionDescriptor.Resources.ComaEveryDay, string.Empty);
            }

            return description;
        }

        protected string TransformCase(string description)
        {
            switch (m_options.CasingType)
            {
                case CasingTypeEnum.Sentence:
                    description = string.Concat(char.ToUpper(description[0]), description.Substring(1));
                    break;
                case CasingTypeEnum.Title:
                    description = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(description);
                    break;
                default:
                    description = description.ToLower();
                    break;

            }
            return description;
        }

        public static string GetDescription(string expression)
        {
            return GetDescription(expression, new Options());
        }

        public static string GetDescription(string expression, Options options)
        {
            ExpressionDescriptor descripter = new ExpressionDescriptor(expression, options);
            return  descripter.GetDescription(DescriptionTypeEnum.FULL);
        }
    }




}