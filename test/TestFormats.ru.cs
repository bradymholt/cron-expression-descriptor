using Xunit;
using Assert = CronExpressionDescriptor.Test.Support.AssertExtensions;

namespace CronExpressionDescriptor.Test
{
    /// <summary>
    /// Tests for Russian translation
    /// </summary>
    public class TestFormatsRU : Support.BaseTestFormats
    {
        protected override string GetLocale()
        {
            return "ru-RU";
        }

        [Fact]
        public void TestEveryMinute()
        {
            Assert.EqualsCaseInsensitive("Каждую минуту", GetDescription("* * * * *"));
        }

        [Fact]
        public void TestEvery1Minute()
        {
            Assert.EqualsCaseInsensitive("Каждую минуту", GetDescription("*/1 * * * *"));
            Assert.EqualsCaseInsensitive("Каждую минуту", GetDescription("0 0/1 * * * ?"));
        }

        [Fact]
        public void TestEveryHour()
        {
            Assert.EqualsCaseInsensitive("Каждый час", GetDescription("0 0 * * * ?"));
            Assert.EqualsCaseInsensitive("Каждый час", GetDescription("0 0 0/1 * * ?"));
        }

        [Fact]
        public void TestTimeOfDayCertainDaysOfWeek()
        {
            Assert.EqualsCaseInsensitive("В 23:00, понедельник по пятница", GetDescription("0 23 ? * MON-FRI"));
        }

        [Fact]
        public void TestEverySecond()
        {
            Assert.EqualsCaseInsensitive("Каждую секунду", GetDescription("* * * * * *"));
        }

        [Fact]
        public void TestEvery45Seconds()
        {
            Assert.EqualsCaseInsensitive("Каждые 45 секунд", GetDescription("*/45 * * * * *"));
        }

        [Fact]
        public void TestEvery5Minutes()
        {
            Assert.EqualsCaseInsensitive("Каждые 5 минут", GetDescription("*/5 * * * *"));
            Assert.EqualsCaseInsensitive("Каждые 10 минут", GetDescription("0 0/10 * * * ?"));
        }

        [Fact]
        public void TestEvery5MinutesOnTheSecond()
        {
            Assert.EqualsCaseInsensitive("Каждые 5 минут", GetDescription("0 */5 * * * *"));
        }

        [Fact]
        public void TestWeekdaysAtTime()
        {
            Assert.EqualsCaseInsensitive("В 11:30, понедельник по пятница", GetDescription("30 11 * * 1-5"));
        }

        [Fact]
        public void TestDailyAtTime()
        {
            Assert.EqualsCaseInsensitive("В 11:30", GetDescription("30 11 * * *"));
        }

        [Fact]
        public void TestMinuteSpan()
        {
            Assert.EqualsCaseInsensitive("Каждую минуту с 11:00 по 11:10", GetDescription("0-10 11 * * *"));
        }

        [Fact]
        public void TestOneMonthOnly()
        {
            Assert.EqualsCaseInsensitive("Каждую минуту, только в март", GetDescription("* * * 3 *"));
        }

        [Fact]
        public void TestTwoMonthsOnly()
        {
            Assert.EqualsCaseInsensitive("Каждую минуту, только в март и июнь", GetDescription("* * * 3,6 *"));
        }

        [Fact]
        public void TestTwoTimesEachAfternoon()
        {
            Assert.EqualsCaseInsensitive("В 14:30 и 16:30", GetDescription("30 14,16 * * *"));
        }

        [Fact]
        public void TestThreeTimesDaily()
        {
            Assert.EqualsCaseInsensitive("В 06:30, 14:30 и 16:30", GetDescription("30 6,14,16 * * *"));
        }

        [Fact]
        public void TestOnceAWeek()
        {
            Assert.EqualsCaseInsensitive("В 09:46, только в понедельник", GetDescription("46 9 * * 1"));
        }

        [Fact]
        public void TestDayOfMonth()
        {
            Assert.EqualsCaseInsensitive("В 12:23, в 15 число месяца", GetDescription("23 12 15 * *"));
        }

        [Fact]
        public void TestMonthName()
        {
            Assert.EqualsCaseInsensitive("В 12:23, только в январь", GetDescription("23 12 * JAN *"));
        }

        [Fact]
        public void TestDayOfMonthWithQuestionMark()
        {
            Assert.EqualsCaseInsensitive("В 12:23, только в январь", GetDescription("23 12 ? JAN *"));
        }

        [Fact]
        public void TestMonthNameRange2()
        {
            Assert.EqualsCaseInsensitive("В 12:23, январь по февраль", GetDescription("23 12 * JAN-FEB *"));
        }

