using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using NUnit.Framework;

namespace CronExpressionDescriptor.Test
{
    [TestFixture]
    public class TestFormatsNL
    {
        [TestFixtureSetUp]
        public void SetUp()
        {
            CultureInfo myCultureInfo = new CultureInfo("nl-NL");
            Thread.CurrentThread.CurrentCulture = myCultureInfo;
            Thread.CurrentThread.CurrentUICulture = myCultureInfo;
        }

        [Test]
             
        public void TestEveryMinute()
        {
            Assert.AreEqual("Elke minuut", ExpressionDescriptor.GetDescription("* * * * *"));
        }

        [Test]
       
        public void TestEvery1Minute()
        {
            Assert.AreEqual("Elke minuut", ExpressionDescriptor.GetDescription("*/1 * * * *"));
            Assert.AreEqual("Elke minuut", ExpressionDescriptor.GetDescription("0 0/1 * * * ?"));
        }

        [Test]
       
        public void TestEveryHour()
        {
            Assert.AreEqual("Elk uur", ExpressionDescriptor.GetDescription("0 0 * * * ?"));
            Assert.AreEqual("Elk uur", ExpressionDescriptor.GetDescription("0 0 0/1 * * ?"));
        }

        [Test]
       
        public void TestTimeOfDayCertainDaysOfWeek()
        {
            Assert.AreEqual("Op 11:00 PM, maandag t/m vrijdag", ExpressionDescriptor.GetDescription("0 23 ? * MON-FRI"));
        }

        [Test]
       
        public void TestEverySecond()
        {
            Assert.AreEqual("Elke seconde", ExpressionDescriptor.GetDescription("* * * * * *"));
        }

        [Test]
       
        public void TestEvery45Seconds()
        {
            Assert.AreEqual("Elke 45 seconden", ExpressionDescriptor.GetDescription("*/45 * * * * *"));
        }

        [Test]
       
        public void TestEvery5Minutes()
        {
            Assert.AreEqual("Elke 5 minuten", ExpressionDescriptor.GetDescription("*/5 * * * *"));
            Assert.AreEqual("Elke 10 minuten", ExpressionDescriptor.GetDescription("0 0/10 * * * ?"));
        }

        [Test]
       
        public void TestEvery5MinutesOnTheSecond()
        {
            Assert.AreEqual("Elke 5 minuten", ExpressionDescriptor.GetDescription("0 */5 * * * *"));
        }

        [Test]
       
        public void TestWeekdaysAtTime()
        {
            Assert.AreEqual("Op 11:30 AM, maandag t/m vrijdag", ExpressionDescriptor.GetDescription("30 11 * * 1-5"));
        }

        [Test]
       
        public void TestDailyAtTime()
        {
            Assert.AreEqual("Op 11:30 AM", ExpressionDescriptor.GetDescription("30 11 * * *"));
        }

        [Test]
       
        public void TestMinuteSpan()
        {
            Assert.AreEqual("Elke minuut tussen 11:00 AM en 11:10 AM", ExpressionDescriptor.GetDescription("0-10 11 * * *"));
        }

        [Test]
       
        public void TestOneMonthOnly()
        {
            Assert.AreEqual("Elke minuut, alleen in maart", ExpressionDescriptor.GetDescription("* * * 3 *"));
        }

        [Test]
       
        public void TestTwoMonthsOnly()
        {
            Assert.AreEqual("Elke minuut, alleen in maart en juni", ExpressionDescriptor.GetDescription("* * * 3,6 *"));
        }

        [Test]
       
        public void TestTwoTimesEachAfternoon()
        {
            Assert.AreEqual("Op 02:30 PM en 04:30 PM", ExpressionDescriptor.GetDescription("30 14,16 * * *"));
        }

        [Test]
       
        public void TestThreeTimesDaily()
        {
            Assert.AreEqual("Op 06:30 AM, 02:30 PM en 04:30 PM", ExpressionDescriptor.GetDescription("30 6,14,16 * * *"));
        }

        [Test]
       
        public void TestOnceAWeek()
        {
            Assert.AreEqual("Op 09:46 AM, alleen op maandag", ExpressionDescriptor.GetDescription("46 9 * * 1"));
        }

        [Test]
       
        public void TestDayOfMonth()
        {
            Assert.AreEqual("Op 12:23 PM, op dag 15 van de maand", ExpressionDescriptor.GetDescription("23 12 15 * *"));
        }

        [Test]
       
        public void TestMonthName()
        {
            Assert.AreEqual("Op 12:23 PM, alleen in januari", ExpressionDescriptor.GetDescription("23 12 * JAN *"));
        }

        [Test]
       
        public void TestDayOfMonthWithQuestionMark()
        {
            Assert.AreEqual("Op 12:23 PM, alleen in januari", ExpressionDescriptor.GetDescription("23 12 ? JAN *"));
        }

        [Test]
       
        public void TestMonthNameRange2()
        {
            Assert.AreEqual("Op 12:23 PM, januari t/m februari", ExpressionDescriptor.GetDescription("23 12 * JAN-FEB *"));
        }

