using Xunit;
using Assert = CronExpressionDescriptor.Test.Support.AssertExtensions;

namespace CronExpressionDescriptor.Test
{
    /// <summary>
    /// Tests for Slovenian
    /// </summary>
    public class TestFormatsSl : Support.BaseTestFormats
    {
        protected override string GetLocale()
        {
            return "sl-SI";
        }

        [Fact]
        public void TestEveryMinute()
        {
            Assert.Equal("Vsako minuto", GetDescription("* * * * *"));
        }

        [Fact]
        public void TestEvery1Minute()
        {
            Assert.Equal("Vsako minuto", GetDescription("*/1 * * * *"));
            Assert.Equal("Vsako minuto", GetDescription("0 0/1 * * * ?"));
        }

        [Fact]
        public void TestEveryHour()
        {
            Assert.Equal("Vsako uro", GetDescription("0 0 * * * ?"));
            Assert.Equal("Vsako uro", GetDescription("0 0 0/1 * * ?"));
        }

        [Fact]
        public void TestTimeOfDayCertainDaysOfWeek()
        {
            Assert.Equal("Ob 23:00, od ponedeljek do petek", GetDescription("0 23 ? * MON-FRI"));
        }

        [Fact]
        public void TestEverySecond()
        {
            Assert.Equal("Vsako sekundo", GetDescription("* * * * * *"));
        }

        [Fact]
        public void TestEvery45Seconds()
        {
            Assert.Equal("Vsakih 45 sekund", GetDescription("*/45 * * * * *"));
        }

        [Fact]
        public void TestEvery5Minutes()
        {
            Assert.Equal("Vsakih 5 minut", GetDescription("*/5 * * * *"));
            Assert.Equal("Vsakih 10 minut", GetDescription("0 0/10 * * * ?"));
        }

        [Fact]
        public void TestEvery5MinutesOnTheSecond()
        {
            Assert.Equal("Vsakih 5 minut", GetDescription("0 */5 * * * *"));
        }

        [Fact]
        public void TestWeekdaysAtTime()
        {
            Assert.Equal("Ob 11:30, od ponedeljek do petek", GetDescription("30 11 * * 1-5"));
        }

        [Fact]
        public void TestDailyAtTime()
        {
            Assert.Equal("Ob 11:30", GetDescription("30 11 * * *"));
        }

        [Fact]
        public void TestMinuteSpan()
        {
            Assert.Equal("Vsako minuto od 11:00 do 11:10", GetDescription("0-10 11 * * *"));
        }

        [Fact]
        public void TestOneMonthOnly()
        {
            Assert.Equal("Vsako minuto, samo v marec", GetDescription("* * * 3 *"));
        }

        [Fact]
        public void TestTwoMonthsOnly()
        {
            Assert.Equal("Vsako minuto, samo v marec in junij", GetDescription("* * * 3,6 *"));
        }

        [Fact]
        public void TestTwoTimesEachAfternoon()
        {
            Assert.Equal("Ob 14:30 in 16:30", GetDescription("30 14,16 * * *"));
        }

        [Fact]
        public void TestThreeTimesDaily()
        {
            Assert.Equal("Ob 06:30, 14:30 in 16:30", GetDescription("30 6,14,16 * * *"));
        }

        [Fact]
        public void TestOnceAWeek()
        {
            Assert.Equal("Ob 09:46, samo v ponedeljek", GetDescription("46 9 * * 1"));
        }

        [Fact]
        public void TestDayOfMonth()
        {
            Assert.Equal("Ob 12:23, 15. dan v mesecu", GetDescription("23 12 15 * *"));
        }

        [Fact]
        public void TestMonthName()
        {
            Assert.Equal("Ob 12:23, samo v januar", GetDescription("23 12 * JAN *"));
        }

        [Fact]
        public void TestLowerCaseMonthName()
        {
            Assert.Equal("Ob 12:23, samo v januar", GetDescription("23 12 * jan *"));
        }

        [Fact]
        public void TestDayOfMonthWithQuestionMark()
        {
            Assert.Equal("Ob 12:23, samo v januar", GetDescription("23 12 ? JAN *"));
        }

        [Fact]
        public void TestMonthNameRange2()
        {
            Assert.Equal("Ob 12:23, od januar do februar", GetDescription("23 12 * JAN-FEB *"));
        }

        [Fact]
        public void TestMonthNameRange3()
        {
            Assert.Equal("Ob 12:23, od januar do marec", GetDescription("23 12 * JAN-MAR *"));
        }

