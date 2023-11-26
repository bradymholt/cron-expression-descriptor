using Xunit;
using Assert = CronExpressionDescriptor.Test.Support.AssertExtensions;

namespace CronExpressionDescriptor.Test
{
    /// <summary>
    /// Tests for English
    /// </summary>
    public class TestFormatsHu : Support.BaseTestFormats
    {
        protected override string GetLocale()
        {
            return "hu";
        }

        [Fact]
        public void TestEveryMinute()
        {
            Assert.Equal("Minden perc", GetDescription("* * * * *"));
        }

        [Fact]
        public void TestEvery1Minute()
        {
            Assert.Equal("Minden perc", GetDescription("*/1 * * * *"));
            Assert.Equal("Minden perc", GetDescription("0 0/1 * * * ?"));
        }

        [Fact]
        public void TestEveryHour()
        {
            Assert.Equal("Minden óra", GetDescription("0 0 * * * ?"));
            Assert.Equal("Minden óra", GetDescription("0 0 0/1 * * ?"));
        }

        [Fact]
        public void TestTimeOfDayCertainDaysOfWeek()
        {
            Assert.Equal("23:00, hétfő-péntek", GetDescription("0 23 ? * MON-FRI"));
        }

        [Fact]
        public void TestEverySecond()
        {
            Assert.Equal("Minden másodperc", GetDescription("* * * * * *"));
        }

        [Fact]
        public void TestEvery45Seconds()
        {
            Assert.Equal("Minden 45. másodpercben", GetDescription("*/45 * * * * *"));
        }

        [Fact]
        public void TestEvery5Minutes()
        {
            Assert.Equal("Minden 5. percben", GetDescription("*/5 * * * *"));
            Assert.Equal("Minden 10. percben", GetDescription("0 0/10 * * * ?"));
        }

        [Fact]
        public void TestEvery5MinutesOnTheSecond()
        {
            Assert.Equal("Minden 5. percben", GetDescription("0 */5 * * * *"));
        }

        [Fact]
        public void TestWeekdaysAtTime()
        {
            Assert.Equal("11:30, hétfő-péntek", GetDescription("30 11 * * 1-5"));
        }

        [Fact]
        public void TestDailyAtTime()
        {
            Assert.Equal("11:30", GetDescription("30 11 * * *"));
        }

        [Fact]
        public void TestMinuteSpan()
        {
            Assert.Equal("Minden percben 11:00 és 11:10 között", GetDescription("0-10 11 * * *"));
        }

        [Fact]
        public void TestOneMonthOnly()
        {
            Assert.Equal("Minden perc, csak március", GetDescription("* * * 3 *"));
        }

        [Fact]
        public void TestTwoMonthsOnly()
        {
            Assert.Equal("Minden perc, csak március és június", GetDescription("* * * 3,6 *"));
        }

        [Fact]
        public void TestTwoTimesEachAfternoon()
        {
            Assert.Equal(" 14:30 és  16:30", GetDescription("30 14,16 * * *"));
        }

        [Fact]
        public void TestThreeTimesDaily()
        {
            Assert.Equal(" 06:30, 14:30 és  16:30", GetDescription("30 6,14,16 * * *"));
        }

        [Fact]
        public void TestOnceAWeek()
        {
            Assert.Equal("09:46, csak hétfő", GetDescription("46 9 * * 1"));
        }

        [Fact]
        public void TestDayOfMonth()
        {
            Assert.Equal("12:23, a hónap 15. napján", GetDescription("23 12 15 * *"));
        }

        [Fact]
        public void TestMonthName()
        {
            Assert.Equal("12:23, csak január", GetDescription("23 12 * JAN *"));
        }

        [Fact]
        public void TestLowerCaseMonthName()
        {
            Assert.Equal("12:23, csak január", GetDescription("23 12 * jan *"));
        }

        [Fact]
        public void TestDayOfMonthWithQuestionMark()
        {
            Assert.Equal("12:23, csak január", GetDescription("23 12 ? JAN *"));
        }

        [Fact]
        public void TestMonthNameRange2()
        {
            Assert.Equal("12:23, január-február", GetDescription("23 12 * JAN-FEB *"));
        }

        [Fact]
        public void TestMonthNameRange3()
        {
            Assert.Equal("12:23, január-március", GetDescription("23 12 * JAN-MAR *"));
        }

        [Fact]
        public void TestDayOfWeekName()
        {
            Assert.Equal("12:23, csak vasárnap", GetDescription("23 12 * * SUN"));
        }

        [Fact]
        public void TestDayOfWeekRange()
        {
            Assert.Equal("Minden 5. percben, 15:00 és 15:59 között, hétfő-péntek", GetDescription("*/5 15 * * MON-FRI"));
        }

