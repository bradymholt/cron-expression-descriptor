using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CronExpressionDescriptor;
using System.Globalization;
using System.Threading;

namespace CronExpressionDescriptor.Test
{
    [TestClass]
    public class TestFormats
    {
        [TestInitialize]
        public void SetUp()
        {
            CultureInfo myCultureInfo = new CultureInfo("en");
            Thread.CurrentThread.CurrentCulture = myCultureInfo;
            Thread.CurrentThread.CurrentUICulture = myCultureInfo;
        }

        [TestMethod]
        public void TestEveryMinute()
        {
           Assert.AreEqual("Every minute", ExpressionDescriptor.GetDescription("* * * * *"));
        }

        [TestMethod]
        public void TestEvery1Minute()
        {
            Assert.AreEqual("Every minute", ExpressionDescriptor.GetDescription("*/1 * * * *"));
            Assert.AreEqual("Every minute", ExpressionDescriptor.GetDescription("0 0/1 * * * ?"));
        }

        [TestMethod]
        public void TestEveryHour()
        {
            Assert.AreEqual("Every hour", ExpressionDescriptor.GetDescription("0 0 * * * ?"));
            Assert.AreEqual("Every hour", ExpressionDescriptor.GetDescription("0 0 0/1 * * ?"));
        }

        [TestMethod]
        public void TestTimeOfDayCertainDaysOfWeek()
        {
            Assert.AreEqual("At 11:00 PM, Monday through Friday", ExpressionDescriptor.GetDescription("0 23 ? * MON-FRI"));
        }

        [TestMethod]
        public void TestEverySecond()
        {
            Assert.AreEqual("Every second", ExpressionDescriptor.GetDescription("* * * * * *"));
        }

        [TestMethod]
        public void TestEvery45Seconds()
        {
            Assert.AreEqual("Every 45 seconds", ExpressionDescriptor.GetDescription("*/45 * * * * *"));
        }

        [TestMethod]
        public void TestEvery5Minutes()
        {
            Assert.AreEqual("Every 05 minutes", ExpressionDescriptor.GetDescription("*/5 * * * *"));
            Assert.AreEqual("Every 10 minutes", ExpressionDescriptor.GetDescription("0 0/10 * * * ?"));
        }

        [TestMethod]
        public void TestEvery5MinutesOnTheSecond()
        {
            Assert.AreEqual("Every 05 minutes", ExpressionDescriptor.GetDescription("0 */5 * * * *"));
        }

        [TestMethod]
        public void TestWeekdaysAtTime()
        {
            Assert.AreEqual("At 11:30 AM, Monday through Friday", ExpressionDescriptor.GetDescription("30 11 * * 1-5"));
        }

        [TestMethod]
        public void TestDailyAtTime()
        {
            Assert.AreEqual("At 11:30 AM", ExpressionDescriptor.GetDescription("30 11 * * *"));
        }

        [TestMethod]
        public void TestMinuteSpan()
        {
            Assert.AreEqual("Every minute between 11:00 AM and 11:10 AM", ExpressionDescriptor.GetDescription("0-10 11 * * *"));
        }

        [TestMethod]
        public void TestOneMonthOnly()
        {
            Assert.AreEqual("Every minute, only in March", ExpressionDescriptor.GetDescription("* * * 3 *"));
        }

        [TestMethod]
        public void TestTwoMonthsOnly()
        {
            Assert.AreEqual("Every minute, only in March and June", ExpressionDescriptor.GetDescription("* * * 3,6 *"));
        }

        [TestMethod]
        public void TestTwoTimesEachAfternoon()
        {
            Assert.AreEqual("At 02:30 PM and 04:30 PM", ExpressionDescriptor.GetDescription("30 14,16 * * *"));
        }

        [TestMethod]
        public void TestThreeTimesDaily()
        {
            Assert.AreEqual("At 06:30 AM, 02:30 PM and 04:30 PM", ExpressionDescriptor.GetDescription("30 6,14,16 * * *"));
        }

        [TestMethod]
        public void TestOnceAWeek()
        {
            Assert.AreEqual("At 09:46 AM, only on Monday", ExpressionDescriptor.GetDescription("46 9 * * 1"));
        }

