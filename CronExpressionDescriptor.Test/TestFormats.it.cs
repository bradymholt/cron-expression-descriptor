using System;
using System.Globalization;
using System.Threading;
using NUnit.Framework;

namespace CronExpressionDescriptor.Test
{
    [TestFixture]
    public class TestFormatsIT
    {
        [TestFixtureSetUp]
        public void SetUp()
        {
            CultureInfo myCultureInfo = new CultureInfo("it-IT");
            Thread.CurrentThread.CurrentCulture = myCultureInfo;
            Thread.CurrentThread.CurrentUICulture = myCultureInfo;
        }

        [Test]
        public void TestEveryMinute()
        {
            Assert.AreEqual("Ogni minuto", ExpressionDescriptor.GetDescription("* * * * *"));
        }

        [Test]
        public void TestEvery1Minute()
        {
            Assert.AreEqual("Ogni minuto", ExpressionDescriptor.GetDescription("*/1 * * * *"));
            Assert.AreEqual("Ogni minuto", ExpressionDescriptor.GetDescription("0 0/1 * * * ?"));
        }

        [Test]
        public void TestEveryHour()
        {
            Assert.AreEqual("Ogni ora", ExpressionDescriptor.GetDescription("0 0 * * * ?"));
            Assert.AreEqual("Ogni ora", ExpressionDescriptor.GetDescription("0 0 0/1 * * ?"));
        }

        [Test]
        public void TestTimeOfDayCertainDaysOfWeek()
        {
            Assert.AreEqual("Alle 23:00, lunedì al venerdì", ExpressionDescriptor.GetDescription("0 23 ? * MON-FRI"));
        }

        [Test]
        public void TestEverySecond()
        {
            Assert.AreEqual("Ogni secondo", ExpressionDescriptor.GetDescription("* * * * * *"));
        }

        [Test]
        public void TestEvery45Seconds()
        {
            Assert.AreEqual("Ogni 45 secondi", ExpressionDescriptor.GetDescription("*/45 * * * * *"));
        }

        [Test]
        public void TestEvery5Minutes()
        {
            Assert.AreEqual("Ogni 5 minuti", ExpressionDescriptor.GetDescription("*/5 * * * *"));
            Assert.AreEqual("Ogni 10 minuti", ExpressionDescriptor.GetDescription("0 0/10 * * * ?"));
        }

        [Test]
        public void TestEvery5MinutesOnTheSecond()
        {
            Assert.AreEqual("Ogni 5 minuti", ExpressionDescriptor.GetDescription("0 */5 * * * *"));
        }

        [Test]
        public void TestWeekdaysAtTime()
        {
            Assert.AreEqual("Alle 11:30, lunedì al venerdì", ExpressionDescriptor.GetDescription("30 11 * * 1-5"));
        }

        [Test]
        public void TestDailyAtTime()
        {
            Assert.AreEqual("Alle 11:30", ExpressionDescriptor.GetDescription("30 11 * * *"));
        }

        [Test]
        public void TestMinuteSpan()
        {
            Assert.AreEqual("Ogni minuto tra le 11:00 e le 11:10", ExpressionDescriptor.GetDescription("0-10 11 * * *"));
        }

        [Test]
        public void TestOneMonthOnly()
        {
            Assert.IsTrue(string.Equals("Ogni minuto, solo in marzo", ExpressionDescriptor.GetDescription("* * * 3 *"),
                 Utilities.IsRunningOnMono() ? StringComparison.OrdinalIgnoreCase : StringComparison.CurrentCulture));
        }

        [Test]
        public void TestTwoMonthsOnly()
        {
            Assert.IsTrue(string.Equals("Ogni minuto, solo in marzo e giugno", ExpressionDescriptor.GetDescription("* * * 3,6 *"),
                 Utilities.IsRunningOnMono() ? StringComparison.OrdinalIgnoreCase : StringComparison.CurrentCulture));
        }

        [Test]
        public void TestTwoTimesEachAfternoon()
        {
            Assert.AreEqual("Alle 14:30 e 16:30", ExpressionDescriptor.GetDescription("30 14,16 * * *"));
        }

        [Test]
        public void TestThreeTimesDaily()
        {
            Assert.AreEqual("Alle 06:30, 14:30 e 16:30", ExpressionDescriptor.GetDescription("30 6,14,16 * * *"));
        }