        [Fact]
        public void TestMonthNameRange3()
        {
            Assert.EqualsCaseInsensitive("В 12:23, январь по март", GetDescription("23 12 * JAN-MAR *"));
        }

        [Fact]
        public void TestDayOfWeekName()
        {
            Assert.EqualsCaseInsensitive("В 12:23, только в воскресенье", GetDescription("23 12 * * SUN"));
        }

        [Fact]
        public void TestDayOfWeekRange()
        {
            Assert.EqualsCaseInsensitive("Каждые 5 минут, с 15:00 по 15:59, понедельник по пятница", GetDescription("*/5 15 * * MON-FRI"));
        }

        [Fact]
        public void TestDayOfWeekOnceInMonth()
        {
            Assert.EqualsCaseInsensitive("Каждую минуту, в третий понедельник месяца", GetDescription("* * * * MON#3"));
        }

        [Fact]
        public void TestLastDayOfTheWeekOfTheMonth()
        {
            Assert.EqualsCaseInsensitive("Каждую минуту, в последний четверг месяца", GetDescription("* * * * 4L"));
        }

        [Fact]
        public void TestLastDayOfTheMonth()
        {
            Assert.EqualsCaseInsensitive("Каждые 5 минут, в последний день месяца, только в январь", GetDescription("*/5 * L JAN *"));
        }

        [Fact]
        public void TestLastWeekdayOfTheMonth()
        {
            Assert.EqualsCaseInsensitive("Каждую минуту, в последний будний день месяца", GetDescription("* * LW * *"));
        }

        [Fact]
        public void TestLastWeekdayOfTheMonth2()
        {
            Assert.EqualsCaseInsensitive("Каждую минуту, в последний будний день месяца", GetDescription("* * WL * *"));
        }

        [Fact]
        public void TestFirstWeekdayOfTheMonth()
        {
            Assert.EqualsCaseInsensitive("Каждую минуту, в первый будний день месяца", GetDescription("* * 1W * *"));
        }

        [Fact]
        public void TestFirstWeekdayOfTheMonth2()
        {
            Assert.EqualsCaseInsensitive("Каждую минуту, в первый будний день месяца", GetDescription("* * W1 * *"));
        }

        [Fact]
        public void TestParticularWeekdayOfTheMonth()
        {
            Assert.EqualsCaseInsensitive("Каждую минуту, в ближайший будний день к 5 месяца", GetDescription("* * 5W * *"));
        }

        [Fact]
        public void TestParticularWeekdayOfTheMonth2()
        {
            Assert.EqualsCaseInsensitive("Каждую минуту, в ближайший будний день к 5 месяца", GetDescription("* * W5 * *"));
        }

        [Fact]
        public void TestTimeOfDayWithSeconds()
        {
            Assert.EqualsCaseInsensitive("В 14:02:30", GetDescription("30 02 14 * * *"));
        }

        [Fact]
        public void TestSecondInternvals()
        {
            Assert.EqualsCaseInsensitive("Секунды с 5 по 10", GetDescription("5-10 * * * * *"));
        }

        [Fact]
        public void TestSecondMinutesHoursIntervals()
        {
            Assert.EqualsCaseInsensitive("Секунды с 5 по 10, минуты с 30 по 35, с 10:00 по 12:59", GetDescription("5-10 30-35 10-12 * * *"));
        }

        [Fact]
        public void TestEvery5MinutesAt30Seconds()
        {
            Assert.EqualsCaseInsensitive("В 30 секунд, каждые 5 минут", GetDescription("30 */5 * * * *"));
        }

        [Fact]
        public void TestMinutesPastTheHourRange()
        {
            Assert.EqualsCaseInsensitive("В 30 минут, с 10:00 по 13:59, только в среда и пятница", GetDescription("0 30 10-13 ? * WED,FRI"));
        }

        [Fact]
        public void TestSecondsPastTheMinuteInterval()
        {
            Assert.EqualsCaseInsensitive("В 10 секунд, каждые 5 минут", GetDescription("10 0/5 * * * ?"));
        }

        [Fact]
        public void TestBetweenWithInterval()
        {
            Assert.EqualsCaseInsensitive("Каждые 3 минут, минуты с 2 по 59, в 01:00, 09:00, и 22:00, с 11 по 26 число месяца, январь по июнь", GetDescription("2-59/3 1,9,22 11-26 1-6 ?"));
        }

