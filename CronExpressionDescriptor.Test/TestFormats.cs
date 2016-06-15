using NUnit.Framework;
using System.Globalization;
using System.Threading;

namespace CronExpressionDescriptor.Test
{
    [TestFixture]
    public class TestFormats
    {
        [TestFixtureSetUp]
        public void SetUp()
        {
            CultureInfo myCultureInfo = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = myCultureInfo;
            Thread.CurrentThread.CurrentUICulture = myCultureInfo;
        }

        [Test]
        public void TestEveryMinute()
        {
           Assert.AreEqual("Every minute", ExpressionDescriptor.GetDescription("* * * * *"));
        }

        [Test]
        public void TestEvery1Minute()
        {
            Assert.AreEqual("Every minute", ExpressionDescriptor.GetDescription("*/1 * * * *"));
            Assert.AreEqual("Every minute", ExpressionDescriptor.GetDescription("0 0/1 * * * ?"));
        }

        [Test]
        public void TestEveryHour()
        {
            Assert.AreEqual("Every hour", ExpressionDescriptor.GetDescription("0 0 * * * ?"));
            Assert.AreEqual("Every hour", ExpressionDescriptor.GetDescription("0 0 0/1 * * ?"));
        }

        [Test]
        public void TestTimeOfDayCertainDaysOfWeek()
        {
            Assert.AreEqual("At 11:00 PM, Monday through Friday", ExpressionDescriptor.GetDescription("0 23 ? * MON-FRI"));
        }

        [Test]
        public void TestEverySecond()
        {
            Assert.AreEqual("Every second", ExpressionDescriptor.GetDescription("* * * * * *"));
        }

        [Test]
        public void TestEvery45Seconds()
        {
            Assert.AreEqual("Every 45 seconds", ExpressionDescriptor.GetDescription("*/45 * * * * *"));
        }

        [Test]
        public void TestEvery5Minutes()
        {
            Assert.AreEqual("Every 5 minutes", ExpressionDescriptor.GetDescription("*/5 * * * *"));
            Assert.AreEqual("Every 10 minutes", ExpressionDescriptor.GetDescription("0 0/10 * * * ?"));
        }

        [Test]
        public void TestEvery5MinutesOnTheSecond()
        {
            Assert.AreEqual("Every 5 minutes", ExpressionDescriptor.GetDescription("0 */5 * * * *"));
        }

        [Test]
        public void TestWeekdaysAtTime()
        {
            Assert.AreEqual("At 11:30 AM, Monday through Friday", ExpressionDescriptor.GetDescription("30 11 * * 1-5"));
        }

        [Test]
        public void TestDailyAtTime()
        {
            Assert.AreEqual("At 11:30 AM", ExpressionDescriptor.GetDescription("30 11 * * *"));
        }

        [Test]
        public void TestMinuteSpan()
        {
            Assert.AreEqual("Every minute between 11:00 AM and 11:10 AM", ExpressionDescriptor.GetDescription("0-10 11 * * *"));
        }

        [Test]
        public void TestOneMonthOnly()
        {
            Assert.AreEqual("Every minute, only in March", ExpressionDescriptor.GetDescription("* * * 3 *"));
        }

        [Test]
        public void TestTwoMonthsOnly()
        {
            Assert.AreEqual("Every minute, only in March and June", ExpressionDescriptor.GetDescription("* * * 3,6 *"));
        }

        [Test]
        public void TestTwoTimesEachAfternoon()
        {
            Assert.AreEqual("At 02:30 PM and 04:30 PM", ExpressionDescriptor.GetDescription("30 14,16 * * *"));
        }

        [Test]
        public void TestThreeTimesDaily()
        {
            Assert.AreEqual("At 06:30 AM, 02:30 PM and 04:30 PM", ExpressionDescriptor.GetDescription("30 6,14,16 * * *"));
        }

        [Test]
        public void TestOnceAWeek()
        {
            Assert.AreEqual("At 09:46 AM, only on Monday", ExpressionDescriptor.GetDescription("46 9 * * 1"));
        }

        [Test]
        public void TestDayOfMonth()
        {
            Assert.AreEqual("At 12:23 PM, on day 15 of the month", ExpressionDescriptor.GetDescription("23 12 15 * *"));
        }

        [Test]
        public void TestMonthName()
        {
            Assert.AreEqual("At 12:23 PM, only in January", ExpressionDescriptor.GetDescription("23 12 * JAN *"));
        }

