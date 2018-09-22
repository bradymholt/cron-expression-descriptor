using Xunit;
using Assert = CronExpressionDescriptor.Test.Support.AssertExtensions;

namespace CronExpressionDescriptor.Test
{
    /// <summary>
    /// Tests for Finnish translation
    /// </summary>
    public class TestFormatsFI : Support.BaseTestFormats
    {
        protected override string GetLocale()
        {
            return "fi-FI";
        }

        [Fact]
        public void TestEveryMinute()
        {
            Assert.Equal("Joka minuutti", GetDescription("* * * * *"));
        }

        [Fact]
        public void TestEvery1Minute()
        {
            Assert.Equal("Joka minuutti", GetDescription("*/1 * * * *"));
            Assert.Equal("Joka minuutti", GetDescription("0 0/1 * * * ?"));
        }

        [Fact]
        public void TestEveryHour()
        {
            Assert.Equal("Joka tunti", GetDescription("0 0 * * * ?"));
            Assert.Equal("Joka tunti", GetDescription("0 0 0/1 * * ?"));
        }

        [Fact]
        public void TestTimeOfDayCertainDaysOfWeek()
        {
            Assert.Equal("Klo 23:00, maanantai - perjantai", GetDescription("0 23 ? * MON-FRI"));
        }

        [Fact]
        public void TestEverySecond()
        {
            Assert.Equal("Joka sekunti", GetDescription("* * * * * *"));
        }

        [Fact]
        public void TestEvery45Seconds()
        {
            Assert.Equal("Joka 45. sekunti", GetDescription("*/45 * * * * *"));
        }

        [Fact]
        public void TestEvery5Minutes()
        {
            Assert.Equal("Joka 5. minuutti", GetDescription("*/5 * * * *"));
            Assert.Equal("Joka 10. minuutti", GetDescription("0 0/10 * * * ?"));
        }

        [Fact]
        public void TestEvery5MinutesOnTheSecond()
        {
            Assert.Equal("Joka 5. minuutti", GetDescription("0 */5 * * * *"));
        }

        [Fact]
        public void TestWeekdaysAtTime()
        {
            Assert.Equal("Klo 11:30, maanantai - perjantai", GetDescription("30 11 * * 1-5"));
        }

        [Fact]
        public void TestDailyAtTime()
        {
            Assert.Equal("Klo 11:30", GetDescription("30 11 * * *"));
        }

        [Fact]
        public void TestMinuteSpan()
        {
            Assert.Equal("Joka minuutti 11:00 - 11:10 välillä", GetDescription("0-10 11 * * *"));
        }

        [Fact]
        public void TestOneMonthOnly()
        {
            Assert.Equal("Joka minuutti, vain maaliskuu", GetDescription("* * * 3 *"));
        }

        [Fact]
        public void TestTwoMonthsOnly()
        {
            Assert.Equal("Joka minuutti, vain maaliskuu ja kesäkuu", GetDescription("* * * 3,6 *"));
        }

        [Fact]
        public void TestTwoTimesEachAfternoon()
        {
            Assert.Equal("Klo 14:30 ja 16:30", GetDescription("30 14,16 * * *"));
        }

        [Fact]
        public void TestThreeTimesDaily()
        {
            Assert.Equal("Klo 06:30, 14:30 ja 16:30", GetDescription("30 6,14,16 * * *"));
        }

        [Fact]
        public void TestOnceAWeek()
        {
            Assert.Equal("Klo 09:46, vain maanantai", GetDescription("46 9 * * 1"));
        }

        [Fact]
        public void TestDayOfMonth()
        {
            Assert.Equal("Klo 12:23, kuukauden 15 päivä", GetDescription("23 12 15 * *"));
        }

        [Fact]
        public void TestMonthName()
        {
            Assert.Equal("Klo 12:23, vain tammikuu", GetDescription("23 12 * JAN *"));
        }

        [Fact]
        public void TestLowerCaseMonthName()
        {
            Assert.Equal("Klo 12:23, vain tammikuu", GetDescription("23 12 * jan *"));
        }

        [Fact]
        public void TestDayOfMonthWithQuestionMark()
        {
            Assert.Equal("Klo 12:23, vain tammikuu", GetDescription("23 12 ? JAN *"));
        }

        [Fact]
        public void TestMonthNameRange2()
        {
            Assert.Equal("Klo 12:23, tammikuu - helmikuu", GetDescription("23 12 * JAN-FEB *"));
        }

        [Fact]
        public void TestMonthNameRange3()
        {
            Assert.Equal("Klo 12:23, tammikuu - maaliskuu", GetDescription("23 12 * JAN-MAR *"));
        }

