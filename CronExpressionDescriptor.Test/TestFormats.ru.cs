using NUnit.Framework;
using System.Globalization;
using System.Threading;

namespace CronExpressionDescriptor.Test
{
    [TestFixture]
    public class TestFormatsRU
    {
        [TestFixtureSetUp]
        public void SetUp()
        {
            CultureInfo myCultureInfo = new CultureInfo("ru-RU");
            Thread.CurrentThread.CurrentCulture = myCultureInfo;
            Thread.CurrentThread.CurrentUICulture = myCultureInfo;
        }

        [Test]
        public void TestEveryMinute()
        {
            Assert.AreEqual("Каждую минуту", ExpressionDescriptor.GetDescription("* * * * *"));
        }

        [Test]
        public void TestEvery1Minute()
        {
            Assert.AreEqual("Каждую минуту", ExpressionDescriptor.GetDescription("*/1 * * * *"));
            Assert.AreEqual("Каждую минуту", ExpressionDescriptor.GetDescription("0 0/1 * * * ?"));
        }

        [Test]
        public void TestEveryHour()
        {
            Assert.AreEqual("Каждый час", ExpressionDescriptor.GetDescription("0 0 * * * ?"));
            Assert.AreEqual("Каждый час", ExpressionDescriptor.GetDescription("0 0 0/1 * * ?"));
        }

        [Test]
        public void TestTimeOfDayCertainDaysOfWeek()
        {
            Assert.AreEqual("В 23:00, понедельник по пятница", ExpressionDescriptor.GetDescription("0 23 ? * MON-FRI"));
        }

        [Test]
        public void TestEverySecond()
        {
            Assert.AreEqual("Каждую секунду", ExpressionDescriptor.GetDescription("* * * * * *"));
        }

        [Test]
        public void TestEvery45Seconds()
        {
            Assert.AreEqual("Каждые 45 секунд", ExpressionDescriptor.GetDescription("*/45 * * * * *"));
        }

        [Test]
        public void TestEvery5Minutes()
        {
            Assert.AreEqual("Каждые 5 минут", ExpressionDescriptor.GetDescription("*/5 * * * *"));
            Assert.AreEqual("Каждые 10 минут", ExpressionDescriptor.GetDescription("0 0/10 * * * ?"));
        }

        [Test]
        public void TestEvery5MinutesOnTheSecond()
        {
            Assert.AreEqual("Каждые 5 минут", ExpressionDescriptor.GetDescription("0 */5 * * * *"));
        }

        [Test]
        public void TestWeekdaysAtTime()
        {
            Assert.AreEqual("В 11:30, понедельник по пятница", ExpressionDescriptor.GetDescription("30 11 * * 1-5"));
        }

        [Test]
        public void TestDailyAtTime()
        {
            Assert.AreEqual("В 11:30", ExpressionDescriptor.GetDescription("30 11 * * *"));
        }

        [Test]
        public void TestMinuteSpan()
        {
            Assert.AreEqual("Каждую минуту с 11:00 по 11:10", ExpressionDescriptor.GetDescription("0-10 11 * * *"));
        }

        [Test]
        public void TestOneMonthOnly()
        {
            Assert.AreEqual("Каждую минуту, только в Март", ExpressionDescriptor.GetDescription("* * * 3 *"));
        }

        [Test]
        public void TestTwoMonthsOnly()
        {
            Assert.AreEqual("Каждую минуту, только в Март и Июнь", ExpressionDescriptor.GetDescription("* * * 3,6 *"));
        }

        [Test]
        public void TestTwoTimesEachAfternoon()
        {
            Assert.AreEqual("В 14:30 и 16:30", ExpressionDescriptor.GetDescription("30 14,16 * * *"));
        }

        [Test]
        public void TestThreeTimesDaily()
        {
            Assert.AreEqual("В 06:30, 14:30 и 16:30", ExpressionDescriptor.GetDescription("30 6,14,16 * * *"));
        }

        [Test]
        public void TestOnceAWeek()
        {
            Assert.AreEqual("В 09:46, только в понедельник", ExpressionDescriptor.GetDescription("46 9 * * 1"));
        }

        [Test]
        public void TestDayOfMonth()
        {
            Assert.AreEqual("В 12:23, в 15 число месяца", ExpressionDescriptor.GetDescription("23 12 15 * *"));
        }

        [Test]
        public void TestMonthName()
        {
            Assert.AreEqual("В 12:23, только в Январь", ExpressionDescriptor.GetDescription("23 12 * JAN *"));
        }

        [Test]
        public void TestDayOfMonthWithQuestionMark()
        {
            Assert.AreEqual("В 12:23, только в Январь", ExpressionDescriptor.GetDescription("23 12 ? JAN *"));
        }