        [Test]
        public void TestOnceAWeek()
        {
            Assert.AreEqual("Alle 09:46, solo il lunedì", ExpressionDescriptor.GetDescription("46 9 * * 1"));
        }

        [Test]
        public void TestDayOfMonth()
        {
            Assert.AreEqual("Alle 12:23, il giorno 15 del mese", ExpressionDescriptor.GetDescription("23 12 15 * *"));
        }

        [Test]
        public void TestMonthName()
        {
            Assert.IsTrue(string.Equals("Alle 12:23, solo in gennaio", ExpressionDescriptor.GetDescription("23 12 * JAN *"),
                Utilities.IsRunningOnMono() ? StringComparison.OrdinalIgnoreCase : StringComparison.CurrentCulture));
        }

        [Test]
        public void TestDayOfMonthWithQuestionMark()
        {
            Assert.IsTrue(string.Equals("Alle 12:23, solo in gennaio", ExpressionDescriptor.GetDescription("23 12 ? JAN *"),
                 Utilities.IsRunningOnMono() ? StringComparison.OrdinalIgnoreCase : StringComparison.CurrentCulture));
        }

        [Test]
        public void TestMonthNameRange2()
        {
            Assert.IsTrue(string.Equals("Alle 12:23, gennaio al febbraio", ExpressionDescriptor.GetDescription("23 12 * JAN-FEB *"),
                 Utilities.IsRunningOnMono() ? StringComparison.OrdinalIgnoreCase : StringComparison.CurrentCulture));
        }


        [Test]
        public void TestMonthNameRange3()
        {
            Assert.IsTrue(string.Equals("Alle 12:23, gennaio al marzo", ExpressionDescriptor.GetDescription("23 12 * JAN-MAR *"),
                 Utilities.IsRunningOnMono() ? StringComparison.OrdinalIgnoreCase : StringComparison.CurrentCulture));
        }

        [Test]
        public void TestDayOfWeekName()
        {
            Assert.AreEqual("Alle 12:23, solo il domenica", ExpressionDescriptor.GetDescription("23 12 * * SUN"));
        }

        [Test]
        public void TestDayOfWeekRange()
        {
            Assert.AreEqual("Ogni 5 minuti, alle 15:00, lunedì al venerdì", ExpressionDescriptor.GetDescription("*/5 15 * * MON-FRI"));
        }

        [Test]
        public void TestDayOfWeekOnceInMonth()
        {
            Assert.AreEqual("Ogni minuto, il terzo lunedì del mese", ExpressionDescriptor.GetDescription("* * * * MON#3"));
        }

        [Test]
        public void TestLastDayOfTheWeekOfTheMonth()
        {
            Assert.AreEqual("Ogni minuto, l'ultimo giovedì del mese", ExpressionDescriptor.GetDescription("* * * * 4L"));
        }

        [Test]
        public void TestLastDayOfTheMonth()
        {
            Assert.IsTrue(string.Equals("Ogni 5 minuti, l'ultimo giorno del mese, solo in gennaio", ExpressionDescriptor.GetDescription("*/5 * L JAN *"),
                 Utilities.IsRunningOnMono() ? StringComparison.OrdinalIgnoreCase : StringComparison.CurrentCulture));
        }

        [Test]
        public void TestLastWeekdayOfTheMonth()
        {
            Assert.AreEqual("Ogni minuto, nell'ultima settimana del mese", ExpressionDescriptor.GetDescription("* * LW * *"));
        }

        [Test]
        public void TestLastWeekdayOfTheMonth2()
        {
            Assert.AreEqual("Ogni minuto, nell'ultima settimana del mese", ExpressionDescriptor.GetDescription("* * WL * *"));
        }

        [Test]
        public void TestFirstWeekdayOfTheMonth()
        {
            Assert.AreEqual("Ogni minuto, il primo giorno della settimana del mese", ExpressionDescriptor.GetDescription("* * 1W * *"));
        }

        [Test]
        public void TestFirstWeekdayOfTheMonth2()
        {
            Assert.AreEqual("Ogni minuto, il primo giorno della settimana del mese", ExpressionDescriptor.GetDescription("* * W1 * *"));
        }

        [Test]
        public void TestParticularWeekdayOfTheMonth()
        {
            Assert.AreEqual("Ogni minuto, il giorno della settimana più vicino al 5 del mese", ExpressionDescriptor.GetDescription("* * 5W * *"));
        }

