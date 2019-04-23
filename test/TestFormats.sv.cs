using Xunit;
using Assert = CronExpressionDescriptor.Test.Support.AssertExtensions;

namespace CronExpressionDescriptor.Test
{
    /// <summary>
    /// Tests for Swedish translation
    /// </summary>
    public class TestFormatsSV : Support.BaseTestFormats
    {
        protected override string GetLocale()
        {
            return "sv-SE";
        }

        [Fact]

        public void TestEveryMinute()
        {
            Assert.EqualsCaseInsensitive("Varje minut", GetDescription("* * * * *"));
        }

        [Fact]

        public void TestEvery1Minute()
        {
            Assert.EqualsCaseInsensitive("Varje minut", GetDescription("*/1 * * * *"));
            Assert.EqualsCaseInsensitive("Varje minut", GetDescription("0 0/1 * * * ?"));
        }

        [Fact]

        public void TestEveryHour()
        {
            Assert.EqualsCaseInsensitive("Varje timme", GetDescription("0 0 * * * ?"));
            Assert.EqualsCaseInsensitive("Varje timme", GetDescription("0 0 0/1 * * ?"));
        }

        [Fact]

        public void TesttimmaOfDayCertainDaysOfWeek()
        {
            Assert.EqualsCaseInsensitive(
                "Klockan 23:00, måndag till och med fredag", GetDescription("0 23 ? * MON-FRI"));
        }

        [Fact]

        public void TestEverySecond()
        {
            Assert.EqualsCaseInsensitive("Varje sekund", GetDescription("* * * * * *"));
        }

        [Fact]

        public void TestEvery45Seconds()
        {
            Assert.EqualsCaseInsensitive("Upprepas efter 45 sekunder", GetDescription("*/45 * * * * *"));
        }

        [Fact]

        public void TestEvery5Minutes()
        {
            Assert.EqualsCaseInsensitive("Upprepas efter 10 minuter", GetDescription("0 0/10 * * * ?"));
        }

        [Fact]

        public void TestEvery5MinutesOnTheSecond()
        {
            Assert.EqualsCaseInsensitive("Upprepas efter 5 minuter", GetDescription("0 */5 * * * *"));
        }

        [Fact]

        public void TestWeekdaysAttimma()
        {
            Assert.EqualsCaseInsensitive("Klockan 11:30, måndag till och med fredag", GetDescription("30 11 * * 1-5"));
        }

        [Fact]

        public void TestDailyAttimma()
        {
            Assert.EqualsCaseInsensitive("Klockan 11:30", GetDescription("30 11 * * *"));
        }

        [Fact]

        public void TestMinuteSpan()
        {
            Assert.EqualsCaseInsensitive(
                "Varje minut mellan 11:00 och 11:10", GetDescription("0-10 11 * * *"));
        }

        [Fact]

        public void TestOneMonthOnly()
        {
            Assert.EqualsCaseInsensitive("Varje minut, bara i mars", GetDescription("* * * 3 *"));
        }

        [Fact]

        public void TestTwoMonthsOnly()
        {
            Assert.EqualsCaseInsensitive("Varje minut, bara i mars och juni", GetDescription("* * * 3,6 *"));
        }

        [Fact]

        public void TestTwotimmasEachAfternoon()
        {
            Assert.EqualsCaseInsensitive("Klockan 14:30 och 16:30", GetDescription("30 14,16 * * *"));
        }

        [Fact]

        public void TestThreetimmasDaily()
        {
            Assert.EqualsCaseInsensitive(
                "Klockan 06:30, 14:30 och 16:30", GetDescription("30 6,14,16 * * *"));
        }

        [Fact]

        public void TestOnceAWeek()
        {
            Assert.EqualsCaseInsensitive("Klockan 09:46, bara på måndag", GetDescription("46 9 * * 1"));
        }

        [Fact]

        public void TestDayOfMonth()
        {
            Assert.EqualsCaseInsensitive("Klockan 12:23, dag 15 i månaden", GetDescription("23 12 15 * *"));
        }

        [Fact]

        public void TestMonthName()
        {
            Assert.EqualsCaseInsensitive("Klockan 12:23, bara i januari", GetDescription("23 12 * JAN *"));
        }

        [Fact]