        [Test]
        public void TestMonthNameRange2()
        {
            Assert.AreEqual("В 12:23, Январь по Февраль", ExpressionDescriptor.GetDescription("23 12 * JAN-FEB *"));
        }

        [Test]
        public void TestMonthNameRange3()
        {
            Assert.AreEqual("В 12:23, Январь по Март", ExpressionDescriptor.GetDescription("23 12 * JAN-MAR *"));
        }

        [Test]
        public void TestDayOfWeekName()
        {
            Assert.AreEqual("В 12:23, только в воскресенье", ExpressionDescriptor.GetDescription("23 12 * * SUN"));
        }

        [Test]
        public void TestDayOfWeekRange()
        {
            Assert.AreEqual("Каждые 5 минут, в 15:00, понедельник по пятница", ExpressionDescriptor.GetDescription("*/5 15 * * MON-FRI"));
        }

        [Test]
        public void TestDayOfWeekOnceInMonth()
        {
            Assert.AreEqual("Каждую минуту, в третий понедельник месяца", ExpressionDescriptor.GetDescription("* * * * MON#3"));
        }

        [Test]
        public void TestLastDayOfTheWeekOfTheMonth()
        {
            Assert.AreEqual("Каждую минуту, в последний четверг месяца", ExpressionDescriptor.GetDescription("* * * * 4L"));
        }

        [Test]
        public void TestLastDayOfTheMonth()
        {
            Assert.AreEqual("Каждые 5 минут, в последний день месяца, только в Январь", ExpressionDescriptor.GetDescription("*/5 * L JAN *"));
        }

        [Test]
        public void TestLastWeekdayOfTheMonth()
        {
            Assert.AreEqual("Каждую минуту, в последний будний день месяца", ExpressionDescriptor.GetDescription("* * LW * *"));
        }

        [Test]
        public void TestLastWeekdayOfTheMonth2()
        {
            Assert.AreEqual("Каждую минуту, в последний будний день месяца", ExpressionDescriptor.GetDescription("* * WL * *"));
        }

        [Test]
        public void TestFirstWeekdayOfTheMonth()
        {
            Assert.AreEqual("Каждую минуту, в первый будний день месяца", ExpressionDescriptor.GetDescription("* * 1W * *"));
        }

        [Test]
        public void TestFirstWeekdayOfTheMonth2()
        {
            Assert.AreEqual("Каждую минуту, в первый будний день месяца", ExpressionDescriptor.GetDescription("* * W1 * *"));
        }

        [Test]
        public void TestParticularWeekdayOfTheMonth()
        {
            Assert.AreEqual("Каждую минуту, в ближайший будний день к 5 месяца", ExpressionDescriptor.GetDescription("* * 5W * *"));
        }

        [Test]
        public void TestParticularWeekdayOfTheMonth2()
        {
            Assert.AreEqual("Каждую минуту, в ближайший будний день к 5 месяца", ExpressionDescriptor.GetDescription("* * W5 * *"));
        }

        [Test]
        public void TestTimeOfDayWithSeconds()
        {
            Assert.AreEqual("В 14:02:30", ExpressionDescriptor.GetDescription("30 02 14 * * *"));
        }

        [Test]
        public void TestSecondInternvals()
        {
            Assert.AreEqual("Секунды с 5 по 10", ExpressionDescriptor.GetDescription("5-10 * * * * *"));
        }

        [Test]
        public void TestSecondMinutesHoursIntervals()
        {
            Assert.AreEqual("Секунды с 5 по 10, минуты с 30 по 35, с 10:00 по 12:59", ExpressionDescriptor.GetDescription("5-10 30-35 10-12 * * *"));
        }

        [Test]
        public void TestEvery5MinutesAt30Seconds()
        {
            Assert.AreEqual("В 30 секунд, каждые 5 минут", ExpressionDescriptor.GetDescription("30 */5 * * * *"));
        }

        [Test]
        public void TestMinutesPastTheHourRange()
        {
            Assert.AreEqual("В 30 минут, с 10:00 по 13:59, только в среда и пятница", ExpressionDescriptor.GetDescription("0 30 10-13 ? * WED,FRI"));
        }

        [Test]
        public void TestSecondsPastTheMinuteInterval()
        {
            Assert.AreEqual("В 10 секунд, каждые 5 минут", ExpressionDescriptor.GetDescription("10 0/5 * * * ?"));
        }

        [Test]
        public void TestBetweenWithInterval()
        {
            Assert.AreEqual("Каждые 3 минут, минуты с 2 по 59, в 01:00, 09:00, и 22:00, с 11 по 26 число месяца, Январь по Июнь", ExpressionDescriptor.GetDescription("2-59/3 1,9,22 11-26 1-6 ?"));
        }

