using Xunit;

namespace CronExpressionDescriptor.Test
{
    /// <summary>
    /// Tests for Norwegian translation
    /// </summary>
    public class TestFormatsNb : Support.BaseTestFormats
    {
        protected override string GetLocale()
        {
            return "nb-NO";
        }

        [Fact]
        public void TestEveryMinute()
        {
            Assert.Equal("Hvert minutt", GetDescription("* * * * *"));
        }

        [Fact]
        public void TestEvery1Minute()
        {
            Assert.Equal("Hvert minutt", GetDescription("*/1 * * * *"));
            Assert.Equal("Hvert minutt", GetDescription("0 0/1 * * * ?"));
        }

        [Fact]
        public void TestEveryHour()
        {
            Assert.Equal("Hver time", GetDescription("0 0 * * * ?"));
            Assert.Equal("Hver time", GetDescription("0 0 0/1 * * ?"));
        }

        [Fact]
        public void TestTimeOfDayCertainDaysOfWeek()
        {
            Assert.Equal(
                "Klokken 23:00, mandag til og med fredag", GetDescription("0 23 ? * MON-FRI"));
        }

        [Fact]
        public void TestEverySecond()
        {
            Assert.Equal("Hvert sekund", GetDescription("* * * * * *"));
        }

        [Fact]
        public void TestEvery45Seconds()
        {
            Assert.Equal("Hvert 45. sekund", GetDescription("*/45 * * * * *"));
        }

        [Fact]
        public void TestEvery5Minutes()
        {
            Assert.Equal("Hvert 5. minutt", GetDescription("*/5 * * * *"));
            Assert.Equal("Hvert 10. minutt", GetDescription("0 0/10 * * * ?"));
        }

        [Fact]
        public void TestEvery5MinutesOnTheSecond()
        {
            Assert.Equal("Hvert 5. minutt", GetDescription("0 */5 * * * *"));
        }

        [Fact]
        public void TestWeekdaysAtTime()
        {
            Assert.Equal("Klokken 11:30, mandag til og med fredag", GetDescription("30 11 * * 1-5"));
        }

        [Fact]
        public void TestDailyAtTime()
        {
            Assert.Equal("Klokken 11:30", GetDescription("30 11 * * *"));
        }

        [Fact]
        public void TestMinuteSpan()
        {
            Assert.Equal(
                "Hvert minutt mellom 11:00 og 11:10", GetDescription("0-10 11 * * *"));
        }

        [Fact]
        public void TestOneMonthOnly()
        {
            Assert.Equal("Hvert minutt, bare i mars", GetDescription("* * * 3 *"));
        }

        [Fact]
        public void TestTwoMonthsOnly()
        {
            Assert.Equal("Hvert minutt, bare i mars og juni", GetDescription("* * * 3,6 *"));
        }

        [Fact]
        public void TestTwoTimesEachAfternoon()
        {
            Assert.Equal("Klokken 14:30 og 16:30", GetDescription("30 14,16 * * *"));
        }

        [Fact]
        public void TestThreeTimesDaily()
        {
            Assert.Equal(
                "Klokken 06:30, 14:30 og 16:30", GetDescription("30 6,14,16 * * *"));
        }

        [Fact]
        public void TestOnceAWeek()
        {
            Assert.Equal("Klokken 09:46, bare på mandag", GetDescription("46 9 * * 1"));
        }

        [Fact]
        public void TestDayOfMonth()
        {
            Assert.Equal("Klokken 12:23, 15. dag i måneden", GetDescription("23 12 15 * *"));
        }

        [Fact]
        public void TestMonthName()
        {
            Assert.Equal("Klokken 12:23, bare i januar", GetDescription("23 12 * JAN *"));
        }

        [Fact]
        public void TestDayOfMonthWithQuestionMark()
        {
            Assert.Equal("Klokken 12:23, bare i januar", GetDescription("23 12 ? JAN *"));
        }

