using Xunit;
using Assert = CronExpressionDescriptor.Test.Support.AssertExtensions;

namespace CronExpressionDescriptor.Test
{
    /// <summary>
    /// Tests for Italian translation
    /// </summary>
    public class TestFormatsIT : Support.BaseTestFormats
    {
        protected override string GetLocale()
        {
            return "it-IT";
        }

        [Fact]
        public void TestEveryMinute()
        {
            Assert.EqualsCaseInsensitive("Ogni minuto", GetDescription("* * * * *"));
        }

        [Fact]
        public void TestEvery1Minute()
        {
            Assert.EqualsCaseInsensitive("Ogni minuto", GetDescription("*/1 * * * *"));
            Assert.EqualsCaseInsensitive("Ogni minuto", GetDescription("0 0/1 * * * ?"));
        }

        [Fact]
        public void TestEveryHour()
        {
            Assert.EqualsCaseInsensitive("Ogni ora", GetDescription("0 0 * * * ?"));
            Assert.EqualsCaseInsensitive("Ogni ora", GetDescription("0 0 0/1 * * ?"));
        }

        [Fact]
        public void TestTimeOfDayCertainDaysOfWeek()
        {
            Assert.EqualsCaseInsensitive("Alle 23:00, Lunedì al Venerdì", GetDescription("0 23 ? * MON-FRI"));
        }

        [Fact]
        public void TestEverySecond()
        {
            Assert.EqualsCaseInsensitive("Ogni secondo", GetDescription("* * * * * *"));
        }

        [Fact]
        public void TestEvery45Seconds()
        {
            Assert.EqualsCaseInsensitive("Ogni 45 secondi", GetDescription("*/45 * * * * *"));
        }

        [Fact]
        public void TestEvery5Minutes()
        {
            Assert.EqualsCaseInsensitive("Ogni 5 minuti", GetDescription("*/5 * * * *"));
            Assert.EqualsCaseInsensitive("Ogni 10 minuti", GetDescription("0 0/10 * * * ?"));
        }

        [Fact]
        public void TestEvery5MinutesOnTheSecond()
        {
            Assert.EqualsCaseInsensitive("Ogni 5 minuti", GetDescription("0 */5 * * * *"));
        }

        [Fact]
        public void TestWeekdaysAtTime()
        {
            Assert.EqualsCaseInsensitive("Alle 11:30, Lunedì al Venerdì", GetDescription("30 11 * * 1-5"));
        }

        [Fact]
        public void TestDailyAtTime()
        {
            Assert.EqualsCaseInsensitive("Alle 11:30", GetDescription("30 11 * * *"));
        }

        [Fact]
        public void TestMinuteSpan()
        {
            Assert.EqualsCaseInsensitive("Ogni minuto tra le 11:00 e le 11:10", GetDescription("0-10 11 * * *"));
        }

        [Fact]
        public void TestOneMonthOnly()
        {
            Assert.EqualsCaseInsensitive("Ogni minuto, solo in Marzo", GetDescription("* * * 3 *"));
        }

        [Fact]
        public void TestTwoMonthsOnly()
        {
            Assert.EqualsCaseInsensitive("Ogni minuto, solo in Marzo e Giugno", GetDescription("* * * 3,6 *"));
        }

        [Fact]
        public void TestTwoTimesEachAfternoon()
        {
            Assert.EqualsCaseInsensitive("Alle 14:30 e 16:30", GetDescription("30 14,16 * * *"));
        }

        [Fact]
        public void TestThreeTimesDaily()
        {
            Assert.EqualsCaseInsensitive("Alle 06:30, 14:30 e 16:30", GetDescription("30 6,14,16 * * *"));
        }

        [Fact]
        public void TestOnceAWeek()
        {
            Assert.EqualsCaseInsensitive("Alle 09:46, solo il Lunedì", GetDescription("46 9 * * 1"));
        }

        [Fact]
        public void TestDayOfMonth()
        {
            Assert.EqualsCaseInsensitive("Alle 12:23, il giorno 15 del mese", GetDescription("23 12 15 * *"));
        }

        [Fact]
        public void TestMonthName()
        {
            Assert.EqualsCaseInsensitive("Alle 12:23, solo in Gennaio",
                GetDescription("23 12 * JAN *"));
        }

        [Fact]
        public void TestDayOfMonthWithQuestionMark()
        {
            Assert.EqualsCaseInsensitive("Alle 12:23, solo in Gennaio", GetDescription("23 12 ? JAN *"));
        }

        [Fact]
        public void TestMonthNameRange2()
        {
            Assert.EqualsCaseInsensitive("Alle 12:23, Gennaio al Febbraio", GetDescription("23 12 * JAN-FEB *"));
        }

        [Fact]
        public void TestMonthNameRange3()
        {
            Assert.EqualsCaseInsensitive("Alle 12:23, Gennaio al Marzo", GetDescription("23 12 * JAN-MAR *"));
        }

        [Fact]
        public void TestDayOfWeekName()
        {
            Assert.EqualsCaseInsensitive("Alle 12:23, solo il Domenica", GetDescription("23 12 * * SUN"));
        }