        [Test]
        public void TestRecurringFirstOfMonth()
        {
            Assert.AreEqual("В 06:00", ExpressionDescriptor.GetDescription("0 0 6 1/1 * ?"));
        }

        [Test]
        public void TestMinutesPastTheHour()
        {
            Assert.AreEqual("В 5 минут", ExpressionDescriptor.GetDescription("0 5 0/1 * * ?"));
        }

        [Test]
        public void TestOneYearOnlyWithSeconds()
        {
            Assert.AreEqual("Каждую секунду, только в 2013", ExpressionDescriptor.GetDescription("* * * * * * 2013"));
        }

        [Test]
        public void TestOneYearOnlyWithoutSeconds()
        {
            Assert.AreEqual("Каждую минуту, только в 2013", ExpressionDescriptor.GetDescription("* * * * * 2013"));
        }

        [Test]
        public void TestTwoYearsOnly()
        {
            Assert.AreEqual("Каждую минуту, только в 2013 и 2014", ExpressionDescriptor.GetDescription("* * * * * 2013,2014"));
        }

        [Test]
        public void TestYearRange2()
        {
            Assert.AreEqual("В 12:23, Январь по Февраль, 2013 по 2014", ExpressionDescriptor.GetDescription("23 12 * JAN-FEB * 2013-2014"));
        }

        [Test]
        public void TestYearRange3()
        {
            Assert.AreEqual("В 12:23, Январь по Март, 2013 по 2015", ExpressionDescriptor.GetDescription("23 12 * JAN-MAR * 2013-2015"));
        }

        [Test]
        public void TestHourRange()
        {
            Assert.AreEqual("Каждые 30 минут, с 08:00 по 09:59, в 5 и 20 число месяца", ExpressionDescriptor.GetDescription("0 0/30 8-9 5,20 * ?"));
        }

        [Test]
        public void TestDayOfWeekModifier()
        {
            Assert.AreEqual("В 12:23, в второй воскресенье месяца", ExpressionDescriptor.GetDescription("23 12 * * SUN#2"));
        }

        [Test]
        public void TestDayOfWeekModifierWithSundayStartOne()
        {
            Options options = new Options();
            options.DayOfWeekStartIndexZero = false;

            Assert.AreEqual("В 12:23, в второй воскресенье месяца", ExpressionDescriptor.GetDescription("23 12 * * 1#2", options));
        }

        [Test]
        public void TestHourRangeWithEveryPortion()
        {
            Assert.AreEqual("В 25 минут, каждые 13 часов, с 07:00 по 19:59", ExpressionDescriptor.GetDescription("0 25 7-19/13 ? * *"));
        }

        [Test]
        public void TestHourRangeWithTrailingZeroWithEveryPortion()
        {
            Assert.AreEqual("В 25 минут, каждые 13 часов, с 07:00 по 20:59", ExpressionDescriptor.GetDescription("0 25 7-20/13 ? * *"));
        }

        [Test]
        public void TestSecondsInternalWithStepValue()
        {
            // GitHub Issue #49: https://github.com/bradyholt/cron-expression-descriptor/issues/49
            Assert.AreEqual("Каждые 30 секунд, начало в 5 секунд", ExpressionDescriptor.GetDescription("5/30 * * * * ?"));
        }

        [Test]
        public void TestMinutesInternalWithStepValue()
        {
            Assert.AreEqual("Каждые 30 минут, начало в 5 минут", ExpressionDescriptor.GetDescription("0 5/30 * * * ?"));
        }
        
        [Test]
        public void TestHoursInternalWithStepValue()
        {
            Assert.AreEqual("Каждую секунду, каждые 8 часов, начало в 05:00", ExpressionDescriptor.GetDescription("* * 5/8 * * ?"));
        }
        
        [Test]
        public void TestDayOfMonthInternalWithStepValue()
        {
            Assert.AreEqual("В 07:05, каждые 3 дней, начало в 2 число месяца", ExpressionDescriptor.GetDescription("0 5 7 2/3 * ? *"));
        }
        
        [Test]
        public void TestMonthInternalWithStepValue()
        {
            Assert.AreEqual("В 07:05, каждые 2 месяцев, Март по Декабрь", ExpressionDescriptor.GetDescription("0 5 7 ? 3/2 ? *"));
        }
        
        [Test]
        public void TestDayOfWeekInternalWithStepValue()
        {
            Assert.AreEqual("В 07:05, каждые 3 дней недели, вторник по суббота", ExpressionDescriptor.GetDescription("0 5 7 ? * 2/3 *"));
        }
                
        [Test]
        public void TestYearInternalWithStepValue()
        {
            Assert.AreEqual("В 07:05, каждые 4 лет, 2016 по 9999", ExpressionDescriptor.GetDescription("0 5 7 ? * ? 2016/4"));
        }
    }
}