        [Test]
        public void TestDayOfMonthWithQuestionMark()
        {
            Assert.AreEqual("At 12:23 PM, only in January", ExpressionDescriptor.GetDescription("23 12 ? JAN *"));
        }

        [Test]
        public void TestMonthNameRange2()
        {
            Assert.AreEqual("At 12:23 PM, January through February", ExpressionDescriptor.GetDescription("23 12 * JAN-FEB *"));
        }

        [Test]
        public void TestMonthNameRange3()
        {
            Assert.AreEqual("At 12:23 PM, January through March", ExpressionDescriptor.GetDescription("23 12 * JAN-MAR *"));
        }

        [Test]
        public void TestDayOfWeekName()
        {
            Assert.AreEqual("At 12:23 PM, only on Sunday", ExpressionDescriptor.GetDescription("23 12 * * SUN"));
        }

        [Test]
        public void TestDayOfWeekRange()
        {
            Assert.AreEqual("Every 5 minutes, at 03:00 PM, Monday through Friday", ExpressionDescriptor.GetDescription("*/5 15 * * MON-FRI"));
        }

        [Test]
        public void TestDayOfWeekOnceInMonth()
        {
            Assert.AreEqual("Every minute, on the third Monday of the month", ExpressionDescriptor.GetDescription("* * * * MON#3"));
        }

        [Test]
        public void TestLastDayOfTheWeekOfTheMonth()
        {
            Assert.AreEqual("Every minute, on the last Thursday of the month", ExpressionDescriptor.GetDescription("* * * * 4L"));
        }

        [Test]
        public void TestLastDayOfTheMonth()
        {
            Assert.AreEqual("Every 5 minutes, on the last day of the month, only in January", ExpressionDescriptor.GetDescription("*/5 * L JAN *"));
        }

        [Test]
        public void TestLastWeekdayOfTheMonth()
        {
            Assert.AreEqual("Every minute, on the last weekday of the month", ExpressionDescriptor.GetDescription("* * LW * *"));
        }

        [Test]
        public void TestLastWeekdayOfTheMonth2()
        {
            Assert.AreEqual("Every minute, on the last weekday of the month", ExpressionDescriptor.GetDescription("* * WL * *"));
        }

        [Test]
        public void TestFirstWeekdayOfTheMonth()
        {
            Assert.AreEqual("Every minute, on the first weekday of the month", ExpressionDescriptor.GetDescription("* * 1W * *"));
        }

        [Test]
        public void TestThirteenthWeekdayOfTheMonth()
        {
            Assert.AreEqual("Every minute, on the weekday nearest day 13 of the month", ExpressionDescriptor.GetDescription("* * 13W * *"));
        }

        [Test]
        public void TestFirstWeekdayOfTheMonth2()
        {
            Assert.AreEqual("Every minute, on the first weekday of the month", ExpressionDescriptor.GetDescription("* * W1 * *"));
        }

        [Test]
        public void TestParticularWeekdayOfTheMonth()
        {
            Assert.AreEqual("Every minute, on the weekday nearest day 5 of the month", ExpressionDescriptor.GetDescription("* * 5W * *"));
        }

        [Test]
        public void TestParticularWeekdayOfTheMonth2()
        {
            Assert.AreEqual("Every minute, on the weekday nearest day 5 of the month", ExpressionDescriptor.GetDescription("* * W5 * *"));
        }

        [Test]
        public void TestTimeOfDayWithSeconds()
        {
            Assert.AreEqual("At 02:02:30 PM", ExpressionDescriptor.GetDescription("30 02 14 * * *"));
        }

        [Test]
        public void TestSecondInternvals()
        {
            Assert.AreEqual("Seconds 5 through 10 past the minute", ExpressionDescriptor.GetDescription("5-10 * * * * *"));
        }

        [Test]
        public void TestSecondMinutesHoursIntervals()
        {
            Assert.AreEqual("Seconds 5 through 10 past the minute, minutes 30 through 35 past the hour, between 10:00 AM and 12:59 PM", ExpressionDescriptor.GetDescription("5-10 30-35 10-12 * * *"));
        }

        [Test]
        public void TestEvery5MinutesAt30Seconds()
        {
            Assert.AreEqual("At 30 seconds past the minute, every 5 minutes", ExpressionDescriptor.GetDescription("30 */5 * * * *"));
        }

        [Test]
        public void TestMinutesPastTheHourRange()
        {
            Assert.AreEqual("At 30 minutes past the hour, between 10:00 AM and 01:59 PM, only on Wednesday and Friday", ExpressionDescriptor.GetDescription("0 30 10-13 ? * WED,FRI"));
        }