        [Fact]
        public void TestMonthNameRange2()
        {
            Assert.Equal(
                "Klokken 12:23, januar til og med februar", GetDescription("23 12 * JAN-FEB *"));
        }

        [Fact]
        public void TestMonthNameRange3()
        {
            Assert.Equal(
                "Klokken 12:23, januar til og med mars", GetDescription("23 12 * JAN-MAR *"));
        }

        [Fact]
        public void TestDayOfWeekName()
        {
            Assert.Equal("Klokken 12:23, bare på søndag", GetDescription("23 12 * * SUN"));
        }

        [Fact]
        public void TestDayOfWeekRange()
        {
            Assert.Equal(
                "Hvert 5. minutt, mellom 15:00 og 15:59, mandag til og med fredag",
                GetDescription("*/5 15 * * MON-FRI"));
        }

        [Fact]
        public void TestDayOfWeekOnceInMonth()
        {
            Assert.Equal(
                "Hvert minutt, den tredje mandag i måneden", GetDescription("* * * * MON#3"));
        }

        [Fact]
        public void TestLastDayOfTheWeekOfTheMonth()
        {
            Assert.Equal(
                "Hvert minutt, den siste torsdag i måneden", GetDescription("* * * * 4L"));
        }

        [Fact]

        public void TestLastDayOfTheMonth()
        {
            Assert.Equal(
                "Hvert 5. minutt, den siste dagen i måneden, bare i januar",
                GetDescription("*/5 * L JAN *"));
        }

        [Fact]

        public void TestLastWeekdayOfTheMonth()
        {
            Assert.Equal(
                "Hvert minutt, den siste ukedagen i måneden", GetDescription("* * LW * *"));
        }

        [Fact]

        public void TestLastWeekdayOfTheMonth2()
        {
            Assert.Equal(
                "Hvert minutt, den siste ukedagen i måneden", GetDescription("* * WL * *"));
        }

        [Fact]

        public void TestFirstWeekdayOfTheMonth()
        {
            Assert.Equal(
                "Hvert minutt, den første ukedag i måneden", GetDescription("* * 1W * *"));
        }

        [Fact]

        public void TestFirstWeekdayOfTheMonth2()
        {
            Assert.Equal(
                "Hvert minutt, den første ukedag i måneden", GetDescription("* * W1 * *"));
        }

        [Fact]

        public void TestParticularWeekdayOfTheMonth()
        {
            Assert.Equal(
                "Hvert minutt, den ukedag nærmest 5. dag i måneden",
                GetDescription("* * 5W * *"));
        }

        [Fact]

        public void TestParticularWeekdayOfTheMonth2()
        {
            Assert.Equal(
                "Hvert minutt, den ukedag nærmest 5. dag i måneden",
                GetDescription("* * W5 * *"));
        }

        [Fact]

        public void TestTimeOfDayWithSeconds()
        {
            Assert.Equal("Klokken 14:02:30", GetDescription("30 02 14 * * *"));
        }

        [Fact]

        public void TestSecondInternvals()
        {
            Assert.Equal(
                "Sekundene fra 5 til og med 10 etter minuttet", GetDescription("5-10 * * * * *"));
        }

        [Fact]

        public void TestSecondMinutesHoursIntervals()
        {
            Assert.Equal(
                "Sekundene fra 5 til og med 10 etter minuttet, minuttene fra 30 til og med 35 etter timen, mellom 10:00 og 12:59",
                GetDescription("5-10 30-35 10-12 * * *"));
        }

        [Fact]

        public void TestEvery5MinutesAt30Seconds()
        {
            Assert.Equal(
                "30 sekunder etter minuttet, hvert 5. minutt", GetDescription("30 */5 * * * *"));
        }

        [Fact]