        [Fact]
        public void TestDayOfWeekRange()
        {
            Assert.EqualsCaseInsensitive("Ogni 5 minuti, tra le 15:00 e le 15:59, lunedì al venerdì", GetDescription("*/5 15 * * MON-FRI"));
        }

        [Fact]
        public void TestDayOfWeekOnceInMonth()
        {
            Assert.EqualsCaseInsensitive("Ogni minuto, il terzo Lunedì del mese", GetDescription("* * * * MON#3"));
        }

        [Fact]
        public void TestLastDayOfTheWeekOfTheMonth()
        {
            Assert.EqualsCaseInsensitive("Ogni minuto, l'ultimo Giovedì del mese", GetDescription("* * * * 4L"));
        }

        [Fact]
        public void TestLastDayOfTheMonth()
        {
            Assert.EqualsCaseInsensitive("Ogni 5 minuti, l'ultimo giorno del mese, solo in Gennaio", GetDescription("*/5 * L JAN *"));
        }

        [Fact]
        public void TestLastWeekdayOfTheMonth()
        {
            Assert.EqualsCaseInsensitive("Ogni minuto, nell'ultima settimana del mese", GetDescription("* * LW * *"));
        }

        [Fact]
        public void TestLastWeekdayOfTheMonth2()
        {
            Assert.EqualsCaseInsensitive("Ogni minuto, nell'ultima settimana del mese", GetDescription("* * WL * *"));
        }

        [Fact]
        public void TestFirstWeekdayOfTheMonth()
        {
            Assert.EqualsCaseInsensitive("Ogni minuto, il primo giorno della settimana del mese", GetDescription("* * 1W * *"));
        }

        [Fact]
        public void TestFirstWeekdayOfTheMonth2()
        {
            Assert.EqualsCaseInsensitive("Ogni minuto, il primo giorno della settimana del mese", GetDescription("* * W1 * *"));
        }

        [Fact]
        public void TestParticularWeekdayOfTheMonth()
        {
            Assert.EqualsCaseInsensitive("Ogni minuto, il giorno della settimana più vicino al 5 del mese", GetDescription("* * 5W * *"));
        }

        [Fact]
        public void TestParticularWeekdayOfTheMonth2()
        {
            Assert.EqualsCaseInsensitive("Ogni minuto, il giorno della settimana più vicino al 5 del mese", GetDescription("* * W5 * *"));
        }

        [Fact]
        public void TestTimeOfDayWithSeconds()
        {
            Assert.EqualsCaseInsensitive("Alle 14:02:30", GetDescription("30 02 14 * * *"));
        }

        [Fact]
        public void TestSecondInternvals()
        {
            Assert.EqualsCaseInsensitive("Secondi 5 al 10 oltre il minuto", GetDescription("5-10 * * * * *"));
        }

        [Fact]
        public void TestSecondMinutesHoursIntervals()
        {
            Assert.EqualsCaseInsensitive("Secondi 5 al 10 oltre il minuto, minuti 30 al 35 dopo l'ora, tra le 10:00 e le 12:59", GetDescription("5-10 30-35 10-12 * * *"));
        }

        [Fact]
        public void TestEvery5MinutesAt30Seconds()
        {
            Assert.EqualsCaseInsensitive("Al 30 secondo passato il minuto, ogni 5 minuti", GetDescription("30 */5 * * * *"));
        }

        [Fact]
        public void TestMinutesPastTheHourRange()
        {
            Assert.EqualsCaseInsensitive("Al 30 minuto passata l'ora, tra le 10:00 e le 13:59, solo il Mercoledì e Venerdì", GetDescription("0 30 10-13 ? * WED,FRI"));
        }

        [Fact]
        public void TestSecondsPastTheMinuteInterval()
        {
            Assert.EqualsCaseInsensitive("Al 10 secondo passato il minuto, ogni 5 minuti", GetDescription("10 0/5 * * * ?"));
        }

        [Fact]
        public void TestBetweenWithInterval()
        {
            Assert.EqualsCaseInsensitive("Ogni 3 minuti, minuti 2 al 59 dopo l'ora, alle 01:00, 09:00, e 22:00, tra il giorno 11 e 26 del mese, Gennaio al Giugno",
             GetDescription("2-59/3 1,9,22 11-26 1-6 ?"));
        }

        [Fact]
        public void TestRecurringFirstOfMonth()
        {
            Assert.EqualsCaseInsensitive("Alle 06:00", GetDescription("0 0 6 1/1 * ?"));
        }


        [Fact]
        public void TestMinutesPastTheHour()
        {
            Assert.EqualsCaseInsensitive("Al 5 minuto passata l'ora", GetDescription("0 5 0/1 * * ?"));
        }

        [Fact]
        public void TestOneYearOnlyWithSeconds()
        {
            Assert.EqualsCaseInsensitive("Ogni secondo, solo in 2013", GetDescription("* * * * * * 2013"));
        }

        [Fact]
        public void TestOneYearOnlyWithoutSeconds()
        {
            Assert.EqualsCaseInsensitive("Ogni minuto, solo in 2013", GetDescription("* * * * * 2013"));
        }

