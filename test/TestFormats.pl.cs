using Xunit;

namespace CronExpressionDescriptor.Test
{
    /// <summary>
    /// Tests for Polish translation
    /// </summary>
    public class TestFormatsPL : Support.BaseTestFormats
    {
        protected override string GetLocale()
        {
            return "pl-PL";
        }

        [Fact]
        public void TestEveryMinute()
        {
            Assert.Equal("Co minutę", GetDescription("* * * * *"));
        }

        [Fact]
        public void TestEvery1Minute()
        {
            Assert.Equal("Co minutę", GetDescription("*/1 * * * *"));
            Assert.Equal("Co minutę", GetDescription("0 0/1 * * * ?"));
        }

        [Fact]
        public void TestEveryHour()
        {
            Assert.Equal("Co godzinę", GetDescription("0 0 * * * ?"));
            Assert.Equal("Co godzinę", GetDescription("0 0 0/1 * * ?"));
        }

        [Fact]
        public void TestTimeOfDayCertainDaysOfWeek()
        {
            Assert.Equal("O 23:00, od poniedziałek do piątek", GetDescription("0 23 ? * MON-FRI"));
        }

        [Fact]
        public void TestEverySecond()
        {
            Assert.Equal("Co sekundę", GetDescription("* * * * * *"));
        }

        [Fact]
        public void TestEvery45Seconds()
        {
            Assert.Equal("Co 45 sekund", GetDescription("*/45 * * * * *"));
        }

        [Fact]
        public void TestEvery5Minutes()
        {
            Assert.Equal("Co 5 minut", GetDescription("*/5 * * * *"));
            Assert.Equal("Co 10 minut", GetDescription("0 0/10 * * * ?"));
        }

        [Fact]
        public void TestEvery5MinutesOnTheSecond()
        {
            Assert.Equal("Co 5 minut", GetDescription("0 */5 * * * *"));
        }

        [Fact]
        public void TestWeekdaysAtTime()
        {
            Assert.Equal("O 11:30, od poniedziałek do piątek", GetDescription("30 11 * * 1-5"));
        }

        [Fact]
        public void TestDailyAtTime()
        {
            Assert.Equal("O 11:30", GetDescription("30 11 * * *"));
        }

        [Fact]
        public void TestMinuteSpan()
        {
            Assert.Equal("Co minutę od 11:00 do 11:10", GetDescription("0-10 11 * * *"));
        }

        [Fact]
        public void TestOneMonthOnly()
        {
            Assert.Equal("Co minutę, tylko marzec", GetDescription("* * * 3 *"));
        }

        [Fact]
        public void TestTwoMonthsOnly()
        {
            Assert.Equal("Co minutę, tylko marzec i czerwiec", GetDescription("* * * 3,6 *"));
        }

        [Fact]
        public void TestTwoTimesEachAfternoon()
        {
            Assert.Equal("O 14:30 i 16:30", GetDescription("30 14,16 * * *"));
        }

        [Fact]
        public void TestThreeTimesDaily()
        {
            Assert.Equal("O 06:30, 14:30 i 16:30", GetDescription("30 6,14,16 * * *"));
        }

        [Fact]
        public void TestOnceAWeek()
        {
            Assert.Equal("O 09:46, tylko poniedziałek", GetDescription("46 9 * * 1"));
        }

        [Fact]
        public void TestDayOfMonth()
        {
            Assert.Equal("O 12:23, 15-ego dnia miesiąca", GetDescription("23 12 15 * *"));
        }

        [Fact]
        public void TestMonthName()
        {
            Assert.Equal("O 12:23, tylko styczeń", GetDescription("23 12 * JAN *"));
        }

        [Fact]
        public void TestDayOfMonthWithQuestionMark()
        {
            Assert.Equal("O 12:23, tylko styczeń", GetDescription("23 12 ? JAN *"));
        }

        [Fact]
        public void TestMonthNameRange2()
        {
            Assert.Equal("O 12:23, od styczeń do luty", GetDescription("23 12 * JAN-FEB *"));
        }

        [Fact]
        public void TestMonthNameRange3()
        {
            Assert.Equal("O 12:23, od styczeń do marzec", GetDescription("23 12 * JAN-MAR *"));
        }

        [Fact]
        public void TestDayOfWeekName()
        {
            Assert.Equal("O 12:23, tylko niedziela", GetDescription("23 12 * * SUN"));
        }

        [Fact]
        public void TestDayOfWeekRange()
        {
            Assert.Equal("Co 5 minut, od 15:00 do 15:59, od poniedziałek do piątek", GetDescription("*/5 15 * * MON-FRI"));
        }

        [Fact]
        public void TestDayOfWeekOnceInMonth()
        {
            Assert.Equal("Co minutę, trzeci poniedziałek miesiąca", GetDescription("* * * * MON#3"));
        }

        [Fact]
        public void TestLastDayOfTheWeekOfTheMonth()
        {
            Assert.Equal("Co minutę, ostatni czwartek miesiąca", GetDescription("* * * * 4L"));
        }

