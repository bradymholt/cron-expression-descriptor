using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Text.RegularExpressions;

namespace CronExpressionDescriptor
{
    /// <summary>
    /// Converts cron expressions into human readable strings.
    /// </summary>
    public class ExpressionDescriptor
    {
        private string m_expression;
        private Options m_options;
        private string[] m_expressionParts;

        public ExpressionDescriptor(string expression) : this(expression, new Options()) { }
        public ExpressionDescriptor(string expression, Options options)
        {
            m_expression = expression;
            m_options = options;
            m_expressionParts = new string[6];
        }

        public string GetDescription()
        {
            string description;

            if (ParseExpression(m_expression, out description) == true)
            {
                try
                {
                    string timeSegment = this.TimeDescription;
                    string dayOfMonthDesc = this.DayOfMonthDescription;
                    string monthDesc = this.MonthDescription;
                    string dayOfWeekDesc = this.DayOfWeekDescription;

                    description = string.Format("{0}{1}{2}",
                        timeSegment,
                        (m_expressionParts[3] == "*" ? dayOfWeekDesc : dayOfMonthDesc),
                        monthDesc);

                    description = TransformVerbosity(description);
                    description = TransformCase(description);
                }
                catch (Exception ex)
                {
                    description = "An error occured when generating the expression description.  Check the cron expression syntax.";
                    if (m_options.ThrowExceptionOnParseError)
                    {
                        throw new FormatException(description, ex);
                    }
                }
            }

            return description;
        }

        private string TransformVerbosity(string description)
        {
            if (!m_options.Verbose)
            {
                description = description.Replace(", every minute", string.Empty);
                description = description.Replace(", every hour", string.Empty);
                description = description.Replace(", every day", string.Empty);
            }

            return description;
        }

        private string TransformCase(string description)
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

        private bool ParseExpression(string expression, out string result)
        {
            result = string.Empty;
            Exception exception = null;

            if (string.IsNullOrEmpty(expression))
            {
                result = "Error: Expression is missing.";
                exception = new MissingFieldException("ExpressionDescriptor", "expression");
            }
            else
            {
                string[] expressionPartsTemp = expression.Split(' ');

                if (expressionPartsTemp.Length < 5)
                {
                    result = string.Format("Error: Expression only has {0} parts.  At least 5 part are required.", expressionPartsTemp.Length);
                    exception = new FormatException(result);
                }
                else if (expressionPartsTemp.Length > 6)
                {
                    result = string.Format("Error: Expression has too many parts ({0}).  Expression must not have more than 6 parts.", expressionPartsTemp.Length);
                    exception = new FormatException(result);
                }
                else if (expressionPartsTemp.Length == 5)
                {
                    //5 part cron so defualt seconds to empty and shift array
                    m_expressionParts[0] = string.Empty;
                    Array.Copy(expressionPartsTemp, 0, m_expressionParts, 1, 5);
                }
                else if (expressionPartsTemp.Length == 6)
                {
                    m_expressionParts = expressionPartsTemp;
                }
            }

            if (exception != null)
            {
                if (m_options.ThrowExceptionOnParseError)
                {
                    throw exception;
                }
            }
            else
            {
                NormalizeExpression();
            }

            return (exception == null);
        }

        private void NormalizeExpression()
        {
            //convert ? to * only for DOM and DOW
            m_expressionParts[3] = m_expressionParts[3].Replace("?", "*");
            m_expressionParts[5] = m_expressionParts[5].Replace("?", "*");

            //convert 0/, 1/ to */
            m_expressionParts[0] = m_expressionParts[0].Replace("0/", "*/"); //seconds
            m_expressionParts[1] = m_expressionParts[1].Replace("0/", "*/"); //minutes
            m_expressionParts[2] = m_expressionParts[2].Replace("0/", "*/"); //hours
            m_expressionParts[3] = m_expressionParts[3].Replace("1/", "*/"); //DOM
            m_expressionParts[4] = m_expressionParts[4].Replace("1/", "*/"); //Month
            m_expressionParts[5] = m_expressionParts[5].Replace("1/", "*/"); //DOW

            //convert */1 to *
            for (int i = 0; i <= 5; i++)
            {
                m_expressionParts[i] = m_expressionParts[i].Replace("*/1", "*");
            }

            //convert SUN-SAT format to 0-6 format
            for (int i = 0; i <= 6; i++)
            {
                DayOfWeek currentDay = (DayOfWeek)i;
                string currentDayOfWeekDescription = currentDay.ToString().Substring(0, 3).ToUpper();
                m_expressionParts[5] = m_expressionParts[5].Replace(currentDayOfWeekDescription, i.ToString());
            }

            //convert  JAN-DEC format to 1-12 format
            for (int i = 1; i <= 12; i++)
            {
                DateTime currentMonth = new DateTime(DateTime.Now.Year, i, 1);
                string currentMonthDescription = currentMonth.ToString("MMM").ToUpper();
                m_expressionParts[4] = m_expressionParts[4].Replace(currentMonthDescription, i.ToString());
            }

            //convert 0 second to (empty)
            if (m_expressionParts[0] == "0")
            {
                m_expressionParts[0] = string.Empty;
            }
        }

        private string TimeDescription
        {
            get { return GetTimeDescription(m_expressionParts[0], m_expressionParts[1], m_expressionParts[2]); }
        }

        private string DayOfMonthDescription
        {
            get { return GetDayOfMonthDescription(m_expressionParts[3]); }
        }