        public void TestMinutesPastTheHourRange()
        {
            Assert.Equal(
                "30 minutter etter timen, mellom 10:00 og 13:59, bare på onsdag og fredag",
                GetDescription("0 30 10-13 ? * WED,FRI"));
        }

        [Fact]

        public void TestSecondsPastTheMinuteInterval()
        {
            Assert.Equal(
                "10 sekunder etter minuttet, hvert 5. minutt", GetDescription("10 0/5 * * * ?"));
        }

        [Fact]

        public void TestBetweenWithInterval()
        {
            Assert.Equal(
                "Hvert 3. minutt, minuttene fra 2 til og med 59 etter timen, på 01:00, 09:00, og 22:00, mellom 11. og 26. dag i måneden, januar til og med juni",
                GetDescription("2-59/3 1,9,22 11-26 1-6 ?"));
        }

        [Fact]

        public void TestRecurringFirstOfMonth()
        {
            Assert.Equal("Klokken 06:00", GetDescription("0 0 6 1/1 * ?"));
        }

        [Fact]

        public void TestMinutesPastTheHour()
        {
            Assert.Equal("5 minutter etter timen", GetDescription("0 5 0/1 * * ?"));
        }

        [Fact]
        public void TestOneYearOnlyWithSeconds()
        {
            Assert.Equal("Hvert sekund, bare i 2013", GetDescription("* * * * * * 2013"));
        }

        [Fact]
        public void TestOneYearOnlyWithoutSeconds()
        {
            Assert.Equal("Hvert minutt, bare i 2013", GetDescription("* * * * * 2013"));
        }

        [Fact]
        public void TestTwoYearsOnly()
        {
            Assert.Equal(
                "Hvert minutt, bare i 2013 og 2014", GetDescription("* * * * * 2013,2014"));
        }

        [Fact]
        public void TestYearRange2()
        {
            Assert.Equal(
                "Klokken 12:23, januar til og med februar, 2013 til og med 2014",
                GetDescription("23 12 * JAN-FEB * 2013-2014"));
        }

        [Fact]
        public void TestYearRange3()
        {
            Assert.Equal(
                "Klokken 12:23, januar til og med mars, 2013 til og med 2015",
                GetDescription("23 12 * JAN-MAR * 2013-2015"));
        }

        [Fact]
        public void TestSecondsInternalWithStepValue()
        {
            // GitHub Issue #49: https://github.com/bradymholt/cron-expression-descriptor/issues/49
            Assert.Equal("Hvert 30. sekund, starter 5 sekunder etter minuttet", GetDescription("5/30 * * * * ?"));
        }

        [Fact]
        public void TestMinutesInternalWithStepValue()
        {
            Assert.Equal("Hvert 30. minutt, starter 5 minutter etter timen", GetDescription("0 5/30 * * * ?"));
        }

        [Fact]
        public void TestHoursInternalWithStepValue()
        {
            Assert.Equal("Hvert sekund, hver 8. time, starter på 05:00", GetDescription("* * 5/8 * * ?"));
        }

        [Fact]
        public void TestDayOfMonthInternalWithStepValue()
        {
            Assert.Equal("Klokken 07:05, hver 3. dag, starter 2. dag i måneden", GetDescription("0 5 7 2/3 * ? *"));
        }

        [Fact]
        public void TestMonthInternalWithStepValue()
        {
            Assert.Equal("Klokken 07:05, hver 2. måned, mars til og med desember", GetDescription("0 5 7 ? 3/2 ? *"));
        }

        [Fact]
        public void TestDayOfWeekInternalWithStepValue()
        {
            Assert.Equal("Klokken 07:05, hver 3. ukedag, tirsdag til og med lørdag", GetDescription("0 5 7 ? * 2/3 *"));
        }

        [Fact]
        public void TestYearInternalWithStepValue()
        {
            Assert.Equal("Klokken 07:05, hvert 4. år, 2016 til og med 9999", GetDescription("0 5 7 ? * ? 2016/4"));
        }
    }
}