        [Test]
        public void TestParticularWeekdayOfTheMonth2()
        {
            Assert.AreEqual("Ogni minuto, il giorno della settimana più vicino al 5 del mese", ExpressionDescriptor.GetDescription("* * W5 * *"));
        }

        [Test]
        public void TestTimeOfDayWithSeconds()
        {
            Assert.AreEqual("Alle 14:02:30", ExpressionDescriptor.GetDescription("30 02 14 * * *"));
        }

        [Test]
        public void TestSecondInternvals()
        {
            Assert.AreEqual("Secondi 5 al 10 oltre il minuto", ExpressionDescriptor.GetDescription("5-10 * * * * *"));
        }

        [Test]
        public void TestSecondMinutesHoursIntervals()
        {
            Assert.AreEqual("Secondi 5 al 10 oltre il minuto, minuti 30 al 35 dopo l'ora, tra le 10:00 e le 12:59", ExpressionDescriptor.GetDescription("5-10 30-35 10-12 * * *"));
        }

        [Test]
        public void TestEvery5MinutesAt30Seconds()
        {
            Assert.AreEqual("Al 30 secondo passato il minuto, ogni 5 minuti", ExpressionDescriptor.GetDescription("30 */5 * * * *"));
        }

        [Test]
        public void TestMinutesPastTheHourRange()
        {
            Assert.AreEqual("Al 30 minuto passata l'ora, tra le 10:00 e le 13:59, solo il mercoledì e venerdì", ExpressionDescriptor.GetDescription("0 30 10-13 ? * WED,FRI"));
        }

        [Test]
        public void TestSecondsPastTheMinuteInterval()
        {
            Assert.AreEqual("Al 10 secondo passato il minuto, ogni 5 minuti", ExpressionDescriptor.GetDescription("10 0/5 * * * ?"));
        }

        [Test]
        public void TestBetweenWithInterval()
        {
            Assert.IsTrue(string.Equals("Ogni 3 minuti, minuti 2 al 59 dopo l'ora, alle 01:00, 09:00, e 22:00, tra il giorno 11 e 26 del mese, gennaio al giugno", ExpressionDescriptor.GetDescription("2-59/3 1,9,22 11-26 1-6 ?"),
                 Utilities.IsRunningOnMono() ? StringComparison.OrdinalIgnoreCase : StringComparison.CurrentCulture));
        }

        [Test]
        public void TestRecurringFirstOfMonth()
        {
            Assert.AreEqual("Alle 06:00", ExpressionDescriptor.GetDescription("0 0 6 1/1 * ?"));
        }


        [Test]
        public void TestMinutesPastTheHour()
        {
            Assert.AreEqual("Al 5 minuto passata l'ora", ExpressionDescriptor.GetDescription("0 5 0/1 * * ?"));
        }

        [Test]
        public void TestOneYearOnlyWithSeconds()
        {
            Assert.AreEqual("Ogni secondo, solo in 2013", ExpressionDescriptor.GetDescription("* * * * * * 2013"));
        }

        [Test]
        public void TestOneYearOnlyWithoutSeconds()
        {
            Assert.AreEqual("Ogni minuto, solo in 2013", ExpressionDescriptor.GetDescription("* * * * * 2013"));
        }

        [Test]
        public void TestTwoYearsOnly()
        {
            Assert.AreEqual("Ogni minuto, solo in 2013 e 2014", ExpressionDescriptor.GetDescription("* * * * * 2013,2014"));
        }

        [Test]
        public void TestYearRange2()
        {
            Assert.IsTrue(string.Equals("Alle 12:23, gennaio al febbraio, 2013 al 2014", ExpressionDescriptor.GetDescription("23 12 * JAN-FEB * 2013-2014"),
                 Utilities.IsRunningOnMono() ? StringComparison.OrdinalIgnoreCase : StringComparison.CurrentCulture));
        }

        [Test]
        public void TestYearRange3()
        {
            Assert.IsTrue(string.Equals("Alle 12:23, gennaio al marzo, 2013 al 2015", ExpressionDescriptor.GetDescription("23 12 * JAN-MAR * 2013-2015"),
                 Utilities.IsRunningOnMono() ? StringComparison.OrdinalIgnoreCase : StringComparison.CurrentCulture));
        }

        [Test]
        public void TestHourRange()
        {
            Assert.AreEqual("Ogni 30 minuti, tra le 08:00 e le 09:59, il giorno 5 e 20 del mese", ExpressionDescriptor.GetDescription("0 0/30 8-9 5,20 * ?"));
        }