        [Fact]
        public void TestLastDayOfTheMonth()
        {
            Assert.Equal("Co 5 minut, ostatni dzień miesiąca, tylko styczeń", GetDescription("*/5 * L JAN *"));
        }

        [Fact]
        public void TestLastWeekdayOfTheMonth()
        {
            Assert.Equal("Co minutę, ostatni dzień roboczy miesiąca", GetDescription("* * LW * *"));
        }

        [Fact]
        public void TestLastWeekdayOfTheMonth2()
        {
            Assert.Equal("Co minutę, ostatni dzień roboczy miesiąca", GetDescription("* * WL * *"));
        }

        [Fact]
        public void TestFirstWeekdayOfThseMonth()
        {
            Assert.Equal("Co minutę, pierwszy dzień roboczy miesiąca", GetDescription("* * 1W * *"));
        }

        [Fact]
        public void TestThirteenthWeekdayOfTheMonth()
        {
            Assert.Equal("Co minutę, dzień roboczy najbliższy 13-ego dnia miesiąca", GetDescription("* * 13W * *"));
        }

        [Fact]
        public void TestFirstWeekdayOfTheMonth2()
        {
            Assert.Equal("Co minutę, pierwszy dzień roboczy miesiąca", GetDescription("* * W1 * *"));
        }

        [Fact]
        public void TestParticularWeekdayOfTheMonth()
        {
            Assert.Equal("Co minutę, dzień roboczy najbliższy 5-ego dnia miesiąca", GetDescription("* * 5W * *"));
        }

        [Fact]
        public void TestParticularWeekdayOfTheMonth2()
        {
            Assert.Equal("Co minutę, dzień roboczy najbliższy 5-ego dnia miesiąca", GetDescription("* * W5 * *"));
        }

        [Fact]
        public void TestTimeOfDayWithSeconds()
        {
            Assert.Equal("O 14:02:30", GetDescription("30 02 14 * * *"));
        }

        [Fact]
        public void TestSecondInternvals()
        {
            Assert.Equal("Sekundy od 5 do 10", GetDescription("5-10 * * * * *"));
        }

        [Fact]
        public void TestSecondMinutesHoursIntervals()
        {
            Assert.Equal("Sekundy od 5 do 10, minuty od 30 do 35, od 10:00 do 12:59", GetDescription("5-10 30-35 10-12 * * *"));
        }

        [Fact]
        public void TestEvery5MinutesAt30Seconds()
        {
            Assert.Equal("W 30 sekundzie, co 5 minut", GetDescription("30 */5 * * * *"));
        }

        [Fact]
        public void TestMinutesPastTheHourRange()
        {
            Assert.Equal("W 30 minucie, od 10:00 do 13:59, tylko środa i piątek", GetDescription("0 30 10-13 ? * WED,FRI"));
        }

        [Fact]
        public void TestSecondsPastTheMinuteInterval()
        {
            Assert.Equal("W 10 sekundzie, co 5 minut", GetDescription("10 0/5 * * * ?"));
        }

        [Fact]
        public void TestBetweenWithInterval()
        {
            Assert.Equal("Co 3 minut, minuty od 2 do 59, o 01:00, 09:00, i 22:00, od 11-ego do 26-ego dnia miesiąca, od styczeń do czerwiec",
                GetDescription("2-59/3 1,9,22 11-26 1-6 ?"));
        }

        [Fact]
        public void TestRecurringFirstOfMonth()
        {
            Assert.Equal("O 06:00", GetDescription("0 0 6 1/1 * ?"));
        }

        [Fact]
        public void TestMinutesPastTheHour()
        {
            Assert.Equal("W 5 minucie", GetDescription("0 5 0/1 * * ?"));
        }

        [Fact]
        public void TestOneYearOnlyWithSeconds()
        {
            Assert.Equal("Co sekundę, tylko 2013", GetDescription("* * * * * * 2013"));
        }

        [Fact]
        public void TestOneYearOnlyWithoutSeconds()
        {
            Assert.Equal("Co minutę, tylko 2013", GetDescription("* * * * * 2013"));
        }

        [Fact]
        public void TestTwoYearsOnly()
        {
            Assert.Equal("Co minutę, tylko 2013 i 2014", GetDescription("* * * * * 2013,2014"));
        }

        [Fact]
        public void TestYearRange2()
        {
            Assert.Equal("O 12:23, od styczeń do luty, od 2013 do 2014", GetDescription("23 12 * JAN-FEB * 2013-2014"));
        }

        [Fact]
        public void TestYearRange3()
        {
            Assert.Equal("O 12:23, od styczeń do marzec, od 2013 do 2015", GetDescription("23 12 * JAN-MAR * 2013-2015"));
        }

        [Fact]
        public void TestHourRange()
        {
            Assert.Equal("Co 30 minut, od 08:00 do 09:59, 5 i 20-ego dnia miesiąca", GetDescription("0 0/30 8-9 5,20 * ?"));
        }

        [Fact]
        public void TestDayOfWeekModifier()
        {
            Assert.Equal("O 12:23, drugi niedziela miesiąca", GetDescription("23 12 * * SUN#2"));
        }