        [Test]
       
        public void TestMonthNameRange3()
        {
            Assert.AreEqual("Op 12:23 PM, januari t/m maart", ExpressionDescriptor.GetDescription("23 12 * JAN-MAR *"));
        }

        [Test]
       
        public void TestDayOfWeekName()
        {
            Assert.AreEqual("Op 12:23 PM, alleen op zondag", ExpressionDescriptor.GetDescription("23 12 * * SUN"));
        }

        [Test]
       
        public void TestDayOfWeekRange()
        {
            Assert.AreEqual("Elke 5 minuten, op 03:00 PM, maandag t/m vrijdag", ExpressionDescriptor.GetDescription("*/5 15 * * MON-FRI"));
        }

        [Test]
       
        public void TestDayOfWeekOnceInMonth()
        {
            Assert.AreEqual("Elke minuut, op de derde maandag van de maand", ExpressionDescriptor.GetDescription("* * * * MON#3"));
        }

        [Test]
       
        public void TestLastDayOfTheWeekOfTheMonth()
        {
            Assert.AreEqual("Elke minuut, op de laatste donderdag van de maand", ExpressionDescriptor.GetDescription("* * * * 4L"));
        }

        [Test]
       
        public void TestLastDayOfTheMonth()
        {
            Assert.AreEqual("Elke 5 minuten, op de laatste dag van de maand, alleen in januari", ExpressionDescriptor.GetDescription("*/5 * L JAN *"));
        }

        [Test]
       
        public void TestLastWeekdayOfTheMonth()
        {
            Assert.AreEqual("Elke minuut, op de laatste werkdag van de maand", ExpressionDescriptor.GetDescription("* * LW * *"));
        }

        [Test]
       
        public void TestLastWeekdayOfTheMonth2()
        {
            Assert.AreEqual("Elke minuut, op de laatste werkdag van de maand", ExpressionDescriptor.GetDescription("* * WL * *"));
        }

        [Test]
       
        public void TestFirstWeekdayOfTheMonth()
        {
            Assert.AreEqual("Elke minuut, op de eerste werkdag van de maand", ExpressionDescriptor.GetDescription("* * 1W * *"));
        }

        [Test]
       
        public void TestFirstWeekdayOfTheMonth2()
        {
            Assert.AreEqual("Elke minuut, op de eerste werkdag van de maand", ExpressionDescriptor.GetDescription("* * W1 * *"));
        }

        [Test]
       
        public void TestParticularWeekdayOfTheMonth()
        {
            Assert.AreEqual("Elke minuut, op de werkdag dichtst bij dag 5 van de maand", ExpressionDescriptor.GetDescription("* * 5W * *"));
        }

        [Test]
       
        public void TestParticularWeekdayOfTheMonth2()
        {
            Assert.AreEqual("Elke minuut, op de werkdag dichtst bij dag 5 van de maand", ExpressionDescriptor.GetDescription("* * W5 * *"));
        }

        [Test]
       
        public void TestTimeOfDayWithSeconds()
        {
            Assert.AreEqual("Op 02:02:30 PM", ExpressionDescriptor.GetDescription("30 02 14 * * *"));
        }

        [Test]
       
        public void TestSecondInternvals()
        {
            Assert.AreEqual("Seconden 5 t/m 10 na de minuut", ExpressionDescriptor.GetDescription("5-10 * * * * *"));
        }

        [Test]
       
        public void TestSecondMinutesHoursIntervals()
        {
            Assert.AreEqual("Seconden 5 t/m 10 na de minuut, minuut 30 t/m 35 na het uur, tussen 10:00 AM en 12:59 PM", ExpressionDescriptor.GetDescription("5-10 30-35 10-12 * * *"));
        }

        [Test]
       
        public void TestEvery5MinutesAt30Seconds()
        {
            Assert.AreEqual("Op 30 seconden na de minuut, elke 5 minuten", ExpressionDescriptor.GetDescription("30 */5 * * * *"));
        }

        [Test]
       
        public void TestMinutesPastTheHourRange()
        {
            Assert.AreEqual("Op 30 minuten na het uur, tussen 10:00 AM en 01:59 PM, alleen op woensdag en vrijdag", ExpressionDescriptor.GetDescription("0 30 10-13 ? * WED,FRI"));
        }

        [Test]
       
        public void TestSecondsPastTheMinuteInterval()
        {
            Assert.AreEqual("Op 10 seconden na de minuut, elke 5 minuten", ExpressionDescriptor.GetDescription("10 0/5 * * * ?"));
        }

        [Test]
       
        public void TestBetweenWithInterval()
        {
            Assert.AreEqual("Elke 3 minuten, minuut 2 t/m 59 na het uur, op 01:00 AM, 09:00 AM, en 10:00 PM, tussen dag 11 en 26 van de maand, januari t/m juni", ExpressionDescriptor.GetDescription("2-59/3 1,9,22 11-26 1-6 ?"));
        }

        [Test]
       