        [TestMethod]
        public void TestDayOfMonth()
        {
            Assert.AreEqual("At 12:23 PM, on day 15 of the month", ExpressionDescriptor.GetDescription("23 12 15 * *"));
        }

        [TestMethod]
        public void TestMonthName()
        {
            Assert.AreEqual("At 12:23 PM, only in January", ExpressionDescriptor.GetDescription("23 12 * JAN *"));
        }

        [TestMethod]
        public void TestDayOfMonthWithQuestionMark()
        {
            Assert.AreEqual("At 12:23 PM, only in January", ExpressionDescriptor.GetDescription("23 12 ? JAN *"));
        }

        [TestMethod]
        public void TestMonthNameRange2()
        {
            Assert.AreEqual("At 12:23 PM, January through February", ExpressionDescriptor.GetDescription("23 12 * JAN-FEB *"));
        }

        [TestMethod]
        public void TestMonthNameRange3()
        {
            Assert.AreEqual("At 12:23 PM, January through March", ExpressionDescriptor.GetDescription("23 12 * JAN-MAR *"));
        }

        [TestMethod]
        public void TestDayOfWeekName()
        {
            Assert.AreEqual("At 12:23 PM, only on Sunday", ExpressionDescriptor.GetDescription("23 12 * * SUN"));
        }

        [TestMethod]
        public void TestDayOfWeekRange()
        {
            Assert.AreEqual("Every 05 minutes, at 03:00 PM, Monday through Friday", ExpressionDescriptor.GetDescription("*/5 15 * * MON-FRI"));
        }

        [TestMethod]
        public void TestDayOfWeekOnceInMonth()
        {
            Assert.AreEqual("Every minute, on the third Monday of the month", ExpressionDescriptor.GetDescription("* * * * MON#3"));
        }

        [TestMethod]
        public void TestLastDayOfTheWeekOfTheMonth()
        {
            Assert.AreEqual("Every minute, on the last Thursday of the month", ExpressionDescriptor.GetDescription("* * * * 4L"));
        }

        [TestMethod]
        public void TestLastDayOfTheMonth()
        {
            Assert.AreEqual("Every 05 minutes, on the last day of the month, only in January", ExpressionDescriptor.GetDescription("*/5 * L JAN *"));
        }

        [TestMethod]
        public void TestLastWeekdayOfTheMonth()
        {
            Assert.AreEqual("Every minute, on the last weekday of the month", ExpressionDescriptor.GetDescription("* * LW * *"));
        }

        [TestMethod]
        public void TestLastWeekdayOfTheMonth2()
        {
            Assert.AreEqual("Every minute, on the last weekday of the month", ExpressionDescriptor.GetDescription("* * WL * *"));
        }

        [TestMethod]
        public void TestFirstWeekdayOfTheMonth()
        {
            Assert.AreEqual("Every minute, on the first weekday of the month", ExpressionDescriptor.GetDescription("* * 1W * *"));
        }

        [TestMethod]
        public void TestFirstWeekdayOfTheMonth2()
        {
            Assert.AreEqual("Every minute, on the first weekday of the month", ExpressionDescriptor.GetDescription("* * W1 * *"));
        }

        [TestMethod]
        public void TestParticularWeekdayOfTheMonth()
        {
            Assert.AreEqual("Every minute, on the weekday nearest day 5 of the month", ExpressionDescriptor.GetDescription("* * 5W * *"));
        }

        [TestMethod]
        public void TestParticularWeekdayOfTheMonth2()
        {
            Assert.AreEqual("Every minute, on the weekday nearest day 5 of the month", ExpressionDescriptor.GetDescription("* * W5 * *"));
        }

        [TestMethod]
        public void TestTimeOfDayWithSeconds()
        {
            Assert.AreEqual("At 02:02:30 PM", ExpressionDescriptor.GetDescription("30 02 14 * * *"));
        }

        [TestMethod]
        public void TestSecondInternvals()
        {
            Assert.AreEqual("Seconds 05 through 10 past the minute", ExpressionDescriptor.GetDescription("5-10 * * * * *"));
        }

        [TestMethod]
        public void TestSecondMinutesHoursIntervals()
        {
            Assert.AreEqual("Seconds 05 through 10 past the minute, minutes 30 through 35 past the hour, between 10:00 AM and 01:00 PM", ExpressionDescriptor.GetDescription("5-10 30-35 10-12 * * *"));
        }