        private string MonthDescription
        {
            get { return GetMonthDescription(m_expressionParts[4]); }
        }

        private string DayOfWeekDescription
        {
            get { return GetDayOfWeekDescription(m_expressionParts[5]); }
        }

        private string GetTimeDescription(string secondsExpression, string minuteExpression, string hourExpression)
        {
            StringBuilder description = new StringBuilder();

            if (minuteExpression.IndexOfAny(new char[] { '/', '-', ',', '*' }) == -1
                && hourExpression.IndexOfAny(new char[] { '/', '-', ',', '*' }) == -1
                && secondsExpression.IndexOfAny(new char[] { '/', '-', ',', '*' }) == -1)
            {
                //specific time of day
                description.Append("At ").Append(FormatTime(hourExpression, minuteExpression, secondsExpression));
            }
            else
            {
                string secondDescription = GetSegmentDescription(secondsExpression,
                   "every second",
                 (s => s.PadLeft(2, '0')),
                 (s => string.Format("every {0} seconds", s)),
                 (s => "seconds {0} through {1} past the minute"),
                 (s => "at {0} seconds past the minute"));

                string minuteDescription = GetSegmentDescription(minuteExpression,
                   "every minute",
                 (s => s.PadLeft(2, '0')),
                 (s => string.Format("every {0} minutes", s.PadLeft(2, '0'))),
                 (s => "minutes {0} through {1} past the hour"),
                 (s => s == "0" ? string.Empty : "at {0} minutes past the hour"));

                string hourDescription = GetSegmentDescription(hourExpression,
                   "every hour",
                 (s => FormatTime(s, "0")),
                 (s => string.Format("every {0} hours", s.PadLeft(2, '0'))),
                 (s => "between {0} and {1}"),
                 (s => "at {0}"));

                //override special cases

                if (minuteExpression.Contains("-") && hourExpression.IndexOfAny(new char[] { '/', '-', ',', '*' }) == -1)
                {
                    //Minute range in single hour (i.e. 0-10 11)
                    string[] minuteParts = minuteExpression.Split('-');
                    minuteDescription = string.Empty;
                    hourDescription = string.Format("Every minute between {0} and {1}",
                        FormatTime(hourExpression, minuteParts[0]),
                        FormatTime(hourExpression, minuteParts[1]));
                }
                else if (hourExpression.Contains(",") && minuteExpression.IndexOfAny(new char[] { '/', '-', ',', '*' }) == -1)
                {
                    //Hours list with single minute (o.e. 30 6,14,16)
                    string[] hourParts = hourExpression.Split(',');
                    minuteDescription = string.Empty;

                    hourDescription = "At";
                    for (int i = 0; i < hourParts.Length; i++)
                    {
                        hourDescription += string.Concat(" ", FormatTime(hourParts[i], minuteExpression));

                        if (i < (hourParts.Length - 2))
                        {
                            hourDescription += ",";
                        }

                        if (i == hourParts.Length - 2)
                        {
                            hourDescription += " and";
                        }
                    }
                }


                description.Append(secondDescription);

                if (description.Length > 0)
                {
                    description.Append(", ");
                }

                description.Append(minuteDescription);

                if (description.Length > 0)
                {
                    description.Append(", ");
                }

                description.Append(hourDescription);
            }

            return description.ToString();
        }

        protected string GetDayOfWeekDescription(string expression)
        {
            string description = GetSegmentDescription(expression,
                ", every day",
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

                  return ((DayOfWeek)Convert.ToInt32(exp)).ToString();
              }),
              (s => string.Format(", every {0} days of the week", s)),
              (s => ", {0} through {1}"),
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
                              dayOfWeekOfMonthDescription = "first";
                              break;
                          case "2":
                              dayOfWeekOfMonthDescription = "second";
                              break;
                          case "3":
                              dayOfWeekOfMonthDescription = "third";
                              break;
                          case "4":
                              dayOfWeekOfMonthDescription = "forth";
                              break;
                          case "5":
                              dayOfWeekOfMonthDescription = "fifth";
                              break;
                      }


                      format = string.Concat(", on the ", dayOfWeekOfMonthDescription, " {0} of the month");
                  }
                  else if (s.Contains("L"))
                  {
                      format = ", on the last {0} of the month";
                  }
                  else
                  {
                      format = ", only on {0}";
                  }

                  return format;
              }));

            return description;
        }

        protected string GetMonthDescription(string expression)
        {
            string description = GetSegmentDescription(expression, string.Empty,
               (s => new DateTime(DateTime.Now.Year, Convert.ToInt32(s), 1).ToString("MMMM")),
               (s => string.Format(", every {0} months", s)),
               (s => ", {0} through {1}"),
               (s => ", only in {0}"));

            return description;
        }

        protected string GetDayOfMonthDescription(string expression)
        {
            string description = null;
            expression = expression.Replace("?", "*");

            if (expression == "L")
            {
                description = ", on the last day of the month";
            }
            else
            {
                description = GetSegmentDescription(expression,
                    ", every day",
                    (s => s),
                    (s => s == "1" ? ", every day" : ", every {0} days"),
                    (s => ", between day {0} and {1} of the month"),
                    (s => ", on day {0} of the month"));
            }

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
                string[] segements = expression.Split('-');
                description = string.Format(getBetweenDescriptionFormat(expression), getSingleItemDescription(segements[0]), getSingleItemDescription(segements[1]));
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
                        descriptionContent += " and ";
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
    }
}