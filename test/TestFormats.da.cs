using Xunit;
using Assert = CronExpressionDescriptor.Test.Support.AssertExtensions;

namespace CronExpressionDescriptor.Test
{
    /// <summary>
    /// Tests for Danish
    /// </summary>
    public class TestFormatsDA : Support.BaseTestFormats
    {
        protected override string GetLocale()
        {
            return "da-DK";
        }

        [Fact]
        public void TestEveryMinute()
        {
            Assert.Equal("Hvert minut", GetDescription("* * * * *"));
        }

        [Fact]
        public void TestEvery1Minute()
        {
            Assert.Equal("Hvert minut", GetDescription("*/1 * * * *"));
            Assert.Equal("Hvert minut", GetDescription("0 0/1 * * * ?"));
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
            Assert.Equal("Kl 23:00, mandag til og med fredag", GetDescription("0 23 ? * MON-FRI"));
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
            Assert.Equal("Hvert 5. minut", GetDescription("*/5 * * * *"));
            Assert.Equal("Hvert 10. minut", GetDescription("0 0/10 * * * ?"));
        }

        [Fact]
        public void TestEvery5MinutesOnTheSecond()
        {
            Assert.Equal("Hvert 5. minut", GetDescription("0 */5 * * * *"));
        }

        [Fact]
        public void TestWeekdaysAtTime()
        {
            Assert.Equal("Kl 11:30, mandag til og med fredag", GetDescription("30 11 * * 1-5"));
        }

        [Fact]
        public void TestDailyAtTime()
        {
            Assert.Equal("Kl 11:30", GetDescription("30 11 * * *"));
        }

        [Fact]
        public void TestMinuteSpan()
        {
            Assert.Equal("Hvert minut mellem 11:00 og 11:10", GetDescription("0-10 11 * * *"));
        }

        [Fact]
        public void TestOneMonthOnly()
        {
            Assert.Equal("Hvert minut, kun i marts", GetDescription("* * * 3 *"));
        }

        [Fact]
        public void TestTwoMonthsOnly()
        {
            Assert.Equal("Hvert minut, kun i marts og juni", GetDescription("* * * 3,6 *"));
        }

        [Fact]
        public void TestTwoTimesEachAfternoon()
        {
            Assert.Equal("Kl 14:30 og 16:30", GetDescription("30 14,16 * * *"));
        }

        [Fact]
        public void TestThreeTimesDaily()
        {
            Assert.Equal("Kl 06:30, 14:30 og 16:30", GetDescription("30 6,14,16 * * *"));
        }

        [Fact]
        public void TestOnceAWeek()
        {
            Assert.Equal("Kl 09:46, kun mandag", GetDescription("46 9 * * 1"));
        }

        [Fact]
        public void TestDayOfMonth()
        {
            Assert.Equal("Kl 12:23, på dag 15 i måneden", GetDescription("23 12 15 * *"));
        }

        [Fact]
        public void TestMonthName()
        {
            Assert.Equal("Kl 12:23, kun i januar", GetDescription("23 12 * JAN *"));
        }

        [Fact]
        public void TestLowerCaseMonthName()
        {
            Assert.Equal("Kl 12:23, kun i januar", GetDescription("23 12 * jan *"));
        }

        [Fact]
        public void TestDayOfMonthWithQuestionMark()
        {
            Assert.Equal("Kl 12:23, kun i januar", GetDescription("23 12 ? JAN *"));
        }

        [Fact]
        public void TestMonthNameRange2()
        {
            Assert.Equal("Kl 12:23, januar til og med februar", GetDescription("23 12 * JAN-FEB *"));
        }

        [Fact]
        public void TestMonthNameRange3()
        {
            Assert.Equal("Kl 12:23, januar til og med marts", GetDescription("23 12 * JAN-MAR *"));
        }

        [Fact]
        public void TestDayOfWeekName()
        {
            Assert.Equal("Kl 12:23, kun søndag", GetDescription("23 12 * * SUN"));
        }