        [Fact]
        public void TestDayOfWeekRangeWithDOWLowerCased()
        {
            Assert.Equal("Minden 5. percben, 15:00 és 15:59 között, hétfő-péntek", GetDescription("*/5 15 * * MoN-fri"));
        }

        [Fact]
        public void TestDayOfWeekOnceInMonth()
        {
            Assert.Equal("Minden perc, a/az harmadik hétfő a hónapban", GetDescription("* * * * MON#3"));
        }

        [Fact]
        public void TestLastDayOfTheWeekOfTheMonth()
        {
            Assert.Equal("Minden perc, a hónap utolsó csütörtök", GetDescription("* * * * 4L"));
        }

        [Fact]
        public void TestLastDayOfTheMonth()
        {
            Assert.Equal("Minden 5. percben, a hónap utolsó napja, csak január", GetDescription("*/5 * L JAN *"));
        }

        [Fact]
        public void TestLastDayOffset()
        {
            Assert.Equal("00:00, 5 nappal a hónap utolsó napja előtt", GetDescription("0 0 0 L-5 * ?"));
        }

        [Fact]
        public void TestLastWeekdayOfTheMonth()
        {
            Assert.Equal("Minden perc, a hónap utolsó hétköznapja", GetDescription("* * LW * *"));
        }

        [Fact]
        public void TestLastWeekdayOfTheMonth2()
        {
            Assert.Equal("Minden perc, a hónap utolsó hétköznapja", GetDescription("* * WL * *"));
        }

        [Fact]
        public void TestFirstWeekdayOfTheMonth()
        {
            Assert.Equal("Minden perc, a hónap első hétköznap", GetDescription("* * 1W * *"));
        }

        [Fact]
        public void TestThirteenthWeekdayOfTheMonth()
        {
            Assert.Equal("Minden perc, a hónap legközelebbi hétköznap 13. napján", GetDescription("* * 13W * *"));
        }

        [Fact]
        public void TestFirstWeekdayOfTheMonth2()
        {
            Assert.Equal("Minden perc, a hónap első hétköznap", GetDescription("* * W1 * *"));
        }

        [Fact]
        public void TestParticularWeekdayOfTheMonth()
        {
            Assert.Equal("Minden perc, a hónap legközelebbi hétköznap 5. napján", GetDescription("* * 5W * *"));
        }

        [Fact]
        public void TestParticularWeekdayOfTheMonth2()
        {
            Assert.Equal("Minden perc, a hónap legközelebbi hétköznap 5. napján", GetDescription("* * W5 * *"));
        }

        [Fact]
        public void TestTimeOfDayWithSeconds()
        {
            Assert.Equal("14:02:30", GetDescription("30 02 14 * * *"));
        }

        [Fact]
        public void TestSecondInternvals()
        {
            Assert.Equal("5-10 másodperccel egész perc után", GetDescription("5-10 * * * * *"));
        }

        [Fact]
        public void TestMultiPartSecond()
        {
            Assert.Equal("15 és 45 másodperccel egész perc után", GetDescription("15,45 * * * * *"));
        }

        [Fact]
        public void TestSecondMinutesHoursIntervals()
        {
            Assert.Equal("5-10 másodperccel egész perc után, 30-35 perccel egész óra után, 10:00 és 12:59 között", GetDescription("5-10 30-35 10-12 * * *"));
        }

        [Fact]
        public void TestEvery5MinutesAt30Seconds()
        {
            Assert.Equal("30 másodperccel egész perc után, minden 5. percben", GetDescription("30 */5 * * * *"));
        }

        [Fact]
        public void TestMinutesPastTheHourRange()
        {
            Assert.Equal("30 perccel egész óra után, 10:00 és 13:59 között, csak szerda és péntek", GetDescription("0 30 10-13 ? * WED,FRI"));
        }

        [Fact]
        public void TestSecondsPastTheMinuteInterval()
        {
            Assert.Equal("10 másodperccel egész perc után, minden 5. percben", GetDescription("10 0/5 * * * ?"));
        }

        [Fact]
        public void TestBetweenWithInterval()
        {
            Assert.Equal("Minden 3. percben, 2-59 perccel egész óra után, 01:00, 09:00, és 22:00, 11 és 26 nap között a hónapban, január-június", GetDescription("2-59/3 1,9,22 11-26 1-6 ?"));
        }

        [Fact]
        public void TestRecurringFirstOfMonth()
        {
            Assert.Equal("06:00", GetDescription("0 0 6 1/1 * ?"));
        }

        [Fact]
        public void TestMinutesPastTheHour()
        {
            Assert.Equal("5 perccel egész óra után", GetDescription("0 5 0/1 * * ?"));
        }

        [Fact]
        public void TestOneYearOnlyWithSeconds()
        {
            Assert.Equal("Minden másodperc, csak 2013", GetDescription("* * * * * * 2013"));
        }

