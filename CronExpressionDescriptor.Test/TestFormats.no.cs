using NUnit.Framework;
using System.Globalization;
using System.Threading;

namespace CronExpressionDescriptor.Test
{
    [TestFixture]
    public class TestFormatsNo
    {
        [TestFixtureSetUp]
        public void SetUp()
        {
            CultureInfo myCultureInfo = new CultureInfo("nb-NO");
            Thread.CurrentThread.CurrentCulture = myCultureInfo;
            Thread.CurrentThread.CurrentUICulture = myCultureInfo;
        }

        [Test]
        
        public void TestEveryMinute()
        {
            Assert.AreEqual("Hvert minutt", ExpressionDescriptor.GetDescription("* * * * *"));
        }

        [Test]
        
        public void TestEvery1Minute()
        {
            Assert.AreEqual("Hvert minutt", ExpressionDescriptor.GetDescription("*/1 * * * *"));
            Assert.AreEqual("Hvert minutt", ExpressionDescriptor.GetDescription("0 0/1 * * * ?"));
        }

        [Test]
        
        public void TestEveryHour()
        {
            Assert.AreEqual("Hver time", ExpressionDescriptor.GetDescription("0 0 * * * ?"));
            Assert.AreEqual("Hver time", ExpressionDescriptor.GetDescription("0 0 0/1 * * ?"));
        }

        [Test]
        
        public void TestTimeOfDayCertainDaysOfWeek()
        {
            Assert.AreEqual(
                "På 11:00 PM, mandag til og med fredag", ExpressionDescriptor.GetDescription("0 23 ? * MON-FRI"));
        }

        [Test]
        
        public void TestEverySecond()
        {
            Assert.AreEqual("Hvert sekund", ExpressionDescriptor.GetDescription("* * * * * *"));
        }

        [Test]
        
        public void TestEvery45Seconds()
        {
            Assert.AreEqual("Hvert 45 sekund", ExpressionDescriptor.GetDescription("*/45 * * * * *"));
        }

        [Test]
        
        public void TestEvery5Minutes()
        {
            Assert.AreEqual("Hvert 5 minutt", ExpressionDescriptor.GetDescription("*/5 * * * *"));
            Assert.AreEqual("Hvert 10 minutt", ExpressionDescriptor.GetDescription("0 0/10 * * * ?"));
        }

        [Test]
        
        public void TestEvery5MinutesOnTheSecond()
        {
            Assert.AreEqual("Hvert 5 minutt", ExpressionDescriptor.GetDescription("0 */5 * * * *"));
        }

        [Test]
        
        public void TestWeekdaysAtTime()
        {
            Assert.AreEqual("På 11:30 AM, mandag til og med fredag", ExpressionDescriptor.GetDescription("30 11 * * 1-5"));
        }

        [Test]
        
        public void TestDailyAtTime()
        {
            Assert.AreEqual("På 11:30 AM", ExpressionDescriptor.GetDescription("30 11 * * *"));
        }

        [Test]
        
        public void TestMinuteSpan()
        {
            Assert.AreEqual(
                "Hvert minutt mellom 11:00 AM og 11:10 AM", ExpressionDescriptor.GetDescription("0-10 11 * * *"));
        }

        [Test]
        
        public void TestOneMonthOnly()
        {
            Assert.AreEqual("Hvert minutt, bare i mars", ExpressionDescriptor.GetDescription("* * * 3 *"));
        }

        [Test]
        
        public void TestTwoMonthsOnly()
        {
            Assert.AreEqual("Hvert minutt, bare i mars og juni", ExpressionDescriptor.GetDescription("* * * 3,6 *"));
        }

        [Test]
        
        public void TestTwoTimesEachAfternoon()
        {
            Assert.AreEqual("På 02:30 PM og 04:30 PM", ExpressionDescriptor.GetDescription("30 14,16 * * *"));
        }

        [Test]
        
        public void TestThreeTimesDaily()
        {
            Assert.AreEqual(
                "På 06:30 AM, 02:30 PM og 04:30 PM", ExpressionDescriptor.GetDescription("30 6,14,16 * * *"));
        }

        [Test]
        
        public void TestOnceAWeek()
        {
            Assert.AreEqual("På 09:46 AM, bare på mandag", ExpressionDescriptor.GetDescription("46 9 * * 1"));
        }

        [Test]
        
        public void TestDayOfMonth()
        {
            Assert.AreEqual("På 12:23 PM, på dag 15 av måneden", ExpressionDescriptor.GetDescription("23 12 15 * *"));
        }

        [Test]
        
        public void TestMonthName()
        {
            Assert.AreEqual("På 12:23 PM, bare i januar", ExpressionDescriptor.GetDescription("23 12 * JAN *"));
        }

