using Xunit;

namespace CronExpressionDescriptor.Test
{
    /// <summary>
    /// Tests for Turkish translation
    /// </summary>
    public class TestFormatsTR : Support.BaseTestFormats
    {
        protected override string GetLocale()
        {
            return "tr-TR";
        }

        [Fact]

        public void TestEveryMinute()
        {
            Assert.Equal("Her dakika", GetDescription("* * * * *"));
        }
        [Fact]

        public void TestEvery1Minute()
        {
            Assert.Equal("Her dakika", GetDescription("*/1 * * * *"));
            Assert.Equal("Her dakika", GetDescription("0 0/1 * * * ?"));
        }
        [Fact]

        public void TestEveryHour()
        {
            Assert.Equal("Her saat", GetDescription("0 0 * * * ?"));
            Assert.Equal("Her saat", GetDescription("0 0 0/1 * * ?"));
        }
        [Fact]

        public void TestTimeOfDayCertainDaysOfWeek()
        {
            Assert.Equal("Saat 23:00, Pazartesi ile Cuma arasında", GetDescription("0 23 ? * MON-FRI"));
        }
        [Fact]

        public void TestEverySecond()
        {
            Assert.Equal("Her saniye", GetDescription("* * * * * *"));
        }
        [Fact]

        public void TestEvery45Seconds()
        {
            Assert.Equal("Her 45 saniyede bir", GetDescription("*/45 * * * * *"));
        }
        [Fact]

        public void TestEvery5Minutes()
        {
            Assert.Equal("Her 5 dakikada bir", GetDescription("*/5 * * * *"));
            Assert.Equal("Her 10 dakikada bir", GetDescription("0 0/10 * * * ?"));
        }
        [Fact]

        public void TestEvery5MinutesOnTheSecond()
        {
            Assert.Equal("Her 5 dakikada bir", GetDescription("0 */5 * * * *"));
        }

        [Fact]

        public void TestWeekdaysAtTime()
        {
            Assert.Equal("Saat 11:30, Pazartesi ile Cuma arasında", GetDescription("30 11 * * 1-5"));
        }

        [Fact]

        public void TestDailyAtTime()
        {
            Assert.Equal("Saat 11:30", GetDescription("30 11 * * *"));
        }
        [Fact]

        public void TestMinuteSpan()
        {
            Assert.Equal("Saat 11:00 ve 11:10 arasındaki her dakika", GetDescription("0-10 11 * * *"));
        }

        [Fact]

        public void TestOneMonthOnly()
        {
            Assert.Equal("Her dakika, sadece Mart için", GetDescription("* * * 3 *"));
        }

        [Fact]

        public void TestTwoMonthsOnly()
        {
            Assert.Equal("Her dakika, sadece Mart ve Haziran için", GetDescription("* * * 3,6 *"));
        }
        [Fact]
        public void TestTwoTimesEachAfternoon()
        {
            Assert.Equal("Saat 14:30 ve 16:30", GetDescription("30 14,16 * * *"));
        }

        [Fact]

        public void TestThreeTimesDaily()
        {
            Assert.Equal("Saat 06:30, 14:30 ve 16:30", GetDescription("30 6,14,16 * * *"));
        }

        [Fact]

        public void TestOnceAWeek()
        {
            Assert.Equal("Saat 09:46, sadece Pazartesi günü", GetDescription("46 9 * * 1"));
        }
        [Fact]

        public void TestDayOfMonth()
        {
            Assert.Equal("Saat 12:23, ayın 15. günü", GetDescription("23 12 15 * *"));
        }

        [Fact]

        public void TestMonthName()
        {
            Assert.Equal("Saat 12:23, sadece Ocak için", GetDescription("23 12 * JAN *"));
        }

        [Fact]

        public void TestDayOfMonthWithQuestionMark()
        {
            Assert.Equal("Saat 12:23, sadece Ocak için", GetDescription("23 12 ? JAN *"));
        }
        [Fact]

        public void TestMonthNameRange2()
        {
            Assert.Equal("Saat 12:23, Ocak ile Şubat arasında", GetDescription("23 12 * JAN-FEB *"));
        }

        [Fact]

