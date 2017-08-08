using NUnit.Framework;
using System.Globalization;
using System.Threading;

namespace CronExpressionDescriptor.Test
{
    [TestFixture]
    public class TestFormatsSV
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            ExpressionDescriptor.SetDefaultLocale("sv-SE");
        }

        [Test]
        
        public void TestEveryMinute()
        {
            Assert.AreEqual("Varje minut", ExpressionDescriptor.GetDescription("* * * * *"));
        }

        [Test]
        
        public void TestEvery1Minute()
        {
            Assert.AreEqual("Varje minut", ExpressionDescriptor.GetDescription("*/1 * * * *"));
            Assert.AreEqual("Varje minut", ExpressionDescriptor.GetDescription("0 0/1 * * * ?"));
        }

        [Test]
        
        public void TestEveryHour()
        {
            Assert.AreEqual("Varje timma", ExpressionDescriptor.GetDescription("0 0 * * * ?"));
            Assert.AreEqual("Varje timma", ExpressionDescriptor.GetDescription("0 0 0/1 * * ?"));
        }

        [Test]
        
        public void TesttimmaOfDayCertainDaysOfWeek()
        {
            Assert.AreEqual(
                "På 11:00 PM, måndag till och med fredag", ExpressionDescriptor.GetDescription("0 23 ? * MON-FRI"));
        }

        [Test]
        
        public void TestEverySecond()
        {
            Assert.AreEqual("Varje sekund", ExpressionDescriptor.GetDescription("* * * * * *"));
        }

        [Test]
        
        public void TestEvery45Seconds()
        {
            Assert.AreEqual("Upprepas efter 45 sekunder", ExpressionDescriptor.GetDescription("*/45 * * * * *"));
        }

        [Test]
        
        public void TestEvery5Minutes()
        {
            Assert.AreEqual("Upprepas efter 10 minuter", ExpressionDescriptor.GetDescription("0 0/10 * * * ?"));
        }

        [Test]
        
        public void TestEvery5MinutesOnTheSecond()
        {
            Assert.AreEqual("Upprepas efter 5 minuter", ExpressionDescriptor.GetDescription("0 */5 * * * *"));
        }

        [Test]
        
        public void TestWeekdaysAttimma()
        {
            Assert.AreEqual("På 11:30 AM, måndag till och med fredag", ExpressionDescriptor.GetDescription("30 11 * * 1-5"));
        }

        [Test]
        
        public void TestDailyAttimma()
        {
            Assert.AreEqual("På 11:30 AM", ExpressionDescriptor.GetDescription("30 11 * * *"));
        }

        [Test]
        
        public void TestMinuteSpan()
        {
            Assert.AreEqual(
                "Varje minut mellan 11:00 AM och 11:10 AM", ExpressionDescriptor.GetDescription("0-10 11 * * *"));
        }

        [Test]
        
        public void TestOneMonthOnly()
        {
            Assert.AreEqual("Varje minut, bara i mars", ExpressionDescriptor.GetDescription("* * * 3 *"));
        }

        [Test]
        
        public void TestTwoMonthsOnly()
        {
            Assert.AreEqual("Varje minut, bara i mars och juni", ExpressionDescriptor.GetDescription("* * * 3,6 *"));
        }

        [Test]
        
        public void TestTwotimmasEachAfternoon()
        {
            Assert.AreEqual("På 02:30 PM och 04:30 PM", ExpressionDescriptor.GetDescription("30 14,16 * * *"));
        }

        [Test]
        
        public void TestThreetimmasDaily()
        {
            Assert.AreEqual(
                "På 06:30 AM, 02:30 PM och 04:30 PM", ExpressionDescriptor.GetDescription("30 6,14,16 * * *"));
        }

        [Test]
        
        public void TestOnceAWeek()
        {
            Assert.AreEqual("På 09:46 AM, bara på måndag", ExpressionDescriptor.GetDescription("46 9 * * 1"));
        }

        [Test]
        
        public void TestDayOfMonth()
        {
            Assert.AreEqual("På 12:23 PM, på dag 15 av månaden", ExpressionDescriptor.GetDescription("23 12 15 * *"));
        }

        [Test]
        
        public void TestMonthName()
        {
            Assert.AreEqual("På 12:23 PM, bara i januari", ExpressionDescriptor.GetDescription("23 12 * JAN *"));
        }

        [Test]
        
        public void TestDayOfMonthWithQuestionMark()
        {
            Assert.AreEqual("På 12:23 PM, bara i januari", ExpressionDescriptor.GetDescription("23 12 ? JAN *"));
        }

        [Test]
        
        public void TestMonthNameRange2()
        {
            Assert.AreEqual(
                "På 12:23 PM, januari till och med februari", ExpressionDescriptor.GetDescription("23 12 * JAN-FEB *"));
        }

        [Test]
        
        public void TestMonthNameRange3()
        {
            Assert.AreEqual(
                "På 12:23 PM, januari till och med mars", ExpressionDescriptor.GetDescription("23 12 * JAN-MAR *"));
        }

        [Test]
        
        public void TestDayOfWeekName()
        {
            Assert.AreEqual("På 12:23 PM, bara på söndag", ExpressionDescriptor.GetDescription("23 12 * * SUN"));
        }

        [Test]
        
        public void TestDayOfWeekRange()
        {
            Assert.AreEqual(
                "Upprepas efter 5 minuter, på 03:00 PM, måndag till och med fredag",
                ExpressionDescriptor.GetDescription("*/5 15 * * MON-FRI"));
        }

        [Test]
        
        public void TestDayOfWeekOnceInMonth()
        {
            Assert.AreEqual(
                "Varje minut, den tredje måndag av månaden", ExpressionDescriptor.GetDescription("* * * * MON#3"));
        }

        [Test]
        
        public void TestLastDayOfTheWeekOfTheMonth()
        {
            Assert.AreEqual(
                "Varje minut, på den sista torsdag av månaden", ExpressionDescriptor.GetDescription("* * * * 4L"));
        }

        [Test]
        
        public void TestLastDayOfTheMonth()
        {
            Assert.AreEqual(
                "Upprepas efter 5 minuter, på den sista dagen i månaden, bara i januari",
                ExpressionDescriptor.GetDescription("*/5 * L JAN *"));
        }

        [Test]
        
        public void TestLastWeekdayOfTheMonth()
        {
            Assert.AreEqual(
                "Varje minut, på den siste veckodagen i månaden", ExpressionDescriptor.GetDescription("* * LW * *"));
        }

        [Test]
        
        public void TestLastWeekdayOfTheMonth2()
        {
            Assert.AreEqual(
                "Varje minut, på den siste veckodagen i månaden", ExpressionDescriptor.GetDescription("* * WL * *"));
        }

        [Test]
        
        public void TestFirstWeekdayOfTheMonth()
        {
            Assert.AreEqual(
                "Varje minut, på den första dagen i veckan av månaden", ExpressionDescriptor.GetDescription("* * 1W * *"));
        }

        [Test]
        
        public void TestFirstWeekdayOfTheMonth2()
        {
            Assert.AreEqual(
                "Varje minut, på den första dagen i veckan av månaden", ExpressionDescriptor.GetDescription("* * W1 * *"));
        }

        [Test]
        
        public void TestParticularWeekdayOfTheMonth()
        {
            Assert.AreEqual(
                "Varje minut, på den veckodag närmast dag 5 av månaden",
                ExpressionDescriptor.GetDescription("* * 5W * *"));
        }

        [Test]
        
        public void TestParticularWeekdayOfTheMonth2()
        {
            Assert.AreEqual(
                "Varje minut, på den veckodag närmast dag 5 av månaden",
                ExpressionDescriptor.GetDescription("* * W5 * *"));
        }

        [Test]
        
        public void TesttimmaOfDayWithSeconds()
        {
            Assert.AreEqual("På 02:02:30 PM", ExpressionDescriptor.GetDescription("30 02 14 * * *"));
        }

        [Test]
        
        public void TestSecondInternvals()
        {
            Assert.AreEqual(
                "Mellan sekund 5 och 10 varje minut", ExpressionDescriptor.GetDescription("5-10 * * * * *"));
        }

        [Test]
        
        public void TestSecondMinutesHoursIntervals()
        {
            Assert.AreEqual(
                "Mellan sekund 5 och 10 varje minut, mellan minut 30 och 35 varje timma, mellan 10:00 AM och 12:59 PM",
                ExpressionDescriptor.GetDescription("5-10 30-35 10-12 * * *"));
        }

        [Test]
        
        public void TestEvery5MinutesAt30Seconds()
        {
            Assert.AreEqual(
                "Efter 30 sekunder, upprepas efter 5 minuter", ExpressionDescriptor.GetDescription("30 */5 * * * *"));
        }

        [Test]
        
        public void TestMinutesPastTheHourRange()
        {
            Assert.AreEqual(
                "Vid 30 minuter över, mellan 10:00 AM och 01:59 PM, bara på onsdag och fredag",
                ExpressionDescriptor.GetDescription("0 30 10-13 ? * WED,FRI"));
        }

        [Test]
        
        public void TestSecondsPastTheMinuteInterval()
        {
            Assert.AreEqual(
                "Efter 10 sekunder, upprepas efter 5 minuter", ExpressionDescriptor.GetDescription("10 0/5 * * * ?"));
        }

        [Test]
        
        public void TestBetweenWithInterval()
        {
            Assert.AreEqual(
                "Upprepas efter 3 minuter, mellan minut 2 och 59 varje timma, på 01:00 AM, 09:00 AM, och 10:00 PM, mellan dag 11 och 26 i månaden, januari till och med juni",
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
            Assert.AreEqual("Vid 5 minuter över", ExpressionDescriptor.GetDescription("0 5 0/1 * * ?"));
        }

        [Test]
        
        public void TestOneYearOnlyWithSeconds()
        {
            Assert.AreEqual("Varje sekund, bara i 2013", ExpressionDescriptor.GetDescription("* * * * * * 2013"));
        }

        [Test]
        
        public void TestOneYearOnlyWithoutSeconds()
        {
            Assert.AreEqual("Varje minut, bara i 2013", ExpressionDescriptor.GetDescription("* * * * * 2013"));
        }

        [Test]
        
        public void TestTwoYearsOnly()
        {
            Assert.AreEqual(
                "Varje minut, bara i 2013 och 2014", ExpressionDescriptor.GetDescription("* * * * * 2013,2014"));
        }

        [Test]
        
        public void TestYearRange2()
        {
            Assert.AreEqual(
                "På 12:23 PM, januari till och med februari, 2013 till och med 2014",
                ExpressionDescriptor.GetDescription("23 12 * JAN-FEB * 2013-2014"));
        }

        [Test]
        
        public void TestYearRange3()
        {
            Assert.AreEqual(
                "På 12:23 PM, januari till och med mars, 2013 till och med 2015",
                ExpressionDescriptor.GetDescription("23 12 * JAN-MAR * 2013-2015"));
        }

        [Test]
        public void TestSecondsInternalWithStepValue()
        {
            // GitHub Issue #49: https://github.com/bradyholt/cron-expression-descriptor/issues/49
            Assert.AreEqual("Upprepas efter 30 sekunder, börjar efter 5 sekunder", ExpressionDescriptor.GetDescription("5/30 * * * * ?"));
        }

        [Test]
        public void TestMinutesInternalWithStepValue()
        {
            Assert.AreEqual("Upprepas efter 30 minuter, börjar vid 5 minuter över", ExpressionDescriptor.GetDescription("0 5/30 * * * ?"));
        }
        
        [Test]
        public void TestHoursInternalWithStepValue()
        {
            Assert.AreEqual("Varje sekund, upprepas efter 8 timmar, börjar på 05:00 AM", ExpressionDescriptor.GetDescription("* * 5/8 * * ?"));
        }
        
        [Test]
        public void TestDayOfMonthInternalWithStepValue()
        {
            Assert.AreEqual("På 07:05 AM, var 3(:e/:a) dag, börjar på dag 2 av månaden", ExpressionDescriptor.GetDescription("0 5 7 2/3 * ? *"));
        }
        
        [Test]
        public void TestMonthInternalWithStepValue()
        {
            Assert.AreEqual("På 07:05 AM, var 2(:e/:a) månad, mars till och med december", ExpressionDescriptor.GetDescription("0 5 7 ? 3/2 ? *"));
        }
        
        [Test]
        public void TestDayOfWeekInternalWithStepValue()
        {
            Assert.AreEqual("På 07:05 AM, var 3(:e/:a) veckodag, tisdag till och med lördag", ExpressionDescriptor.GetDescription("0 5 7 ? * 2/3 *"));
        }
                
        [Test]
        public void TestYearInternalWithStepValue()
        {
            Assert.AreEqual("På 07:05 AM, var 4 år, 2016 till och med 9999", ExpressionDescriptor.GetDescription("0 5 7 ? * ? 2016/4"));
        }
    }
}
