using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;
using System.Threading;

namespace CronExpressionDescriptor.Test
{
    [TestClass]
    public class TestFormatsFR
    {
        [TestInitialize]
        public void SetUp()
        {
            CultureInfo myCultureInfo = new CultureInfo("fr");
            Thread.CurrentThread.CurrentCulture = myCultureInfo;
            Thread.CurrentThread.CurrentUICulture = myCultureInfo;
        }

        [TestMethod]
        [DeploymentItem(@"fr\CronExpressionDescriptor.resources.dll", "fr")]
        public void TestEveryMinute()
        {
            Assert.AreEqual("Toutes les minutes", ExpressionDescriptor.GetDescription("* * * * *"));
        }
        [TestMethod]
        [DeploymentItem(@"fr\CronExpressionDescriptor.resources.dll", "fr")]
        public void TestEvery1Minute()
        {
            Assert.AreEqual("Toutes les minutes", ExpressionDescriptor.GetDescription("*/1 * * * *"));
            Assert.AreEqual("Toutes les minutes", ExpressionDescriptor.GetDescription("0 0/1 * * * ?"));
        }
        [TestMethod]
        [DeploymentItem(@"fr\CronExpressionDescriptor.resources.dll", "fr")]
        public void TestEveryHour()
        {
            Assert.AreEqual("Toutes les heures", ExpressionDescriptor.GetDescription("0 0 * * * ?"));
            Assert.AreEqual("Toutes les heures", ExpressionDescriptor.GetDescription("0 0 0/1 * * ?"));
        }
        [TestMethod]
        [DeploymentItem(@"fr\CronExpressionDescriptor.resources.dll", "fr")]
        public void TestTimeOfDayCertainDaysOfWeek()
        {
            Assert.AreEqual("À 11:00 PM, de lundi à vendredi", ExpressionDescriptor.GetDescription("0 23 ? * MON-FRI"));
        }
        [TestMethod]
        [DeploymentItem(@"fr\CronExpressionDescriptor.resources.dll", "fr")]
        public void TestEverySecond()
        {
            Assert.AreEqual("Toutes les secondes", ExpressionDescriptor.GetDescription("* * * * * *"));
        }
        [TestMethod]
        [DeploymentItem(@"fr\CronExpressionDescriptor.resources.dll", "fr")]
        public void TestEvery45Seconds()
        {
            Assert.AreEqual("Toutes les 45 secondes", ExpressionDescriptor.GetDescription("*/45 * * * * *"));
        }
        [TestMethod]
        [DeploymentItem(@"fr\CronExpressionDescriptor.resources.dll", "fr")]
        public void TestEvery5Minutes()
        {
            Assert.AreEqual("Toutes les 05 minutes", ExpressionDescriptor.GetDescription("*/5 * * * *"));
            Assert.AreEqual("Toutes les 10 minutes", ExpressionDescriptor.GetDescription("0 0/10 * * * ?"));
        }
        [TestMethod]
        [DeploymentItem(@"fr\CronExpressionDescriptor.resources.dll", "fr")]
        public void TestEvery5MinutesOnTheSecond()
        {
            Assert.AreEqual("Toutes les 05 minutes", ExpressionDescriptor.GetDescription("0 */5 * * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"fr\CronExpressionDescriptor.resources.dll", "fr")]
        public void TestWeekdaysAtTime()
        {
            Assert.AreEqual("À 11:30 AM, de lundi à vendredi", ExpressionDescriptor.GetDescription("30 11 * * 1-5"));
        }

        [TestMethod]
        [DeploymentItem(@"fr\CronExpressionDescriptor.resources.dll", "fr")]
        public void TestDailyAtTime()
        {
            Assert.AreEqual("À 11:30 AM", ExpressionDescriptor.GetDescription("30 11 * * *"));
        }
        [TestMethod]
        [DeploymentItem(@"fr\CronExpressionDescriptor.resources.dll", "fr")]
        public void TestMinuteSpan()
        {
            Assert.AreEqual("Toutes les minutes entre 11:00 AM et 11:10 AM", ExpressionDescriptor.GetDescription("0-10 11 * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"fr\CronExpressionDescriptor.resources.dll", "fr")]
        public void TestOneMonthOnly()
        {
            Assert.AreEqual("Toutes les minutes, uniquement en mars", ExpressionDescriptor.GetDescription("* * * 3 *"));
        }

        [TestMethod]
        [DeploymentItem(@"fr\CronExpressionDescriptor.resources.dll", "fr")]
        public void TestTwoMonthsOnly()
        {
            Assert.AreEqual("Toutes les minutes, uniquement en mars et juin", ExpressionDescriptor.GetDescription("* * * 3,6 *"));
        }
        [TestMethod]
        public void TestTwoTimesEachAfternoon()
        {
            Assert.AreEqual("À 02:30 PM et 04:30 PM", ExpressionDescriptor.GetDescription("30 14,16 * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"fr\CronExpressionDescriptor.resources.dll", "fr")]
        public void TestThreeTimesDaily()
        {
            Assert.AreEqual("À 06:30 AM, 02:30 PM et 04:30 PM", ExpressionDescriptor.GetDescription("30 6,14,16 * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"fr\CronExpressionDescriptor.resources.dll", "fr")]
        public void TestOnceAWeek()
        {
            Assert.AreEqual("À 09:46 AM, uniquement le lundi", ExpressionDescriptor.GetDescription("46 9 * * 1"));
        }
        [TestMethod]
        [DeploymentItem(@"fr\CronExpressionDescriptor.resources.dll", "fr")]
        public void TestDayOfMonth()
        {
            Assert.AreEqual("À 12:23 PM, le 15 du mois", ExpressionDescriptor.GetDescription("23 12 15 * *"));
        }

        [TestMethod]
        [DeploymentItem(@"fr\CronExpressionDescriptor.resources.dll", "fr")]
        public void TestMonthName()
        {
            Assert.AreEqual("À 12:23 PM, uniquement en janvier", ExpressionDescriptor.GetDescription("23 12 * JAN *"));
        }

        [TestMethod]
        [DeploymentItem(@"fr\CronExpressionDescriptor.resources.dll", "fr")]
        public void TestDayOfMonthWithQuestionMark()
        {
            Assert.AreEqual("À 12:23 PM, uniquement en janvier", ExpressionDescriptor.GetDescription("23 12 ? JAN *"));
        }
        [TestMethod]
        [DeploymentItem(@"fr\CronExpressionDescriptor.resources.dll", "fr")]
        public void TestMonthNameRange2()
        {
            Assert.AreEqual("À 12:23 PM, de janvier à février", ExpressionDescriptor.GetDescription("23 12 * JAN-FEB *"));
        }

        [TestMethod]
        [DeploymentItem(@"fr\CronExpressionDescriptor.resources.dll", "fr")]
        public void TestMonthNameRange3()
        {
            Assert.AreEqual("À 12:23 PM, de janvier à mars", ExpressionDescriptor.GetDescription("23 12 * JAN-MAR *"));
        }

        [TestMethod]
        [DeploymentItem(@"fr\CronExpressionDescriptor.resources.dll", "fr")]
        public void TestDayOfWeekName()
        {
            Assert.AreEqual("À 12:23 PM, uniquement le dimanche", ExpressionDescriptor.GetDescription("23 12 * * SUN"));
        }
        [TestMethod]
        [DeploymentItem(@"fr\CronExpressionDescriptor.resources.dll", "fr")]
        public void TestDayOfWeekRange()
        {
            Assert.AreEqual("Toutes les 05 minutes, à 03:00 PM, de lundi à vendredi", ExpressionDescriptor.GetDescription("*/5 15 * * MON-FRI"));
        }

        [TestMethod]
        [DeploymentItem(@"fr\CronExpressionDescriptor.resources.dll", "fr")]
        public void TestDayOfWeekOnceInMonth()
        {
            Assert.AreEqual("Toutes les minutes, le troisième lundi du mois", ExpressionDescriptor.GetDescription("* * * * MON#3"));
        }

        [TestMethod]
        [DeploymentItem(@"fr\CronExpressionDescriptor.resources.dll", "fr")]
        public void TestLastDayOfTheWeekOfTheMonth()
        {
            Assert.AreEqual("Toutes les minutes, le dernier jeudi du mois", ExpressionDescriptor.GetDescription("* * * * 4L"));
        }
        [TestMethod]
        [DeploymentItem(@"fr\CronExpressionDescriptor.resources.dll", "fr")]
        public void TestLastDayOfTheMonth()
        {
            Assert.AreEqual("Toutes les 05 minutes, le dernier jour du mois, uniquement en janvier", ExpressionDescriptor.GetDescription("*/5 * L JAN *"));
        }

        [TestMethod]
        [DeploymentItem(@"fr\CronExpressionDescriptor.resources.dll", "fr")]
        public void TestLastWeekdayOfTheMonth()
        {
            Assert.AreEqual("Toutes les minutes, le dernier jour ouvrable du mois", ExpressionDescriptor.GetDescription("* * LW * *"));
        }

        [TestMethod]
        [DeploymentItem(@"fr\CronExpressionDescriptor.resources.dll", "fr")]
        public void TestLastWeekdayOfTheMonth2()
        {
            Assert.AreEqual("Toutes les minutes, le dernier jour ouvrable du mois", ExpressionDescriptor.GetDescription("* * WL * *"));
        }
        [TestMethod]
        [DeploymentItem(@"fr\CronExpressionDescriptor.resources.dll", "fr")]
        public void TestFirstWeekdayOfTheMonth()
        {
            Assert.AreEqual("Toutes les minutes, le premier jour ouvrable du mois", ExpressionDescriptor.GetDescription("* * 1W * *"));
        }

        [TestMethod]
        [DeploymentItem(@"fr\CronExpressionDescriptor.resources.dll", "fr")]
        public void TestFirstWeekdayOfTheMonth2()
        {
            Assert.AreEqual("Toutes les minutes, le premier jour ouvrable du mois", ExpressionDescriptor.GetDescription("* * W1 * *"));
        }

        [TestMethod]
        [DeploymentItem(@"fr\CronExpressionDescriptor.resources.dll", "fr")]
        public void TestParticularWeekdayOfTheMonth()
        {
            Assert.AreEqual("Toutes les minutes, le jour ouvrable le plus proche du 5 du mois", ExpressionDescriptor.GetDescription("* * 5W * *"));
        }
        [TestMethod]
        [DeploymentItem(@"fr\CronExpressionDescriptor.resources.dll", "fr")]
        public void TestParticularWeekdayOfTheMonth2()
        {
            Assert.AreEqual("Toutes les minutes, le jour ouvrable le plus proche du 5 du mois", ExpressionDescriptor.GetDescription("* * W5 * *"));
        }

        [TestMethod]
        [DeploymentItem(@"fr\CronExpressionDescriptor.resources.dll", "fr")]
        public void TestTimeOfDayWithSeconds()
        {
            Assert.AreEqual("À 02:02:30 PM", ExpressionDescriptor.GetDescription("30 02 14 * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"fr\CronExpressionDescriptor.resources.dll", "fr")]
        public void TestSecondInternvals()
        {
            Assert.AreEqual("Les secondes entre 05 et 10 après la minute", ExpressionDescriptor.GetDescription("5-10 * * * * *"));
        }
        [TestMethod]
        [DeploymentItem(@"fr\CronExpressionDescriptor.resources.dll", "fr")]
        public void TestSecondMinutesHoursIntervals()
        {
            Assert.AreEqual("Les secondes entre 05 et 10 après la minute, les minutes entre 30 et 35 après l'heure, de 10:00 AM à 12:59 PM", ExpressionDescriptor.GetDescription("5-10 30-35 10-12 * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"fr\CronExpressionDescriptor.resources.dll", "fr")]
        public void TestEvery5MinutesAt30Seconds()
        {
            Assert.AreEqual("30 secondes après la minute, toutes les 05 minutes", ExpressionDescriptor.GetDescription("30 */5 * * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"fr\CronExpressionDescriptor.resources.dll", "fr")]
        public void TestMinutesPastTheHourRange()
        {
            Assert.AreEqual("30 minutes après l'heure, de 10:00 AM à 01:59 PM, uniquement le mercredi et vendredi", ExpressionDescriptor.GetDescription("0 30 10-13 ? * WED,FRI"));
        }
        [TestMethod]
        [DeploymentItem(@"fr\CronExpressionDescriptor.resources.dll", "fr")]
        public void TestSecondsPastTheMinuteInterval()
        {
            Assert.AreEqual("10 secondes après la minute, toutes les 05 minutes", ExpressionDescriptor.GetDescription("10 0/5 * * * ?"));
        }
        [TestMethod]
        [DeploymentItem(@"fr\CronExpressionDescriptor.resources.dll", "fr")]
        public void TestBetweenWithInterval()
        {
            Assert.AreEqual("Toutes les 03 minutes, les minutes entre 02 et 59 après l'heure, à 01:00 AM, 09:00 AM, et 10:00 PM, du 11 au 26 du mois, de janvier à juin", ExpressionDescriptor.GetDescription("2-59/3 1,9,22 11-26 1-6 ?"));
        }
        [TestMethod]
        [DeploymentItem(@"fr\CronExpressionDescriptor.resources.dll", "fr")]
        public void TestRecurringFirstOfMonth()
        {
            Assert.AreEqual("À 06:00 AM", ExpressionDescriptor.GetDescription("0 0 6 1/1 * ?"));
        }
        [TestMethod]
        [DeploymentItem(@"fr\CronExpressionDescriptor.resources.dll", "fr")]
        public void TestMinutesPastTheHour()
        {
            Assert.AreEqual("05 minutes après l'heure", ExpressionDescriptor.GetDescription("0 5 0/1 * * ?"));
        }
        [TestMethod]
        [DeploymentItem(@"fr\CronExpressionDescriptor.resources.dll", "fr")]
        public void TestOneYearOnlyWithSeconds()
        {
            Assert.AreEqual("Toutes les secondes, uniquement en 2013", ExpressionDescriptor.GetDescription("* * * * * * 2013"));
        }

        [TestMethod]
        [DeploymentItem(@"fr\CronExpressionDescriptor.resources.dll", "fr")]
        public void TestOneYearOnlyWithoutSeconds()
        {
            Assert.AreEqual("Toutes les minutes, uniquement en 2013", ExpressionDescriptor.GetDescription("* * * * * 2013"));
        }

        [TestMethod]
        [DeploymentItem(@"fr\CronExpressionDescriptor.resources.dll", "fr")]
        public void TestTwoYearsOnly()
        {
            Assert.AreEqual("Toutes les minutes, uniquement en 2013 et 2014", ExpressionDescriptor.GetDescription("* * * * * 2013,2014"));
        }

        [TestMethod]
        [DeploymentItem(@"fr\CronExpressionDescriptor.resources.dll", "fr")]
        public void TestYearRange2()
        {
            Assert.AreEqual("À 12:23 PM, de janvier à février, de 2013 à 2014", ExpressionDescriptor.GetDescription("23 12 * JAN-FEB * 2013-2014"));
        }

        [TestMethod]
        [DeploymentItem(@"fr\CronExpressionDescriptor.resources.dll", "fr")]
        public void TestYearRange3()
        {
            Assert.AreEqual("À 12:23 PM, de janvier à mars, de 2013 à 2015", ExpressionDescriptor.GetDescription("23 12 * JAN-MAR * 2013-2015"));
        }
    }
}