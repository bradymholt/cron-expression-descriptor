using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCrontab;

namespace CronExpressionDescripter
{
    /// <summary>
    /// Converts cron expressions into human readable strings.
    /// </summary>
    public class ExpressionDescripter
    {
        private string m_cronExpression;

        public ExpressionDescripter(string cronExpression)
        {
            if (string.IsNullOrEmpty(cronExpression))
            {
                throw new MissingFieldException("CronExpressionHumanizer", "cronExpression");
            }
            else
            {
                ValueOrError<CrontabSchedule> sc = CrontabSchedule.TryParse(cronExpression);
                if (!sc.IsError)
                {
                    m_cronExpression = cronExpression;
                }
                else
                {
                    throw new FormatException(sc.Error.Message, sc.Error);
                }
            }
        }

        public string GetHumanDescription()
        {
            string description = string.Empty;

            string[] segments = m_cronExpression.Split(' ');

            string timeSegment = GetTimeDescription(segments[0], segments[1]);
            string dayOfMonthDesc = GetDayOfMonthDescription(segments[2]);
            string monthDesc = GetMonthDescription(segments[3]);
            string dayOfWeekDesc = GetDayOfWeekDescription(segments[4]);

            if (!string.IsNullOrEmpty(dayOfMonthDesc))
            {
                dayOfWeekDesc = string.Empty;
            }

            description = string.Format("{0}{1}{2}{3}",
                timeSegment, dayOfWeekDesc, dayOfMonthDesc, monthDesc);


            return description;
        }

        protected string GetTimeDescription(string minuteExpression, string hourExpression)
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
                description = string.Format("{0}{1}{2}",
                    minuteVerboseDescription,
                    !string.IsNullOrEmpty(hourVerboseDescription) ? ", " : string.Empty,
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
            string description = GetSegmentDescription(expression, ", daily",
              (s => ((DayOfWeek)Convert.ToInt32(s)).ToString()),
              (s => string.Format(", every {0} days of the week", s)),
              (s => ", {0}-{1}"),
              (s => ", only on {0}s"));

            return description;
        }

        protected string GetMonthDescription(string expression)
        {
            string description = GetSegmentDescription(expression, string.Empty,
               (s => new DateTime(DateTime.Now.Year, Convert.ToInt32(s), 1).ToString("MMMM")),
               (s => string.Format(", every {0} months", s)),
               (s => ", between {0} and {1}"),
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