        [Fact]
        public void TestDayOfWeekRange()
        {
            Assert.Equal("Hvert 5. minut, mellem 15:00 og 15:59, mandag til og med fredag", GetDescription("*/5 15 * * MON-FRI"));
        }

        [Fact]
        public void TestDayOfWeekRangeWithDOWLowerCased()
        {
            Assert.Equal("Hvert 5. minut, mellem 15:00 og 15:59, mandag til og med fredag", GetDescription("*/5 15 * * MoN-fri"));
        }

        [Fact]
        public void TestDayOfWeekOnceInMonth()
        {
            Assert.Equal("Hvert minut, på den tredje mandag i måneden", GetDescription("* * * * MON#3"));
        }

        [Fact]
        public void TestLastDayOfTheWeekOfTheMonth()
        {
            Assert.Equal("Hvert minut, på den sidste torsdag i måneden", GetDescription("* * * * 4L"));
        }

        [Fact]
        public void TestLastDayOfTheMonth()
        {
            Assert.Equal("Hvert 5. minut, på den sidste dag i måneden, kun i januar", GetDescription("*/5 * L JAN *"));
        }

        [Fact]
        public void TestLastDayOffset()
        {
            Assert.Equal("Kl 00:00, 5 dage før den sidste dag i måneden", GetDescription("0 0 0 L-5 * ?"));
        }

        [Fact]
        public void TestLastWeekdayOfTheMonth()
        {
            Assert.Equal("Hvert minut, på den sidste hverdag i måneden", GetDescription("* * LW * *"));
        }

        [Fact]
        public void TestLastWeekdayOfTheMonth2()
        {
            Assert.Equal("Hvert minut, på den sidste hverdag i måneden", GetDescription("* * WL * *"));
        }

        [Fact]
        public void TestFirstWeekdayOfTheMonth()
        {
            Assert.Equal("Hvert minut, på den første hverdag i måneden", GetDescription("* * 1W * *"));
        }

        [Fact]
        public void TestThirteenthWeekdayOfTheMonth()
        {
            Assert.Equal("Hvert minut, på den hverdag nærmest dag 13 i måneden", GetDescription("* * 13W * *"));
        }

        [Fact]
        public void TestFirstWeekdayOfTheMonth2()
        {
            Assert.Equal("Hvert minut, på den første hverdag i måneden", GetDescription("* * W1 * *"));
        }

        [Fact]
        public void TestParticularWeekdayOfTheMonth()
        {
            Assert.Equal("Hvert minut, på den hverdag nærmest dag 5 i måneden", GetDescription("* * 5W * *"));
        }

        [Fact]
        public void TestParticularWeekdayOfTheMonth2()
        {
            Assert.Equal("Hvert minut, på den hverdag nærmest dag 5 i måneden", GetDescription("* * W5 * *"));
        }

        [Fact]
        public void TestTimeOfDayWithSeconds()
        {
            Assert.Equal("Kl 14:02:30", GetDescription("30 02 14 * * *"));
        }

        [Fact]
        public void TestSecondInternvals()
        {
            Assert.Equal("Sekunderne fra 5 til og med 10 hvert minut", GetDescription("5-10 * * * * *"));
        }

        [Fact]
        public void TestMultiPartSecond()
        {
            Assert.Equal("15 og 45 sekunder efter minutskift", GetDescription("15,45 * * * * *"));
        }
        
        [Fact]
        public void TestSecondMinutesHoursIntervals()
        {
            Assert.Equal("Sekunderne fra 5 til og med 10 hvert minut, minutterne fra 30 til og med 35 hver time, mellem 10:00 og 12:59", GetDescription("5-10 30-35 10-12 * * *"));
        }

        [Fact]
        public void TestEvery5MinutesAt30Seconds()
        {
            Assert.Equal("30 sekunder efter minutskift, hvert 5. minut", GetDescription("30 */5 * * * *"));
        }

