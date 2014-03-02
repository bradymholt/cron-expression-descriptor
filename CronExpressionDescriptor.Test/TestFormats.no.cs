using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;
using System.Threading;

namespace CronExpressionDescriptor.Test
{
    [TestClass]
    public class TestFormatsNo
    {
        [TestInitialize]
        public void SetUp()
        {
            CultureInfo myCultureInfo = new CultureInfo("no");
            Thread.CurrentThread.CurrentCulture = myCultureInfo;
            Thread.CurrentThread.CurrentUICulture = myCultureInfo;
        }

        [TestMethod]
        [DeploymentItem(@"no\CronExpressionDescriptor.resources.dll", "no")]
        public void TestEveryMinute()
        {
            Assert.AreEqual("Hvert minutt", ExpressionDescriptor.GetDescription("* * * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"no\CronExpressionDescriptor.resources.dll", "no")]
        public void TestEvery1Minute()
        {
            Assert.AreEqual("Hvert minutt", ExpressionDescriptor.GetDescription("*/1 * * * *"));
            Assert.AreEqual("Hvert minutt", ExpressionDescriptor.GetDescription("0 0/1 * * * ?"));
        }

        [TestMethod]
        [DeploymentItem(@"no\CronExpressionDescriptor.resources.dll", "no")]
        public void TestEveryHour()
        {
            Assert.AreEqual("Hver time", ExpressionDescriptor.GetDescription("0 0 * * * ?"));
            Assert.AreEqual("Hver time", ExpressionDescriptor.GetDescription("0 0 0/1 * * ?"));
        }

        [TestMethod]
        [DeploymentItem(@"no\CronExpressionDescriptor.resources.dll", "no")]
        public void TestTimeOfDayCertainDaysOfWeek()
        {
            Assert.AreEqual(
                "På 11:00 PM, mandag til og med fredag", ExpressionDescriptor.GetDescription("0 23 ? * MON-FRI"));
        }

        [TestMethod]
        [DeploymentItem(@"no\CronExpressionDescriptor.resources.dll", "no")]
        public void TestEverySecond()
        {
            Assert.AreEqual("Hvert sekund", ExpressionDescriptor.GetDescription("* * * * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"no\CronExpressionDescriptor.resources.dll", "no")]
        public void TestEvery45Seconds()
        {
            Assert.AreEqual("Hvert 45 sekund", ExpressionDescriptor.GetDescription("*/45 * * * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"no\CronExpressionDescriptor.resources.dll", "no")]
        public void TestEvery5Minutes()
        {
            Assert.AreEqual("Hvert 05 minutt", ExpressionDescriptor.GetDescription("*/5 * * * *"));
            Assert.AreEqual("Hvert 10 minutt", ExpressionDescriptor.GetDescription("0 0/10 * * * ?"));
        }

        [TestMethod]
        [DeploymentItem(@"no\CronExpressionDescriptor.resources.dll", "no")]
        public void TestEvery5MinutesOnTheSecond()
        {
            Assert.AreEqual("Hvert 05 minutt", ExpressionDescriptor.GetDescription("0 */5 * * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"no\CronExpressionDescriptor.resources.dll", "no")]
        public void TestWeekdaysAtTime()
        {
            Assert.AreEqual("På 11:30 AM, mandag til og med fredag", ExpressionDescriptor.GetDescription("30 11 * * 1-5"));
        }

        [TestMethod]
        [DeploymentItem(@"no\CronExpressionDescriptor.resources.dll", "no")]
        public void TestDailyAtTime()
        {
            Assert.AreEqual("På 11:30 AM", ExpressionDescriptor.GetDescription("30 11 * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"no\CronExpressionDescriptor.resources.dll", "no")]
        public void TestMinuteSpan()
        {
            Assert.AreEqual(
                "Hvert minutt mellom 11:00 AM og 11:10 AM", ExpressionDescriptor.GetDescription("0-10 11 * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"no\CronExpressionDescriptor.resources.dll", "no")]
        public void TestOneMonthOnly()
        {
            Assert.AreEqual("Hvert minutt, bare i mars", ExpressionDescriptor.GetDescription("* * * 3 *"));
        }

        [TestMethod]
        [DeploymentItem(@"no\CronExpressionDescriptor.resources.dll", "no")]
        public void TestTwoMonthsOnly()
        {
            Assert.AreEqual("Hvert minutt, bare i mars og juni", ExpressionDescriptor.GetDescription("* * * 3,6 *"));
        }

        [TestMethod]
        [DeploymentItem(@"no\CronExpressionDescriptor.resources.dll", "no")]
        public void TestTwoTimesEachAfternoon()
        {
            Assert.AreEqual("På 02:30 PM og 04:30 PM", ExpressionDescriptor.GetDescription("30 14,16 * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"no\CronExpressionDescriptor.resources.dll", "no")]
        public void TestThreeTimesDaily()
        {
            Assert.AreEqual(
                "På 06:30 AM, 02:30 PM og 04:30 PM", ExpressionDescriptor.GetDescription("30 6,14,16 * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"no\CronExpressionDescriptor.resources.dll", "no")]
        public void TestOnceAWeek()
        {
            Assert.AreEqual("På 09:46 AM, bare på mandag", ExpressionDescriptor.GetDescription("46 9 * * 1"));
        }

        [TestMethod]
        [DeploymentItem(@"no\CronExpressionDescriptor.resources.dll", "no")]
        public void TestDayOfMonth()
        {
            Assert.AreEqual("På 12:23 PM, på dag 15 av måneden", ExpressionDescriptor.GetDescription("23 12 15 * *"));
        }

        [TestMethod]
        [DeploymentItem(@"no\CronExpressionDescriptor.resources.dll", "no")]
        public void TestMonthName()
        {
            Assert.AreEqual("På 12:23 PM, bare i januar", ExpressionDescriptor.GetDescription("23 12 * JAN *"));
        }

        [TestMethod]
        [DeploymentItem(@"no\CronExpressionDescriptor.resources.dll", "no")]
        public void TestDayOfMonthWithQuestionMark()
        {
            Assert.AreEqual("På 12:23 PM, bare i januar", ExpressionDescriptor.GetDescription("23 12 ? JAN *"));
        }

        [TestMethod]
        [DeploymentItem(@"no\CronExpressionDescriptor.resources.dll", "no")]
        public void TestMonthNameRange2()
        {
            Assert.AreEqual(
                "På 12:23 PM, januar til og med februar", ExpressionDescriptor.GetDescription("23 12 * JAN-FEB *"));
        }

        [TestMethod]
        [DeploymentItem(@"no\CronExpressionDescriptor.resources.dll", "no")]
        public void TestMonthNameRange3()
        {
            Assert.AreEqual(
                "På 12:23 PM, januar til og med mars", ExpressionDescriptor.GetDescription("23 12 * JAN-MAR *"));
        }

        [TestMethod]
        [DeploymentItem(@"no\CronExpressionDescriptor.resources.dll", "no")]
        public void TestDayOfWeekName()
        {
            Assert.AreEqual("På 12:23 PM, bare på søndag", ExpressionDescriptor.GetDescription("23 12 * * SUN"));
        }

        [TestMethod]
        [DeploymentItem(@"no\CronExpressionDescriptor.resources.dll", "no")]
        public void TestDayOfWeekRange()
        {
            Assert.AreEqual(
                "Hvert 05 minutt, på 03:00 PM, mandag til og med fredag",
                ExpressionDescriptor.GetDescription("*/5 15 * * MON-FRI"));
        }

        [TestMethod]
        [DeploymentItem(@"no\CronExpressionDescriptor.resources.dll", "no")]
        public void TestDayOfWeekOnceInMonth()
        {
            Assert.AreEqual(
                "Hvert minutt, på den tredje mandag av måneden", ExpressionDescriptor.GetDescription("* * * * MON#3"));
        }

        [TestMethod]
        [DeploymentItem(@"no\CronExpressionDescriptor.resources.dll", "no")]
        public void TestLastDayOfTheWeekOfTheMonth()
        {
            Assert.AreEqual(
                "Hvert minutt, på den siste torsdag av måneden", ExpressionDescriptor.GetDescription("* * * * 4L"));
        }

        [TestMethod]
        [DeploymentItem(@"no\CronExpressionDescriptor.resources.dll", "no")]
        public void TestLastDayOfTheMonth()
        {
            Assert.AreEqual(
                "Hvert 05 minutt, på den siste dagen i måneden, bare i januar",
                ExpressionDescriptor.GetDescription("*/5 * L JAN *"));
        }

        [TestMethod]
        [DeploymentItem(@"no\CronExpressionDescriptor.resources.dll", "no")]
        public void TestLastWeekdayOfTheMonth()
        {
            Assert.AreEqual(
                "Hvert minutt, på den siste ukedagen i måneden", ExpressionDescriptor.GetDescription("* * LW * *"));
        }

        [TestMethod]
        [DeploymentItem(@"no\CronExpressionDescriptor.resources.dll", "no")]
        public void TestLastWeekdayOfTheMonth2()
        {
            Assert.AreEqual(
                "Hvert minutt, på den siste ukedagen i måneden", ExpressionDescriptor.GetDescription("* * WL * *"));
        }

        [TestMethod]
        [DeploymentItem(@"no\CronExpressionDescriptor.resources.dll", "no")]
        public void TestFirstWeekdayOfTheMonth()
        {
            Assert.AreEqual(
                "Hvert minutt, på den første ukedag av måneden", ExpressionDescriptor.GetDescription("* * 1W * *"));
        }

        [TestMethod]
        [DeploymentItem(@"no\CronExpressionDescriptor.resources.dll", "no")]
        public void TestFirstWeekdayOfTheMonth2()
        {
            Assert.AreEqual(
                "Hvert minutt, på den første ukedag av måneden", ExpressionDescriptor.GetDescription("* * W1 * *"));
        }

        [TestMethod]
        [DeploymentItem(@"no\CronExpressionDescriptor.resources.dll", "no")]
        public void TestParticularWeekdayOfTheMonth()
        {
            Assert.AreEqual(
                "Hvert minutt, på den ukedag nærmest dag 5 av måneden",
                ExpressionDescriptor.GetDescription("* * 5W * *"));
        }

        [TestMethod]
        [DeploymentItem(@"no\CronExpressionDescriptor.resources.dll", "no")]
        public void TestParticularWeekdayOfTheMonth2()
        {
            Assert.AreEqual(
                "Hvert minutt, på den ukedag nærmest dag 5 av måneden",
                ExpressionDescriptor.GetDescription("* * W5 * *"));
        }

        [TestMethod]
        [DeploymentItem(@"no\CronExpressionDescriptor.resources.dll", "no")]
        public void TestTimeOfDayWithSeconds()
        {
            Assert.AreEqual("På 02:02:30 PM", ExpressionDescriptor.GetDescription("30 02 14 * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"no\CronExpressionDescriptor.resources.dll", "no")]
        public void TestSecondInternvals()
        {
            Assert.AreEqual(
                "Sekundene fra 05 til og med 10 etter minuttet", ExpressionDescriptor.GetDescription("5-10 * * * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"no\CronExpressionDescriptor.resources.dll", "no")]
        public void TestSecondMinutesHoursIntervals()
        {
            Assert.AreEqual(
                "Sekundene fra 05 til og med 10 etter minuttet, minuttene fra 30 til og med 35 etter timen, mellom 10:00 AM og 01:00 PM",
                ExpressionDescriptor.GetDescription("5-10 30-35 10-12 * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"no\CronExpressionDescriptor.resources.dll", "no")]
        public void TestEvery5MinutesAt30Seconds()
        {
            Assert.AreEqual(
                "På 30 sekunder etter minuttet, hvert 05 minutt", ExpressionDescriptor.GetDescription("30 */5 * * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"no\CronExpressionDescriptor.resources.dll", "no")]
        public void TestMinutesPastTheHourRange()
        {
            Assert.AreEqual(
                "På 30 minutter etter timen, mellom 10:00 AM og 02:00 PM, bare på onsdag og fredag",
                ExpressionDescriptor.GetDescription("0 30 10-13 ? * WED,FRI"));
        }

        [TestMethod]
        [DeploymentItem(@"no\CronExpressionDescriptor.resources.dll", "no")]
        public void TestSecondsPastTheMinuteInterval()
        {
            Assert.AreEqual(
                "På 10 sekunder etter minuttet, hvert 05 minutt", ExpressionDescriptor.GetDescription("10 0/5 * * * ?"));
        }

        [TestMethod]
        [DeploymentItem(@"no\CronExpressionDescriptor.resources.dll", "no")]
        public void TestBetweenWithInterval()
        {
            Assert.AreEqual(
                "Hvert 03 minutt, minuttene fra 02 til og med 59 etter timen, på 01:00 AM, 09:00 AM, og 10:00 PM, mellom dag 11 og 26 av måneden, januar til og med juni",
                ExpressionDescriptor.GetDescription("2-59/3 1,9,22 11-26 1-6 ?"));
        }

        [TestMethod]
        [DeploymentItem(@"no\CronExpressionDescriptor.resources.dll", "no")]
        public void TestRecurringFirstOfMonth()
        {
            Assert.AreEqual("På 06:00 AM", ExpressionDescriptor.GetDescription("0 0 6 1/1 * ?"));
        }

        [TestMethod]
        [DeploymentItem(@"no\CronExpressionDescriptor.resources.dll", "no")]
        public void TestMinutesPastTheHour()
        {
            Assert.AreEqual("På 05 minutter etter timen", ExpressionDescriptor.GetDescription("0 5 0/1 * * ?"));
        }

        [TestMethod]
        [DeploymentItem(@"no\CronExpressionDescriptor.resources.dll", "no")]
        public void TestOneYearOnlyWithSeconds()
        {
            Assert.AreEqual("Hvert sekund, bare i 2013", ExpressionDescriptor.GetDescription("* * * * * * 2013"));
        }

        [TestMethod]
        [DeploymentItem(@"no\CronExpressionDescriptor.resources.dll", "no")]
        public void TestOneYearOnlyWithoutSeconds()
        {
            Assert.AreEqual("Hvert minutt, bare i 2013", ExpressionDescriptor.GetDescription("* * * * * 2013"));
        }

        [TestMethod]
        [DeploymentItem(@"no\CronExpressionDescriptor.resources.dll", "no")]
        public void TestTwoYearsOnly()
        {
            Assert.AreEqual(
                "Hvert minutt, bare i 2013 og 2014", ExpressionDescriptor.GetDescription("* * * * * 2013,2014"));
        }

        [TestMethod]
        [DeploymentItem(@"no\CronExpressionDescriptor.resources.dll", "no")]
        public void TestYearRange2()
        {
            Assert.AreEqual(
                "På 12:23 PM, januar til og med februar, 2013 til og med 2014",
                ExpressionDescriptor.GetDescription("23 12 * JAN-FEB * 2013-2014"));
        }

        [TestMethod]
        [DeploymentItem(@"no\CronExpressionDescriptor.resources.dll", "no")]
        public void TestYearRange3()
        {
            Assert.AreEqual(
                "På 12:23 PM, januar til og med mars, 2013 til og med 2015",
                ExpressionDescriptor.GetDescription("23 12 * JAN-MAR * 2013-2015"));
        }
    }
}