        [Fact]
        public void TestDayOfWeekModifierWithSundayStartOne()
        {
            Options options = new Options();
            options.DayOfWeekStartIndexZero = false;

            Assert.Equal("O 12:23, drugi niedziela miesiąca", GetDescription("23 12 * * 1#2", options));
        }

        [Fact]
        public void TestHourRangeWithEveryPortion()
        {
            Assert.Equal("W 25 minucie, co 13 godzin, od 07:00 do 19:59", GetDescription("0 25 7-19/13 ? * *"));
        }

        [Fact]
        public void TestHourRangeWithTrailingZeroWithEveryPortion()
        {
            Assert.Equal("W 25 minucie, co 13 godzin, od 07:00 do 20:59", GetDescription("0 25 7-20/13 ? * *"));
        }

        [Fact]
        public void TestEvery3Day()
        {
            Assert.Equal("O 08:00, co 3 dni", GetDescription("0 0 8 1/3 * ? *"));
        }

        [Fact]
        public void TestsEvery3DayOfTheWeek()
        {
            Assert.Equal("O 10:15, co 3 dni tygodnia", GetDescription("0 15 10 ? * */3"));
        }

        [Fact]
        public void TestEvery2DayOfTheWeekInRange()
        {
            // GitHub Issue #58: https://github.com/bradymholt/cron-expression-descriptor/issues/58
            Assert.Equal("Co sekundę, co 2 dni tygodnia, od poniedziałek do piątek", GetDescription("* * * ? * 1-5/2"));
        }

        [Fact]
        public void TestEvery2DayOfTheWeekInRangeWithSundayStartOne()
        {
            // GitHub Issue #59: https://github.com/bradymholt/cron-expression-descriptor/issues/59

            var options = new Options { DayOfWeekStartIndexZero = false };

            Assert.Equal("Co sekundę, co 2 dni tygodnia, od poniedziałek do piątek",
                GetDescription("* * * ? * 2-6/2", options));
        }

        [Fact]
        public void TestEvery3Month()
        {
            Assert.Equal("O 07:05, 2-ego dnia miesiąca, co 3 miesięcy", GetDescription("0 5 7 2 1/3 ? *"));
        }

        [Fact]
        public void TestEvery2Years()
        {
            Assert.Equal("O 06:15, 1-ego dnia miesiąca, tylko styczeń, co 2 lat", GetDescription("0 15 6 1 1 ? 1/2"));
        }

        [Fact]
        public void TestMutiPartRangeSeconds()
        {
            Assert.Equal("W 2 i od 4 do 5 minucie, o 01:00", GetDescription("2,4-5 1 * * *"));
        }

        [Fact]
        public void TestMutiPartRangeSeconds2()
        {
            Assert.Equal("W 2 i od 26 do 28 minucie, o 18:00", GetDescription("2,26-28 18 * * *"));
        }

        [Fact]
        public void TrailingSpaceDoesNotCauseAWrongDescription()
        {
            // GitHub Issue #51: https://github.com/bradymholt/cron-expression-descriptor/issues/51
            Assert.Equal("O 07:00", GetDescription("0 7 * * * "));
        }

        [Fact]
        public void TestMultiPartDayOfTheWeek()
        {
            // GitHub Issue #44: https://github.com/bradymholt/cron-expression-descriptor/issues/44
            Assert.Equal("O 10:00, tylko od poniedziałek do czwartek i niedziela", GetDescription("0 00 10 ? * MON-THU,SUN *"));
        }

        [Fact]
        public void TestSecondsInternalWithStepValue()
        {
            // GitHub Issue #49: https://github.com/bradymholt/cron-expression-descriptor/issues/49
            Assert.Equal("Co 30 sekund, startowy w 5 sekundzie", GetDescription("5/30 * * * * ?"));
        }

        [Fact]
        public void TestMinutesInternalWithStepValue()
        {
            Assert.Equal("Co 30 minut, startowy w 5 minucie", GetDescription("0 5/30 * * * ?"));
        }

        [Fact]
        public void TestHoursInternalWithStepValue()
        {
            Assert.Equal("Co sekundę, co 8 godzin, startowy o 05:00", GetDescription("* * 5/8 * * ?"));
        }

        [Fact]
        public void TestDayOfMonthInternalWithStepValue()
        {
            Assert.Equal("O 07:05, co 3 dni, startowy 2-ego dnia miesiąca", GetDescription("0 5 7 2/3 * ? *"));
        }

        [Fact]
        public void TestMonthInternalWithStepValue()
        {
            Assert.Equal("O 07:05, co 2 miesięcy, od marzec do grudzień", GetDescription("0 5 7 ? 3/2 ? *"));
        }

        [Fact]
        public void TestDayOfWeekInternalWithStepValue()
        {
            Assert.Equal("O 07:05, co 3 dni tygodnia, od wtorek do sobota", GetDescription("0 5 7 ? * 2/3 *"));
        }

        [Fact]
        public void TestYearInternalWithStepValue()
        {
            Assert.Equal("O 07:05, co 4 lat, od 2016 do 9999", GetDescription("0 5 7 ? * ? 2016/4"));
        }
    }
}