        [Fact]
        public void TestDayOfWeekName()
        {
            Assert.Equal("Ob 12:23, samo v nedelja", GetDescription("23 12 * * SUN"));
        }

        [Fact]
        public void TestDayOfWeekRange()
        {
            Assert.Equal("Vsakih 5 minut, od 15:00 do 15:59, od ponedeljek do petek", GetDescription("*/5 15 * * MON-FRI"));
        }

        [Fact]
        public void TestDayOfWeekRangeWithDOWLowerCased()
        {
            Assert.Equal("Vsakih 5 minut, od 15:00 do 15:59, od ponedeljek do petek", GetDescription("*/5 15 * * MoN-fri"));
        }

        [Fact]
        public void TestDayOfWeekOnceInMonth()
        {
            Assert.Equal("Vsako minuto, tretji ponedeljek v mesecu", GetDescription("* * * * MON#3"));
        }

        [Fact]
        public void TestLastDayOfTheWeekOfTheMonth()
        {
            Assert.Equal("Vsako minuto, zadnji četrtek v mesecu", GetDescription("* * * * 4L"));
        }

        [Fact]
        public void TestLastDayOfTheMonth()
        {
            Assert.Equal("Vsakih 5 minut, zadnji dan v mesecu, samo v januar", GetDescription("*/5 * L JAN *"));
        }

        [Fact]
        public void TestLastDayOffset()
        {
            Assert.Equal("Ob 00:00, 5 dni pred koncem meseca", GetDescription("0 0 0 L-5 * ?"));
        }

        [Fact]
        public void TestLastWeekdayOfTheMonth()
        {
            Assert.Equal("Vsako minuto, zadnji delovni dan v mesecu", GetDescription("* * LW * *"));
        }

        [Fact]
        public void TestLastWeekdayOfTheMonth2()
        {
            Assert.Equal("Vsako minuto, zadnji delovni dan v mesecu", GetDescription("* * WL * *"));
        }

        [Fact]
        public void TestFirstWeekdayOfTheMonth()
        {
            Assert.Equal("Vsako minuto, prvi delovni dan v mesecu", GetDescription("* * 1W * *"));
        }

        [Fact]
        public void TestThirteenthWeekdayOfTheMonth()
        {
            Assert.Equal("Vsako minuto, delovni dan, najbližji 13. dnevu v mesecu", GetDescription("* * 13W * *"));
        }

        [Fact]
        public void TestFirstWeekdayOfTheMonth2()
        {
            Assert.Equal("Vsako minuto, prvi delovni dan v mesecu", GetDescription("* * W1 * *"));
        }

        [Fact]
        public void TestParticularWeekdayOfTheMonth()
        {
            Assert.Equal("Vsako minuto, delovni dan, najbližji 5. dnevu v mesecu", GetDescription("* * 5W * *"));
        }

        [Fact]
        public void TestParticularWeekdayOfTheMonth2()
        {
            Assert.Equal("Vsako minuto, delovni dan, najbližji 5. dnevu v mesecu", GetDescription("* * W5 * *"));
        }

        [Fact]
        public void TestTimeOfDayWithSeconds()
        {
            Assert.Equal("Ob 14:02:30", GetDescription("30 02 14 * * *"));
        }

        [Fact]
        public void TestSecondInternvals()
        {
            Assert.Equal("Sekunde od 5 do 10", GetDescription("5-10 * * * * *"));
        }

        [Fact]
        public void TestMultiPartSecond()
        {
            Assert.Equal("Ob 15 in 45. sekundi", GetDescription("15,45 * * * * *"));
        }

        [Fact]
        public void TestSecondMinutesHoursIntervals()
        {
            Assert.Equal("Sekunde od 5 do 10, minute od 30 do 35, od 10:00 do 12:59", GetDescription("5-10 30-35 10-12 * * *"));
        }

        [Fact]
        public void TestEvery5MinutesAt30Seconds()
        {
            Assert.Equal("Ob 30. sekundi, vsakih 5 minut", GetDescription("30 */5 * * * *"));
        }

        [Fact]
        public void TestMinutesPastTheHourRange()
        {
            Assert.Equal("Ob 30. minuti, od 10:00 do 13:59, samo v sreda in petek", GetDescription("0 30 10-13 ? * WED,FRI"));
        }

