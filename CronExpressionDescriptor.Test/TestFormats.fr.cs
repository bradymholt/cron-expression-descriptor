using NUnit.Framework;
using System.Globalization;
using System.Threading;

namespace CronExpressionDescriptor.Test
{
    [TestFixture]
    public class TestFormatsFR
    {
        [TestFixtureSetUp]
        public void SetUp()
        {
            CultureInfo myCultureInfo = new CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = myCultureInfo;
            Thread.CurrentThread.CurrentUICulture = myCultureInfo;
        }

        [Test]
       
        public void TestEveryMinute()
        {
            Assert.AreEqual("Toutes les minutes", ExpressionDescriptor.GetDescription("* * * * *"));
        }
        [Test]
       
        public void TestEvery1Minute()
        {
            Assert.AreEqual("Toutes les minutes", ExpressionDescriptor.GetDescription("*/1 * * * *"));
            Assert.AreEqual("Toutes les minutes", ExpressionDescriptor.GetDescription("0 0/1 * * * ?"));
        }
        [Test]
       
        public void TestEveryHour()
        {
            Assert.AreEqual("Toutes les heures", ExpressionDescriptor.GetDescription("0 0 * * * ?"));
            Assert.AreEqual("Toutes les heures", ExpressionDescriptor.GetDescription("0 0 0/1 * * ?"));
        }
        [Test]
       
        public void TestTimeOfDayCertainDaysOfWeek()
        {
            Assert.AreEqual("À 11:00 PM, de lundi à vendredi", ExpressionDescriptor.GetDescription("0 23 ? * MON-FRI"));
        }
        [Test]
       
        public void TestEverySecond()
        {
            Assert.AreEqual("Toutes les secondes", ExpressionDescriptor.GetDescription("* * * * * *"));
        }
        [Test]
       
        public void TestEvery45Seconds()
        {
            Assert.AreEqual("Toutes les 45 secondes", ExpressionDescriptor.GetDescription("*/45 * * * * *"));
        }
        [Test]
       
        public void TestEvery5Minutes()
        {
            Assert.AreEqual("Toutes les 5 minutes", ExpressionDescriptor.GetDescription("*/5 * * * *"));
            Assert.AreEqual("Toutes les 10 minutes", ExpressionDescriptor.GetDescription("0 0/10 * * * ?"));
        }
        [Test]
       
        public void TestEvery5MinutesOnTheSecond()
        {
            Assert.AreEqual("Toutes les 5 minutes", ExpressionDescriptor.GetDescription("0 */5 * * * *"));
        }

        [Test]
       
        public void TestWeekdaysAtTime()
        {
            Assert.AreEqual("À 11:30 AM, de lundi à vendredi", ExpressionDescriptor.GetDescription("30 11 * * 1-5"));
        }

        [Test]
       
        public void TestDailyAtTime()
        {
            Assert.AreEqual("À 11:30 AM", ExpressionDescriptor.GetDescription("30 11 * * *"));
        }
        [Test]
       
        public void TestMinuteSpan()
        {
            Assert.AreEqual("Toutes les minutes entre 11:00 AM et 11:10 AM", ExpressionDescriptor.GetDescription("0-10 11 * * *"));
        }

        [Test]
       
        public void TestOneMonthOnly()
        {
            Assert.AreEqual("Toutes les minutes, uniquement en mars", ExpressionDescriptor.GetDescription("* * * 3 *"));
        }

        [Test]
       
        public void TestTwoMonthsOnly()
        {
            Assert.AreEqual("Toutes les minutes, uniquement en mars et juin", ExpressionDescriptor.GetDescription("* * * 3,6 *"));
        }
        [Test]
        public void TestTwoTimesEachAfternoon()
        {
            Assert.AreEqual("À 02:30 PM et 04:30 PM", ExpressionDescriptor.GetDescription("30 14,16 * * *"));
        }

        [Test]
       
        public void TestThreeTimesDaily()
        {
            Assert.AreEqual("À 06:30 AM, 02:30 PM et 04:30 PM", ExpressionDescriptor.GetDescription("30 6,14,16 * * *"));
        }

        [Test]
       
        public void TestOnceAWeek()
        {
            Assert.AreEqual("À 09:46 AM, uniquement le lundi", ExpressionDescriptor.GetDescription("46 9 * * 1"));
        }
        [Test]
       
        public void TestDayOfMonth()
        {
            Assert.AreEqual("À 12:23 PM, le 15 du mois", ExpressionDescriptor.GetDescription("23 12 15 * *"));
        }

        [Test]
       