        public void TestDayOfMonthWithQuestionMark()
        {
            Assert.EqualsCaseInsensitive("Klockan 12:23, bara i januari", GetDescription("23 12 ? JAN *"));
        }

        [Fact]

        public void TestMonthNameRange2()
        {
            Assert.EqualsCaseInsensitive(
                "Klockan 12:23, januari till och med februari", GetDescription("23 12 * JAN-FEB *"));
        }

        [Fact]

        public void TestMonthNameRange3()
        {
            Assert.EqualsCaseInsensitive(
                "Klockan 12:23, januari till och med mars", GetDescription("23 12 * JAN-MAR *"));
        }

        [Fact]

        public void TestDayOfWeekName()
        {
            Assert.EqualsCaseInsensitive("Klockan 12:23, bara på söndag", GetDescription("23 12 * * SUN"));
        }

        [Fact]

        public void TestDayOfWeekRange()
        {
            Assert.EqualsCaseInsensitive(
                "Upprepas efter 5 minuter, mellan 15:00 och 15:59, måndag till och med fredag",
                GetDescription("*/5 15 * * MON-FRI"));
        }

        [Fact]

        public void TestDayOfWeekOnceInMonth()
        {
            Assert.EqualsCaseInsensitive(
                "Varje minut, den tredje måndag i månaden", GetDescription("* * * * MON#3"));
        }

        [Fact]

        public void TestLastDayOfTheWeekOfTheMonth()
        {
            Assert.EqualsCaseInsensitive(
                "Varje minut, den sista torsdag i månaden", GetDescription("* * * * 4L"));
        }

        [Fact]

        public void TestLastDayOfTheMonth()
        {
            Assert.EqualsCaseInsensitive(
                "Upprepas efter 5 minuter, den sista dagen i månaden, bara i januari",
                GetDescription("*/5 * L JAN *"));
        }

        [Fact]

        public void TestLastWeekdayOfTheMonth()
        {
            Assert.EqualsCaseInsensitive(
                "Varje minut, den sista veckodagen i månaden", GetDescription("* * LW * *"));
        }

        [Fact]

        public void TestLastWeekdayOfTheMonth2()
        {
            Assert.EqualsCaseInsensitive(
                "Varje minut, den sista veckodagen i månaden", GetDescription("* * WL * *"));
        }

        [Fact]

        public void TestFirstWeekdayOfTheMonth()
        {
            Assert.EqualsCaseInsensitive(
                "Varje minut, den första dagen i veckan i månaden", GetDescription("* * 1W * *"));
        }

        [Fact]

        public void TestFirstWeekdayOfTheMonth2()
        {
            Assert.EqualsCaseInsensitive(
                "Varje minut, den första dagen i veckan i månaden", GetDescription("* * W1 * *"));
        }

        [Fact]

        public void TestParticularWeekdayOfTheMonth()
        {
            Assert.EqualsCaseInsensitive(
                "Varje minut, den veckodag som är närmast dag 5 i månaden",
                GetDescription("* * 5W * *"));
        }

        [Fact]

        public void TestParticularWeekdayOfTheMonth2()
        {
            Assert.EqualsCaseInsensitive(
                "Varje minut, den veckodag som är närmast dag 5 i månaden",
                GetDescription("* * W5 * *"));
        }

        [Fact]

        public void TesttimmaOfDayWithSeconds()
        {
            Assert.EqualsCaseInsensitive("Klockan 14:02:30", GetDescription("30 02 14 * * *"));
        }

        [Fact]

        public void TestSecondInternvals()
        {
            Assert.EqualsCaseInsensitive(
                "Mellan sekund 5 och 10 varje minut", GetDescription("5-10 * * * * *"));
        }

        [Fact]

        public void TestSecondMinutesHoursIntervals()
        {
            Assert.EqualsCaseInsensitive(
                "Mellan sekund 5 och 10 varje minut, mellan minut 30 och 35 varje timme, mellan 10:00 och 12:59",
                GetDescription("5-10 30-35 10-12 * * *"));
        }

        [Fact]

        public void TestEvery5MinutesAt30Seconds()
        {
            Assert.EqualsCaseInsensitive(
                "Efter 30 sekunder, upprepas efter 5 minuter", GetDescription("30 */5 * * * *"));
        }

        [Fact]