        [Fact]
        public void TestDayOfWeekName()
        {
            Assert.Equal("Klo 12:23, vain sunnuntai", GetDescription("23 12 * * SUN"));
        }

        [Fact]
        public void TestDayOfWeekRange()
        {
            Assert.Equal("Joka 5. minuutti, 15:00 - 15:59 välillä, maanantai - perjantai", GetDescription("*/5 15 * * MON-FRI"));
        }

        [Fact]
        public void TestDayOfWeekRangeWithDOWLowerCased()
        {
            Assert.Equal("Joka 5. minuutti, 15:00 - 15:59 välillä, maanantai - perjantai", GetDescription("*/5 15 * * MoN-fri"));
        }

        [Fact]
        public void TestDayOfWeekOnceInMonth()
        {
            Assert.Equal("Joka minuutti, kolmas maanantai kuukaudessa", GetDescription("* * * * MON#3"));
        }

        [Fact]
        public void TestLastDayOfTheWeekOfTheMonth()
        {
            Assert.Equal("Joka minuutti, kuukauden viimeinen torstai", GetDescription("* * * * 4L"));
        }

        [Fact]
        public void TestLastDayOfTheMonth()
        {
            Assert.Equal("Joka 5. minuutti, kuukauden viimeisenä päivänä, vain tammikuu", GetDescription("*/5 * L JAN *"));
        }

        [Fact]
        public void TestLastDayOffset()
        {
            Assert.Equal("Klo 00:00, 5 päivää ennen kuukauden viimeistä päivää", GetDescription("0 0 0 L-5 * ?"));
        }

        [Fact]
        public void TestLastWeekdayOfTheMonth()
        {
            Assert.Equal("Joka minuutti, kuukauden viimeisenä viikonpäivänä", GetDescription("* * LW * *"));
        }

        [Fact]
        public void TestLastWeekdayOfTheMonth2()
        {
            Assert.Equal("Joka minuutti, kuukauden viimeisenä viikonpäivänä", GetDescription("* * WL * *"));
        }

        [Fact]
        public void TestFirstWeekdayOfTheMonth()
        {
            Assert.Equal("Joka minuutti, kuukauden ensimmäinen viikonpäivä", GetDescription("* * 1W * *"));
        }

        [Fact]
        public void TestThirteenthWeekdayOfTheMonth()
        {
            Assert.Equal("Joka minuutti, kuukauden viikonpäivä lähintä 13 päivää", GetDescription("* * 13W * *"));
        }

        [Fact]
        public void TestFirstWeekdayOfTheMonth2()
        {
            Assert.Equal("Joka minuutti, kuukauden ensimmäinen viikonpäivä", GetDescription("* * W1 * *"));
        }

        [Fact]
        public void TestParticularWeekdayOfTheMonth()
        {
            Assert.Equal("Joka minuutti, kuukauden viikonpäivä lähintä 5 päivää", GetDescription("* * 5W * *"));
        }

        [Fact]
        public void TestParticularWeekdayOfTheMonth2()
        {
            Assert.Equal("Joka minuutti, kuukauden viikonpäivä lähintä 5 päivää", GetDescription("* * W5 * *"));
        }

        [Fact]
        public void TestTimeOfDayWithSeconds()
        {
            Assert.Equal("Klo 14:02:30", GetDescription("30 02 14 * * *"));
        }

        [Fact]
        public void TestSecondInternvals()
        {
            Assert.Equal("Joka minuutti sekunttien 5 - 10 välillä", GetDescription("5-10 * * * * *"));
        }

        [Fact]
        public void TestMultiPartSecond()
        {
            Assert.Equal("15 ja 45 sekunnnin jälkeen", GetDescription("15,45 * * * * *"));
        }

        [Fact]
        public void TestSecondMinutesHoursIntervals()
        {
            Assert.Equal("Joka minuutti sekunttien 5 - 10 välillä minuuttien 30 - 35 välillä, 10:00 - 12:59 välillä", GetDescription("5-10 30-35 10-12 * * *"));
        }

        [Fact]
        public void TestEvery5MinutesAt30Seconds()
        {
            Assert.Equal("30 sekunnnin jälkeen, joka 5. minuutti", GetDescription("30 */5 * * * *"));
        }

        [Fact]
        public void TestMinutesPastTheHourRange()
        {
            Assert.Equal("30 minuuttia yli, 10:00 - 13:59 välillä, vain keskiviikko ja perjantai", GetDescription("0 30 10-13 ? * WED,FRI"));
        }