        [Test]
        
        public void TestDayOfMonthWithQuestionMark()
        {
            Assert.AreEqual("På 12:23 PM, bare i januar", ExpressionDescriptor.GetDescription("23 12 ? JAN *"));
        }

        [Test]
        
        public void TestMonthNameRange2()
        {
            Assert.AreEqual(
                "På 12:23 PM, januar til og med februar", ExpressionDescriptor.GetDescription("23 12 * JAN-FEB *"));
        }

        [Test]
        
        public void TestMonthNameRange3()
        {
            Assert.AreEqual(
                "På 12:23 PM, januar til og med mars", ExpressionDescriptor.GetDescription("23 12 * JAN-MAR *"));
        }

        [Test]
        
        public void TestDayOfWeekName()
        {
            Assert.AreEqual("På 12:23 PM, bare på søndag", ExpressionDescriptor.GetDescription("23 12 * * SUN"));
        }

        [Test]
        
        public void TestDayOfWeekRange()
        {
            Assert.AreEqual(
                "Hvert 5 minutt, på 03:00 PM, mandag til og med fredag",
                ExpressionDescriptor.GetDescription("*/5 15 * * MON-FRI"));
        }

        [Test]
        
        public void TestDayOfWeekOnceInMonth()
        {
            Assert.AreEqual(
                "Hvert minutt, på den tredje mandag av måneden", ExpressionDescriptor.GetDescription("* * * * MON#3"));
        }

        [Test]
        
        public void TestLastDayOfTheWeekOfTheMonth()
        {
            Assert.AreEqual(
                "Hvert minutt, på den siste torsdag av måneden", ExpressionDescriptor.GetDescription("* * * * 4L"));
        }

        [Test]
        
        public void TestLastDayOfTheMonth()
        {
            Assert.AreEqual(
                "Hvert 5 minutt, på den siste dagen i måneden, bare i januar",
                ExpressionDescriptor.GetDescription("*/5 * L JAN *"));
        }

        [Test]
        
        public void TestLastWeekdayOfTheMonth()
        {
            Assert.AreEqual(
                "Hvert minutt, på den siste ukedagen i måneden", ExpressionDescriptor.GetDescription("* * LW * *"));
        }

        [Test]
        
        public void TestLastWeekdayOfTheMonth2()
        {
            Assert.AreEqual(
                "Hvert minutt, på den siste ukedagen i måneden", ExpressionDescriptor.GetDescription("* * WL * *"));
        }

        [Test]
        
        public void TestFirstWeekdayOfTheMonth()
        {
            Assert.AreEqual(
                "Hvert minutt, på den første ukedag av måneden", ExpressionDescriptor.GetDescription("* * 1W * *"));
        }

        [Test]
        
        public void TestFirstWeekdayOfTheMonth2()
        {
            Assert.AreEqual(
                "Hvert minutt, på den første ukedag av måneden", ExpressionDescriptor.GetDescription("* * W1 * *"));
        }

        [Test]
        
        public void TestParticularWeekdayOfTheMonth()
        {
            Assert.AreEqual(
                "Hvert minutt, på den ukedag nærmest dag 5 av måneden",
                ExpressionDescriptor.GetDescription("* * 5W * *"));
        }

        [Test]
        
        public void TestParticularWeekdayOfTheMonth2()
        {
            Assert.AreEqual(
                "Hvert minutt, på den ukedag nærmest dag 5 av måneden",
                ExpressionDescriptor.GetDescription("* * W5 * *"));
        }

        [Test]
        
        public void TestTimeOfDayWithSeconds()
        {
            Assert.AreEqual("På 02:02:30 PM", ExpressionDescriptor.GetDescription("30 02 14 * * *"));
        }

        [Test]
        
        public void TestSecondInternvals()
        {
            Assert.AreEqual(
                "Sekundene fra 5 til og med 10 etter minuttet", ExpressionDescriptor.GetDescription("5-10 * * * * *"));
        }

        [Test]
        
        public void TestSecondMinutesHoursIntervals()
        {
            Assert.AreEqual(
                "Sekundene fra 5 til og med 10 etter minuttet, minuttene fra 30 til og med 35 etter timen, mellom 10:00 AM og 12:59 PM",
                ExpressionDescriptor.GetDescription("5-10 30-35 10-12 * * *"));
        }

        [Test]
        
        public void TestEvery5MinutesAt30Seconds()
        {
            Assert.AreEqual(
                "På 30 sekunder etter minuttet, hvert 5 minutt", ExpressionDescriptor.GetDescription("30 */5 * * * *"));
        }

        [Test]
        
