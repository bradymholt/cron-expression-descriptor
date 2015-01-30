using System;
using System.Globalization;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CronExpressionDescriptor.Test
{
    [TestClass]
    public class TestFormatsIT
    {
        [TestInitialize]
        public void SetUp()
        {
            CultureInfo myCultureInfo = new CultureInfo("it");
            Thread.CurrentThread.CurrentCulture = myCultureInfo;
            Thread.CurrentThread.CurrentUICulture = myCultureInfo;
        }

        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestEveryMinute()
        {
            Assert.AreEqual("Ogni minuto", ExpressionDescriptor.GetDescription("* * * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestEvery1Minute()
        {
            Assert.AreEqual("Ogni minuto", ExpressionDescriptor.GetDescription("*/1 * * * *"));
            Assert.AreEqual("Ogni minuto", ExpressionDescriptor.GetDescription("0 0/1 * * * ?"));
        }

        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestEveryHour()
        {
            Assert.AreEqual("Ogni ora", ExpressionDescriptor.GetDescription("0 0 * * * ?"));
            Assert.AreEqual("Ogni ora", ExpressionDescriptor.GetDescription("0 0 0/1 * * ?"));
        }

        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestTimeOfDayCertainDaysOfWeek()
        {
            Assert.AreEqual("Alle 23:00, lunedì al venerdì", ExpressionDescriptor.GetDescription("0 23 ? * MON-FRI"));
        }

        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestEverySecond()
        {
            Assert.AreEqual("Ogni secondo", ExpressionDescriptor.GetDescription("* * * * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestEvery45Seconds()
        {
            Assert.AreEqual("Ogni 45 secondi", ExpressionDescriptor.GetDescription("*/45 * * * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestEvery5Minutes()
        {
            Assert.AreEqual("Ogni 05 minuti", ExpressionDescriptor.GetDescription("*/5 * * * *"));
            Assert.AreEqual("Ogni 10 minuti", ExpressionDescriptor.GetDescription("0 0/10 * * * ?"));
        }

        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestEvery5MinutesOnTheSecond()
        {
            Assert.AreEqual("Ogni 05 minuti", ExpressionDescriptor.GetDescription("0 */5 * * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestWeekdaysAtTime()
        {
            Assert.AreEqual("Alle 11:30, lunedì al venerdì", ExpressionDescriptor.GetDescription("30 11 * * 1-5"));
        }

        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestDailyAtTime()
        {
            Assert.AreEqual("Alle 11:30", ExpressionDescriptor.GetDescription("30 11 * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestMinuteSpan()
        {
            Assert.AreEqual("Ogni minuto tra le 11:00 e le 11:10", ExpressionDescriptor.GetDescription("0-10 11 * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestOneMonthOnly()
        {
            Assert.AreEqual("Ogni minuto, solo in marzo", ExpressionDescriptor.GetDescription("* * * 3 *"));
        }

        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestTwoMonthsOnly()
        {
            Assert.AreEqual("Ogni minuto, solo in marzo e giugno", ExpressionDescriptor.GetDescription("* * * 3,6 *"));
        }

        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestTwoTimesEachAfternoon()
        {
            Assert.AreEqual("Alle 14:30 e 16:30", ExpressionDescriptor.GetDescription("30 14,16 * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestThreeTimesDaily()
        {
            Assert.AreEqual("Alle 06:30, 14:30 e 16:30", ExpressionDescriptor.GetDescription("30 6,14,16 * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestOnceAWeek()
        {
            Assert.AreEqual("Alle 09:46, solo il lunedì", ExpressionDescriptor.GetDescription("46 9 * * 1"));
        }

        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestDayOfMonth()
        {
            Assert.AreEqual("Alle 12:23, il giorno 15 del mese", ExpressionDescriptor.GetDescription("23 12 15 * *"));
        }

        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestMonthName()
        {
            Assert.AreEqual("Alle 12:23, solo in gennaio", ExpressionDescriptor.GetDescription("23 12 * JAN *"));
        }

        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestDayOfMonthWithQuestionMark()
        {
            Assert.AreEqual("Alle 12:23, solo in gennaio", ExpressionDescriptor.GetDescription("23 12 ? JAN *"));
        }

        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestMonthNameRange2()
        {
            Assert.AreEqual("Alle 12:23, gennaio al febbraio", ExpressionDescriptor.GetDescription("23 12 * JAN-FEB *"));
        }


        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestMonthNameRange3()
        {
            Assert.AreEqual("Alle 12:23, gennaio al marzo", ExpressionDescriptor.GetDescription("23 12 * JAN-MAR *"));
        }

        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestDayOfWeekName()
        {
            Assert.AreEqual("Alle 12:23, solo il domenica", ExpressionDescriptor.GetDescription("23 12 * * SUN"));
        }

        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestDayOfWeekRange()
        {
            Assert.AreEqual("Ogni 05 minuti, alle 15:00, lunedì al venerdì", ExpressionDescriptor.GetDescription("*/5 15 * * MON-FRI"));
        }

        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestDayOfWeekOnceInMonth()
        {
            Assert.AreEqual("Ogni minuto, il terzo lunedì del mese", ExpressionDescriptor.GetDescription("* * * * MON#3"));
        }

        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestLastDayOfTheWeekOfTheMonth()
        {
            Assert.AreEqual("Ogni minuto, l'ultimo giovedì del mese", ExpressionDescriptor.GetDescription("* * * * 4L"));
        }

        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestLastDayOfTheMonth()
        {
            Assert.AreEqual("Ogni 05 minuti, l'ultimo giorno del mese, solo in gennaio", ExpressionDescriptor.GetDescription("*/5 * L JAN *"));
        }

        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestLastWeekdayOfTheMonth()
        {
            Assert.AreEqual("Ogni minuto, nell'ultima settimana del mese", ExpressionDescriptor.GetDescription("* * LW * *"));
        }

        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestLastWeekdayOfTheMonth2()
        {
            Assert.AreEqual("Ogni minuto, nell'ultima settimana del mese", ExpressionDescriptor.GetDescription("* * WL * *"));
        }

        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestFirstWeekdayOfTheMonth()
        {
            Assert.AreEqual("Ogni minuto, il primo giorno della settimana del mese", ExpressionDescriptor.GetDescription("* * 1W * *"));
        }

        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestFirstWeekdayOfTheMonth2()
        {
            Assert.AreEqual("Ogni minuto, il primo giorno della settimana del mese", ExpressionDescriptor.GetDescription("* * W1 * *"));
        }

        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestParticularWeekdayOfTheMonth()
        {
            Assert.AreEqual("Ogni minuto, il giorno della settimana più vicino al 5 del mese", ExpressionDescriptor.GetDescription("* * 5W * *"));
        }

        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestParticularWeekdayOfTheMonth2()
        {
            Assert.AreEqual("Ogni minuto, il giorno della settimana più vicino al 5 del mese", ExpressionDescriptor.GetDescription("* * W5 * *"));
        }

        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestTimeOfDayWithSeconds()
        {
            Assert.AreEqual("Alle 14:02:30", ExpressionDescriptor.GetDescription("30 02 14 * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestSecondInternvals()
        {
            Assert.AreEqual("Secondi 05 al 10 oltre il minuto", ExpressionDescriptor.GetDescription("5-10 * * * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestSecondMinutesHoursIntervals()
        {
            Assert.AreEqual("Secondi 05 al 10 oltre il minuto, minuti 30 al 35 dopo l'ora, tra le 10:00 e le 12:59", ExpressionDescriptor.GetDescription("5-10 30-35 10-12 * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestEvery5MinutesAt30Seconds()
        {
            Assert.AreEqual("Al 30 secondo passato il minuto, ogni 05 minuti", ExpressionDescriptor.GetDescription("30 */5 * * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestMinutesPastTheHourRange()
        {
            Assert.AreEqual("Al 30 minuto passata l'ora, tra le 10:00 e le 13:59, solo il mercoledì e venerdì", ExpressionDescriptor.GetDescription("0 30 10-13 ? * WED,FRI"));
        }

        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestSecondsPastTheMinuteInterval()
        {
            Assert.AreEqual("Al 10 secondo passato il minuto, ogni 05 minuti", ExpressionDescriptor.GetDescription("10 0/5 * * * ?"));
        }

        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestBetweenWithInterval()
        {
            Assert.AreEqual("Ogni 03 minuti, minuti 02 al 59 dopo l'ora, alle 01:00, 09:00, e 22:00, tra il giorno 11 e 26 del mese, gennaio al giugno", ExpressionDescriptor.GetDescription("2-59/3 1,9,22 11-26 1-6 ?"));
        }

        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestRecurringFirstOfMonth()
        {
            Assert.AreEqual("Alle 06:00", ExpressionDescriptor.GetDescription("0 0 6 1/1 * ?"));
        }


        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestMinutesPastTheHour()
        {
            Assert.AreEqual("Al 05 minuto passata l'ora", ExpressionDescriptor.GetDescription("0 5 0/1 * * ?"));
        }

        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestOneYearOnlyWithSeconds()
        {
            Assert.AreEqual("Ogni secondo, solo in 2013", ExpressionDescriptor.GetDescription("* * * * * * 2013"));
        }

        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestOneYearOnlyWithoutSeconds()
        {
            Assert.AreEqual("Ogni minuto, solo in 2013", ExpressionDescriptor.GetDescription("* * * * * 2013"));
        }

        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestTwoYearsOnly()
        {
            Assert.AreEqual("Ogni minuto, solo in 2013 e 2014", ExpressionDescriptor.GetDescription("* * * * * 2013,2014"));
        }

        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestYearRange2()
        {
            Assert.AreEqual("Alle 12:23, gennaio al febbraio, 2013 al 2014", ExpressionDescriptor.GetDescription("23 12 * JAN-FEB * 2013-2014"));
        }

        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestYearRange3()
        {
            Assert.AreEqual("Alle 12:23, gennaio al marzo, 2013 al 2015", ExpressionDescriptor.GetDescription("23 12 * JAN-MAR * 2013-2015"));
        }

        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestHourRange()
        {
            Assert.AreEqual("Ogni 30 minuti, tra le 08:00 e le 09:59, il giorno 5 e 20 del mese", ExpressionDescriptor.GetDescription("0 0/30 8-9 5,20 * ?"));
        }

        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestDayOfWeekModifier()
        {
            Assert.AreEqual("Alle 12:23, il secondo domenica del mese", ExpressionDescriptor.GetDescription("23 12 * * SUN#2"));
        }

        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestDayOfWeekModifierWithSundayStartOne()
        {
            Options options = new Options();
            options.DayOfWeekStartIndexZero = false;

            Assert.AreEqual("Alle 12:23, il secondo domenica del mese", ExpressionDescriptor.GetDescription("23 12 * * 1#2", options));
        }

        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestHourRangeWithEveryPortion()
        {
            Assert.AreEqual("Al 25 minuto passata l'ora, ogni 13 ore, tra le 07:00 e le 19:59", ExpressionDescriptor.GetDescription("0 25 7-19/13 ? * *"));
        }

        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestHourRangeWithTrailingZeroWithEveryPortion()
        {
            Assert.AreEqual("Al 25 minuto passata l'ora, ogni 13 ore, tra le 07:00 e le 20:59", ExpressionDescriptor.GetDescription("0 25 7-20/13 ? * *"));
        }

        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestEvery3Day()
        {
            Assert.AreEqual("Alle 08:00, ogni 3 giorni", ExpressionDescriptor.GetDescription("0 0 8 1/3 * ? *"));
        }

        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestsEvery3DayOfTheWeek()
        {
            Assert.AreEqual("Alle 10:15, ogni 3 giorni della settimana", ExpressionDescriptor.GetDescription("0 15 10 ? * */3"));
        }

        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestEvery3Month()
        {
            Assert.AreEqual("Alle 07:05, il giorno 2 del mese, ogni 3 mesi", ExpressionDescriptor.GetDescription("0 5 7 2 1/3 ? *"));
        }

        [TestMethod]
        [DeploymentItem(@"it\CronExpressionDescriptor.resources.dll", "it")]
        public void TestEvery2Years()
        {
            Assert.AreEqual("Alle 06:15, il giorno 1 del mese, solo in gennaio, ogni 2 anni", ExpressionDescriptor.GetDescription("0 15 6 1 1 ? 1/2"));
        }



    }
}