        [Fact]
        public void TestTwoYearsOnly()
        {
            Assert.EqualsCaseInsensitive("Ogni minuto, solo in 2013 e 2014", GetDescription("* * * * * 2013,2014"));
        }

        [Fact]
        public void TestYearRange2()
        {
            Assert.EqualsCaseInsensitive("Alle 12:23, Gennaio al Febbraio, 2013 al 2014", GetDescription("23 12 * JAN-FEB * 2013-2014"));
        }

        [Fact]
        public void TestYearRange3()
        {
            Assert.EqualsCaseInsensitive("Alle 12:23, Gennaio al Marzo, 2013 al 2015", GetDescription("23 12 * JAN-MAR * 2013-2015"));
        }

        [Fact]
        public void TestHourRange()
        {
            Assert.EqualsCaseInsensitive("Ogni 30 minuti, tra le 08:00 e le 09:59, il giorno 5 e 20 del mese", GetDescription("0 0/30 8-9 5,20 * ?"));
        }

        [Fact]
        public void TestDayOfWeekModifier()
        {
            Assert.EqualsCaseInsensitive("Alle 12:23, il secondo Domenica del mese", GetDescription("23 12 * * SUN#2"));
        }

        [Fact]
        public void TestDayOfWeekModifierWithSundayStartOne()
        {
            Options options = new Options();
            options.DayOfWeekStartIndexZero = false;

            Assert.EqualsCaseInsensitive("Alle 12:23, il secondo Domenica del mese", GetDescription("23 12 * * 1#2", options));
        }

        [Fact]
        public void TestHourRangeWithEveryPortion()
        {
            Assert.EqualsCaseInsensitive("Al 25 minuto passata l'ora, ogni 13 ore, tra le 07:00 e le 19:59", GetDescription("0 25 7-19/13 ? * *"));
        }

        [Fact]
        public void TestHourRangeWithTrailingZeroWithEveryPortion()
        {
            Assert.EqualsCaseInsensitive("Al 25 minuto passata l'ora, ogni 13 ore, tra le 07:00 e le 20:59", GetDescription("0 25 7-20/13 ? * *"));
        }

        [Fact]
        public void TestEvery3Day()
        {
            Assert.EqualsCaseInsensitive("Alle 08:00, ogni 3 giorni", GetDescription("0 0 8 1/3 * ? *"));
        }

        [Fact]
        public void TestsEvery3DayOfTheWeek()
        {
            Assert.EqualsCaseInsensitive("Alle 10:15, ogni 3 giorni della settimana", GetDescription("0 15 10 ? * */3"));
        }

        [Fact]
        public void TestEvery3Month()
        {
            Assert.EqualsCaseInsensitive("Alle 07:05, il giorno 2 del mese, ogni 3 mesi", GetDescription("0 5 7 2 1/3 ? *"));
        }

        [Fact]
        public void TestEvery2Years()
        {
            Assert.EqualsCaseInsensitive("Alle 06:15, il giorno 1 del mese, solo in Gennaio, ogni 2 anni", GetDescription("0 15 6 1 1 ? 1/2"));
        }

        [Fact]
        public void TestSecondsInternalWithStepValue()
        {
            // GitHub Issue #49: https://github.com/bradymholt/cron-expression-descriptor/issues/49
            Assert.EqualsCaseInsensitive("Ogni 30 secondi, a partire al 5 secondo passato il minuto", GetDescription("5/30 * * * * ?"));
        }

        [Fact]
        public void TestMinutesInternalWithStepValue()
        {
            Assert.EqualsCaseInsensitive("Ogni 30 minuti, a partire al 5 minuto passata l'ora", GetDescription("0 5/30 * * * ?"));
        }

        [Fact]
        public void TestHoursInternalWithStepValue()
        {
            Assert.EqualsCaseInsensitive("Ogni secondo, ogni 8 ore, a partire alle 05:00", GetDescription("* * 5/8 * * ?"));
        }

        [Fact]
        public void TestDayOfMonthInternalWithStepValue()
        {
            Assert.EqualsCaseInsensitive("Alle 07:05, ogni 3 giorni, a partire il giorno 2 del mese", GetDescription("0 5 7 2/3 * ? *"));
        }

        [Fact]
        public void TestMonthInternalWithStepValue()
        {
            Assert.EqualsCaseInsensitive("Alle 07:05, ogni 2 mesi, Marzo al Dicembre", GetDescription("0 5 7 ? 3/2 ? *"));
        }

        [Fact]
        public void TestDayOfWeekInternalWithStepValue()
        {
            Assert.EqualsCaseInsensitive("Alle 07:05, ogni 3 giorni della settimana, Martedì al Sabato", GetDescription("0 5 7 ? * 2/3 *"));
        }

        [Fact]
        public void TestYearInternalWithStepValue()
        {
            Assert.EqualsCaseInsensitive("Alle 07:05, ogni 4 anni, 2016 al 9999", GetDescription("0 5 7 ? * ? 2016/4"));
        }
    }
}