        [Fact]
        public void TestSecondsPastTheMinuteInterval()
        {
            Assert.Equal("10 sekunnnin jälkeen, joka 5. minuutti", GetDescription("10 0/5 * * * ?"));
        }

        [Fact]
        public void TestBetweenWithInterval()
        {
            Assert.Equal("Joka 3. minuutti minuuttien 2 - 59 välillä, klo 01:00, 09:00, ja 22:00, kuukauden päivien 11 ja 26 välillä, tammikuu - kesäkuu", GetDescription("2-59/3 1,9,22 11-26 1-6 ?"));
        }

        [Fact]
        public void TestRecurringFirstOfMonth()
        {
            Assert.Equal("Klo 06:00", GetDescription("0 0 6 1/1 * ?"));
        }

        [Fact]
        public void TestMinutesPastTheHour()
        {
            Assert.Equal("5 minuuttia yli", GetDescription("0 5 0/1 * * ?"));
        }

        [Fact]
        public void TestOneYearOnlyWithSeconds()
        {
            Assert.Equal("Joka sekunti, vain 2013", GetDescription("* * * * * * 2013"));
        }

        [Fact]
        public void TestOneYearOnlyWithoutSeconds()
        {
            Assert.Equal("Joka minuutti, vain 2013", GetDescription("* * * * * 2013"));
        }

        [Fact]
        public void TestTwoYearsOnly()
        {
            Assert.Equal("Joka minuutti, vain 2013 ja 2014", GetDescription("* * * * * 2013,2014"));
        }

        [Fact]
        public void TestYearRange2()
        {
            Assert.Equal("Klo 12:23, tammikuu - helmikuu, 2013 - 2014", GetDescription("23 12 * JAN-FEB * 2013-2014"));
        }

        [Fact]
        public void TestYearRange3()
        {
            Assert.Equal("Klo 12:23, tammikuu - maaliskuu, 2013 - 2015", GetDescription("23 12 * JAN-MAR * 2013-2015"));
        }

        [Fact]
        public void TestHourRange()
        {
            Assert.Equal("Joka 30. minuutti, 08:00 - 09:59 välillä, kuukauden 5 ja 20 päivä", GetDescription("0 0/30 8-9 5,20 * ?"));
        }

        [Fact]
        public void TestDayOfWeekModifier()
        {
            Assert.Equal("Klo 12:23, toinen sunnuntai kuukaudessa", GetDescription("23 12 * * SUN#2"));
        }

        [Fact]
        public void TestDayOfWeekModifierWithSundayStartOne()
        {
            Options options = new Options();
            options.DayOfWeekStartIndexZero = false;

            Assert.Equal("Klo 12:23, toinen sunnuntai kuukaudessa", GetDescription("23 12 * * 1#2", options));
        }

        [Fact]
        public void TestHourRangeWithEveryPortion()
        {
            Assert.Equal("25 minuuttia yli, joka 8. tunti, 07:00 - 19:59 välillä", GetDescription("0 25 7-19/8 ? * *"));
        }

        [Fact]
        public void TestHourRangeWithTrailingZeroWithEveryPortion()
        {
            Assert.Equal("25 minuuttia yli, joka 13. tunti, 07:00 - 20:59 välillä", GetDescription("0 25 7-20/13 ? * *"));
        }

        [Fact]
        public void TestEvery3Day()
        {
            Assert.Equal("Klo 08:00, joka 3. päivä", GetDescription("0 0 8 1/3 * ? *"));
        }

        [Fact]
        public void TestsEvery3DayOfTheWeek()
        {
            Assert.Equal("Klo 10:15, joka 3. viikonpäivä", GetDescription("0 15 10 ? * */3"));
        }

        [Fact]
        public void TestEvery2DayOfTheWeekInRange()
        {
            // GitHub Issue #58: https://github.com/bradymholt/cron-expression-descriptor/issues/58
            Assert.Equal("Joka sekunti, joka 2. viikonpäivä, maanantai - perjantai", GetDescription("* * * ? * 1-5/2"));
        }

        [Fact]
        public void TestEvery2DayOfTheWeekInRangeWithSundayStartOne()
        {
            // GitHub Issue #59: https://github.com/bradymholt/cron-expression-descriptor/issues/59

            var options = new Options { DayOfWeekStartIndexZero = false };

            Assert.Equal("Joka sekunti, joka 2. viikonpäivä, maanantai - perjantai",
                GetDescription("* * * ? * 2-6/2", options));
        }

        [Fact]
        public void TestEvery3Month()
        {
            Assert.Equal("Klo 07:05, kuukauden 2 päivä, joka 3. kuukausi", GetDescription("0 5 7 2 1/3 ? *"));
        }