        public void TestMinutesPastTheHourRange()
        {
            Assert.EqualsCaseInsensitive(
                "Vid 30 minuter över, mellan 10:00 och 13:59, bara på onsdag och fredag",
                GetDescription("0 30 10-13 ? * WED,FRI"));
        }

        [Fact]

        public void TestSecondsPastTheMinuteInterval()
        {
            Assert.EqualsCaseInsensitive(
                "Efter 10 sekunder, upprepas efter 5 minuter", GetDescription("10 0/5 * * * ?"));
        }

        [Fact]

        public void TestBetweenWithInterval()
        {
            Assert.EqualsCaseInsensitive(
                "Upprepas efter 3 minuter, mellan minut 2 och 59 varje timme, klockan 01:00, 09:00, och 22:00, mellan dag 11 och 26 i månaden, januari till och med juni",
                GetDescription("2-59/3 1,9,22 11-26 1-6 ?"));
        }

        [Fact]

        public void TestRecurringFirstOfMonth()
        {
            Assert.EqualsCaseInsensitive("Klockan 06:00", GetDescription("0 0 6 1/1 * ?"));
        }

        [Fact]

        public void TestMinutesPastTheHour()
        {
            Assert.EqualsCaseInsensitive("Vid 5 minuter över", GetDescription("0 5 0/1 * * ?"));
        }

        [Fact]

        public void TestOneYearOnlyWithSeconds()
        {
            Assert.EqualsCaseInsensitive("Varje sekund, bara under 2013", GetDescription("* * * * * * 2013"));
        }

        [Fact]

        public void TestOneYearOnlyWithoutSeconds()
        {
            Assert.EqualsCaseInsensitive("Varje minut, bara under 2013", GetDescription("* * * * * 2013"));
        }

        [Fact]

        public void TestTwoYearsOnly()
        {
            Assert.EqualsCaseInsensitive(
                "Varje minut, bara under 2013 och 2014", GetDescription("* * * * * 2013,2014"));
        }

        [Fact]

        public void TestYearRange2()
        {
            Assert.EqualsCaseInsensitive(
                "Klockan 12:23, januari till och med februari, 2013 till och med 2014",
                GetDescription("23 12 * JAN-FEB * 2013-2014"));
        }

        [Fact]

        public void TestYearRange3()
        {
            Assert.EqualsCaseInsensitive(
                "Klockan 12:23, januari till och med mars, 2013 till och med 2015",
                GetDescription("23 12 * JAN-MAR * 2013-2015"));
        }

        [Fact]
        public void TestSecondsInternalWithStepValue()
        {
            // GitHub Issue #49: https://github.com/bradymholt/cron-expression-descriptor/issues/49
            Assert.EqualsCaseInsensitive("Upprepas efter 30 sekunder, börjar efter 5 sekunder", GetDescription("5/30 * * * * ?"));
        }

        [Fact]
        public void TestMinutesInternalWithStepValue()
        {
            Assert.EqualsCaseInsensitive("Upprepas efter 30 minuter, börjar vid 5 minuter över", GetDescription("0 5/30 * * * ?"));
        }

        [Fact]
        public void TestHoursInternalWithStepValue()
        {
            Assert.EqualsCaseInsensitive("Varje sekund, upprepas efter 8 timmar, börjar klockan 05:00", GetDescription("* * 5/8 * * ?"));
        }

        [Fact]
        public void TestDayOfMonthInternalWithStepValue()
        {
            Assert.EqualsCaseInsensitive("Klockan 07:05, var 3:e dag, börjar dag 2 i månaden", GetDescription("0 5 7 2/3 * ? *"));
        }

        [Fact]
        public void TestMonthInternalWithStepValue()
        {
            Assert.EqualsCaseInsensitive("Klockan 07:05, var 2:e månad, mars till och med december", GetDescription("0 5 7 ? 3/2 ? *"));
        }

        [Fact]
        public void TestDayOfWeekInternalWithStepValue()
        {
            Assert.EqualsCaseInsensitive("Klockan 07:05, var 3:e veckodag, tisdag till och med lördag", GetDescription("0 5 7 ? * 2/3 *"));
        }

        [Fact]
        public void TestYearInternalWithStepValue()
        {
            Assert.EqualsCaseInsensitive("Klockan 07:05, var 4:e år, 2016 till och med 9999", GetDescription("0 5 7 ? * ? 2016/4"));
        }
    }
}