        public void TestMonthNameRange3()
        {
            Assert.Equal("Saat 12:23, Ocak ile Mart arasında", GetDescription("23 12 * JAN-MAR *"));
        }

        [Fact]

        public void TestDayOfWeekName()
        {
            Assert.Equal("Saat 12:23, sadece Pazar günü", GetDescription("23 12 * * SUN"));
        }
        [Fact]

        public void TestDayOfWeekRange()
        {
            Assert.Equal("Her 5 dakikada bir, 15:00 ile 15:59 arasında, Pazartesi ile Cuma arasında", GetDescription("*/5 15 * * MON-FRI"));
        }

        [Fact]

        public void TestDayOfWeekOnceInMonth()
        {
            Assert.Equal("Her dakika, ayın üçüncü Pazartesi günü", GetDescription("* * * * MON#3"));
        }

        [Fact]

        public void TestLastDayOfTheWeekOfTheMonth()
        {
            Assert.Equal("Her dakika, ayın son Perşembe günü", GetDescription("* * * * 4L"));
        }
        [Fact]

        public void TestLastDayOfTheMonth()
        {
            Assert.Equal("Her 5 dakikada bir, ayın son günü, sadece Ocak için", GetDescription("*/5 * L JAN *"));
        }

        [Fact]

        public void TestLastWeekdayOfTheMonth()
        {
            Assert.Equal("Her dakika, ayın son iş günü", GetDescription("* * LW * *"));
        }

        [Fact]

        public void TestLastWeekdayOfTheMonth2()
        {
            Assert.Equal("Her dakika, ayın son iş günü", GetDescription("* * WL * *"));
        }
        [Fact]

        public void TestFirstWeekdayOfTheMonth()
        {
            Assert.Equal("Her dakika, ayın ilk iş günü", GetDescription("* * 1W * *"));
        }

        [Fact]

        public void TestFirstWeekdayOfTheMonth2()
        {
            Assert.Equal("Her dakika, ayın ilk iş günü", GetDescription("* * W1 * *"));
        }

        [Fact]

        public void TestParticularWeekdayOfTheMonth()
        {
            Assert.Equal("Her dakika, ayın 5. günü sonrasındaki ilk iş günü", GetDescription("* * 5W * *"));
        }
        [Fact]

        public void TestParticularWeekdayOfTheMonth2()
        {
            Assert.Equal("Her dakika, ayın 5. günü sonrasındaki ilk iş günü", GetDescription("* * W5 * *"));
        }

        [Fact]

        public void TestTimeOfDayWithSeconds()
        {
            Assert.Equal("Saat 14:02:30", GetDescription("30 02 14 * * *"));
        }

        [Fact]

        public void TestSecondInternvals()
        {
            Assert.Equal("Dakikaların 5. ve 10. saniyeleri arası", GetDescription("5-10 * * * * *"));
        }
        [Fact]

        public void TestSecondMinutesHoursIntervals()
        {
            Assert.Equal("Dakikaların 5. ve 10. saniyeleri arası, saatlerin 30. ve 35. dakikaları arası, 10:00 ile 12:59 arasında", GetDescription("5-10 30-35 10-12 * * *"));
        }

        [Fact]

        public void TestEvery5MinutesAt30Seconds()
        {
            Assert.Equal("Dakikaların 30. saniyesinde, her 5 dakikada bir", GetDescription("30 */5 * * * *"));
        }

        [Fact]

        public void TestMinutesPastTheHourRange()
        {
            Assert.Equal("Saatlerin 30. dakikasında, 10:00 ile 13:59 arasında, sadece Çarşamba ve Cuma günü", GetDescription("0 30 10-13 ? * WED,FRI"));
        }
        [Fact]

        public void TestSecondsPastTheMinuteInterval()
        {
            Assert.Equal("Dakikaların 10. saniyesinde, her 5 dakikada bir", GetDescription("10 0/5 * * * ?"));
        }
        [Fact]

        public void TestBetweenWithInterval()
        {
            Assert.Equal("Her 3 dakikada bir, saatlerin 2. ve 59. dakikaları arası, saat 01:00, 09:00, ve 22:00, ayın 11. ve 26. günleri arası, Ocak ile Haziran arasında", GetDescription("2-59/3 1,9,22 11-26 1-6 ?"));
        }
        [Fact]