        [Fact]
        public void TestMinutesPastTheHourRange()
        {
            Assert.Equal("30 minutter efter timeskift, mellem 10:00 og 13:59, kun onsdag og fredag", GetDescription("0 30 10-13 ? * WED,FRI"));
        }

        [Fact]
        public void TestSecondsPastTheMinuteInterval()
        {
            Assert.Equal("10 sekunder efter minutskift, hvert 5. minut", GetDescription("10 0/5 * * * ?"));
        }

        [Fact]
        public void TestBetweenWithInterval()
        {
            Assert.Equal("Hvert 3. minut, minutterne fra 2 til og med 59 hver time, kl 01:00, 09:00, og 22:00, mellem dag 11 og 26 i måneden, januar til og med juni", GetDescription("2-59/3 1,9,22 11-26 1-6 ?"));
        }

        [Fact]
        public void TestRecurringFirstOfMonth()
        {
            Assert.Equal("Kl 06:00", GetDescription("0 0 6 1/1 * ?"));
        }

        [Fact]
        public void TestMinutesPastTheHour()
        {
            Assert.Equal("5 minutter efter timeskift", GetDescription("0 5 0/1 * * ?"));
        }

        [Fact]
        public void TestOneYearOnlyWithSeconds()
        {
            Assert.Equal("Hvert sekund, kun i 2013", GetDescription("* * * * * * 2013"));
        }

        [Fact]
        public void TestOneYearOnlyWithoutSeconds()
        {
            Assert.Equal("Hvert minut, kun i 2013", GetDescription("* * * * * 2013"));
        }

        [Fact]
        public void TestTwoYearsOnly()
        {
            Assert.Equal("Hvert minut, kun i 2013 og 2014", GetDescription("* * * * * 2013,2014"));
        }

        [Fact]
        public void TestYearRange2()
        {
            Assert.Equal("Kl 12:23, januar til og med februar, 2013 til og med 2014", GetDescription("23 12 * JAN-FEB * 2013-2014"));
        }

        [Fact]
        public void TestYearRange3()
        {
            Assert.Equal("Kl 12:23, januar til og med marts, 2013 til og med 2015", GetDescription("23 12 * JAN-MAR * 2013-2015"));
        }

        [Fact]
        public void TestHourRange()
        {
            Assert.Equal("Hvert 30. minut, mellem 08:00 og 09:59, på dag 5 og 20 i måneden", GetDescription("0 0/30 8-9 5,20 * ?"));
        }

        [Fact]
        public void TestDayOfWeekModifier()
        {
            Assert.Equal("Kl 12:23, på den anden søndag i måneden", GetDescription("23 12 * * SUN#2"));
        }

        [Fact]
        public void TestDayOfWeekModifierWithSundayStartOne()
        {
            Options options = new Options();
            options.DayOfWeekStartIndexZero = false;
            Assert.Equal("Kl 12:23, på den anden søndag i måneden", GetDescription("23 12 * * 1#2", options));
        }

        [Fact]
        public void TestHourRangeWithEveryPortion()
        {
            Assert.Equal("25 minutter efter timeskift, hver 8. time, mellem 07:00 og 19:59", GetDescription("0 25 7-19/8 ? * *"));
        }

        [Fact]
        public void TestHourRangeWithTrailingZeroWithEveryPortion()
        {
            Assert.Equal("25 minutter efter timeskift, hver 13. time, mellem 07:00 og 20:59", GetDescription("0 25 7-20/13 ? * *"));
        }

        [Fact]
        public void TestEvery3Day()
        {
            Assert.Equal("Kl 08:00, hver 3. dag", GetDescription("0 0 8 1/3 * ? *"));
        }

        [Fact]
        public void TestsEvery3DayOfTheWeek()
        {
            Assert.Equal("Kl 10:15, hver 3. ugedag", GetDescription("0 15 10 ? * */3"));
        }

        [Fact]
        public void TestEvery2DayOfTheWeekInRange()
        {
            Assert.Equal("Hvert sekund, hver 2. ugedag, mandag til og med fredag", GetDescription("* * * ? * 1-5/2"));
        }