        [Test]
        public void TestSecondsPastTheMinuteInterval()
        {
            Assert.AreEqual("At 10 seconds past the minute, every 5 minutes", ExpressionDescriptor.GetDescription("10 0/5 * * * ?"));
        }

        [Test]
        public void TestBetweenWithInterval()
        {
            Assert.AreEqual("Every 3 minutes, minutes 2 through 59 past the hour, at 01:00 AM, 09:00 AM, and 10:00 PM, between day 11 and 26 of the month, January through June", ExpressionDescriptor.GetDescription("2-59/3 1,9,22 11-26 1-6 ?"));
        }

        [Test]
        public void TestRecurringFirstOfMonth()
        {
            Assert.AreEqual("At 06:00 AM", ExpressionDescriptor.GetDescription("0 0 6 1/1 * ?"));
        }

        [Test]
        public void TestMinutesPastTheHour()
        {
            Assert.AreEqual("At 5 minutes past the hour", ExpressionDescriptor.GetDescription("0 5 0/1 * * ?"));
        }

        [Test]
        public void TestOneYearOnlyWithSeconds()
        {
            Assert.AreEqual("Every second, only in 2013", ExpressionDescriptor.GetDescription("* * * * * * 2013"));
        }
        
        [Test]
        public void TestOneYearOnlyWithoutSeconds()
        {
            Assert.AreEqual("Every minute, only in 2013", ExpressionDescriptor.GetDescription("* * * * * 2013"));
        }

        [Test]
        public void TestTwoYearsOnly()
        {
            Assert.AreEqual("Every minute, only in 2013 and 2014", ExpressionDescriptor.GetDescription("* * * * * 2013,2014"));
        }

        [Test]
        public void TestYearRange2()
        {
            Assert.AreEqual("At 12:23 PM, January through February, 2013 through 2014", ExpressionDescriptor.GetDescription("23 12 * JAN-FEB * 2013-2014"));
        }

        [Test]
        public void TestYearRange3()
        {
            Assert.AreEqual("At 12:23 PM, January through March, 2013 through 2015", ExpressionDescriptor.GetDescription("23 12 * JAN-MAR * 2013-2015"));
        }

        [Test]
        public void TestHourRange()
        {
            Assert.AreEqual("Every 30 minutes, between 08:00 AM and 09:59 AM, on day 5 and 20 of the month", ExpressionDescriptor.GetDescription("0 0/30 8-9 5,20 * ?"));
        }

        [Test]
        public void TestDayOfWeekModifier()
        {
            Assert.AreEqual("At 12:23 PM, on the second Sunday of the month", ExpressionDescriptor.GetDescription("23 12 * * SUN#2"));
        }

        [Test]
        public void TestDayOfWeekModifierWithSundayStartOne()
        {
            Options options = new Options();
            options.DayOfWeekStartIndexZero = false;

            Assert.AreEqual("At 12:23 PM, on the second Sunday of the month", ExpressionDescriptor.GetDescription("23 12 * * 1#2", options));
        }

        [Test]
        public void TestHourRangeWithEveryPortion()
        {
            Assert.AreEqual("At 25 minutes past the hour, every 8 hours, between 07:00 AM and 07:59 PM", ExpressionDescriptor.GetDescription("0 25 7-19/8 ? * *"));
        }

        [Test]
        public void TestHourRangeWithTrailingZeroWithEveryPortion()
        {
            Assert.AreEqual("At 25 minutes past the hour, every 13 hours, between 07:00 AM and 08:59 PM", ExpressionDescriptor.GetDescription("0 25 7-20/13 ? * *"));
        }

        [Test]
        public void TestEvery3Day()
        {
            Assert.AreEqual("At 08:00 AM, every 3 days", ExpressionDescriptor.GetDescription("0 0 8 1/3 * ? *"));
        }

        [Test]
        public void TestsEvery3DayOfTheWeek()
        {
            Assert.AreEqual("At 10:15 AM, every 3 days of the week", ExpressionDescriptor.GetDescription("0 15 10 ? * */3"));
        }

        [Test]
        public void TestEvery2DayOfTheWeekInRange()
        {
            // GitHub Issue #58: https://github.com/bradyholt/cron-expression-descriptor/issues/58
            Assert.AreEqual("Every second, every 2 days of the week, Monday through Friday", ExpressionDescriptor.GetDescription("* * * ? * 1-5/2"));
        }

