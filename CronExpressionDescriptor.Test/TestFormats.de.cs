using System.Globalization;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CronExpressionDescriptor.Test
{
    [TestClass]
    public class TestFormatsDE
    {
        [TestInitialize]
        public void SetUp()
        {
            CultureInfo myCultureInfo = new CultureInfo("de");
            Thread.CurrentThread.CurrentCulture = myCultureInfo;
            Thread.CurrentThread.CurrentUICulture = myCultureInfo;
        }

        [TestMethod]
        [DeploymentItem(@"de\CronExpressionDescriptor.resources.dll", "de")]
        public void TestEveryMinute()
        {
            Assert.AreEqual("Jede Minute", ExpressionDescriptor.GetDescription("* * * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"de\CronExpressionDescriptor.resources.dll", "de")]
        public void TestEvery1Minute()
        {
            Assert.AreEqual("Jede Minute", ExpressionDescriptor.GetDescription("*/1 * * * *"));
            Assert.AreEqual("Jede Minute", ExpressionDescriptor.GetDescription("0 0/1 * * * ?"));
        }

        [TestMethod]
        [DeploymentItem(@"de\CronExpressionDescriptor.resources.dll", "de")]
        public void TestEveryHour()
        {
            Assert.AreEqual("Jede Stunde", ExpressionDescriptor.GetDescription("0 0 * * * ?"));
            Assert.AreEqual("Jede Stunde", ExpressionDescriptor.GetDescription("0 0 0/1 * * ?"));
        }

        [TestMethod]
        [DeploymentItem(@"de\CronExpressionDescriptor.resources.dll", "de")]
        public void TestTimeOfDayCertainDaysOfWeek()
        {
            Assert.AreEqual("Um 23:00, Montag bis Freitag", ExpressionDescriptor.GetDescription("0 23 ? * MON-FRI", new Options { Use24HourTimeFormat = true }));
        }

        [TestMethod]
        [DeploymentItem(@"de\CronExpressionDescriptor.resources.dll", "de")]
        public void TestEverySecond()
        {
            Assert.AreEqual("Jede Sekunde", ExpressionDescriptor.GetDescription("* * * * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"de\CronExpressionDescriptor.resources.dll", "de")]
        public void TestEvery45Seconds()
        {
            Assert.AreEqual("Alle 45 Sekunden", ExpressionDescriptor.GetDescription("*/45 * * * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"de\CronExpressionDescriptor.resources.dll", "de")]
        public void TestEvery5Minutes()
        {
            Assert.AreEqual("Alle 05 Minuten", ExpressionDescriptor.GetDescription("*/5 * * * *"));
            Assert.AreEqual("Alle 10 Minuten", ExpressionDescriptor.GetDescription("0 0/10 * * * ?"));
        }

        [TestMethod]
        [DeploymentItem(@"de\CronExpressionDescriptor.resources.dll", "de")]
        public void TestEvery5MinutesOnTheSecond()
        {
            Assert.AreEqual("Alle 05 Minuten", ExpressionDescriptor.GetDescription("0 */5 * * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"de\CronExpressionDescriptor.resources.dll", "de")]
        public void TestWeekdaysAtTime()
        {
            Assert.AreEqual("Um 11:30, Montag bis Freitag", ExpressionDescriptor.GetDescription("30 11 * * 1-5", new Options { Use24HourTimeFormat = true }));
        }

        [TestMethod]
        [DeploymentItem(@"de\CronExpressionDescriptor.resources.dll", "de")]
        public void TestDailyAtTime()
        {
            Assert.AreEqual("Um 11:30", ExpressionDescriptor.GetDescription("30 11 * * *", new Options { Use24HourTimeFormat = true }));
        }

        [TestMethod]
        [DeploymentItem(@"de\CronExpressionDescriptor.resources.dll", "de")]
        public void TestMinuteSpan()
        {
            Assert.AreEqual("Jede Minute zwischen 11:00 und 11:10", ExpressionDescriptor.GetDescription("0-10 11 * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"de\CronExpressionDescriptor.resources.dll", "de")]
        public void TestOneMonthOnly()
        {
            Assert.AreEqual("Jede Minute, nur im März", ExpressionDescriptor.GetDescription("* * * 3 *"));
        }

        [TestMethod]
        [DeploymentItem(@"de\CronExpressionDescriptor.resources.dll", "de")]
        public void TestTwoMonthsOnly()
        {
            Assert.AreEqual("Jede Minute, nur im März und Juni", ExpressionDescriptor.GetDescription("* * * 3,6 *"));
        }

        [TestMethod]
        [DeploymentItem(@"de\CronExpressionDescriptor.resources.dll", "de")]
        public void TestTwoTimesEachAfternoon()
        {
            Assert.AreEqual("At 02:30 PM and 04:30 PM", ExpressionDescriptor.GetDescription("30 14,16 * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"de\CronExpressionDescriptor.resources.dll", "de")]
        public void TestThreeTimesDaily()
        {
            Assert.AreEqual("At 06:30 AM, 02:30 PM and 04:30 PM", ExpressionDescriptor.GetDescription("30 6,14,16 * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"de\CronExpressionDescriptor.resources.dll", "de")]
        public void TestOnceAWeek()
        {
            Assert.AreEqual("Um 09:46, nur am Montag", ExpressionDescriptor.GetDescription("46 9 * * 1", new Options { Use24HourTimeFormat = true }));
        }

        [TestMethod]
        [DeploymentItem(@"de\CronExpressionDescriptor.resources.dll", "de")]
        public void TestDayOfMonth()
        {
            Assert.AreEqual("Um 12:23, am 15. Tag des Monats", ExpressionDescriptor.GetDescription("23 12 15 * *", new Options { Use24HourTimeFormat = true }));
        }

        [TestMethod]
        [DeploymentItem(@"de\CronExpressionDescriptor.resources.dll", "de")]
        public void TestMonthName()
        {
            Assert.AreEqual("Um 12:23, nur im Januar", ExpressionDescriptor.GetDescription("23 12 * JAN *", new Options { Use24HourTimeFormat = true }));
        }

        [TestMethod]
        [DeploymentItem(@"de\CronExpressionDescriptor.resources.dll", "de")]
        public void TestDayOfMonthWithQuestionMark()
        {
            Assert.AreEqual("Um 12:23, nur im Januar", ExpressionDescriptor.GetDescription("23 12 ? JAN *", new Options { Use24HourTimeFormat = true }));
        }

        [TestMethod]
        [DeploymentItem(@"de\CronExpressionDescriptor.resources.dll", "de")]
        public void TestMonthNameRange2()
        {
            Assert.AreEqual("Um 12:23, Januar bis Februar", ExpressionDescriptor.GetDescription("23 12 * JAN-FEB *", new Options { Use24HourTimeFormat = true }));
        }

        [TestMethod]
        [DeploymentItem(@"de\CronExpressionDescriptor.resources.dll", "de")]
        public void TestMonthNameRange3()
        {
            Assert.AreEqual("At 12:23 PM, January through March", ExpressionDescriptor.GetDescription("23 12 * JAN-MAR *", new Options { Use24HourTimeFormat = true }));
        }

        [TestMethod]
        [DeploymentItem(@"de\CronExpressionDescriptor.resources.dll", "de")]
        public void TestDayOfWeekName()
        {
            Assert.AreEqual("Um 12:23, nur am Sonntag", ExpressionDescriptor.GetDescription("23 12 * * SUN", new Options { Use24HourTimeFormat = true }));
        }

        [TestMethod]
        [DeploymentItem(@"de\CronExpressionDescriptor.resources.dll", "de")]
        public void TestDayOfWeekRange()
        {
            Assert.AreEqual("Every 05 minutes, at 03:00 PM, Monday through Friday", ExpressionDescriptor.GetDescription("*/5 15 * * MON-FRI", new Options { Use24HourTimeFormat = true }));
        }

        [TestMethod]
        [DeploymentItem(@"de\CronExpressionDescriptor.resources.dll", "de")]
        public void TestDayOfWeekOnceInMonth()
        {
            Assert.AreEqual("Jede Minute, on the third Monday of the month", ExpressionDescriptor.GetDescription("* * * * MON#3"));
        }

        [TestMethod]
        [DeploymentItem(@"de\CronExpressionDescriptor.resources.dll", "de")]
        public void TestLastDayOfTheWeekOfTheMonth()
        {
            Assert.AreEqual("Jede Minute, on the last Thursday of the month", ExpressionDescriptor.GetDescription("* * * * 4L"));
        }

        [TestMethod]
        [DeploymentItem(@"de\CronExpressionDescriptor.resources.dll", "de")]
        public void TestLastDayOfTheMonth()
        {
            Assert.AreEqual("Every 05 minutes, on the last day of the month, only in January", ExpressionDescriptor.GetDescription("*/5 * L JAN *"));
        }

        [TestMethod]
        [DeploymentItem(@"de\CronExpressionDescriptor.resources.dll", "de")]
        public void TestLastWeekdayOfTheMonth()
        {
            Assert.AreEqual("Jede Minute, am letzten Wochentag im Monat", ExpressionDescriptor.GetDescription("* * LW * *"));
        }

        [TestMethod]
        [DeploymentItem(@"de\CronExpressionDescriptor.resources.dll", "de")]
        public void TestLastWeekdayOfTheMonth2()
        {
            Assert.AreEqual("Jede Minute, am letzten Wochentag des Monats", ExpressionDescriptor.GetDescription("* * WL * *"));
        }

        [TestMethod]
        [DeploymentItem(@"de\CronExpressionDescriptor.resources.dll", "de")]
        public void TestFirstWeekdayOfTheMonth()
        {
            Assert.AreEqual("Jede Minute, am ersten Wochentag des Monats", ExpressionDescriptor.GetDescription("* * 1W * *"));
        }

        [TestMethod]
        [DeploymentItem(@"de\CronExpressionDescriptor.resources.dll", "de")]
        public void TestFirstWeekdayOfTheMonth2()
        {
            Assert.AreEqual("Jede Minute, am ersten Wochentag des Monats", ExpressionDescriptor.GetDescription("* * W1 * *"));
        }

        [TestMethod]
        [DeploymentItem(@"de\CronExpressionDescriptor.resources.dll", "de")]
        public void TestParticularWeekdayOfTheMonth()
        {
            Assert.AreEqual("Jede Minute, on the weekday nearest day 5 of the month", ExpressionDescriptor.GetDescription("* * 5W * *"));
        }

        [TestMethod]
        [DeploymentItem(@"de\CronExpressionDescriptor.resources.dll", "de")]
        public void TestParticularWeekdayOfTheMonth2()
        {
            Assert.AreEqual("Jede Minute, on the weekday nearest day 5 of the month", ExpressionDescriptor.GetDescription("* * W5 * *"));
        }

        [TestMethod]
        [DeploymentItem(@"de\CronExpressionDescriptor.resources.dll", "de")]
        public void TestTimeOfDayWithSeconds()
        {
            Assert.AreEqual("Um 14:02:30", ExpressionDescriptor.GetDescription("30 02 14 * * *", new Options { Use24HourTimeFormat = true }));
        }

        [TestMethod]
        [DeploymentItem(@"de\CronExpressionDescriptor.resources.dll", "de")]
        public void TestSecondInternvals()
        {
            Assert.AreEqual("Seconds 05 through 10 past the minute", ExpressionDescriptor.GetDescription("5-10 * * * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"de\CronExpressionDescriptor.resources.dll", "de")]
        public void TestSecondMinutesHoursIntervals()
        {
            Assert.AreEqual("Seconds 05 through 10 past the minute, minutes 30 through 35 past the hour, between 10:00 AM and 12:59 PM", ExpressionDescriptor.GetDescription("5-10 30-35 10-12 * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"de\CronExpressionDescriptor.resources.dll", "de")]
        public void TestEvery5MinutesAt30Seconds()
        {
            Assert.AreEqual("At 30 seconds past the minute, every 05 minutes", ExpressionDescriptor.GetDescription("30 */5 * * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"de\CronExpressionDescriptor.resources.dll", "de")]
        public void TestMinutesPastTheHourRange()
        {
            Assert.AreEqual("At 30 minutes past the hour, between 10:00 AM and 01:59 PM, only on Wednesday and Friday", ExpressionDescriptor.GetDescription("0 30 10-13 ? * WED,FRI"));
        }

        [TestMethod]
        [DeploymentItem(@"de\CronExpressionDescriptor.resources.dll", "de")]
        public void TestSecondsPastTheMinuteInterval()
        {
            Assert.AreEqual("At 10 seconds past the minute, every 05 minutes", ExpressionDescriptor.GetDescription("10 0/5 * * * ?"));
        }

        [TestMethod]
        [DeploymentItem(@"de\CronExpressionDescriptor.resources.dll", "de")]
        public void TestBetweenWithInterval()
        {
            Assert.AreEqual("Every 03 minutes, minutes 02 through 59 past the hour, at 01:00 AM, 09:00 AM, and 10:00 PM, between day 11 and 26 of the month, January through June", ExpressionDescriptor.GetDescription("2-59/3 1,9,22 11-26 1-6 ?"));
        }

        [TestMethod]
        [DeploymentItem(@"de\CronExpressionDescriptor.resources.dll", "de")]
        public void TestRecurringFirstOfMonth()
        {
            Assert.AreEqual("At 06:00 AM", ExpressionDescriptor.GetDescription("0 0 6 1/1 * ?"));
        }

        [TestMethod]
        [DeploymentItem(@"de\CronExpressionDescriptor.resources.dll", "de")]
        public void TestMinutesPastTheHour()
        {
            Assert.AreEqual("At 05 minutes past the hour", ExpressionDescriptor.GetDescription("0 5 0/1 * * ?"));
        }

        [TestMethod]
        [DeploymentItem(@"de\CronExpressionDescriptor.resources.dll", "de")]
        public void TestOneYearOnlyWithSeconds()
        {
            Assert.AreEqual("Every second, nur im 2013", ExpressionDescriptor.GetDescription("* * * * * * 2013"));
        }

        [TestMethod]
        [DeploymentItem(@"de\CronExpressionDescriptor.resources.dll", "de")]
        public void TestOneYearOnlyWithoutSeconds()
        {
            Assert.AreEqual("Jede Minute, nur im 2013", ExpressionDescriptor.GetDescription("* * * * * 2013"));
        }

        [TestMethod]
        [DeploymentItem(@"de\CronExpressionDescriptor.resources.dll", "de")]
        public void TestTwoYearsOnly()
        {
            Assert.AreEqual("Jede Minute, nur im 2013 und 2014", ExpressionDescriptor.GetDescription("* * * * * 2013,2014"));
        }

        [TestMethod]
        [DeploymentItem(@"de\CronExpressionDescriptor.resources.dll", "de")]
        public void TestYearRange2()
        {
            Assert.AreEqual("At 12:23 PM, January through February, 2013 through 2014", ExpressionDescriptor.GetDescription("23 12 * JAN-FEB * 2013-2014"));
        }

        [TestMethod]
        [DeploymentItem(@"de\CronExpressionDescriptor.resources.dll", "de")]
        public void TestYearRange3()
        {
            Assert.AreEqual("At 12:23 PM, January through March, 2013 through 2015", ExpressionDescriptor.GetDescription("23 12 * JAN-MAR * 2013-2015"));
        }

        [TestMethod]
        [DeploymentItem(@"de\CronExpressionDescriptor.resources.dll", "de")]
        public void TestHourRange()
        {
            Assert.AreEqual("Every 30 minutes, between 08:00 AM and 09:59 AM, on day 5 and 20 of the month", ExpressionDescriptor.GetDescription("0 0/30 8-9 5,20 * ?"));
        }

        [TestMethod]
        [DeploymentItem(@"de\CronExpressionDescriptor.resources.dll", "de")]
        public void TestDayOfWeekModifier()
        {
            Assert.AreEqual("Um 12:23, am zweiten Sonntag im Monat", ExpressionDescriptor.GetDescription("23 12 * * SUN#2", new Options { Use24HourTimeFormat = true }));
        }

        [TestMethod]
        [DeploymentItem(@"de\CronExpressionDescriptor.resources.dll", "de")]
        public void TestDayOfWeekModifierWithSundayStartOne()
        {
            Options options = new Options();
            options.DayOfWeekStartIndexZero = false;
            options.Use24HourTimeFormat = true;

            Assert.AreEqual("Um 12:23, am zweiten Sonntag im Monat", ExpressionDescriptor.GetDescription("23 12 * * 1#2", options));
        }

        [TestMethod]
        [DeploymentItem(@"de\CronExpressionDescriptor.resources.dll", "de")]
        public void TestHourRangeWithEveryPortion()
        {
            Assert.AreEqual("At 25 minutes past the hour, every 13 hours, between 07:00 AM and 07:59 PM", ExpressionDescriptor.GetDescription("0 25 7-19/13 ? * *"));
        }

        [TestMethod]
        [DeploymentItem(@"de\CronExpressionDescriptor.resources.dll", "de")]
        public void TestHourRangeWithTrailingZeroWithEveryPortion()
        {
            Assert.AreEqual("At 25 minutes past the hour, every 13 hours, between 07:00 AM and 08:59 PM", ExpressionDescriptor.GetDescription("0 25 7-20/13 ? * *"));
        }
    }
}