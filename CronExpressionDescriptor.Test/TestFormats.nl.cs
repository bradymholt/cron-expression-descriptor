using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CronExpressionDescriptor.Test
{
    [TestClass]
    public class TestFormatsNL
    {
        [TestInitialize]
        public void SetUp()
        {
            CultureInfo myCultureInfo = new CultureInfo("nl");
            Thread.CurrentThread.CurrentCulture = myCultureInfo;
            Thread.CurrentThread.CurrentUICulture = myCultureInfo;
        }

        [TestMethod]
        [DeploymentItem(@"nl\CronExpressionDescriptor.resources.dll", "nl")]        
        public void TestEveryMinute()
        {
            Assert.AreEqual("Elke minuut", ExpressionDescriptor.GetDescription("* * * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"nl\CronExpressionDescriptor.resources.dll", "nl")]
        public void TestEvery1Minute()
        {
            Assert.AreEqual("Elke minuut", ExpressionDescriptor.GetDescription("*/1 * * * *"));
            Assert.AreEqual("Elke minuut", ExpressionDescriptor.GetDescription("0 0/1 * * * ?"));
        }

        [TestMethod]
        [DeploymentItem(@"nl\CronExpressionDescriptor.resources.dll", "nl")]
        public void TestEveryHour()
        {
            Assert.AreEqual("Elk uur", ExpressionDescriptor.GetDescription("0 0 * * * ?"));
            Assert.AreEqual("Elk uur", ExpressionDescriptor.GetDescription("0 0 0/1 * * ?"));
        }

        [TestMethod]
        [DeploymentItem(@"nl\CronExpressionDescriptor.resources.dll", "nl")]
        public void TestTimeOfDayCertainDaysOfWeek()
        {
            Assert.AreEqual("Op 11:00 PM, maandag t/m vrijdag", ExpressionDescriptor.GetDescription("0 23 ? * MON-FRI"));
        }

        [TestMethod]
        [DeploymentItem(@"nl\CronExpressionDescriptor.resources.dll", "nl")]
        public void TestEverySecond()
        {
            Assert.AreEqual("Elke seconde", ExpressionDescriptor.GetDescription("* * * * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"nl\CronExpressionDescriptor.resources.dll", "nl")]
        public void TestEvery45Seconds()
        {
            Assert.AreEqual("Elke 45 seconden", ExpressionDescriptor.GetDescription("*/45 * * * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"nl\CronExpressionDescriptor.resources.dll", "nl")]
        public void TestEvery5Minutes()
        {
            Assert.AreEqual("Elke 05 minuten", ExpressionDescriptor.GetDescription("*/5 * * * *"));
            Assert.AreEqual("Elke 10 minuten", ExpressionDescriptor.GetDescription("0 0/10 * * * ?"));
        }

        [TestMethod]
        [DeploymentItem(@"nl\CronExpressionDescriptor.resources.dll", "nl")]
        public void TestEvery5MinutesOnTheSecond()
        {
            Assert.AreEqual("Elke 05 minuten", ExpressionDescriptor.GetDescription("0 */5 * * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"nl\CronExpressionDescriptor.resources.dll", "nl")]
        public void TestWeekdaysAtTime()
        {
            Assert.AreEqual("Op 11:30 AM, maandag t/m vrijdag", ExpressionDescriptor.GetDescription("30 11 * * 1-5"));
        }

        [TestMethod]
        [DeploymentItem(@"nl\CronExpressionDescriptor.resources.dll", "nl")]
        public void TestDailyAtTime()
        {
            Assert.AreEqual("Op 11:30 AM", ExpressionDescriptor.GetDescription("30 11 * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"nl\CronExpressionDescriptor.resources.dll", "nl")]
        public void TestMinuteSpan()
        {
            Assert.AreEqual("Elke minuut tussen 11:00 AM en 11:10 AM", ExpressionDescriptor.GetDescription("0-10 11 * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"nl\CronExpressionDescriptor.resources.dll", "nl")]
        public void TestOneMonthOnly()
        {
            Assert.AreEqual("Elke minuut, alleen in maart", ExpressionDescriptor.GetDescription("* * * 3 *"));
        }

        [TestMethod]
        [DeploymentItem(@"nl\CronExpressionDescriptor.resources.dll", "nl")]
        public void TestTwoMonthsOnly()
        {
            Assert.AreEqual("Elke minuut, alleen in maart en juni", ExpressionDescriptor.GetDescription("* * * 3,6 *"));
        }

        [TestMethod]
        [DeploymentItem(@"nl\CronExpressionDescriptor.resources.dll", "nl")]
        public void TestTwoTimesEachAfternoon()
        {
            Assert.AreEqual("Op 02:30 PM en 04:30 PM", ExpressionDescriptor.GetDescription("30 14,16 * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"nl\CronExpressionDescriptor.resources.dll", "nl")]
        public void TestThreeTimesDaily()
        {
            Assert.AreEqual("Op 06:30 AM, 02:30 PM en 04:30 PM", ExpressionDescriptor.GetDescription("30 6,14,16 * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"nl\CronExpressionDescriptor.resources.dll", "nl")]
        public void TestOnceAWeek()
        {
            Assert.AreEqual("Op 09:46 AM, alleen op maandag", ExpressionDescriptor.GetDescription("46 9 * * 1"));
        }

        [TestMethod]
        [DeploymentItem(@"nl\CronExpressionDescriptor.resources.dll", "nl")]
        public void TestDayOfMonth()
        {
            Assert.AreEqual("Op 12:23 PM, op dag 15 van de maand", ExpressionDescriptor.GetDescription("23 12 15 * *"));
        }

        [TestMethod]
        [DeploymentItem(@"nl\CronExpressionDescriptor.resources.dll", "nl")]
        public void TestMonthName()
        {
            Assert.AreEqual("Op 12:23 PM, alleen in januari", ExpressionDescriptor.GetDescription("23 12 * JAN *"));
        }

        [TestMethod]
        [DeploymentItem(@"nl\CronExpressionDescriptor.resources.dll", "nl")]
        public void TestDayOfMonthWithQuestionMark()
        {
            Assert.AreEqual("Op 12:23 PM, alleen in januari", ExpressionDescriptor.GetDescription("23 12 ? JAN *"));
        }

        [TestMethod]
        [DeploymentItem(@"nl\CronExpressionDescriptor.resources.dll", "nl")]
        public void TestMonthNameRange2()
        {
            Assert.AreEqual("Op 12:23 PM, januari t/m februari", ExpressionDescriptor.GetDescription("23 12 * JAN-FEB *"));
        }

        [TestMethod]
        [DeploymentItem(@"nl\CronExpressionDescriptor.resources.dll", "nl")]
        public void TestMonthNameRange3()
        {
            Assert.AreEqual("Op 12:23 PM, januari t/m maart", ExpressionDescriptor.GetDescription("23 12 * JAN-MAR *"));
        }

        [TestMethod]
        [DeploymentItem(@"nl\CronExpressionDescriptor.resources.dll", "nl")]
        public void TestDayOfWeekName()
        {
            Assert.AreEqual("Op 12:23 PM, alleen op zondag", ExpressionDescriptor.GetDescription("23 12 * * SUN"));
        }

        [TestMethod]
        [DeploymentItem(@"nl\CronExpressionDescriptor.resources.dll", "nl")]
        public void TestDayOfWeekRange()
        {
            Assert.AreEqual("Elke 05 minuten, op 03:00 PM, maandag t/m vrijdag", ExpressionDescriptor.GetDescription("*/5 15 * * MON-FRI"));
        }

        [TestMethod]
        [DeploymentItem(@"nl\CronExpressionDescriptor.resources.dll", "nl")]
        public void TestDayOfWeekOnceInMonth()
        {
            Assert.AreEqual("Elke minuut, op de derde maandag van de maand", ExpressionDescriptor.GetDescription("* * * * MON#3"));
        }

        [TestMethod]
        [DeploymentItem(@"nl\CronExpressionDescriptor.resources.dll", "nl")]
        public void TestLastDayOfTheWeekOfTheMonth()
        {
            Assert.AreEqual("Elke minuut, op de laatste donderdag van de maand", ExpressionDescriptor.GetDescription("* * * * 4L"));
        }

        [TestMethod]
        [DeploymentItem(@"nl\CronExpressionDescriptor.resources.dll", "nl")]
        public void TestLastDayOfTheMonth()
        {
            Assert.AreEqual("Elke 05 minuten, op de laatste dag van de maand, alleen in januari", ExpressionDescriptor.GetDescription("*/5 * L JAN *"));
        }

        [TestMethod]
        [DeploymentItem(@"nl\CronExpressionDescriptor.resources.dll", "nl")]
        public void TestLastWeekdayOfTheMonth()
        {
            Assert.AreEqual("Elke minuut, op de laatste werkdag van de maand", ExpressionDescriptor.GetDescription("* * LW * *"));
        }

        [TestMethod]
        [DeploymentItem(@"nl\CronExpressionDescriptor.resources.dll", "nl")]
        public void TestLastWeekdayOfTheMonth2()
        {
            Assert.AreEqual("Elke minuut, op de laatste werkdag van de maand", ExpressionDescriptor.GetDescription("* * WL * *"));
        }

        [TestMethod]
        [DeploymentItem(@"nl\CronExpressionDescriptor.resources.dll", "nl")]
        public void TestFirstWeekdayOfTheMonth()
        {
            Assert.AreEqual("Elke minuut, op de eerste werkdag van de maand", ExpressionDescriptor.GetDescription("* * 1W * *"));
        }

        [TestMethod]
        [DeploymentItem(@"nl\CronExpressionDescriptor.resources.dll", "nl")]
        public void TestFirstWeekdayOfTheMonth2()
        {
            Assert.AreEqual("Elke minuut, op de eerste werkdag van de maand", ExpressionDescriptor.GetDescription("* * W1 * *"));
        }

        [TestMethod]
        [DeploymentItem(@"nl\CronExpressionDescriptor.resources.dll", "nl")]
        public void TestParticularWeekdayOfTheMonth()
        {
            Assert.AreEqual("Elke minuut, op de werkdag dichtst bij dag 5 van de maand", ExpressionDescriptor.GetDescription("* * 5W * *"));
        }

        [TestMethod]
        [DeploymentItem(@"nl\CronExpressionDescriptor.resources.dll", "nl")]
        public void TestParticularWeekdayOfTheMonth2()
        {
            Assert.AreEqual("Elke minuut, op de werkdag dichtst bij dag 5 van de maand", ExpressionDescriptor.GetDescription("* * W5 * *"));
        }

        [TestMethod]
        [DeploymentItem(@"nl\CronExpressionDescriptor.resources.dll", "nl")]
        public void TestTimeOfDayWithSeconds()
        {
            Assert.AreEqual("Op 02:02:30 PM", ExpressionDescriptor.GetDescription("30 02 14 * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"nl\CronExpressionDescriptor.resources.dll", "nl")]
        public void TestSecondInternvals()
        {
            Assert.AreEqual("Seconden 05 t/m 10 na de minuut", ExpressionDescriptor.GetDescription("5-10 * * * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"nl\CronExpressionDescriptor.resources.dll", "nl")]
        public void TestSecondMinutesHoursIntervals()
        {
            Assert.AreEqual("Seconden 05 t/m 10 na de minuut, minuut 30 t/m 35 na het uur, tussen 10:00 AM en 01:00 PM", ExpressionDescriptor.GetDescription("5-10 30-35 10-12 * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"nl\CronExpressionDescriptor.resources.dll", "nl")]
        public void TestEvery5MinutesAt30Seconds()
        {
            Assert.AreEqual("Op 30 seconden na de minuut, elke 05 minuten", ExpressionDescriptor.GetDescription("30 */5 * * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"nl\CronExpressionDescriptor.resources.dll", "nl")]
        public void TestMinutesPastTheHourRange()
        {
            Assert.AreEqual("Op 30 minuten na het uur, tussen 10:00 AM en 02:00 PM, alleen op woensdag en vrijdag", ExpressionDescriptor.GetDescription("0 30 10-13 ? * WED,FRI"));
        }

        [TestMethod]
        [DeploymentItem(@"nl\CronExpressionDescriptor.resources.dll", "nl")]
        public void TestSecondsPastTheMinuteInterval()
        {
            Assert.AreEqual("Op 10 seconden na de minuut, elke 05 minuten", ExpressionDescriptor.GetDescription("10 0/5 * * * ?"));
        }

        [TestMethod]
        [DeploymentItem(@"nl\CronExpressionDescriptor.resources.dll", "nl")]
        public void TestBetweenWithInterval()
        {
            Assert.AreEqual("Elke 03 minuten, minuut 02 t/m 59 na het uur, op 01:00 AM, 09:00 AM, en 10:00 PM, tussen dag 11 en 26 van de maand, januari t/m juni", ExpressionDescriptor.GetDescription("2-59/3 1,9,22 11-26 1-6 ?"));
        }

        [TestMethod]
        [DeploymentItem(@"nl\CronExpressionDescriptor.resources.dll", "nl")]
        public void TestRecurringFirstOfMonth()
        {
            Assert.AreEqual("Op 06:00 AM", ExpressionDescriptor.GetDescription("0 0 6 1/1 * ?"));
        }

        [TestMethod]
        [DeploymentItem(@"nl\CronExpressionDescriptor.resources.dll", "nl")]
        public void TestMinutesPastTheHour()
        {
            Assert.AreEqual("Op 05 minuten na het uur", ExpressionDescriptor.GetDescription("0 5 0/1 * * ?"));
        }

        [TestMethod]
        [DeploymentItem(@"nl\CronExpressionDescriptor.resources.dll", "nl")]
        public void TestOneYearOnlyWithSeconds()
        {
            Assert.AreEqual("Elke seconde, alleen in 2013", ExpressionDescriptor.GetDescription("* * * * * * 2013"));
        }
        
        [TestMethod]
        [DeploymentItem(@"nl\CronExpressionDescriptor.resources.dll", "nl")]
        public void TestOneYearOnlyWithoutSeconds()
        {
            Assert.AreEqual("Elke minuut, alleen in 2013", ExpressionDescriptor.GetDescription("* * * * * 2013"));
        }

        [TestMethod]
        [DeploymentItem(@"nl\CronExpressionDescriptor.resources.dll", "nl")]
        public void TestTwoYearsOnly()
        {
            Assert.AreEqual("Elke minuut, alleen in 2013 en 2014", ExpressionDescriptor.GetDescription("* * * * * 2013,2014"));
        }

        [TestMethod]
        [DeploymentItem(@"nl\CronExpressionDescriptor.resources.dll", "nl")]
        public void TestYearRange2()
        {
            Assert.AreEqual("Op 12:23 PM, januari t/m februari, 2013 t/m 2014", ExpressionDescriptor.GetDescription("23 12 * JAN-FEB * 2013-2014"));
        }

        [TestMethod]
        [DeploymentItem(@"nl\CronExpressionDescriptor.resources.dll", "nl")]
        public void TestYearRange3()
        {
            Assert.AreEqual("Op 12:23 PM, januari t/m maart, 2013 t/m 2015", ExpressionDescriptor.GetDescription("23 12 * JAN-MAR * 2013-2015"));
        }

        [TestMethod]
        [DeploymentItem(@"nl\CronExpressionDescriptor.resources.dll", "nl")]
        public void TestHourRange()
        {
            Assert.AreEqual("Elke 30 minuten, tussen 08:00 AM en 10:00 AM, op dag 5 en 20 van de maand", ExpressionDescriptor.GetDescription("0 0/30 8-9 5,20 * ?"));
        }

        [TestMethod]
        [DeploymentItem(@"nl\CronExpressionDescriptor.resources.dll", "nl")]
        public void TestDayOfWeekModifier()
        {
            Assert.AreEqual("Op 12:23 PM, op de tweede zondag van de maand", ExpressionDescriptor.GetDescription("23 12 * * SUN#2"));
        }

        [TestMethod]
        [DeploymentItem(@"nl\CronExpressionDescriptor.resources.dll", "nl")]
        public void TestDayOfWeekModifierWithSundayStartOne()
        {
            Options options = new Options();
            options.DayOfWeekStartIndexZero = false;

            Assert.AreEqual("Op 12:23 PM, op de tweede zondag van de maand", ExpressionDescriptor.GetDescription("23 12 * * 1#2", options));
        }

        [TestMethod]
        [DeploymentItem(@"nl\CronExpressionDescriptor.resources.dll", "nl")]
        public void TestHourRangeWithEveryPortion()
        {
            Assert.AreEqual("Op 25 minuten na het uur, elke 13 uur, tussen 07:00 AM en 07:00 PM", ExpressionDescriptor.GetDescription("0 25 7-19/13 ? * *"));
        }

        [TestMethod]
        [DeploymentItem(@"nl\CronExpressionDescriptor.resources.dll", "nl")]
        public void TestHourRangeWithTrailingZeroWithEveryPortion()
        {
            Assert.AreEqual("Op 25 minuten na het uur, elke 13 uur, tussen 07:00 AM en 08:00 PM", ExpressionDescriptor.GetDescription("0 25 7-20/13 ? * *"));
        }
    }
}