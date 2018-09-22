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
                "På 11:00 PM, mandag til og med fredag", GetDescription("0 23 ? * MON-FRI"));
        }

        [Fact]
        public void TestEverySecond()
        {
            Assert.Equal("Hvert sekund", GetDescription("* * * * * *"));
        }

        [Fact]
        public void TestEvery45Seconds()
        {
            Assert.Equal("Hvert 45 sekund", GetDescription("*/45 * * * * *"));
        }

        [Fact]
        public void TestEvery5Minutes()
        {
            Assert.Equal("Hvert 5 minutt", GetDescription("*/5 * * * *"));
            Assert.Equal("Hvert 10 minutt", GetDescription("0 0/10 * * * ?"));
        }

        [Fact]
        public void TestEvery5MinutesOnTheSecond()
        {
            Assert.Equal("Hvert 5 minutt", GetDescription("0 */5 * * * *"));
        }

        [Fact]
        public void TestWeekdaysAtTime()
        {
            Assert.Equal("På 11:30 AM, mandag til og med fredag", GetDescription("30 11 * * 1-5"));
        }

        [Fact]
        public void TestDailyAtTime()
        {
            Assert.Equal("På 11:30 AM", GetDescription("30 11 * * *"));
        }

        [Fact]
        public void TestMinuteSpan()
        {
            Assert.Equal(
                "Hvert minutt mellom 11:00 AM og 11:10 AM", GetDescription("0-10 11 * * *"));
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
            Assert.Equal("På 02:30 PM og 04:30 PM", GetDescription("30 14,16 * * *"));
        }

        [Fact]
        public void TestThreeTimesDaily()
        {
            Assert.Equal(
                "På 06:30 AM, 02:30 PM og 04:30 PM", GetDescription("30 6,14,16 * * *"));
        }

        [Fact]
        public void TestOnceAWeek()
        {
            Assert.Equal("På 09:46 AM, bare på mandag", GetDescription("46 9 * * 1"));
        }

        [Fact]
        public void TestDayOfMonth()
        {
            Assert.Equal("På 12:23 PM, på dag 15 av måneden", GetDescription("23 12 15 * *"));
        }

        [Fact]
        public void TestMonthName()
        {
            Assert.Equal("På 12:23 PM, bare i januar", GetDescription("23 12 * JAN *"));
        }

        [Fact]
        public void TestDayOfMonthWithQuestionMark()
        {
            Assert.Equal("På 12:23 PM, bare i januar", GetDescription("23 12 ? JAN *"));
        }

        [Fact]
        public void TestMonthNameRange2()
        {
            Assert.Equal(
                "På 12:23 PM, januar til og med februar", GetDescription("23 12 * JAN-FEB *"));
        }

        [Fact]
        public void TestMonthNameRange3()
        {
            Assert.Equal(
                "På 12:23 PM, januar til og med mars", GetDescription("23 12 * JAN-MAR *"));
        }

        [Fact]
        public void TestDayOfWeekName()
        {
            Assert.Equal("På 12:23 PM, bare på søndag", GetDescription("23 12 * * SUN"));
        }

        [Fact]
        public void TestDayOfWeekRange()
        {
            Assert.Equal(
                "Hvert 5 minutt, mellom 03:00 PM og 03:59 PM, mandag til og med fredag",
                GetDescription("*/5 15 * * MON-FRI"));
        }

        [Fact]
        public void TestDayOfWeekOnceInMonth()
        {
            Assert.Equal(
                "Hvert minutt, på den tredje mandag av måneden", GetDescription("* * * * MON#3"));
        }

        [Fact]
        public void TestLastDayOfTheWeekOfTheMonth()
        {
            Assert.Equal(
                "Hvert minutt, på den siste torsdag av måneden", GetDescription("* * * * 4L"));
        }

        [Fact]

        public void TestLastDayOfTheMonth()
        {
            Assert.Equal(
                "Hvert 5 minutt, på den siste dagen i måneden, bare i januar",
                GetDescription("*/5 * L JAN *"));
        }

        [Fact]

        public void TestLastWeekdayOfTheMonth()
        {
            Assert.Equal(
                "Hvert minutt, på den siste ukedagen i måneden", GetDescription("* * LW * *"));
        }

        [Fact]

        public void TestLastWeekdayOfTheMonth2()
        {
            Assert.Equal(
                "Hvert minutt, på den siste ukedagen i måneden", GetDescription("* * WL * *"));
        }

        [Fact]

        public void TestFirstWeekdayOfTheMonth()
        {
            Assert.Equal(
                "Hvert minutt, på den første ukedag av måneden", GetDescription("* * 1W * *"));
        }

        [Fact]

        public void TestFirstWeekdayOfTheMonth2()
        {
            Assert.Equal(
                "Hvert minutt, på den første ukedag av måneden", GetDescription("* * W1 * *"));
        }

        [Fact]

        public void TestParticularWeekdayOfTheMonth()
        {
            Assert.Equal(
                "Hvert minutt, på den ukedag nærmest dag 5 av måneden",
                GetDescription("* * 5W * *"));
        }

        [Fact]

        public void TestParticularWeekdayOfTheMonth2()
        {
            Assert.Equal(
                "Hvert minutt, på den ukedag nærmest dag 5 av måneden",
                GetDescription("* * W5 * *"));
        }

        [Fact]

        public void TestTimeOfDayWithSeconds()
        {
            Assert.Equal("På 02:02:30 PM", GetDescription("30 02 14 * * *"));
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
                "Sekundene fra 5 til og med 10 etter minuttet, minuttene fra 30 til og med 35 etter timen, mellom 10:00 AM og 12:59 PM",
                GetDescription("5-10 30-35 10-12 * * *"));
        }

        [Fact]

        public void TestEvery5MinutesAt30Seconds()
        {
            Assert.Equal(
                "På 30 sekunder etter minuttet, hvert 5 minutt", GetDescription("30 */5 * * * *"));
        }

        [Fact]

        public void TestMinutesPastTheHourRange()
        {
            Assert.Equal(
                "På 30 minutter etter timen, mellom 10:00 AM og 01:59 PM, bare på onsdag og fredag",
                GetDescription("0 30 10-13 ? * WED,FRI"));
        }

        [Fact]

        public void TestSecondsPastTheMinuteInterval()
        {
            Assert.Equal(
                "På 10 sekunder etter minuttet, hvert 5 minutt", GetDescription("10 0/5 * * * ?"));
        }

        [Fact]

        public void TestBetweenWithInterval()
        {
            Assert.Equal(
                "Hvert 3 minutt, minuttene fra 2 til og med 59 etter timen, på 01:00 AM, 09:00 AM, og 10:00 PM, mellom dag 11 og 26 av måneden, januar til og med juni",
                GetDescription("2-59/3 1,9,22 11-26 1-6 ?"));
        }

        [Fact]

        public void TestRecurringFirstOfMonth()
        {
            Assert.Equal("På 06:00 AM", GetDescription("0 0 6 1/1 * ?"));
        }

        [Fact]

        public void TestMinutesPastTheHour()
        {
            Assert.Equal("På 5 minutter etter timen", GetDescription("0 5 0/1 * * ?"));
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
                "På 12:23 PM, januar til og med februar, 2013 til og med 2014",
                GetDescription("23 12 * JAN-FEB * 2013-2014"));
        }

        [Fact]
        public void TestYearRange3()
        {
            Assert.Equal(
                "På 12:23 PM, januar til og med mars, 2013 til og med 2015",
                GetDescription("23 12 * JAN-MAR * 2013-2015"));
        }

        [Fact]
        public void TestSecondsInternalWithStepValue()
        {
            // GitHub Issue #49: https://github.com/bradymholt/cron-expression-descriptor/issues/49
            Assert.Equal("Hvert 30 sekund, starter på 5 sekunder etter minuttet", GetDescription("5/30 * * * * ?"));
        }

        [Fact]
        public void TestMinutesInternalWithStepValue()
        {
            Assert.Equal("Hvert 30 minutt, starter på 5 minutter etter timen", GetDescription("0 5/30 * * * ?"));
        }

        [Fact]
        public void TestHoursInternalWithStepValue()
        {
            Assert.Equal("Hvert sekund, hver 8 time, starter på 05:00 AM", GetDescription("* * 5/8 * * ?"));
        }

        [Fact]
        public void TestDayOfMonthInternalWithStepValue()
        {
            Assert.Equal("På 07:05 AM, hver 3 dag, starter på dag 2 av måneden", GetDescription("0 5 7 2/3 * ? *"));
        }

        [Fact]
        public void TestMonthInternalWithStepValue()
        {
            Assert.Equal("På 07:05 AM, hver 2 måned], mars til og med desember", GetDescription("0 5 7 ? 3/2 ? *"));
        }

        [Fact]
        public void TestDayOfWeekInternalWithStepValue()
        {
            Assert.Equal("På 07:05 AM, hver 3 ukedag, tirsdag til og med lørdag", GetDescription("0 5 7 ? * 2/3 *"));
        }

        [Fact]
        public void TestYearInternalWithStepValue()
        {
            Assert.Equal("På 07:05 AM, hvert 4 år, 2016 til og med 9999", GetDescription("0 5 7 ? * ? 2016/4"));
        }
    }
}
