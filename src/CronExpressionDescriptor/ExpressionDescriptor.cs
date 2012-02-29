using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCrontab;

namespace CronExpressionDescriptor
{
    /// <summary>
    /// Converts cron expressions into human readable strings.
    /// </summary>
    public class ExpressionDescriptor
    {
        private string[] m_cronExpression;

        public ExpressionDescriptor(string cronExpression)
        {
            if (string.IsNullOrEmpty(cronExpression))
            {
                throw new MissingFieldException("ExpressionDescriptor", "cronExpression");
            }
            else
            {
                ValueOrError<CrontabSchedule> sc = CrontabSchedule.TryParse(cronExpression);
                if (!sc.IsError)
                {
                    m_cronExpression = cronExpression.Split(' '); ;
                }
                else
                {
                    throw new FormatException(sc.Error.Message, sc.Error);
                }
            }
        }

        public string TimeDescription
        {
            get { return GetTimeDescription(m_cronExpression[0], m_cronExpression[1]); }
        }

        public string DayOfMonthDescription
        {
            get { return GetDayOfMonthDescription(m_cronExpression[2]); }
        }

        public string MonthDescription
        {
            get { return GetMonthDescription(m_cronExpression[3]); }
        }

        public string DayOfWeekDescription
        {
            get { return GetDayOfWeekDescription(m_cronExpression[4]); }
        }


        public string FullDescription
        {
            get
            {
                string description = string.Empty;

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


                return description;
            }
        }

        public string GetTimeDescription(string minuteExpression, string hourExpression)
        {
            string description = string.Empty;

            string minuteVerboseDescription = GetMinuteDescription(minuteExpression);
            string hourVerboseDescription = GetHourDescription(hourExpression);

            if (minuteExpression.IndexOfAny(new char[] { '/', '-', ',', '*' }) == -1
                && hourExpression.IndexOfAny(new char[] { '/', '-', ',', '*' }) == -1)
            {
                description = string.Concat("At ", FormatTime(hourExpression, minuteExpression));
            }
            else if (minuteExpression.IndexOfAny(new char[] { '/', '-', ',', '*' }) == -1
               && hourExpression.Contains(","))
            {
                description = GetSegmentDescription(hourExpression, string.Empty,
                     (s => FormatTime(s, minuteExpression)),
                     (s => string.Empty),
                     (s => string.Empty),
                     (s => "At {0}"));
            }
            else if (minuteExpression.Contains("-")
                && hourExpression.IndexOfAny(new char[] { '/', '-', ',', '*' }) == -1)
            {
                description = GetSegmentDescription(minuteExpression, string.Empty,
                    (s => FormatTime(hourExpression, s)),
                    (s => string.Empty),
                    (s => "Every minute between {0} and {1}"),
                    (s => string.Empty));
            }
            else
            {
                description = string.Format("{0}{1}",
                    minuteVerboseDescription,
                    hourVerboseDescription);
            }

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
            (s => FormatTime(s, "00")),
            (s => string.Format(", every {0} hours", s)),
            (s => ", between the hours of {0} and {1}"),
            (s => ", at {0}"));

            return description;
        }

        protected string GetDayOfWeekDescription(string expression)
        {
            //convert SUN-SAT format to 0-6
            for (int i = 0; i <= 6; i++)
            {
                DayOfWeek currentDay = (DayOfWeek)i;
                string currentDayOfWeekDescription = currentDay.ToString().Substring(0, 3).ToUpper();
                expression = expression.Replace(currentDayOfWeekDescription, i.ToString());
            }

            string description = GetSegmentDescription(expression, ", daily",
              (s => ((DayOfWeek)Convert.ToInt32(s)).ToString()),
              (s => string.Format(", every {0} days of the week", s)),
              (s => ", {0}-{1}"),
              (s => ", only on {0}s"));

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
            string description = GetSegmentDescription(expression, string.Empty,
                (s => s),
                (s => ", every {0} days"),
                (s => ", between day {0} and {1} of the month"),
                (s => ", on day {0} of the month"));

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

        protected string FormatTime(string hourExpression, string minuteExpression)
        {
            int hour = Convert.ToInt32(hourExpression);
            string amPM = hour >= 12 ? "PM" : "AM";
            if (hour > 12) { hour -= 12; }
            int minute = Convert.ToInt32(minuteExpression);

            return string.Format("{0}:{1} {2}",
                hour.ToString().PadLeft(2, '0'), minute.ToString().PadLeft(2, '0'), amPM);
        }
    }
}