        [Fact]
        public void TestSecondsPastTheMinuteInterval()
        {
            Assert.Equal("Ob 10. sekundi, vsakih 5 minut", GetDescription("10 0/5 * * * ?"));
        }

        [Fact]
        public void TestBetweenWithInterval()
        {
            Assert.Equal("Vsakih 3 minut, minute od 2 do 59, ob 01:00, 09:00, in 22:00, od 11. do 26. dne v mesecu, od januar do junij", GetDescription("2-59/3 1,9,22 11-26 1-6 ?"));
        }

        [Fact]
        public void TestRecurringFirstOfMonth()
        {
            Assert.Equal("Ob 06:00", GetDescription("0 0 6 1/1 * ?"));
        }

        [Fact]
        public void TestMinutesPastTheHour()
        {
            Assert.Equal("Ob 5. minuti", GetDescription("0 5 0/1 * * ?"));
        }

        [Fact]
        public void TestOneYearOnlyWithSeconds()
        {
            Assert.Equal("Vsako sekundo, samo v 2013", GetDescription("* * * * * * 2013"));
        }

        [Fact]
        public void TestOneYearOnlyWithoutSeconds()
        {
            Assert.Equal("Vsako minuto, samo v 2013", GetDescription("* * * * * 2013"));
        }

        [Fact]
        public void TestTwoYearsOnly()
        {
            Assert.Equal("Vsako minuto, samo v 2013 in 2014", GetDescription("* * * * * 2013,2014"));
        }

        [Fact]
        public void TestYearRange2()
        {
            Assert.Equal("Ob 12:23, od januar do februar, od 2013 do 2014", GetDescription("23 12 * JAN-FEB * 2013-2014"));
        }

        [Fact]
        public void TestYearRange3()
        {
            Assert.Equal("Ob 12:23, od januar do marec, od 2013 do 2015", GetDescription("23 12 * JAN-MAR * 2013-2015"));
        }

        [Fact]
        public void TestHourRange()
        {
            Assert.Equal("Vsakih 30 minut, od 08:00 do 09:59, 5 in 20. dan v mesecu", GetDescription("0 0/30 8-9 5,20 * ?"));
        }

        [Fact]
        public void TestDayOfWeekModifier()
        {
            Assert.Equal("Ob 12:23, drugi nedelja v mesecu", GetDescription("23 12 * * SUN#2"));
        }

        [Fact]
        public void TestDayOfWeekModifierWithSundayStartOne()
        {
            Options options = new Options();
            options.DayOfWeekStartIndexZero = false;

            Assert.Equal("Ob 12:23, drugi nedelja v mesecu", GetDescription("23 12 * * 1#2", options));
        }

        [Fact]
        public void TestHourRangeWithEveryPortion()
        {
            Assert.Equal("Ob 25. minuti, vsakih 8 ur, od 07:00 do 19:59", GetDescription("0 25 7-19/8 ? * *"));
        }

        [Fact]
        public void TestHourRangeWithTrailingZeroWithEveryPortion()
        {
            Assert.Equal("Ob 25. minuti, vsakih 13 ur, od 07:00 do 20:59", GetDescription("0 25 7-20/13 ? * *"));
        }

        [Fact]
        public void TestEvery3Day()
        {
            Assert.Equal("Ob 08:00, vsakih 3 dni", GetDescription("0 0 8 1/3 * ? *"));
        }

        [Fact]
        public void TestsEvery3DayOfTheWeek()
        {
            Assert.Equal("Ob 10:15, vsakih 3 dni v tednu", GetDescription("0 15 10 ? * */3"));
        }

        [Fact]
        public void TestEvery2DayOfTheWeekInRange()
        {
            // GitHub Issue #58: https://github.com/bradymholt/cron-expression-descriptor/issues/58
            Assert.Equal("Vsako sekundo, vsakih 2 dni v tednu, od ponedeljek do petek", GetDescription("* * * ? * 1-5/2"));
        }

        [Fact]
        public void TestEvery2DayOfTheWeekInRangeWithSundayStartOne()
        {
            // GitHub Issue #59: https://github.com/bradymholt/cron-expression-descriptor/issues/59

            var options = new Options { DayOfWeekStartIndexZero = false };

            Assert.Equal("Vsako sekundo, vsakih 2 dni v tednu, od ponedeljek do petek",
                GetDescription("* * * ? * 2-6/2", options));
        }