        public void TestMonthName()
        {
            Assert.AreEqual("À 12:23 PM, uniquement en janvier", ExpressionDescriptor.GetDescription("23 12 * JAN *"));
        }

        [Test]
       
        public void TestDayOfMonthWithQuestionMark()
        {
            Assert.AreEqual("À 12:23 PM, uniquement en janvier", ExpressionDescriptor.GetDescription("23 12 ? JAN *"));
        }
        [Test]
       
        public void TestMonthNameRange2()
        {
            Assert.AreEqual("À 12:23 PM, de janvier à février", ExpressionDescriptor.GetDescription("23 12 * JAN-FEB *"));
        }

        [Test]
       
        public void TestMonthNameRange3()
        {
            Assert.AreEqual("À 12:23 PM, de janvier à mars", ExpressionDescriptor.GetDescription("23 12 * JAN-MAR *"));
        }

        [Test]
       
        public void TestDayOfWeekName()
        {
            Assert.AreEqual("À 12:23 PM, uniquement le dimanche", ExpressionDescriptor.GetDescription("23 12 * * SUN"));
        }
        [Test]
       
        public void TestDayOfWeekRange()
        {
            Assert.AreEqual("Toutes les 5 minutes, à 03:00 PM, de lundi à vendredi", ExpressionDescriptor.GetDescription("*/5 15 * * MON-FRI"));
        }

        [Test]
       
        public void TestDayOfWeekOnceInMonth()
        {
            Assert.AreEqual("Toutes les minutes, le troisième lundi du mois", ExpressionDescriptor.GetDescription("* * * * MON#3"));
        }

        [Test]
       
        public void TestLastDayOfTheWeekOfTheMonth()
        {
            Assert.AreEqual("Toutes les minutes, le dernier jeudi du mois", ExpressionDescriptor.GetDescription("* * * * 4L"));
        }
        [Test]
       
        public void TestLastDayOfTheMonth()
        {
            Assert.AreEqual("Toutes les 5 minutes, le dernier jour du mois, uniquement en janvier", ExpressionDescriptor.GetDescription("*/5 * L JAN *"));
        }

        [Test]
       
        public void TestLastWeekdayOfTheMonth()
        {
            Assert.AreEqual("Toutes les minutes, le dernier jour ouvrable du mois", ExpressionDescriptor.GetDescription("* * LW * *"));
        }

        [Test]
       
        public void TestLastWeekdayOfTheMonth2()
        {
            Assert.AreEqual("Toutes les minutes, le dernier jour ouvrable du mois", ExpressionDescriptor.GetDescription("* * WL * *"));
        }
        [Test]
       
        public void TestFirstWeekdayOfTheMonth()
        {
            Assert.AreEqual("Toutes les minutes, le premier jour ouvrable du mois", ExpressionDescriptor.GetDescription("* * 1W * *"));
        }

        [Test]
       
        public void TestFirstWeekdayOfTheMonth2()
        {
            Assert.AreEqual("Toutes les minutes, le premier jour ouvrable du mois", ExpressionDescriptor.GetDescription("* * W1 * *"));
        }

        [Test]
       
        public void TestParticularWeekdayOfTheMonth()
        {
            Assert.AreEqual("Toutes les minutes, le jour ouvrable le plus proche du 5 du mois", ExpressionDescriptor.GetDescription("* * 5W * *"));
        }
        [Test]
       
        public void TestParticularWeekdayOfTheMonth2()
        {
            Assert.AreEqual("Toutes les minutes, le jour ouvrable le plus proche du 5 du mois", ExpressionDescriptor.GetDescription("* * W5 * *"));
        }

        [Test]
       
        public void TestTimeOfDayWithSeconds()
        {
            Assert.AreEqual("À 02:02:30 PM", ExpressionDescriptor.GetDescription("30 02 14 * * *"));
        }

        [Test]
       
        public void TestSecondInternvals()
        {
            Assert.AreEqual("Les secondes entre 5 et 10 après la minute", ExpressionDescriptor.GetDescription("5-10 * * * * *"));
        }
        [Test]
       
        public void TestSecondMinutesHoursIntervals()
        {
            Assert.AreEqual("Les secondes entre 5 et 10 après la minute, les minutes entre 30 et 35 après l'heure, de 10:00 AM à 12:59 PM", ExpressionDescriptor.GetDescription("5-10 30-35 10-12 * * *"));
        }

        [Test]
       
        public void TestEvery5MinutesAt30Seconds()
        {
            Assert.AreEqual("30 secondes après la minute, toutes les 5 minutes", ExpressionDescriptor.GetDescription("30 */5 * * * *"));
        }

