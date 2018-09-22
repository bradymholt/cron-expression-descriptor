using Xunit;
using Assert = CronExpressionDescriptor.Test.Support.AssertExtensions;

namespace CronExpressionDescriptor.Test
{
    /// <summary>
    /// Tests for Ukrainian translation
    /// </summary>
    public class TestFormatsUk : Support.BaseTestFormats
    {
        protected override string GetLocale()
        {
            return "uk-UA";
        }

        [Fact]
        public void TestEveryMinute()
        {
            Assert.EqualsCaseInsensitive("Щохвилини", GetDescription("* * * * *"));
        }

        [Fact]
        public void TestEvery1Minute()
        {
            Assert.EqualsCaseInsensitive("Щохвилини", GetDescription("*/1 * * * *"));
            Assert.EqualsCaseInsensitive("Щохвилини", GetDescription("0 0/1 * * * ?"));
        }

        [Fact]
        public void TestEveryHour()
        {
            Assert.EqualsCaseInsensitive("Щогодини", GetDescription("0 0 * * * ?"));
            Assert.EqualsCaseInsensitive("Щогодини", GetDescription("0 0 0/1 * * ?"));
        }

        [Fact]
        public void TestTimeOfDayCertainDaysOfWeek()
        {
            string expected = "О 23:00, понеділок по пʼятниця";
            string description = GetDescription("0 23 ? * MON-FRI").Replace('\'', 'ʼ');

            Assert.EqualsCaseInsensitive(expected, description);
        }

        [Fact]
        public void TestEverySecond()
        {
            Assert.EqualsCaseInsensitive("Щосекунди", GetDescription("* * * * * *"));
        }

        [Fact]
        public void TestEvery45Seconds()
        {
            Assert.EqualsCaseInsensitive("Кожні 45 секунд", GetDescription("*/45 * * * * *"));
        }

        [Fact]
        public void TestEvery5Minutes()
        {
            Assert.EqualsCaseInsensitive("Кожні 5 хвилин", GetDescription("*/5 * * * *"));
            Assert.EqualsCaseInsensitive("Кожні 10 хвилин", GetDescription("0 0/10 * * * ?"));
        }

        [Fact]
        public void TestEvery5MinutesOnTheSecond()
        {
            Assert.EqualsCaseInsensitive("Кожні 5 хвилин", GetDescription("0 */5 * * * *"));
        }

        [Fact]
        public void TestWeekdaysAtTime()
        {
            string expected = "О 11:30, понеділок по пʼятниця";
            string description = GetDescription("30 11 * * 1-5").Replace('\'', 'ʼ');

            Assert.EqualsCaseInsensitive(expected, description);
        }

        [Fact]
        public void TestDailyAtTime()
        {
            Assert.EqualsCaseInsensitive("О 11:30", GetDescription("30 11 * * *"));
        }

        [Fact]
        public void TestMinuteSpan()
        {
            Assert.EqualsCaseInsensitive("Щохвилини між 11:00 та 11:10", GetDescription("0-10 11 * * *"));
        }

        [Fact]
        public void TestOneMonthOnly()
        {
            Assert.EqualsCaseInsensitive("Щохвилини, тільки в березень", GetDescription("* * * 3 *"));
        }

        [Fact]
        public void TestTwoMonthsOnly()
        {
            Assert.EqualsCaseInsensitive("Щохвилини, тільки в березень та червень", GetDescription("* * * 3,6 *"));
        }

        [Fact]
        public void TestTwoTimesEachAfternoon()
        {
            Assert.EqualsCaseInsensitive("О 14:30 та 16:30", GetDescription("30 14,16 * * *"));
        }

        [Fact]
        public void TestThreeTimesDaily()
        {
            Assert.EqualsCaseInsensitive("О 06:30, 14:30 та 16:30", GetDescription("30 6,14,16 * * *"));
        }

        [Fact]
        public void TestOnceAWeek()
        {
            Assert.EqualsCaseInsensitive("О 09:46, тільки в понеділок", GetDescription("46 9 * * 1"));
        }

        [Fact]
        public void TestDayOfMonth()
        {
            Assert.EqualsCaseInsensitive("О 12:23, на 15 день місяця", GetDescription("23 12 15 * *"));
        }

        [Fact]
        public void TestMonthName()
        {
            Assert.EqualsCaseInsensitive("О 12:23, тільки в січень", GetDescription("23 12 * JAN * "));
        }

        [Fact]
        public void TestDayOfMonthWithQuestionMark()
        {
            Assert.EqualsCaseInsensitive("О 12:23, тільки в січень", GetDescription("23 12 ? JAN *"));
        }

        [Fact]
        public void TestMonthNameRange2()
        {
            Assert.EqualsCaseInsensitive("О 12:23, січень по лютий", GetDescription("23 12 * JAN-FEB *"));
        }

        [Fact]
        public void TestMonthNameRange3()
        {
            Assert.EqualsCaseInsensitive("О 12:23, січень по березень", GetDescription("23 12 * JAN-MAR *"));
        }