        [Fact]
        public void TestEvery2Years()
        {
            Assert.Equal("Klo 06:15, kuukauden 1 päivä, vain tammikuu, joka 2. vuosi", GetDescription("0 15 6 1 1 ? 1/2"));
        }

        [Fact]
        public void TestMutiPartRangeMinutes()
        {
            Assert.Equal("2 ja 4 - 5 minuuttia yli, klo 01:00", GetDescription("2,4-5 1 * * *"));
        }

        [Fact]
        public void TestMutiPartRangeMinutes2()
        {
            Assert.Equal("2 ja 26 - 28 minuuttia yli, klo 18:00", GetDescription("2,26-28 18 * * *"));
        }

        [Fact]
        public void TrailingSpaceDoesNotCauseAWrongDescription()
        {
            // GitHub Issue #51: https://github.com/bradymholt/cron-expression-descriptor/issues/51
            Assert.Equal("Klo 07:00", GetDescription("0 7 * * * "));
        }

        [Fact]
        public void TestMultiPartDayOfTheWeek()
        {
            // GitHub Issue #44: https://github.com/bradymholt/cron-expression-descriptor/issues/44
            Assert.Equal("Klo 10:00, vain maanantai - torstai ja sunnuntai", GetDescription("0 00 10 ? * MON-THU,SUN *"));
        }

        [Fact]
        public void TestDayOfWeekWithDayOfMonth()
        {
            // GitHub Issue #46: https://github.com/bradymholt/cron-expression-descriptor/issues/46
            Assert.Equal("Klo 00:00, kuukauden 1, 2, ja 3 päivä, vain keskiviikko ja perjantai", GetDescription("0 0 0 1,2,3 * WED,FRI"));
        }

        [Fact]
        public void TestSecondsInternalWithStepValue()
        {
            // GitHub Issue #49: https://github.com/bradymholt/cron-expression-descriptor/issues/49
            Assert.Equal("Joka 30. sekunti, alkaen 5 sekunnnin jälkeen", GetDescription("5/30 * * * * ?"));
        }

        [Fact]
        public void TestMinutesInternalWithStepValue()
        {
            Assert.Equal("Joka 30. minuutti, alkaen 5 minuuttia yli", GetDescription("0 5/30 * * * ?"));
        }

        [Fact]
        public void TestHoursInternalWithStepValue()
        {
            Assert.Equal("Joka sekunti, joka 8. tunti, alkaen klo 05:00", GetDescription("* * 5/8 * * ?"));
        }

        [Fact]
        public void TestDayOfMonthInternalWithStepValue()
        {
            Assert.Equal("Klo 07:05, joka 3. päivä, alkaen kuukauden 2 päivä", GetDescription("0 5 7 2/3 * ? *"));
        }

        [Fact]
        public void TestMonthInternalWithStepValue()
        {
            Assert.Equal("Klo 07:05, joka 2. kuukausi, maaliskuu - joulukuu", GetDescription("0 5 7 ? 3/2 ? *"));
        }

        [Fact]
        public void TestDayOfWeekInternalWithStepValue()
        {
            Assert.Equal("Klo 07:05, joka 3. viikonpäivä, tiistai - lauantai", GetDescription("0 5 7 ? * 2/3 *"));
        }

        [Fact]
        public void TestYearInternalWithStepValue()
        {
            Assert.Equal("Klo 07:05, joka 4. vuosi, 2016 - 9999", GetDescription("0 5 7 ? * ? 2016/4"));
        }

        [Fact]
        public void TestMinutesCombinedWithMultipleHourRanges()
        {
            Assert.Equal("1 minuuttia yli, klo 01:00 ja 03:00 - 04:59", GetDescription("1 1,3-4 * * *"));
        }

        [Fact]
        public void TestMinuteRangeConbinedWithSecondRange()
        {
            Assert.Equal("Joka minuutti sekunttien 12 - 50 välillä minuuttien 0 - 10 välillä, klo 06:00, vain 2022", GetDescription("12-50 0-10 6 * * * 2022"));
        }

        [Fact]
        public void TestSecondsExpressionCombinedWithHoursListAndSingleMinute()
{            Assert.Equal("5 sekunnnin jälkeen, 30 minuuttia yli, klo 06:00, 14:00, ja 16:00, kuukauden 5 päivä", GetDescription("5 30 6,14,16 5 * *"));
        }

        [Fact]
        public void TestSundayExpression()
        {
            Options options = new Options
            {
                DayOfWeekStartIndexZero = false
            };

            Assert.Equal("Joka 2. tunti, vain sunnuntai", GetDescription("0 0 0/2 ? * 1", options));
        }        
    }
}