        [Fact]
        public void TestOneYearOnlyWithoutSeconds()
        {
            Assert.Equal("Minden perc, csak 2013", GetDescription("* * * * * 2013"));
        }

        [Fact]
        public void TestTwoYearsOnly()
        {
            Assert.Equal("Minden perc, csak 2013 és 2014", GetDescription("* * * * * 2013,2014"));
        }

        [Fact]
        public void TestYearRange2()
        {
            Assert.Equal("12:23, január-február, 2013-2014", GetDescription("23 12 * JAN-FEB * 2013-2014"));
        }

        [Fact]
        public void TestYearRange3()
        {
            Assert.Equal("12:23, január-március, 2013-2015", GetDescription("23 12 * JAN-MAR * 2013-2015"));
        }

        [Fact]
        public void TestHourRange()
        {
            Assert.Equal("Minden 30. percben, 08:00 és 09:59 között, a hónap 5 és 20. napján", GetDescription("0 0/30 8-9 5,20 * ?"));
        }

        [Fact]
        public void TestDayOfWeekModifier()
        {
            Assert.Equal("12:23, a/az második vasárnap a hónapban", GetDescription("23 12 * * SUN#2"));
        }

        [Fact]
        public void TestDayOfWeekModifierWithSundayStartOne()
        {
            Options options = new Options();
            options.DayOfWeekStartIndexZero = false;

            Assert.Equal("12:23, a/az második vasárnap a hónapban", GetDescription("23 12 * * 1#2", options));
        }

        [Fact]
        public void TestHourRangeWithEveryPortion()
        {
            Assert.Equal("25 perccel egész óra után, minden 8. órában, 07:00 és 19:59 között", GetDescription("0 25 7-19/8 ? * *"));
        }

        [Fact]
        public void TestHourRangeWithTrailingZeroWithEveryPortion()
        {
            Assert.Equal("25 perccel egész óra után, minden 13. órában, 07:00 és 20:59 között", GetDescription("0 25 7-20/13 ? * *"));
        }

        [Fact]
        public void TestEvery3Day()
        {
            Assert.Equal("08:00, minden 3. nap", GetDescription("0 0 8 1/3 * ? *"));
        }

        [Fact]
        public void TestsEvery3DayOfTheWeek()
        {
            Assert.Equal("10:15, a hét 3. napján", GetDescription("0 15 10 ? * */3"));
        }

        [Fact]
        public void TestEvery2DayOfTheWeekInRange()
        {
            // GitHub Issue #58: https://github.com/bradymholt/cron-expression-descriptor/issues/58
            Assert.Equal("Minden másodperc, a hét 2. napján, hétfő-péntek", GetDescription("* * * ? * 1-5/2"));
        }

        [Fact]
        public void TestEvery2DayOfTheWeekInRangeWithSundayStartOne()
        {
            // GitHub Issue #59: https://github.com/bradymholt/cron-expression-descriptor/issues/59

            var options = new Options { DayOfWeekStartIndexZero = false };

            Assert.Equal("Minden másodperc, a hét 2. napján, hétfő-péntek",
                GetDescription("* * * ? * 2-6/2", options));
        }

        [Fact]
        public void TestMultiWithDayOfWeekStartIndexZeroFalse()
        {
            // Coverage for GitHub Issue #126: https://github.com/bradymholt/cron-expression-descriptor/issues/126
            var options = new Options { DayOfWeekStartIndexZero = false };

            Assert.Equal("Minden másodperc, csak vasárnap, hétfő, és kedd",
                GetDescription("* * * ? * 1,2,3", options));
        }

        [Fact]
        public void TestEvery3Month()
        {
            Assert.Equal("07:05, a hónap 2. napján, minden 3. hónapban", GetDescription("0 5 7 2 1/3 ? *"));
        }

        [Fact]
        public void TestEvery2Years()
        {
            Assert.Equal("06:15, a hónap 1. napján, csak január, minden 2. évben", GetDescription("0 15 6 1 1 ? 1/2"));
        }

        [Fact]
        public void TestMutiPartRangeMinutes()
        {
            Assert.Equal("2 és 4-5 perccel egész óra után, 01:00", GetDescription("2,4-5 1 * * *"));
        }

        [Fact]
        public void TestMutiPartRangeMinutes2()
        {
            Assert.Equal("2 és 26-28 perccel egész óra után, 18:00", GetDescription("2,26-28 18 * * *"));
        }

        [Fact]
        public void TrailingSpaceDoesNotCauseAWrongDescription()
        {
            // GitHub Issue #51: https://github.com/bradymholt/cron-expression-descriptor/issues/51
            Assert.Equal("07:00", GetDescription("0 7 * * * "));
        }