        [Fact]
        public void TestDayOfWeekName()
        {
            Assert.EqualsCaseInsensitive("О 12:23, тільки в неділя", GetDescription("23 12 * * SUN"));
        }

        [Fact]
        public void TestDayOfWeekRange()
        {
            string expected = "Кожні 5 хвилин, між 15:00 та 15:59, понеділок по пʼятниця";
            string description = GetDescription("*/5 15 * * MON-FRI").Replace('\'', 'ʼ');

            Assert.EqualsCaseInsensitive(expected, description);
        }

        [Fact]
        public void TestDayOfWeekOnceInMonth()
        {
            Assert.EqualsCaseInsensitive("Щохвилини, в третій понеділок місяця", GetDescription("* * * * MON#3"));
        }

        [Fact]
        public void TestLastDayOfTheWeekOfTheMonth()
        {
            Assert.EqualsCaseInsensitive("Щохвилини, в останній четвер місяця", GetDescription("* * * * 4L"));
        }

        [Fact]
        public void TestLastDayOfTheMonth()
        {
            Assert.EqualsCaseInsensitive("Кожні 5 хвилин, в останній день місяця, тільки в січень", GetDescription("*/5 * L JAN *"));
        }

        [Fact]
        public void TestLastWeekdayOfTheMonth()
        {
            Assert.EqualsCaseInsensitive("Щохвилини, в останній будень місяця", GetDescription("* * LW * *"));
        }

        [Fact]
        public void TestLastWeekdayOfTheMonth2()
        {
            Assert.EqualsCaseInsensitive("Щохвилини, в останній будень місяця", GetDescription("* * WL * *"));
        }

        [Fact]
        public void TestFirstWeekdayOfTheMonth()
        {
            Assert.EqualsCaseInsensitive("Щохвилини, в перший будень місяця", GetDescription("* * 1W * *"));
        }

        [Fact]
        public void TestFirstWeekdayOfTheMonth2()
        {
            Assert.EqualsCaseInsensitive("Щохвилини, в перший будень місяця", GetDescription("* * W1 * *"));
        }

        [Fact]
        public void TestParticularWeekdayOfTheMonth()
        {
            Assert.EqualsCaseInsensitive("Щохвилини, в будень найближчий до 5 дня місяця", GetDescription("* * 5W * *"));
        }

        [Fact]
        public void TestParticularWeekdayOfTheMonth2()
        {
            Assert.EqualsCaseInsensitive("Щохвилини, в будень найближчий до 5 дня місяця", GetDescription("* * W5 * *"));
        }

        [Fact]
        public void TestTimeOfDayWithSeconds()
        {
            Assert.EqualsCaseInsensitive("О 14:02:30", GetDescription("30 02 14 * * *"));
        }

        [Fact]
        public void TestSecondInternvals()
        {
            Assert.EqualsCaseInsensitive("З 5 по 10 секунду", GetDescription("5-10 * * * * *"));
        }

        [Fact]
        public void TestSecondMinutesHoursIntervals()
        {
            Assert.EqualsCaseInsensitive("З 5 по 10 секунду, з 30 по 35 хвилину, між 10:00 та 12:59", GetDescription("5-10 30-35 10-12 * * *"));
        }

        [Fact]
        public void TestEvery5MinutesAt30Seconds()
        {
            Assert.EqualsCaseInsensitive("О 30 секунді, кожні 5 хвилин", GetDescription("30 */5 * * * *"));
        }

        [Fact]
        public void TestMinutesPastTheHourRange()
        {
            string expected = "О 30 хвилині, між 10:00 та 13:59, тільки в середа та пʼятниця";
            string description = GetDescription("0 30 10-13 ? * WED,FRI").Replace('\'', 'ʼ');

            Assert.EqualsCaseInsensitive(expected, description);
        }

        [Fact]
        public void TestSecondsPastTheMinuteInterval()
        {
            Assert.EqualsCaseInsensitive("О 10 секунді, кожні 5 хвилин", GetDescription("10 0/5 * * * ?"));
        }

        [Fact]
        public void TestBetweenWithInterval()
        {
            Assert.EqualsCaseInsensitive("Кожні 3 хвилин, з 2 по 59 хвилину, о 01:00, 09:00, та 22:00, між 11 та 26 днями місяця, січень по червень", GetDescription("2-59/3 1,9,22 11-26 1-6 ?"));
        }

        [Fact]
        public void TestRecurringFirstOfMonth()
        {
            Assert.EqualsCaseInsensitive("О 06:00", GetDescription("0 0 6 1/1 * ?"));
        }

        [Fact]
        public void TestMinutesPastTheHour()
        {
            Assert.EqualsCaseInsensitive("О 5 хвилині", GetDescription("0 5 0/1 * * ?"));
        }

        [Fact]
        public void TestOneYearOnlyWithSeconds()
        {
            Assert.EqualsCaseInsensitive("Щосекунди, тільки в 2013", GetDescription("* * * * * * 2013"));
        }