        [TestMethod]
        public void TestEvery5MinutesAt30Seconds()
        {
            Assert.AreEqual("At 30 seconds past the minute, every 05 minutes", ExpressionDescriptor.GetDescription("30 */5 * * * *"));
        }

        [TestMethod]
        public void TestMinutesPastTheHourRange()
        {
            Assert.AreEqual("At 30 minutes past the hour, between 10:00 AM and 02:00 PM, only on Wednesday and Friday", ExpressionDescriptor.GetDescription("0 30 10-13 ? * WED,FRI"));
        }

        [TestMethod]
        public void TestSecondsPastTheMinuteInterval()
        {
            Assert.AreEqual("At 10 seconds past the minute, every 05 minutes", ExpressionDescriptor.GetDescription("10 0/5 * * * ?"));
        }

        [TestMethod]
        public void TestBetweenWithInterval()
        {
            Assert.AreEqual("Every 03 minutes, minutes 02 through 59 past the hour, at 01:00 AM, 09:00 AM, and 10:00 PM, between day 11 and 26 of the month, January through June", ExpressionDescriptor.GetDescription("2-59/3 1,9,22 11-26 1-6 ?"));
        }

        [TestMethod]
        public void TestRecurringFirstOfMonth()
        {
            Assert.AreEqual("At 06:00 AM", ExpressionDescriptor.GetDescription("0 0 6 1/1 * ?"));
        }

        [TestMethod]
        public void TestMinutesPastTheHour()
        {
            Assert.AreEqual("At 05 minutes past the hour", ExpressionDescriptor.GetDescription("0 5 0/1 * * ?"));
        }

        [TestMethod]
        public void TestOneYearOnlyWithSeconds()
        {
            Assert.AreEqual("Every second, only in 2013", ExpressionDescriptor.GetDescription("* * * * * * 2013"));
        }
        
        [TestMethod]
        public void TestOneYearOnlyWithoutSeconds()
        {
            Assert.AreEqual("Every minute, only in 2013", ExpressionDescriptor.GetDescription("* * * * * 2013"));
        }

        [TestMethod]
        public void TestTwoYearsOnly()
        {
            Assert.AreEqual("Every minute, only in 2013 and 2014", ExpressionDescriptor.GetDescription("* * * * * 2013,2014"));
        }

        [TestMethod]
        public void TestYearRange2()
        {
            Assert.AreEqual("At 12:23 PM, January through February, 2013 through 2014", ExpressionDescriptor.GetDescription("23 12 * JAN-FEB * 2013-2014"));
        }

        [TestMethod]
        public void TestYearRange3()
        {
            Assert.AreEqual("At 12:23 PM, January through March, 2013 through 2015", ExpressionDescriptor.GetDescription("23 12 * JAN-MAR * 2013-2015"));
        }

        [TestMethod]
        public void TestHourRange()
        {
            Assert.AreEqual("Every 30 minutes, between 08:00 AM and 10:00 AM, on day 5 and 20 of the month", ExpressionDescriptor.GetDescription("0 0/30 8-9 5,20 * ?"));
        }

        [TestMethod]
        public void TestDayOfWeekModifier()
        {
            Assert.AreEqual("At 12:23 PM, on the second Sunday of the month", ExpressionDescriptor.GetDescription("23 12 * * SUN#2"));
        }

        [TestMethod]
        public void TestDayOfWeekModifierWithSundayStartOne()
        {
            Options options = new Options();
            options.DayOfWeekStartIndexZero = false;

            Assert.AreEqual("At 12:23 PM, on the second Sunday of the month", ExpressionDescriptor.GetDescription("23 12 * * 1#2", options));
        }

        [TestMethod]
        public void TestHourRangeWithEveryPortion()
        {
            Assert.AreEqual("At 25 minutes past the hour, every 13 hours, between 07:00 AM and 07:00 PM", ExpressionDescriptor.GetDescription("0 25 7-19/13 ? * *"));
        }

        [TestMethod]
        public void TestHourRangeWithTrailingZeroWithEveryPortion()
        {
            Assert.AreEqual("At 25 minutes past the hour, every 13 hours, between 07:00 AM and 08:00 PM", ExpressionDescriptor.GetDescription("0 25 7-20/13 ? * *"));
        }
    }
}