        public void TestRecurringFirstOfMonth()
        {
            Assert.Equal("Saat 06:00", GetDescription("0 0 6 1/1 * ?"));
        }
        [Fact]

        public void TestMinutesPastTheHour()
        {
            Assert.Equal("Saatlerin 5. dakikasında", GetDescription("0 5 0/1 * * ?"));
        }
        [Fact]

        public void TestOneYearOnlyWithSeconds()
        {
            Assert.Equal("Her saniye, sadece 2013 için", GetDescription("* * * * * * 2013"));
        }

        [Fact]

        public void TestOneYearOnlyWithoutSeconds()
        {
            Assert.Equal("Her dakika, sadece 2013 için", GetDescription("* * * * * 2013"));
        }

        [Fact]

        public void TestTwoYearsOnly()
        {
            Assert.Equal("Her dakika, sadece 2013 ve 2014 için", GetDescription("* * * * * 2013,2014"));
        }

        [Fact]

        public void TestYearRange2()
        {
            Assert.Equal("Saat 12:23, Ocak ile Şubat arasında, 2013 ile 2014 arasında", GetDescription("23 12 * JAN-FEB * 2013-2014"));
        }

        [Fact]

        public void TestYearRange3()
        {
            Assert.Equal("Saat 12:23, Ocak ile Mart arasında, 2013 ile 2015 arasında", GetDescription("23 12 * JAN-MAR * 2013-2015"));
        }

        [Fact]

        public void TestHourRange()
        {
            Assert.Equal("Her 30 dakikada bir, 08:00 ile 09:59 arasında, ayın 5 ve 20. günü", GetDescription("0 0/30 8-9 5,20 * ?"));
        }

        [Fact]

        public void TestDayOfWeekModifier()
        {
            Assert.Equal("Saat 12:23, ayın ikinci Pazar günü", GetDescription("23 12 * * SUN#2"));
        }

        [Fact]

        public void TestDayOfWeekModifierWithSundayStartOne()
        {
            Options options = new Options();
            options.DayOfWeekStartIndexZero = false;

            Assert.Equal("Saat 12:23, ayın ikinci Pazar günü", GetDescription("23 12 * * 1#2", options));
        }

        [Fact]
        public void TestSecondsInternalWithStepValue()
        {
            // GitHub Issue #49: https://github.com/bradymholt/cron-expression-descriptor/issues/49
            Assert.Equal("Her 30 saniyede bir, başlangıç dakikaların 5. saniyesinde", GetDescription("5/30 * * * * ?"));
        }

        [Fact]
        public void TestMinutesInternalWithStepValue()
        {
            Assert.Equal("Her 30 dakikada bir, başlangıç saatlerin 5. dakikasında", GetDescription("0 5/30 * * * ?"));
        }

        [Fact]
        public void TestHoursInternalWithStepValue()
        {
            Assert.Equal("Her saniye, her 8 saatte, başlangıç saat 05:00", GetDescription("* * 5/8 * * ?"));
        }

        [Fact]
        public void TestDayOfMonthInternalWithStepValue()
        {
            Assert.Equal("Saat 07:05, 3 günde bir, başlangıç ayın 2. günü", GetDescription("0 5 7 2/3 * ? *"));
        }

        [Fact]
        public void TestMonthInternalWithStepValue()
        {
            Assert.Equal("Saat 07:05, 2 ayda bir, Mart ile Aralık arasında", GetDescription("0 5 7 ? 3/2 ? *"));
        }

        [Fact]
        public void TestDayOfWeekInternalWithStepValue()
        {
            Assert.Equal("Saat 07:05, ayın her 3 günü, Salı ile Cumartesi arasında", GetDescription("0 5 7 ? * 2/3 *"));
        }

        [Fact]
        public void TestYearInternalWithStepValue()
        {
            Assert.Equal("Saat 07:05, 4 yılda bir, 2016 ile 9999 arasında", GetDescription("0 5 7 ? * ? 2016/4"));
        }
    }
}