        [Test]
        public void TestDayOfWeekModifier()
        {
            Assert.AreEqual("Alle 12:23, il secondo domenica del mese", ExpressionDescriptor.GetDescription("23 12 * * SUN#2"));
        }

        [Test]
        public void TestDayOfWeekModifierWithSundayStartOne()
        {
            Options options = new Options();
            options.DayOfWeekStartIndexZero = false;

            Assert.AreEqual("Alle 12:23, il secondo domenica del mese", ExpressionDescriptor.GetDescription("23 12 * * 1#2", options));
        }

        [Test]
        public void TestHourRangeWithEveryPortion()
        {
            Assert.AreEqual("Al 25 minuto passata l'ora, ogni 13 ore, tra le 07:00 e le 19:59", ExpressionDescriptor.GetDescription("0 25 7-19/13 ? * *"));
        }

        [Test]
        public void TestHourRangeWithTrailingZeroWithEveryPortion()
        {
            Assert.AreEqual("Al 25 minuto passata l'ora, ogni 13 ore, tra le 07:00 e le 20:59", ExpressionDescriptor.GetDescription("0 25 7-20/13 ? * *"));
        }

        [Test]
        public void TestEvery3Day()
        {
            Assert.AreEqual("Alle 08:00, ogni 3 giorni", ExpressionDescriptor.GetDescription("0 0 8 1/3 * ? *"));
        }

        [Test]
        public void TestsEvery3DayOfTheWeek()
        {
            Assert.AreEqual("Alle 10:15, ogni 3 giorni della settimana", ExpressionDescriptor.GetDescription("0 15 10 ? * */3"));
        }

        [Test]
        public void TestEvery3Month()
        {
            Assert.AreEqual("Alle 07:05, il giorno 2 del mese, ogni 3 mesi", ExpressionDescriptor.GetDescription("0 5 7 2 1/3 ? *"));
        }

        [Test]
        public void TestEvery2Years()
        {
            Assert.IsTrue(string.Equals("Alle 06:15, il giorno 1 del mese, solo in gennaio, ogni 2 anni", ExpressionDescriptor.GetDescription("0 15 6 1 1 ? 1/2"),
                Utilities.IsRunningOnMono() ? StringComparison.OrdinalIgnoreCase : StringComparison.CurrentCulture));
        }

        [Test]
        public void TestSecondsInternalWithStepValue()
        {
            // GitHub Issue #49: https://github.com/bradyholt/cron-expression-descriptor/issues/49
            Assert.AreEqual("Ogni 30 secondi, a partire al 5 secondo passato il minuto", ExpressionDescriptor.GetDescription("5/30 * * * * ?"));
        }

        [Test]
        public void TestMinutesInternalWithStepValue()
        {
            Assert.AreEqual("Ogni 30 minuti, a partire al 5 minuto passata l'ora", ExpressionDescriptor.GetDescription("0 5/30 * * * ?"));
        }
        
        [Test]
        public void TestHoursInternalWithStepValue()
        {
            Assert.AreEqual("Ogni secondo, ogni 8 ore, a partire alle 05:00", ExpressionDescriptor.GetDescription("* * 5/8 * * ?"));
        }
        
        [Test]
        public void TestDayOfMonthInternalWithStepValue()
        {
            Assert.AreEqual("Alle 07:05, ogni 3 giorni, a partire il giorno 2 del mese", ExpressionDescriptor.GetDescription("0 5 7 2/3 * ? *"));
        }
        
        [Test]
        public void TestMonthInternalWithStepValue()
        {
            Assert.IsTrue(string.Equals("Alle 07:05, ogni 2 mesi, marzo al dicembre", ExpressionDescriptor.GetDescription("0 5 7 ? 3/2 ? *"),
                Utilities.IsRunningOnMono() ? StringComparison.OrdinalIgnoreCase : StringComparison.CurrentCulture));
        }
        
        [Test]
        public void TestDayOfWeekInternalWithStepValue()
        {
            Assert.AreEqual("Alle 07:05, ogni 3 giorni della settimana, martedì al sabato", ExpressionDescriptor.GetDescription("0 5 7 ? * 2/3 *"));
        }
                
        [Test]
        public void TestYearInternalWithStepValue()
        {
            Assert.AreEqual("Alle 07:05, ogni 4 anni, 2016 al 9999", ExpressionDescriptor.GetDescription("0 5 7 ? * ? 2016/4"));
        }
    }
}
