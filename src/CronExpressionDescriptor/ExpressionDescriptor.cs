using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CronExpressionDescriptor
{
    /// <summary>
    /// Converts cron expressions into human readable strings.
    /// </summary>
    public class ExpressionDescriptor
    {
        private ExpressionTypeEnum m_type;
        private string m_expression;
        private Options m_options;
        private string m_secondsExpression;
        private string m_minutesExpression;
        private string m_hoursExpression;
        private string m_dayOfMonthExpression;
        private string m_monthExpression;
        private string m_dayOfWeekExpression;
        private string m_yearExpression;

        public ExpressionDescriptor(string expression) : this(ExpressionTypeEnum.Crontab, expression) { }
        public ExpressionDescriptor(ExpressionTypeEnum type, string expression) : this(type, expression, new Options()) { }
        public ExpressionDescriptor(ExpressionTypeEnum type, string expression, Options options)
        {
            m_type = type;
            m_expression = expression;
            m_options = options;
        }

        public string GetDescription()
        {
            string description;

            if (ParseExpression(m_expression, out description) == true)
            {
                string timeSegment = this.TimeDescription;
                string dayOfMonthDesc = this.DayOfMonthDescription;
                string monthDesc = this.MonthDescription;
                string dayOfWeekDesc = this.DayOfWeekDescription;
                string yearDesc = this.YearDescription;

                if (!string.IsNullOrEmpty(dayOfMonthDesc))
                {
                    dayOfWeekDesc = string.Empty;
                }

                description = string.Format("{0}{1}{2}{3}{4}",
                    timeSegment, dayOfWeekDesc, dayOfMonthDesc, monthDesc, yearDesc);

            }

            return description;
        }

        private bool ParseExpression(string expression, out string result)
        {
            result = string.Empty;
            Exception exception = null;

            if (string.IsNullOrEmpty(expression))
            {
                result = "expression was empty!";
                exception = new MissingFieldException("ExpressionDescriptor", "expression");
            }
            else
            {
                string[] expressionParts = expression.Split(' ');

                if (expressionParts.Length < 5)
                {
                    result = string.Format("expression only has {0} parts!", expressionParts.Length);
                    exception = new FormatException(result);
                }

                //default seconds and year to empty as these are optional.
                m_secondsExpression = string.Empty;
                m_yearExpression = string.Empty;

                switch (m_type)
                {
                    case ExpressionTypeEnum.Quartz:
                        if (expressionParts.Length < 6)
                        {
                            result = string.Format("expression only has {0} parts!  Quartz type requires at least 6 parts.", expressionParts.Length);
                            exception = new FormatException(result);
                        }
                        else
                        {
                            m_secondsExpression = expressionParts[0];
                            m_minutesExpression = expressionParts[1];
                            m_hoursExpression = expressionParts[2];
                            m_dayOfMonthExpression = expressionParts[3];
                            m_monthExpression = expressionParts[4];
                            m_dayOfWeekExpression = expressionParts[5];

                            if (expressionParts.Length == 7)
                            {
                                m_yearExpression = expressionParts[6];
                            }
                        }
                        break;
                    default:
                        m_minutesExpression = expressionParts[0];
                        m_hoursExpression = expressionParts[1];
                        m_dayOfMonthExpression = expressionParts[2];
                        m_monthExpression = expressionParts[3];
                        m_dayOfWeekExpression = expressionParts[4];

                        if (expressionParts.Length == 6)
                        {
                            m_yearExpression = expressionParts[5];
                        }
                        break;
                }
            }

            if (m_options.ThrowExceptionOnParseError)
            {
                throw exception;
            }

            return (exception == null);
        }

        private string TimeDescription
        {
            get { return GetTimeDescription(m_secondsExpression, m_minutesExpression, m_hoursExpression); }
        }

        private string DayOfMonthDescription
        {
            get { return GetDayOfMonthDescription(m_dayOfMonthExpression); }
        }

        private string MonthDescription
        {
            get { return GetMonthDescription(m_monthExpression); }
        }

        private string DayOfWeekDescription
        {
            get { return GetDayOfWeekDescription(m_dayOfWeekExpression); }
        }

        private string YearDescription
        {
            get { return GetYearDescription(m_yearExpression); }
        }

        private string GetTimeDescription(string secondsExpression, string minuteExpression, string hourExpression)
        {
            string description = string.Empty;

            string minuteVerboseDescription = GetMinuteDescription(minuteExpression);
            string hourVerboseDescription = GetHourDescription(hourExpression);
            string secondVerboseDescription = GetSecondDescription(secondsExpression);

            if (minuteExpression.IndexOfAny(new char[] { '/', '-', ',', '*' }) == -1
                && hourExpression.IndexOfAny(new char[] { '/', '-', ',', '*' }) == -1
                && secondsExpression.IndexOfAny(new char[] { '/', '-', ',', '*' }) == -1)
            {
                description = string.Concat("At ", FormatTime(hourExpression, minuteExpression, secondsExpression));
            }
            else if (minuteExpression.IndexOfAny(new char[] { '/', '-', ',', '*' }) == -1
                && secondsExpression.IndexOfAny(new char[] { '/', '-', ',', '*' }) == -1
               && hourExpression.Contains(","))
            {
                description = GetSegmentDescription(hourExpression, string.Empty,
                     (s => FormatTime(s, minuteExpression, secondsExpression)),
                     (s => string.Empty),
                     (s => string.Empty),
                     (s => "At {0}"));
            }
            else if (minuteExpression.Contains("-")
                && hourExpression.IndexOfAny(new char[] { '/', '-', ',', '*' }) == -1)
            {
                description = GetSegmentDescription(minuteExpression, string.Empty,
                    (s => FormatTime(hourExpression, s, secondsExpression)),
                    (s => string.Empty),
                    (s => "Every minute between {0} and {1}"),
                    (s => string.Empty));
            }
            else
            {
                description = string.Format("{0}{1}{2}",
                    minuteVerboseDescription,
                    hourVerboseDescription,
                    secondVerboseDescription);
            }

            return description;
        }

        protected string GetSecondDescription(string expression)
        {
            string description = GetSegmentDescription(expression, "Every second",
           (s => string.Concat(":", s)),
           (s => string.Format("Every {0} seconds", s)),
           (s => "Every second between {0} and {1}"),
           (s => "At {0}"));

            return description;
        }

        protected string GetMinuteDescription(string expression)
        {
            string description = GetSegmentDescription(expression, "Every minute",
           (s => string.Concat(":", s)),
           (s => string.Format("Every {0} minutes", s)),
           (s => "Every minute between {0} and {1}"),
           (s => "At {0}"));

            return description;
        }

        protected string GetHourDescription(string expression)
        {
            string description = GetSegmentDescription(expression, string.Empty,
            (s => FormatTime(s, "00", string.Empty)),
            (s => string.Format(", every {0} hours", s)),
            (s => ", between the hours of {0} and {1}"),
            (s => ", at {0}"));

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

            string description = GetSegmentDescription(expression, ", daily",
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
                description = GetSegmentDescription(expression, string.Empty,
                    (s => s),
                    (s => ", every {0} days"),
                    (s => ", between day {0} and {1} of the month"),
                    (s => ", on day {0} of the month"));
            }

            return description;
        }

        protected string GetYearDescription(string expression)
        {
            string description = string.Empty;
            if (!string.IsNullOrEmpty(expression))
            {
                description = GetSegmentDescription(expression, string.Empty,
              (s => s),
              (s => string.Format(", every {0} years", s)),
              (s => ", {0}-{1}"),
              (s => ", only in the year {0}"));
            }

            return description;
        }

        protected string GetSegmentDescription(string expression, string allDescription,
            Func<string, string> getSingleItemDescription,
            Func<string, string> getIntervalDescriptionFormat,
            Func<string, string> getBetweenDescriptionFormat,
            Func<string, string> getDescriptionFormat)
        {
            string description = string.Empty;

            if (expression == "*")
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
            string second = string.IsNullOrEmpty(secondExpression) ? string.Empty : string.Concat(":", Convert.ToInt32(secondExpression).ToString());

            return string.Format("{0}:{1}{2} {3}",
                hour.ToString().PadLeft(2, '0'), minute.PadLeft(2, '0'), second, amPM);
        }
    }
}