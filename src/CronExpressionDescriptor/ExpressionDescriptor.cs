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

                    if (!string.IsNullOrEmpty(dayOfMonthDesc))
                    {
                        dayOfWeekDesc = string.Empty;
                    }

                    description = string.Format("{0}{1}{2}{3}",
                        timeSegment, dayOfWeekDesc, dayOfMonthDesc, monthDesc);

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

            if (exception != null && m_options.ThrowExceptionOnParseError)
            {
                throw exception;
            }

            return (exception == null);
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
            string description = string.Empty;

            if (minuteExpression.IndexOfAny(new char[] { '/', '-', ',', '*' }) == -1
                && hourExpression.IndexOfAny(new char[] { '/', '-', ',', '*' }) == -1
                && secondsExpression.IndexOfAny(new char[] { '/', '-', ',', '*' }) == -1)
            {
                //specific time of day
                description = string.Concat("At ", FormatTime(hourExpression, minuteExpression, secondsExpression));
            }
            else
            {
                bool isBetweenMinutesInSingleHourFormat = minuteExpression.Contains("-") && hourExpression.IndexOfAny(new char[] { '/', '-', ',', '*' }) == -1;
                bool isBetweenMinutesInMultipleHourFormat = minuteExpression.Contains("-") && hourExpression.IndexOfAny(new char[] { '/', '-', ',', '*' }) > -1;
                bool isSpecificMinuteFormat = minuteExpression.IndexOfAny(new char[] { '/', '-', ',', '*' }) == -1;
                bool isSpecificSecondsFormat = secondsExpression.IndexOfAny(new char[] { '/', '-', ',', '*' }) == -1;

                string secondVerboseDescription = GetSegmentDescription(secondsExpression,
                    "every second",
                  (s => string.Concat(":", s.PadLeft(2, '0'))),
                  (s => string.Format("every {0} seconds", s)),
                  (s => "every second between {0} and {1}"),
                  (s => s == "0" ? string.Empty : "at seconds {0}"));

                string minuteVerboseDescription = GetSegmentDescription(minuteExpression,
                   !string.IsNullOrEmpty(secondsExpression) ? string.Empty : "every minute",
                   (s =>
                     {
                         if (isBetweenMinutesInSingleHourFormat)
                         {
                             return FormatTime(hourExpression, s, secondsExpression);
                         }
                         else if (isBetweenMinutesInMultipleHourFormat)
                         {
                             return string.Concat(":", s.PadLeft(2, '0'));
                         }
                         else
                         {
                             return string.Empty;
                         }

                     }),
                   (s => string.Format("every {0} minutes", s)),
                   (s => isBetweenMinutesInSingleHourFormat ? "every minute between {0} and {1}" : "between the minutes of {0} and {1}"),
                   (s => isSpecificMinuteFormat ? string.Empty : "at {0}")
                );


                string hourVerboseDescription = GetSegmentDescription(hourExpression,
                    string.Empty,
                    (s =>
                    {
                        if (isBetweenMinutesInMultipleHourFormat)
                        {
                            return FormatTime(s, "00", string.Empty);
                        }
                        else
                        {
                            return FormatTime(s, isSpecificMinuteFormat ? minuteExpression : "00", secondsExpression);
                        }
                    }),
                 (s => string.Format(", every {0} hours", s)),
                 (s => "between the hours of {0} and {1}"),
                 (s => isBetweenMinutesInSingleHourFormat ? string.Empty : "at {0}"));

                description += secondVerboseDescription;

                if (description.Length > 0 && !string.IsNullOrEmpty(minuteVerboseDescription))
                {
                    description += ", ";
                }

                description += minuteVerboseDescription;

                if (description.Length > 0 && !string.IsNullOrEmpty(hourVerboseDescription))
                {
                    description += ", ";
                }

                description += hourVerboseDescription;
            }

            return description;
        }

        protected string GetDayOfWeekDescription(string expression)
        {
            expression = expression.Replace("?", "*");

            //convert SUN-SAT format to 0-6
            for (int i = 0; i <= 6; i++)
            {
                DayOfWeek currentDay = (DayOfWeek)i;
                string currentDayOfWeekDescription = currentDay.ToString().Substring(0, 3).ToUpper();
                expression = expression.Replace(currentDayOfWeekDescription, i.ToString());
            }

            string description = GetSegmentDescription(expression,
                string.Empty,
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
              (s => ", {0}-{1}"),
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
                      format = ", only on {0}s";
                  }

                  return format;
              }));

            return description;
        }

        protected string GetMonthDescription(string expression)
        {
            //convert  JAN-DEC format to 1-12 
            for (int i = 1; i <= 12; i++)
            {
                DateTime currentMonth = new DateTime(DateTime.Now.Year, i, 1);
                string currentMonthDescription = currentMonth.ToString("MMM").ToUpper();
                expression = expression.Replace(currentMonthDescription, i.ToString());
            }

            string description = GetSegmentDescription(expression, string.Empty,
               (s => new DateTime(DateTime.Now.Year, Convert.ToInt32(s), 1).ToString("MMMM")),
               (s => string.Format(", every {0} months", s)),
               (s => ", {0}-{1}"),
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
                    string.Empty,
                    (s => s),
                    (s => ", every {0} days"),
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
                description = getIntervalDescriptionFormat(expression.Substring(expression.IndexOf("/") + 1));
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