        [Fact]
        public void TestMultiPartDayOfTheWeek()
        {
            // GitHub Issue #44: https://github.com/bradymholt/cron-expression-descriptor/issues/44
            Assert.Equal("10:00, csak hétfő-csütörtök és vasárnap", GetDescription("0 00 10 ? * MON-THU,SUN *"));
        }

        [Fact]
        public void TestDayOfWeekWithDayOfMonth()
        {
            // GitHub Issue #46: https://github.com/bradymholt/cron-expression-descriptor/issues/46
            Assert.Equal("00:00, a hónap 1, 2, és 3. napján, csak szerda és péntek", GetDescription("0 0 0 1,2,3 * WED,FRI"));
        }

        [Fact]
        public void TestSecondsInternalWithStepValue()
        {
            // GitHub Issue #49: https://github.com/bradymholt/cron-expression-descriptor/issues/49
            Assert.Equal("Minden 30. másodpercben, kezdés 5 másodperccel egész perc után", GetDescription("5/30 * * * * ?"));
        }

        [Fact]
        public void TestMinutesInternalWithStepValue()
        {
            Assert.Equal("Minden 30. percben, kezdés 5 perccel egész óra után", GetDescription("0 5/30 * * * ?"));
        }

        [Fact]
        public void TestHoursInternalWithStepValue()
        {
            Assert.Equal("Minden másodperc, minden 8. órában, kezdés 05:00", GetDescription("* * 5/8 * * ?"));
        }

        [Fact]
        public void TestDayOfMonthInternalWithStepValue()
        {
            Assert.Equal("07:05, minden 3. nap, kezdés a hónap 2. napján", GetDescription("0 5 7 2/3 * ? *"));
        }

        [Fact]
        public void TestMonthInternalWithStepValue()
        {
            Assert.Equal("07:05, minden 2. hónapban, március-december", GetDescription("0 5 7 ? 3/2 ? *"));
        }

        [Fact]
        public void TestDayOfWeekInternalWithStepValue()
        {
            Assert.Equal("07:05, a hét 3. napján, kedd-szombat", GetDescription("0 5 7 ? * 2/3 *"));
        }

        [Fact]
        public void TestYearInternalWithStepValue()
        {
            Assert.Equal("07:05, minden 4. évben, 2016-9999", GetDescription("0 5 7 ? * ? 2016/4"));
        }

        [Fact]
        public void TestMinutesCombinedWithMultipleHourRanges()
        {
            Assert.Equal("1 perccel egész óra után, 01:00 és 03:00-04:59", GetDescription("1 1,3-4 * * *"));
        }

        [Fact]
        public void TestMinuteRangeConbinedWithSecondRange()
        {
            Assert.Equal("12-50 másodperccel egész perc után, 0-10 perccel egész óra után, 06:00, csak 2022", GetDescription("12-50 0-10 6 * * * 2022"));
        }

        [Fact]
        public void TestSecondsExpressionCombinedWithHoursListésSingleMinute()
        {
            Assert.Equal("At 5 seconds past the minute, at 30 minutes past the hour, at 06:00, 14:00, és 16:00, on day 5 of the month", GetDescription("5 30 6,14,16 5 * *"));
        }

        [Fact]
        public void TestMinuteRangeWithInterval()
        {
            Assert.Equal("Minden 3. percben, 0-20 perccel egész óra után, 09:00 és 09:59 között", GetDescription("0-20/3 9 * * *"));
        }

        [Fact]
        public void MinutesZero1()
        {
            Assert.Equal("Minden másodperc, 0 perccel egész óra után, minden 4. órában", GetDescription("* 0 */4 * * *"));
        }

        [Fact]
        public void MinutesZero2()
        {
            Assert.Equal("Minden 10. másodpercben, 0 perccel egész óra után", GetDescription("*/10 0 * * * *"));
        }

        [Fact]
        public void MinutesZero3()
        {
            Assert.Equal("Minden másodperc, 0 perccel egész óra után, 00:00 és 00:59 között", GetDescription("* 0 0 * * *"));
        }

        [Fact]
        public void MinutesZero4()
        {
            Assert.Equal("Minden perc, 00:00 és 00:59 között", GetDescription("* 0 * * *"));
        }

        [Fact]
        public void MinutesZero5()
        {
            Assert.Equal("Minden másodperc, 0 perccel egész óra után", GetDescription("* 0 * * * *"));
        }

        [Fact]
        public void Sunday7()
        {
            Assert.Equal("09:00, csak vasárnap", GetDescription("0 0 9 ? * 7"));
        }

        [Fact]
        public void EveryYear()
        {
            Assert.Equal("Minden 10. percben, hétfő-péntek", GetDescription("0/10 * ? * MON-FRI *"));

        }
    }
}