        [Fact]
        public void TestEvery3Month()
        {
            Assert.Equal("Ob 07:05, 2. dan v mesecu, vsakih 3 mesecev", GetDescription("0 5 7 2 1/3 ? *"));
        }

        [Fact]
        public void TestEvery2Years()
        {
            Assert.Equal("Ob 06:15, 1. dan v mesecu, samo v januar, vsakih 2 let", GetDescription("0 15 6 1 1 ? 1/2"));
        }

        [Fact]
        public void TestMutiPartRangeMinutes()
        {
            Assert.Equal("Ob 2 in od 4 do 5. minuti, ob 01:00", GetDescription("2,4-5 1 * * *"));
        }

        [Fact]
        public void TestMutiPartRangeMinutes2()
        {
            Assert.Equal("Ob 2 in od 26 do 28. minuti, ob 18:00", GetDescription("2,26-28 18 * * *"));
        }

        [Fact]
        public void TrailingSpaceDoesNotCauseAWrongDescription()
        {
            // GitHub Issue #51: https://github.com/bradymholt/cron-expression-descriptor/issues/51
            Assert.Equal("Ob 07:00", GetDescription("0 7 * * * "));
        }

        [Fact]
        public void TestMultiPartDayOfTheWeek()
        {
            // GitHub Issue #44: https://github.com/bradymholt/cron-expression-descriptor/issues/44
            Assert.Equal("Ob 10:00, samo v od ponedeljek do četrtek in nedelja", GetDescription("0 00 10 ? * MON-THU,SUN *"));
        }

        [Fact]
        public void TestDayOfWeekWithDayOfMonth()
        {
            // GitHub Issue #46: https://github.com/bradymholt/cron-expression-descriptor/issues/46
            Assert.Equal("Ob 00:00, 1, 2, in 3. dan v mesecu, samo v sreda in petek", GetDescription("0 0 0 1,2,3 * WED,FRI"));
        }

        [Fact]
        public void TestSecondsInternalWithStepValue()
        {
            // GitHub Issue #49: https://github.com/bradymholt/cron-expression-descriptor/issues/49
            Assert.Equal("Vsakih 30 sekund, začenši ob 5. sekundi", GetDescription("5/30 * * * * ?"));
        }

        [Fact]
        public void TestMinutesInternalWithStepValue()
        {
            Assert.Equal("Vsakih 30 minut, začenši ob 5. minuti", GetDescription("0 5/30 * * * ?"));
        }

        [Fact]
        public void TestHoursInternalWithStepValue()
        {
            Assert.Equal("Vsako sekundo, vsakih 8 ur, začenši ob 05:00", GetDescription("* * 5/8 * * ?"));
        }

        [Fact]
        public void TestDayOfMonthInternalWithStepValue()
        {
            Assert.Equal("Ob 07:05, vsakih 3 dni, začenši 2. dan v mesecu", GetDescription("0 5 7 2/3 * ? *"));
        }

        [Fact]
        public void TestMonthInternalWithStepValue()
        {
            Assert.Equal("Ob 07:05, vsakih 2 mesecev, od marec do december", GetDescription("0 5 7 ? 3/2 ? *"));
        }

        [Fact]
        public void TestDayOfWeekInternalWithStepValue()
        {
            Assert.Equal("Ob 07:05, vsakih 3 dni v tednu, od torek do sobota", GetDescription("0 5 7 ? * 2/3 *"));
        }

        [Fact]
        public void TestYearInternalWithStepValue()
        {
            Assert.Equal("Ob 07:05, vsakih 4 let, od 2016 do 9999", GetDescription("0 5 7 ? * ? 2016/4"));
        }

        [Fact]
        public void TestMinutesCombinedWithMultipleHourRanges()
        {
            Assert.Equal("Ob 1. minuti, ob 01:00 in od 03:00 do 04:59", GetDescription("1 1,3-4 * * *"));
        }

        [Fact]
        public void TestMinuteRangeConbinedWithSecondRange()
        {
            Assert.Equal("Sekunde od 12 do 50, minute od 0 do 10, ob 06:00, samo v 2022", GetDescription("12-50 0-10 6 * * * 2022"));
        }

        [Fact]
        public void TestSecondsExpressionCombinedWithHoursListAndSingleMinute()
{            Assert.Equal("Ob 5. sekundi, ob 30. minuti, ob 06:00, 14:00, in 16:00, 5. dan v mesecu", GetDescription("5 30 6,14,16 5 * *"));
        }
    }
}