        [Test]
        public void TestEvery2DayOfTheWeekInRangeWithSundayStartOne()
        {
            // GitHub Issue #59: https://github.com/bradyholt/cron-expression-descriptor/issues/59

            var options = new Options { DayOfWeekStartIndexZero = false };

            Assert.AreEqual("Every second, every 2 days of the week, Monday through Friday",
                ExpressionDescriptor.GetDescription("* * * ? * 2-6/2", options));
        }

        [Test]
        public void TestEvery3Month()
        {
            Assert.AreEqual("At 07:05 AM, on day 2 of the month, every 3 months", ExpressionDescriptor.GetDescription("0 5 7 2 1/3 ? *"));
        }

        [Test]
        public void TestEvery2Years()
        {
            Assert.AreEqual("At 06:15 AM, on day 1 of the month, only in January, every 2 years", ExpressionDescriptor.GetDescription("0 15 6 1 1 ? 1/2"));
        }

        [Test]
        public void TestMutiPartRangeSeconds()
        {
            Assert.AreEqual("At 2 and 4 through 5 minutes past the hour, at 01:00 AM", ExpressionDescriptor.GetDescription("2,4-5 1 * * *"));
        }

        [Test]
        public void TestMutiPartRangeSeconds2()
        {
            Assert.AreEqual("At 2 and 26 through 28 minutes past the hour, at 06:00 PM", ExpressionDescriptor.GetDescription("2,26-28 18 * * *"));
        }

        [Test]
        public void TrailingSpaceDoesNotCauseAWrongDescription()
        {
            // GitHub Issue #51: https://github.com/bradyholt/cron-expression-descriptor/issues/51
            Assert.AreEqual("At 07:00 AM", ExpressionDescriptor.GetDescription("0 7 * * * "));
        }

        [Test]
        public void TestMultiPartDayOfTheWeek()
        {
            // GitHub Issue #44: https://github.com/bradyholt/cron-expression-descriptor/issues/44
            Assert.AreEqual("At 10:00 AM, only on Monday through Thursday and Sunday", ExpressionDescriptor.GetDescription("0 00 10 ? * MON-THU,SUN *"));
        }

        [Test]
        public void TestDayOfWeekWithDayOfMonth()
        {
            // GitHub Issue #46: https://github.com/bradyholt/cron-expression-descriptor/issues/46
            Assert.AreEqual("At 00:00 AM, on day 1, 2, and 3 of the month, only on Wednesday and Friday", ExpressionDescriptor.GetDescription("0 0 0 1,2,3 * WED,FRI"));
        }

        [Test]
        public void TestSecondsInternalWithStepValue()
        {
            // GitHub Issue #49: https://github.com/bradyholt/cron-expression-descriptor/issues/49
            Assert.AreEqual("Every 30 seconds, starting at 5 seconds past the minute", ExpressionDescriptor.GetDescription("5/30 * * * * ?"));
        }

        [Test]
        public void TestMinutesInternalWithStepValue()
        {
            Assert.AreEqual("Every 30 minutes, starting at 5 minutes past the hour", ExpressionDescriptor.GetDescription("0 5/30 * * * ?"));
        }
        
        [Test]
        public void TestHoursInternalWithStepValue()
        {
            Assert.AreEqual("Every second, every 8 hours, starting at 05:00 AM", ExpressionDescriptor.GetDescription("* * 5/8 * * ?"));
        }
        
        [Test]
        public void TestDayOfMonthInternalWithStepValue()
        {
            Assert.AreEqual("At 07:05 AM, every 3 days, starting on day 2 of the month", ExpressionDescriptor.GetDescription("0 5 7 2/3 * ? *"));
        }
        
        [Test]
        public void TestMonthInternalWithStepValue()
        {
            Assert.AreEqual("At 07:05 AM, every 2 months, March through December", ExpressionDescriptor.GetDescription("0 5 7 ? 3/2 ? *"));
        }
        
        [Test]
        public void TestDayOfWeekInternalWithStepValue()
        {
            Assert.AreEqual("At 07:05 AM, every 3 days of the week, Tuesday through Saturday", ExpressionDescriptor.GetDescription("0 5 7 ? * 2/3 *"));
        }
                
        [Test]
        public void TestYearInternalWithStepValue()
        {
            Assert.AreEqual("At 07:05 AM, every 4 years, 2016 through 9999", ExpressionDescriptor.GetDescription("0 5 7 ? * ? 2016/4"));
        } 
    }
}