        public void TestRecurringFirstOfMonth()
        {
            Assert.AreEqual("Op 06:00 AM", ExpressionDescriptor.GetDescription("0 0 6 1/1 * ?"));
        }

        [Test]
       
        public void TestMinutesPastTheHour()
        {
            Assert.AreEqual("Op 5 minuten na het uur", ExpressionDescriptor.GetDescription("0 5 0/1 * * ?"));
        }

        [Test]
       
        public void TestOneYearOnlyWithSeconds()
        {
            Assert.AreEqual("Elke seconde, alleen in 2013", ExpressionDescriptor.GetDescription("* * * * * * 2013"));
        }
        
        [Test]
       
        public void TestOneYearOnlyWithoutSeconds()
        {
            Assert.AreEqual("Elke minuut, alleen in 2013", ExpressionDescriptor.GetDescription("* * * * * 2013"));
        }

        [Test]
       
        public void TestTwoYearsOnly()
        {
            Assert.AreEqual("Elke minuut, alleen in 2013 en 2014", ExpressionDescriptor.GetDescription("* * * * * 2013,2014"));
        }

        [Test]
       
        public void TestYearRange2()
        {
            Assert.AreEqual("Op 12:23 PM, januari t/m februari, 2013 t/m 2014", ExpressionDescriptor.GetDescription("23 12 * JAN-FEB * 2013-2014"));
        }

        [Test]
       
        public void TestYearRange3()
        {
            Assert.AreEqual("Op 12:23 PM, januari t/m maart, 2013 t/m 2015", ExpressionDescriptor.GetDescription("23 12 * JAN-MAR * 2013-2015"));
        }

        [Test]
       
        public void TestHourRange()
        {
            Assert.AreEqual("Elke 30 minuten, tussen 08:00 AM en 09:59 AM, op dag 5 en 20 van de maand", ExpressionDescriptor.GetDescription("0 0/30 8-9 5,20 * ?"));
        }

        [Test]
       
        public void TestDayOfWeekModifier()
        {
            Assert.AreEqual("Op 12:23 PM, op de tweede zondag van de maand", ExpressionDescriptor.GetDescription("23 12 * * SUN#2"));
        }

        [Test]
       
        public void TestDayOfWeekModifierWithSundayStartOne()
        {
            Options options = new Options();
            options.DayOfWeekStartIndexZero = false;

            Assert.AreEqual("Op 12:23 PM, op de tweede zondag van de maand", ExpressionDescriptor.GetDescription("23 12 * * 1#2", options));
        }

        [Test]
       
        public void TestHourRangeWithEveryPortion()
        {
            Assert.AreEqual("Op 25 minuten na het uur, elke 13 uur, tussen 07:00 AM en 07:59 PM", ExpressionDescriptor.GetDescription("0 25 7-19/13 ? * *"));
        }

        [Test]
       
        public void TestHourRangeWithTrailingZeroWithEveryPortion()
        {
            Assert.AreEqual("Op 25 minuten na het uur, elke 13 uur, tussen 07:00 AM en 08:59 PM", ExpressionDescriptor.GetDescription("0 25 7-20/13 ? * *"));
        }

        [Test]
        public void TestSecondsInternalWithStepValue()
        {
            // GitHub Issue #49: https://github.com/bradyholt/cron-expression-descriptor/issues/49
            Assert.AreEqual("Elke 30 seconden, beginnend op 5 seconden na de minuut", ExpressionDescriptor.GetDescription("5/30 * * * * ?"));
        }

        [Test]
        public void TestMinutesInternalWithStepValue()
        {
            Assert.AreEqual("Elke 30 minuten, beginnend op 5 minuten na het uur", ExpressionDescriptor.GetDescription("0 5/30 * * * ?"));
        }
        
        [Test]
        public void TestHoursInternalWithStepValue()
        {
            Assert.AreEqual("Elke seconde, elke 8 uur, beginnend op 05:00 AM", ExpressionDescriptor.GetDescription("* * 5/8 * * ?"));
        }
        
        [Test]
        public void TestDayOfMonthInternalWithStepValue()
        {
            Assert.AreEqual("Op 07:05 AM, elke 3 dagen, beginnend op dag 2 van de maand", ExpressionDescriptor.GetDescription("0 5 7 2/3 * ? *"));
        }
        
        [Test]
        public void TestMonthInternalWithStepValue()
        {
            Assert.AreEqual("Op 07:05 AM, elke 2 maanden, maart t/m december", ExpressionDescriptor.GetDescription("0 5 7 ? 3/2 ? *"));
        }
        
        [Test]
        public void TestDayOfWeekInternalWithStepValue()
        {
            Assert.AreEqual("Op 07:05 AM, elke 3 dagen van de week, dinsdag t/m zaterdag", ExpressionDescriptor.GetDescription("0 5 7 ? * 2/3 *"));
        }
                
        [Test]
        public void TestYearInternalWithStepValue()
        {
            Assert.AreEqual("Op 07:05 AM, elke 4 jaren, 2016 t/m 9999", ExpressionDescriptor.GetDescription("0 5 7 ? * ? 2016/4"));
        }
    }
}