        [Fact]
        public void TestRecurringFirstOfMonth()
        {
            Assert.EqualsCaseInsensitive("В 06:00", GetDescription("0 0 6 1/1 * ?"));
        }

        [Fact]
        public void TestMinutesPastTheHour()
        {
            Assert.EqualsCaseInsensitive("В 5 минут", GetDescription("0 5 0/1 * * ?"));
        }

        [Fact]
        public void TestOneYearOnlyWithSeconds()
        {
            Assert.EqualsCaseInsensitive("Каждую секунду, только в 2013", GetDescription("* * * * * * 2013"));
        }

        [Fact]
        public void TestOneYearOnlyWithoutSeconds()
        {
            Assert.EqualsCaseInsensitive("Каждую минуту, только в 2013", GetDescription("* * * * * 2013"));
        }

        [Fact]
        public void TestTwoYearsOnly()
        {
            Assert.EqualsCaseInsensitive("Каждую минуту, только в 2013 и 2014", GetDescription("* * * * * 2013,2014"));
        }

        [Fact]
        public void TestYearRange2()
        {
            Assert.EqualsCaseInsensitive("В 12:23, январь по февраль, 2013 по 2014", GetDescription("23 12 * JAN-FEB * 2013-2014"));
        }

        [Fact]
        public void TestYearRange3()
        {
            Assert.EqualsCaseInsensitive("В 12:23, январь по март, 2013 по 2015", GetDescription("23 12 * JAN-MAR * 2013-2015"));
        }

        [Fact]
        public void TestHourRange()
        {
            Assert.EqualsCaseInsensitive("Каждые 30 минут, с 08:00 по 09:59, в 5 и 20 число месяца", GetDescription("0 0/30 8-9 5,20 * ?"));
        }

        [Fact]
        public void TestDayOfWeekModifier()
        {
            Assert.EqualsCaseInsensitive("В 12:23, в второй воскресенье месяца", GetDescription("23 12 * * SUN#2"));
        }

        [Fact]
        public void TestDayOfWeekModifierWithSundayStartOne()
        {
            Options options = new Options();
            options.DayOfWeekStartIndexZero = false;

            Assert.EqualsCaseInsensitive("В 12:23, в второй воскресенье месяца", GetDescription("23 12 * * 1#2", options));
        }

        [Fact]
        public void TestHourRangeWithEveryPortion()
        {
            Assert.EqualsCaseInsensitive("В 25 минут, каждые 13 часов, с 07:00 по 19:59", GetDescription("0 25 7-19/13 ? * *"));
        }

        [Fact]
        public void TestHourRangeWithTrailingZeroWithEveryPortion()
        {
            Assert.EqualsCaseInsensitive("В 25 минут, каждые 13 часов, с 07:00 по 20:59", GetDescription("0 25 7-20/13 ? * *"));
        }

        [Fact]
        public void TestSecondsInternalWithStepValue()
        {
            // GitHub Issue #49: https://github.com/bradymholt/cron-expression-descriptor/issues/49
            Assert.EqualsCaseInsensitive("Каждые 30 секунд, начало в 5 секунд", GetDescription("5/30 * * * * ?"));
        }

        [Fact]
        public void TestMinutesInternalWithStepValue()
        {
            Assert.EqualsCaseInsensitive("Каждые 30 минут, начало в 5 минут", GetDescription("0 5/30 * * * ?"));
        }

        [Fact]
        public void TestHoursInternalWithStepValue()
        {
            Assert.EqualsCaseInsensitive("Каждую секунду, каждые 8 часов, начало в 05:00", GetDescription("* * 5/8 * * ?"));
        }

        [Fact]
        public void TestDayOfMonthInternalWithStepValue()
        {
            Assert.EqualsCaseInsensitive("В 07:05, каждые 3 дней, начало в 2 число месяца", GetDescription("0 5 7 2/3 * ? *"));
        }

        [Fact]
        public void TestMonthInternalWithStepValue()
        {
            Assert.EqualsCaseInsensitive("В 07:05, каждые 2 месяцев, март по декабрь", GetDescription("0 5 7 ? 3/2 ? *"));
        }

        [Fact]
        public void TestDayOfWeekInternalWithStepValue()
        {
            Assert.EqualsCaseInsensitive("В 07:05, каждые 3 дней недели, вторник по суббота", GetDescription("0 5 7 ? * 2/3 *"));
        }

        [Fact]
        public void TestYearInternalWithStepValue()
        {
            Assert.EqualsCaseInsensitive("В 07:05, каждые 4 лет, 2016 по 9999", GetDescription("0 5 7 ? * ? 2016/4"));
        }
    }
}
