using Xunit;

namespace CronExpressionDescriptor.Test
{
    /// <summary>
    /// Tests for French translation
    /// </summary>
    public class TestFormatsFR : Support.BaseTestFormats
    {
        protected override string GetLocale()
        {
            return "fr-FR";
        }

        [Fact]
        public void TestEveryMinute()
        {
            Assert.Equal("Toutes les minutes", GetDescription("* * * * *"));
        }

        [Fact]
        public void TestEvery1Minute()
        {
            Assert.Equal("Toutes les minutes", GetDescription("*/1 * * * *"));
            Assert.Equal("Toutes les minutes", GetDescription("0 0/1 * * * ?"));
        }

        [Fact]
        public void TestEveryHour()
        {
            Assert.Equal("Toutes les heures", GetDescription("0 0 * * * ?"));
            Assert.Equal("Toutes les heures", GetDescription("0 0 0/1 * * ?"));
        }

        [Fact]
        public void TestTimeOfDayCertainDaysOfWeek()
        {
            Assert.Equal("À 11:00 PM, de lundi à vendredi", GetDescription("0 23 ? * MON-FRI"));
        }

        [Fact]
        public void TestEverySecond()
        {
            Assert.Equal("Toutes les secondes", GetDescription("* * * * * *"));
        }

        [Fact]
        public void TestEvery45Seconds()
        {
            Assert.Equal("Toutes les 45 secondes", GetDescription("*/45 * * * * *"));
        }

        [Fact]
        public void TestEvery5Minutes()
        {
            Assert.Equal("Toutes les 5 minutes", GetDescription("*/5 * * * *"));
            Assert.Equal("Toutes les 10 minutes", GetDescription("0 0/10 * * * ?"));
        }

        [Fact]
        public void TestEvery5MinutesOnTheSecond()
        {
            Assert.Equal("Toutes les 5 minutes", GetDescription("0 */5 * * * *"));
        }

        [Fact]
        public void TestWeekdaysAtTime()
        {
            Assert.Equal("À 11:30 AM, de lundi à vendredi", GetDescription("30 11 * * 1-5"));
        }

        [Fact]
        public void TestDailyAtTime()
        {
            Assert.Equal("À 11:30 AM", GetDescription("30 11 * * *"));
        }

        [Fact]
        public void TestMinuteSpan()
        {
            Assert.Equal("Toutes les minutes entre 11:00 AM et 11:10 AM", GetDescription("0-10 11 * * *"));
        }

        [Fact]
        public void TestOneMonthOnly()
        {
            Assert.Equal("Toutes les minutes, uniquement en mars", GetDescription("* * * 3 *"));
        }

        [Fact]
        public void TestTwoMonthsOnly()
        {
            Assert.Equal("Toutes les minutes, uniquement en mars et juin", GetDescription("* * * 3,6 *"));
        }

        [Fact]
        public void TestTwoTimesEachAfternoon()
        {
            Assert.Equal("À 02:30 PM et 04:30 PM", GetDescription("30 14,16 * * *"));
        }

        [Fact]
        public void TestThreeTimesDaily()
        {
            Assert.Equal("À 06:30 AM, 02:30 PM et 04:30 PM", GetDescription("30 6,14,16 * * *"));
        }

        [Fact]
        public void TestOnceAWeek()
        {
            Assert.Equal("À 09:46 AM, uniquement le lundi", GetDescription("46 9 * * 1"));
        }

        [Fact]
        public void TestDayOfMonth()
        {
            Assert.Equal("À 12:23 PM, le 15 du mois", GetDescription("23 12 15 * *"));
        }

        [Fact]
        public void TestMonthName()
        {
            Assert.Equal("À 12:23 PM, uniquement en janvier", GetDescription("23 12 * JAN *"));
        }

        [Fact]
        public void TestDayOfMonthWithQuestionMark()
        {
            Assert.Equal("À 12:23 PM, uniquement en janvier", GetDescription("23 12 ? JAN *"));
        }

        [Fact]
        public void TestMonthNameRange2()
        {
            Assert.Equal("À 12:23 PM, de janvier à février", GetDescription("23 12 * JAN-FEB *"));
        }

        [Fact]
        public void TestMonthNameRange3()
        {
            Assert.Equal("À 12:23 PM, de janvier à mars", GetDescription("23 12 * JAN-MAR *"));
        }

        [Fact]
        public void TestDayOfWeekName()
        {
            Assert.Equal("À 12:23 PM, uniquement le dimanche", GetDescription("23 12 * * SUN"));
        }

        [Fact]
        public void TestDayOfWeekRange()
        {
            Assert.Equal("Toutes les 5 minutes, de 03:00 PM à 03:59 PM, de lundi à vendredi", GetDescription("*/5 15 * * MON-FRI"));
        }

        [Fact]
        public void TestDayOfWeekOnceInMonth()
        {
            Assert.Equal("Toutes les minutes, le troisième lundi du mois", GetDescription("* * * * MON#3"));
        }

        [Fact]
        public void TestLastDayOfTheWeekOfTheMonth()
        {
            Assert.Equal("Toutes les minutes, le dernier jeudi du mois", GetDescription("* * * * 4L"));
        }

        [Fact]
        public void TestLastDayOfTheMonth()
        {
            Assert.Equal("Toutes les 5 minutes, le dernier jour du mois, uniquement en janvier", GetDescription("*/5 * L JAN *"));
        }

        [Fact]
        public void TestLastWeekdayOfTheMonth()
        {
            Assert.Equal("Toutes les minutes, le dernier jour ouvrable du mois", GetDescription("* * LW * *"));
        }

        [Fact]
        public void TestLastWeekdayOfTheMonth2()
        {
            Assert.Equal("Toutes les minutes, le dernier jour ouvrable du mois", GetDescription("* * WL * *"));
        }