        public void TestMinutesPastTheHourRange()
        {
            Assert.AreEqual(
                "På 30 minutter etter timen, mellom 10:00 AM og 01:59 PM, bare på onsdag og fredag",
                ExpressionDescriptor.GetDescription("0 30 10-13 ? * WED,FRI"));
        }

        [Test]
        
        public void TestSecondsPastTheMinuteInterval()
        {
            Assert.AreEqual(
                "På 10 sekunder etter minuttet, hvert 5 minutt", ExpressionDescriptor.GetDescription("10 0/5 * * * ?"));
        }

        [Test]
        
        public void TestBetweenWithInterval()
        {
            Assert.AreEqual(
                "Hvert 3 minutt, minuttene fra 2 til og med 59 etter timen, på 01:00 AM, 09:00 AM, og 10:00 PM, mellom dag 11 og 26 av måneden, januar til og med juni",
                ExpressionDescriptor.GetDescription("2-59/3 1,9,22 11-26 1-6 ?"));
        }

        [Test]
        
        public void TestRecurringFirstOfMonth()
        {
            Assert.AreEqual("På 06:00 AM", ExpressionDescriptor.GetDescription("0 0 6 1/1 * ?"));
        }

        [Test]
        
        public void TestMinutesPastTheHour()
        {
            Assert.AreEqual("På 5 minutter etter timen", ExpressionDescriptor.GetDescription("0 5 0/1 * * ?"));
        }

        [Test]
        
        public void TestOneYearOnlyWithSeconds()
        {
            Assert.AreEqual("Hvert sekund, bare i 2013", ExpressionDescriptor.GetDescription("* * * * * * 2013"));
        }

        [Test]
        
        public void TestOneYearOnlyWithoutSeconds()
        {
            Assert.AreEqual("Hvert minutt, bare i 2013", ExpressionDescriptor.GetDescription("* * * * * 2013"));
        }

        [Test]
        
        public void TestTwoYearsOnly()
        {
            Assert.AreEqual(
                "Hvert minutt, bare i 2013 og 2014", ExpressionDescriptor.GetDescription("* * * * * 2013,2014"));
        }

        [Test]
        
        public void TestYearRange2()
        {
            Assert.AreEqual(
                "På 12:23 PM, januar til og med februar, 2013 til og med 2014",
                ExpressionDescriptor.GetDescription("23 12 * JAN-FEB * 2013-2014"));
        }

        [Test]
        
        public void TestYearRange3()
        {
            Assert.AreEqual(
                "På 12:23 PM, januar til og med mars, 2013 til og med 2015",
                ExpressionDescriptor.GetDescription("23 12 * JAN-MAR * 2013-2015"));
        }

        [Test]
        public void TestSecondsInternalWithStepValue()
        {
            // GitHub Issue #49: https://github.com/bradyholt/cron-expression-descriptor/issues/49
            Assert.AreEqual("Hvert 30 sekund, starter på 5 sekunder etter minuttet", ExpressionDescriptor.GetDescription("5/30 * * * * ?"));
        }

        [Test]
        public void TestMinutesInternalWithStepValue()
        {
            Assert.AreEqual("Hvert 30 minutt, starter på 5 minutter etter timen", ExpressionDescriptor.GetDescription("0 5/30 * * * ?"));
        }
        
        [Test]
        public void TestHoursInternalWithStepValue()
        {
            Assert.AreEqual("Hvert sekund, hver 8 time, starter på 05:00 AM", ExpressionDescriptor.GetDescription("* * 5/8 * * ?"));
        }
        
        [Test]
        public void TestDayOfMonthInternalWithStepValue()
        {
            Assert.AreEqual("På 07:05 AM, hver 3 dag, starter på dag 2 av måneden", ExpressionDescriptor.GetDescription("0 5 7 2/3 * ? *"));
        }
        
        [Test]
        public void TestMonthInternalWithStepValue()
        {
            Assert.AreEqual("På 07:05 AM, hver 2 måned], mars til og med desember", ExpressionDescriptor.GetDescription("0 5 7 ? 3/2 ? *"));
        }
        
        [Test]
        public void TestDayOfWeekInternalWithStepValue()
        {
            Assert.AreEqual("På 07:05 AM, hver 3 ukedag, tirsdag til og med lørdag", ExpressionDescriptor.GetDescription("0 5 7 ? * 2/3 *"));
        }
                
        [Test]
        public void TestYearInternalWithStepValue()
        {
            Assert.AreEqual("På 07:05 AM, hvert 4 år, 2016 til og med 9999", ExpressionDescriptor.GetDescription("0 5 7 ? * ? 2016/4"));
        }
    }
}