        [Fact]
        public void TestEvery2DayOfTheWeekInRangeWithSundayStartOne()
        {
            var options = new Options { DayOfWeekStartIndexZero = false };
            Assert.Equal("Hvert sekund, hver 2. ugedag, mandag til og med fredag", GetDescription("* * * ? * 2-6/2", options));
        }

        [Fact]
        public void TestEvery3Month()
        {
            Assert.Equal("Kl 07:05, på dag 2 i måneden, hver 3. måned", GetDescription("0 5 7 2 1/3 ? *"));
        }

        [Fact]
        public void TestEvery2Years()
        {
            Assert.Equal("Kl 06:15, på dag 1 i måneden, kun i januar, hvert 2. år", GetDescription("0 15 6 1 1 ? 1/2"));
        }

        [Fact]
        public void TestMutiPartRangeMinutes()
        {
            Assert.Equal("2 og 4 til og med 5 minutter efter timeskift, kl 01:00", GetDescription("2,4-5 1 * * *"));
        }
        
        [Fact]
        public void TestMutiPartRangeMinutes2()
        {
            Assert.Equal("2 og 26 til og med 28 minutter efter timeskift, kl 18:00", GetDescription("2,26-28 18 * * *"));
        }
        
        [Fact]
        public void TrailingSpaceDoesNotCauseAWrongDescription()
        {
            Assert.Equal("Kl 07:00", GetDescription("0 7 * * * "));
        }
        
        [Fact]
        public void TestMultiPartDayOfTheWeek()
        {
            Assert.Equal("Kl 10:00, kun mandag til og med torsdag og søndag", GetDescription("0 00 10 ? * MON-THU,SUN *"));
        }
        
        [Fact]
        public void TestDayOfWeekWithDayOfMonth()
        {
            Assert.Equal("Kl 00:00, på dag 1, 2, og 3 i måneden, kun onsdag og fredag", GetDescription("0 0 0 1,2,3 * WED,FRI"));
        }
        
        [Fact]
        public void TestSecondsInternalWithStepValue()
        {
            Assert.Equal("Hvert 30. sekund, startende 5 sekunder efter minutskift", GetDescription("5/30 * * * * ?"));
        }

        [Fact]
        public void TestMinutesInternalWithStepValue()
        {
            Assert.Equal("Hvert 30. minut, startende 5 minutter efter timeskift", GetDescription("0 5/30 * * * ?"));
        }

        [Fact]
        public void TestHoursInternalWithStepValue()
        {
            Assert.Equal("Hvert sekund, hver 8. time, startende kl 05:00", GetDescription("* * 5/8 * * ?"));
        }

        [Fact]
        public void TestDayOfMonthInternalWithStepValue()
        {
            Assert.Equal("Kl 07:05, hver 3. dag, startende på dag 2 i måneden", GetDescription("0 5 7 2/3 * ? *"));
        }

        [Fact]
        public void TestMonthInternalWithStepValue()
        {
            Assert.Equal("Kl 07:05, hver 2. måned, marts til og med december", GetDescription("0 5 7 ? 3/2 ? *"));
        }

        [Fact]
        public void TestDayOfWeekInternalWithStepValue()
        {
            Assert.Equal("Kl 07:05, hver 3. ugedag, tirsdag til og med lørdag", GetDescription("0 5 7 ? * 2/3 *"));
        }

        [Fact]
        public void TestYearInternalWithStepValue()
        {
            Assert.Equal("Kl 07:05, hvert 4. år, 2016 til og med 9999", GetDescription("0 5 7 ? * ? 2016/4"));
        }
        
        [Fact]
        public void TestMinitesCombinedWithMultipleHourRanges()
        {
            Assert.Equal("1 minutter efter timeskift, kl 01:00 og 03:00 til og med 04:59", GetDescription("1 1,3-4 * * *"));
        }
    }
}