        [Fact]
        public void TestOneYearOnlyWithoutSeconds()
        {
            Assert.EqualsCaseInsensitive("Щохвилини, тільки в 2013", GetDescription("* * * * * 2013"));
        }

        [Fact]
        public void TestTwoYearsOnly()
        {
            Assert.EqualsCaseInsensitive("Щохвилини, тільки в 2013 та 2014", GetDescription("* * * * * 2013,2014"));
        }

        [Fact]
        public void TestYearRange2()
        {
            Assert.EqualsCaseInsensitive("О 12:23, січень по лютий, 2013 по 2014", GetDescription("23 12 * JAN-FEB * 2013-2014"));
        }

        [Fact]
        public void TestYearRange3()
        {
            Assert.EqualsCaseInsensitive("О 12:23, січень по березень, 2013 по 2015", GetDescription("23 12 * JAN-MAR * 2013-2015"));
        }

        [Fact]
        public void TestHourRange()
        {
            Assert.EqualsCaseInsensitive("Кожні 30 хвилин, між 08:00 та 09:59, на 5 та 20 день місяця", GetDescription("0 0/30 8-9 5,20 * ?"));
        }

        [Fact]
        public void TestDayOfWeekModifier()
        {
            Assert.EqualsCaseInsensitive("О 12:23, в другий неділя місяця", GetDescription("23 12 * * SUN#2"));
        }

        [Fact]
        public void TestDayOfWeekModifierWithSundayStartOne()
        {
            Options options = new Options();
            options.DayOfWeekStartIndexZero = false;

            Assert.EqualsCaseInsensitive("О 12:23, в другий неділя місяця", GetDescription("23 12 * * 1#2", options));
        }

        [Fact]
        public void TestHourRangeWithEveryPortion()
        {
            Assert.EqualsCaseInsensitive("О 25 хвилині, кожні 13 годин, між 07:00 та 19:59", GetDescription("0 25 7-19/13 ? * *"));
        }

        [Fact]
        public void TestHourRangeWithTrailingZeroWithEveryPortion()
        {
            Assert.EqualsCaseInsensitive("О 25 хвилині, кожні 13 годин, між 07:00 та 20:59", GetDescription("0 25 7-20/13 ? * *"));
        }

        [Fact]
        public void TestEvery3Day()
        {
            Assert.EqualsCaseInsensitive("О 08:00, кожен 3 день", GetDescription("0 0 8 1/3 * ? *"));
        }

        [Fact]
        public void TestsEvery3DayOfTheWeek()
        {
            Assert.EqualsCaseInsensitive("О 10:15, кожен 3 день тижня", GetDescription("0 15 10 ? * */3"));
        }

        [Fact]
        public void TestEvery3Month()
        {
            Assert.EqualsCaseInsensitive("О 07:05, на 2 день місяця, кожен 3 місяць", GetDescription("0 5 7 2 1/3 ? *"));
        }

        [Fact]
        public void TestEvery2Years()
        {
            Assert.EqualsCaseInsensitive("О 06:15, на 1 день місяця, тільки в січень, кожні 2 роки", GetDescription("0 15 6 1 1 ? 1/2"));
        }

        [Fact]
        public void TestSecondsInternalWithStepValue()
        {
            // GitHub Issue #49: https://github.com/bradymholt/cron-expression-descriptor/issues/49
            Assert.EqualsCaseInsensitive("Кожні 30 секунд, початок о 5 секунді", GetDescription("5/30 * * * * ?"));
        }

        [Fact]
        public void TestMinutesInternalWithStepValue()
        {
            Assert.EqualsCaseInsensitive("Кожні 30 хвилин, початок о 5 хвилині", GetDescription("0 5/30 * * * ?"));
        }

        [Fact]
        public void TestHoursInternalWithStepValue()
        {
            Assert.EqualsCaseInsensitive("Щосекунди, кожні 8 годин, початок о 05:00", GetDescription("* * 5/8 * * ?"));
        }

        [Fact]
        public void TestDayOfMonthInternalWithStepValue()
        {
            Assert.EqualsCaseInsensitive("О 07:05, кожен 3 день, початок на 2 день місяця", GetDescription("0 5 7 2/3 * ? *"));
        }

        [Fact]
        public void TestMonthInternalWithStepValue()
        {
            Assert.EqualsCaseInsensitive("О 07:05, кожен 2 місяць, березень по грудень", GetDescription("0 5 7 ? 3/2 ? *"));
        }

        [Fact]
        public void TestDayOfWeekInternalWithStepValue()
        {
            Assert.EqualsCaseInsensitive("О 07:05, кожен 3 день тижня, вівторок по субота", GetDescription("0 5 7 ? * 2/3 *"));
        }

        [Fact]
        public void TestYearInternalWithStepValue()
        {
            Assert.EqualsCaseInsensitive("О 07:05, кожні 4 роки, 2016 по 9999", GetDescription("0 5 7 ? * ? 2016/4"));
        }
    }
}
