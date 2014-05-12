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
    public class TestFormatsCN
    {
        [TestInitialize]
        public void SetUp()
        {
            CultureInfo myCultureInfo = new CultureInfo("zh-CHS");
            Thread.CurrentThread.CurrentCulture = myCultureInfo;
            Thread.CurrentThread.CurrentUICulture = myCultureInfo;
        }
        [TestMethod]
        public void TestEveryMinute()
        {
            Assert.AreEqual("每分钟", ExpressionDescriptor.GetDescription("* * * * *"));
        }

        [TestMethod]
        public void TestEvery1Minute()
        {
            Assert.AreEqual("每分钟", ExpressionDescriptor.GetDescription("*/1 * * * *"));
            Assert.AreEqual("每分钟", ExpressionDescriptor.GetDescription("0 0/1 * * * ?"));
        }

        [TestMethod]
        public void TestEveryHour()
        {
            Assert.AreEqual("每小时", ExpressionDescriptor.GetDescription("0 0 * * * ?"));
            Assert.AreEqual("每小时", ExpressionDescriptor.GetDescription("0 0 0/1 * * ?"));
        }

        [TestMethod]
        public void TestTimeOfDayCertainDaysOfWeek()
        {
            Assert.AreEqual("在 11:00 PM, 星期一 到 星期五", ExpressionDescriptor.GetDescription("0 23 ? * MON-FRI"));
        }

        [TestMethod]
        public void TestEverySecond()
        {
            Assert.AreEqual("每秒", ExpressionDescriptor.GetDescription("* * * * * *"));
        }

        [TestMethod]
        public void TestEvery45Seconds()
        {
            Assert.AreEqual("每 45 秒", ExpressionDescriptor.GetDescription("*/45 * * * * *"));
        }

        [TestMethod]
        public void TestEvery5Minutes()
        {
            Assert.AreEqual("每 05 分钟", ExpressionDescriptor.GetDescription("*/5 * * * *"));
            Assert.AreEqual("每 10 分钟", ExpressionDescriptor.GetDescription("0 0/10 * * * ?"));
        }

        [TestMethod]
        public void TestEvery5MinutesOnTheSecond()
        {
            Assert.AreEqual("每 05 分钟", ExpressionDescriptor.GetDescription("0 */5 * * * *"));
        }

        [TestMethod]
        public void TestWeekdaysAtTime()
        {
            Assert.AreEqual("在 11:30 AM, 星期一 到 星期五", ExpressionDescriptor.GetDescription("30 11 * * 1-5"));
        }

        [TestMethod]
        public void TestDailyAtTime()
        {
            Assert.AreEqual("在 11:30 AM", ExpressionDescriptor.GetDescription("30 11 * * *"));
        }

        [TestMethod]
        public void TestMinuteSpan()
        {
            Assert.AreEqual("在 11:00 AM 和 11:10 AM 之间的每分钟", ExpressionDescriptor.GetDescription("0-10 11 * * *"));
        }

        [TestMethod]
        public void TestOneMonthOnly()
        {
            Assert.AreEqual("每分钟, 仅在 三月", ExpressionDescriptor.GetDescription("* * * 3 *"));
        }

        [TestMethod]
        public void TestTwoMonthsOnly()
        {
            Assert.AreEqual("每分钟, 仅在 三月 和 六月", ExpressionDescriptor.GetDescription("* * * 3,6 *"));
        }

        [TestMethod]
        public void TestTwoTimesEachAfternoon()
        {
            Assert.AreEqual("在 02:30 PM 和 04:30 PM", ExpressionDescriptor.GetDescription("30 14,16 * * *"));
        }

        [TestMethod]
        public void TestThreeTimesDaily()
        {
            Assert.AreEqual("在 06:30 AM, 02:30 PM 和 04:30 PM", ExpressionDescriptor.GetDescription("30 6,14,16 * * *"));
        }

        [TestMethod]
        public void TestOnceAWeek()
        {
            Assert.AreEqual("在 09:46 AM, 仅在 星期一", ExpressionDescriptor.GetDescription("46 9 * * 1"));
        }

        [TestMethod]
        public void TestDayOfMonth()
        {
            Assert.AreEqual("在 12:23 PM, 每月的 15 号", ExpressionDescriptor.GetDescription("23 12 15 * *"));
        }

        [TestMethod]
        public void TestMonthName()
        {
            Assert.AreEqual("在 12:23 PM, 仅在 一月", ExpressionDescriptor.GetDescription("23 12 * JAN *"));
        }

        [TestMethod]
        public void TestDayOfMonthWithQuestionMark()
        {
            Assert.AreEqual("在 12:23 PM, 仅在 一月", ExpressionDescriptor.GetDescription("23 12 ? JAN *"));
        }

        [TestMethod]
        public void TestMonthNameRange2()
        {
            Assert.AreEqual("在 12:23 PM, 一月 到 二月", ExpressionDescriptor.GetDescription("23 12 * JAN-FEB *"));
        }

        [TestMethod]
        public void TestMonthNameRange3()
        {
            Assert.AreEqual("在 12:23 PM, 一月 到 三月", ExpressionDescriptor.GetDescription("23 12 * JAN-MAR *"));
        }

        [TestMethod]
        public void TestDayOfWeekName()
        {
            Assert.AreEqual("在 12:23 PM, 仅在 星期日", ExpressionDescriptor.GetDescription("23 12 * * SUN"));
        }

        [TestMethod]
        public void TestDayOfWeekRange()
        {
            Assert.AreEqual("每 05 分钟, 在 03:00 PM, 星期一 到 星期五", ExpressionDescriptor.GetDescription("*/5 15 * * MON-FRI"));
        }

        [TestMethod]
        public void TestDayOfWeekOnceInMonth()
        {
            Assert.AreEqual("每分钟, 在 第三个星期一 每月", ExpressionDescriptor.GetDescription("* * * * MON#3"));
        }

        [TestMethod]
        public void TestLastDayOfTheWeekOfTheMonth()
        {
            Assert.AreEqual("每分钟, 每月的最后一个 星期四 ", ExpressionDescriptor.GetDescription("* * * * 4L"));
        }

        [TestMethod]
        public void TestLastDayOfTheMonth()
        {
            Assert.AreEqual("每 05 分钟, 每月的最后一天, 仅在 一月", ExpressionDescriptor.GetDescription("*/5 * L JAN *"));
        }

        [TestMethod]
        public void TestLastWeekdayOfTheMonth()
        {
            Assert.AreEqual("每分钟, 每月的最后一个平日", ExpressionDescriptor.GetDescription("* * LW * *"));
        }

        [TestMethod]
        public void TestLastWeekdayOfTheMonth2()
        {
            Assert.AreEqual("每分钟, 每月的最后一个平日", ExpressionDescriptor.GetDescription("* * WL * *"));
        }

        [TestMethod]
        public void TestFirstWeekdayOfTheMonth()
        {
            Assert.AreEqual("每分钟, 每月的 第一个平日 ", ExpressionDescriptor.GetDescription("* * 1W * *"));
        }

        [TestMethod]
        public void TestFirstWeekdayOfTheMonth2()
        {
            Assert.AreEqual("每分钟, 每月的 第一个平日 ", ExpressionDescriptor.GetDescription("* * W1 * *"));
        }

        [TestMethod]
        public void TestParticularWeekdayOfTheMonth()
        {
            Assert.AreEqual("每分钟, 每月的 最接近 5 号的平日 ", ExpressionDescriptor.GetDescription("* * 5W * *"));
        }

        [TestMethod]
        public void TestParticularWeekdayOfTheMonth2()
        {
            Assert.AreEqual("每分钟, 每月的 最接近 5 号的平日 ", ExpressionDescriptor.GetDescription("* * W5 * *"));
        }

        [TestMethod]
        public void TestTimeOfDayWithSeconds()
        {
            Assert.AreEqual("在 02:02:30 PM", ExpressionDescriptor.GetDescription("30 02 14 * * *"));
        }

        [TestMethod]
        public void TestSecondInternvals()
        {
            Assert.AreEqual("在每分钟的 05 到 10 秒", ExpressionDescriptor.GetDescription("5-10 * * * * *"));
        }

        [TestMethod]
        public void TestSecondMinutesHoursIntervals()
        {
            Assert.AreEqual("在每分钟的 05 到 10 秒, 在每小时的 30 到 35 分钟, 在 10:00 AM 和 01:00 PM 之间", ExpressionDescriptor.GetDescription("5-10 30-35 10-12 * * *"));
        }

        [TestMethod]
        public void TestEvery5MinutesAt30Seconds()
        {
            Assert.AreEqual("在每分钟的 30 秒, 每 05 分钟", ExpressionDescriptor.GetDescription("30 */5 * * * *"));
        }

        [TestMethod]
        public void TestMinutesPastTheHourRange()
        {
            Assert.AreEqual("在每小时的 30 分, 在 10:00 AM 和 02:00 PM 之间, 仅在 星期三 和 星期五", ExpressionDescriptor.GetDescription("0 30 10-13 ? * WED,FRI"));
        }

        [TestMethod]
        public void TestSecondsPastTheMinuteInterval()
        {
            Assert.AreEqual("在每分钟的 10 秒, 每 05 分钟", ExpressionDescriptor.GetDescription("10 0/5 * * * ?"));
        }

        [TestMethod]
        public void TestBetweenWithInterval()
        {
            Assert.AreEqual("每 03 分钟, 在每小时的 02 到 59 分钟, 在 01:00 AM, 09:00 AM, 和 10:00 PM, 在每月的 11 和 26 号之间, 一月 到 六月", ExpressionDescriptor.GetDescription("2-59/3 1,9,22 11-26 1-6 ?"));
        }

        [TestMethod]
        public void TestRecurringFirstOfMonth()
        {
            Assert.AreEqual("在 06:00 AM", ExpressionDescriptor.GetDescription("0 0 6 1/1 * ?"));
        }

        [TestMethod]
        public void TestMinutesPastTheHour()
        {
            Assert.AreEqual("在每小时的 05 分", ExpressionDescriptor.GetDescription("0 5 0/1 * * ?"));
        }

        [TestMethod]
        public void TestOneYearOnlyWithSeconds()
        {
            Assert.AreEqual("每秒, 仅在 2013", ExpressionDescriptor.GetDescription("* * * * * * 2013"));
        }
        
        [TestMethod]
        public void TestOneYearOnlyWithoutSeconds()
        {
            Assert.AreEqual("每分钟, 仅在 2013", ExpressionDescriptor.GetDescription("* * * * * 2013"));
        }

        [TestMethod]
        public void TestTwoYearsOnly()
        {
            Assert.AreEqual("每分钟, 仅在 2013 和 2014", ExpressionDescriptor.GetDescription("* * * * * 2013,2014"));
        }

        [TestMethod]
        public void TestYearRange2()
        {
            Assert.AreEqual("在 12:23 PM, 一月 到 二月, 2013 到 2014", ExpressionDescriptor.GetDescription("23 12 * JAN-FEB * 2013-2014"));
        }

        [TestMethod]
        public void TestYearRange3()
        {
            Assert.AreEqual("在 12:23 PM, 一月 到 三月, 2013 到 2015", ExpressionDescriptor.GetDescription("23 12 * JAN-MAR * 2013-2015"));
        }

        [TestMethod]
        public void TestHourRange()
        {
            Assert.AreEqual("每 30 分钟, 在 08:00 AM 和 10:00 AM 之间, 每月的 5 和 20 号", ExpressionDescriptor.GetDescription("0 0/30 8-9 5,20 * ?"));
        }

        [TestMethod]
        public void TestDayOfWeekModifier()
        {
            Assert.AreEqual("在 12:23 PM, 在 第二个星期日 每月", ExpressionDescriptor.GetDescription("23 12 * * SUN#2"));
        }

        [TestMethod]
        public void TestDayOfWeekModifierWithSundayStartOne()
        {
            Options options = new Options();
            options.DayOfWeekStartIndexZero = false;

            Assert.AreEqual("在 12:23 PM, 在 第二个星期日 每月", ExpressionDescriptor.GetDescription("23 12 * * 1#2", options));
        }

        [TestMethod]
        public void TestHourRangeWithEveryPortion()
        {
            Assert.AreEqual("在每小时的 25 分, 每 13 小时, 在 07:00 AM 和 07:00 PM 之间", ExpressionDescriptor.GetDescription("0 25 7-19/13 ? * *"));
        }

        [TestMethod]
        public void TestHourRangeWithTrailingZeroWithEveryPortion()
        {
            Assert.AreEqual("在每小时的 25 分, 每 13 小时, 在 07:00 AM 和 08:00 PM 之间", ExpressionDescriptor.GetDescription("0 25 7-20/13 ? * *"));
        }
    }
}