        [Fact]
        public void TestFirstWeekdayOfTheMonth()
        {
            Assert.Equal("Toutes les minutes, le premier jour ouvrable du mois", GetDescription("* * 1W * *"));
        }

        [Fact]
        public void TestFirstWeekdayOfTheMonth2()
        {
            Assert.Equal("Toutes les minutes, le premier jour ouvrable du mois", GetDescription("* * W1 * *"));
        }

        [Fact]
        public void TestParticularWeekdayOfTheMonth()
        {
            Assert.Equal("Toutes les minutes, le jour ouvrable le plus proche du 5 du mois", GetDescription("* * 5W * *"));
        }

        [Fact]
        public void TestParticularWeekdayOfTheMonth2()
        {
            Assert.Equal("Toutes les minutes, le jour ouvrable le plus proche du 5 du mois", GetDescription("* * W5 * *"));
        }

        [Fact]
        public void TestTimeOfDayWithSeconds()
        {
            Assert.Equal("À 02:02:30 PM", GetDescription("30 02 14 * * *"));
        }

        [Fact]
        public void TestSecondInternvals()
        {
            Assert.Equal("Les secondes entre 5 et 10 après la minute", GetDescription("5-10 * * * * *"));
        }

        [Fact]
        public void TestSecondMinutesHoursIntervals()
        {
            Assert.Equal("Les secondes entre 5 et 10 après la minute, les minutes entre 30 et 35 après l'heure, de 10:00 AM à 12:59 PM", GetDescription("5-10 30-35 10-12 * * *"));
        }

        [Fact]
        public void TestEvery5MinutesAt30Seconds()
        {
            Assert.Equal("30 secondes après la minute, toutes les 5 minutes", GetDescription("30 */5 * * * *"));
        }

        [Fact]
        public void TestMinutesPastTheHourRange()
        {
            Assert.Equal("30 minutes après l'heure, de 10:00 AM à 01:59 PM, uniquement le mercredi et vendredi", GetDescription("0 30 10-13 ? * WED,FRI"));
        }

        [Fact]
        public void TestSecondsPastTheMinuteInterval()
        {
            Assert.Equal("10 secondes après la minute, toutes les 5 minutes", GetDescription("10 0/5 * * * ?"));
        }

        [Fact]
        public void TestBetweenWithInterval()
        {
            Assert.Equal("Toutes les 3 minutes, les minutes entre 2 et 59 après l'heure, à 01:00 AM, 09:00 AM, et 10:00 PM, du 11 au 26 du mois, de janvier à juin", GetDescription("2-59/3 1,9,22 11-26 1-6 ?"));
        }

        [Fact]
        public void TestRecurringFirstOfMonth()
        {
            Assert.Equal("À 06:00 AM", GetDescription("0 0 6 1/1 * ?"));
        }

        [Fact]
        public void TestMinutesPastTheHour()
        {
            Assert.Equal("5 minutes après l'heure", GetDescription("0 5 0/1 * * ?"));
        }

        [Fact]
        public void TestOneYearOnlyWithSeconds()
        {
            Assert.Equal("Toutes les secondes, uniquement en 2013", GetDescription("* * * * * * 2013"));
        }

        [Fact]
        public void TestOneYearOnlyWithoutSeconds()
        {
            Assert.Equal("Toutes les minutes, uniquement en 2013", GetDescription("* * * * * 2013"));
        }

        [Fact]
        public void TestTwoYearsOnly()
        {
            Assert.Equal("Toutes les minutes, uniquement en 2013 et 2014", GetDescription("* * * * * 2013,2014"));
        }

        [Fact]
        public void TestYearRange2()
        {
            Assert.Equal("À 12:23 PM, de janvier à février, de 2013 à 2014", GetDescription("23 12 * JAN-FEB * 2013-2014"));
        }

        [Fact]
        public void TestYearRange3()
        {
            Assert.Equal("À 12:23 PM, de janvier à mars, de 2013 à 2015", GetDescription("23 12 * JAN-MAR * 2013-2015"));
        }

        [Fact]
        public void TestSecondsInternalWithStepValue()
        {
            // GitHub Issue #49: https://github.com/bradymholt/cron-expression-descriptor/issues/49
            Assert.Equal("Toutes les 30 secondes, départ 5 secondes après la minute", GetDescription("5/30 * * * * ?"));
        }

        [Fact]
        public void TestMinutesInternalWithStepValue()
        {
            Assert.Equal("Toutes les 30 minutes, départ 5 minutes après l'heure", GetDescription("0 5/30 * * * ?"));
        }

        [Fact]
        public void TestHoursInternalWithStepValue()
        {
            Assert.Equal("Toutes les secondes, toutes les 8 heures, départ à 05:00 AM", GetDescription("* * 5/8 * * ?"));
        }

        [Fact]
        public void TestDayOfMonthInternalWithStepValue()
        {
            Assert.Equal("À 07:05 AM, tous les 3 jours, départ le 2 du mois", GetDescription("0 5 7 2/3 * ? *"));
        }

        [Fact]
        public void TestMonthInternalWithStepValue()
        {
            Assert.Equal("À 07:05 AM, tous les 2 mois, de mars à décembre", GetDescription("0 5 7 ? 3/2 ? *"));
        }

        [Fact]
        public void TestDayOfWeekInternalWithStepValue()
        {
            Assert.Equal("À 07:05 AM, every 3 days of the week, de mardi à samedi", GetDescription("0 5 7 ? * 2/3 *"));
        }

        [Fact]
        public void TestYearInternalWithStepValue()
        {
            Assert.Equal("À 07:05 AM, tous les 4 ans, de 2016 à 9999", GetDescription("0 5 7 ? * ? 2016/4"));
        }
    }
}