        [Test]
       
        public void TestMinutesPastTheHourRange()
        {
            Assert.AreEqual("30 minutes après l'heure, de 10:00 AM à 01:59 PM, uniquement le mercredi et vendredi", ExpressionDescriptor.GetDescription("0 30 10-13 ? * WED,FRI"));
        }
        [Test]
       
        public void TestSecondsPastTheMinuteInterval()
        {
            Assert.AreEqual("10 secondes après la minute, toutes les 5 minutes", ExpressionDescriptor.GetDescription("10 0/5 * * * ?"));
        }
        [Test]
       
        public void TestBetweenWithInterval()
        {
            Assert.AreEqual("Toutes les 3 minutes, les minutes entre 2 et 59 après l'heure, à 01:00 AM, 09:00 AM, et 10:00 PM, du 11 au 26 du mois, de janvier à juin", ExpressionDescriptor.GetDescription("2-59/3 1,9,22 11-26 1-6 ?"));
        }
        [Test]
       
        public void TestRecurringFirstOfMonth()
        {
            Assert.AreEqual("À 06:00 AM", ExpressionDescriptor.GetDescription("0 0 6 1/1 * ?"));
        }
        [Test]
       
        public void TestMinutesPastTheHour()
        {
            Assert.AreEqual("5 minutes après l'heure", ExpressionDescriptor.GetDescription("0 5 0/1 * * ?"));
        }
        [Test]
       
        public void TestOneYearOnlyWithSeconds()
        {
            Assert.AreEqual("Toutes les secondes, uniquement en 2013", ExpressionDescriptor.GetDescription("* * * * * * 2013"));
        }

        [Test]
       
        public void TestOneYearOnlyWithoutSeconds()
        {
            Assert.AreEqual("Toutes les minutes, uniquement en 2013", ExpressionDescriptor.GetDescription("* * * * * 2013"));
        }

        [Test]
       
        public void TestTwoYearsOnly()
        {
            Assert.AreEqual("Toutes les minutes, uniquement en 2013 et 2014", ExpressionDescriptor.GetDescription("* * * * * 2013,2014"));
        }

        [Test]
       
        public void TestYearRange2()
        {
            Assert.AreEqual("À 12:23 PM, de janvier à février, de 2013 à 2014", ExpressionDescriptor.GetDescription("23 12 * JAN-FEB * 2013-2014"));
        }

        [Test]
       
        public void TestYearRange3()
        {
            Assert.AreEqual("À 12:23 PM, de janvier à mars, de 2013 à 2015", ExpressionDescriptor.GetDescription("23 12 * JAN-MAR * 2013-2015"));
        }

        [Test]
        public void TestSecondsInternalWithStepValue()
        {
            // GitHub Issue #49: https://github.com/bradyholt/cron-expression-descriptor/issues/49
            Assert.AreEqual("Toutes les 30 secondes, départ 5 secondes après la minute", ExpressionDescriptor.GetDescription("5/30 * * * * ?"));
        }

        [Test]
        public void TestMinutesInternalWithStepValue()
        {
            Assert.AreEqual("Toutes les 30 minutes, départ 5 minutes après l'heure", ExpressionDescriptor.GetDescription("0 5/30 * * * ?"));
        }
        
        [Test]
        public void TestHoursInternalWithStepValue()
        {
            Assert.AreEqual("Toutes les secondes, toutes les 8 heures, départ à 05:00 AM", ExpressionDescriptor.GetDescription("* * 5/8 * * ?"));
        }
        
        [Test]
        public void TestDayOfMonthInternalWithStepValue()
        {
            Assert.AreEqual("À 07:05 AM, tous les 3 jours, départ le 2 du mois", ExpressionDescriptor.GetDescription("0 5 7 2/3 * ? *"));
        }
        
        [Test]
        public void TestMonthInternalWithStepValue()
        {
            Assert.AreEqual("À 07:05 AM, tous les 2 mois, de mars à décembre", ExpressionDescriptor.GetDescription("0 5 7 ? 3/2 ? *"));
        }
        
        [Test]
        public void TestDayOfWeekInternalWithStepValue()
        {
            Assert.AreEqual("À 07:05 AM, every 3 days of the week, de mardi à samedi", ExpressionDescriptor.GetDescription("0 5 7 ? * 2/3 *"));
        }
                
        [Test]
        public void TestYearInternalWithStepValue()
        {
            Assert.AreEqual("À 07:05 AM, tous les 4 ans, de 2016 à 9999", ExpressionDescriptor.GetDescription("0 5 7 ? * ? 2016/4"));
        }
    }
}