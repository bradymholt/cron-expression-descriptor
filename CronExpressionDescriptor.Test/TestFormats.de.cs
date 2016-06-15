using System.Globalization;
using System.Threading;
using NUnit.Framework;

namespace CronExpressionDescriptor.Test
{
    [TestFixture]
    public class TestFormatsDE
    {
        [TestFixtureSetUp]
        public void SetUp()
        {
            CultureInfo myCultureInfo = new CultureInfo("de-DE");
            Thread.CurrentThread.CurrentCulture = myCultureInfo;
            Thread.CurrentThread.CurrentUICulture = myCultureInfo;
        }

        [Test]
        public void TestEveryMinute()
        {
            Assert.AreEqual("Jede Minute", ExpressionDescriptor.GetDescription("* * * * *"));
        }

        [Test]       
        public void TestEvery1Minute()
        {
            Assert.AreEqual("Jede Minute", ExpressionDescriptor.GetDescription("*/1 * * * *"));
            Assert.AreEqual("Jede Minute", ExpressionDescriptor.GetDescription("0 0/1 * * * ?"));
        }

        [Test]       
        public void TestEveryHour()
        {
            Assert.AreEqual("Jede Stunde", ExpressionDescriptor.GetDescription("0 0 * * * ?"));
            Assert.AreEqual("Jede Stunde", ExpressionDescriptor.GetDescription("0 0 0/1 * * ?"));
        }

        [Test]       
        public void TestTimeOfDayCertainDaysOfWeek()
        {
            Assert.AreEqual("Um 23:00, Montag bis Freitag", ExpressionDescriptor.GetDescription("0 23 ? * MON-FRI"));
        }

        [Test]       
        public void TestEverySecond()
        {
            Assert.AreEqual("Jede Sekunde", ExpressionDescriptor.GetDescription("* * * * * *"));
        }

        [Test]       
        public void TestEvery45Seconds()
        {
            Assert.AreEqual("Alle 45 Sekunden", ExpressionDescriptor.GetDescription("*/45 * * * * *"));
        }

        [Test]       
        public void TestEvery5Minutes()
        {
            Assert.AreEqual("Alle 5 Minuten", ExpressionDescriptor.GetDescription("*/5 * * * *"));
            Assert.AreEqual("Alle 10 Minuten", ExpressionDescriptor.GetDescription("0 0/10 * * * ?"));
        }

        [Test]       
        public void TestEvery5MinutesOnTheSecond()
        {
            Assert.AreEqual("Alle 5 Minuten", ExpressionDescriptor.GetDescription("0 */5 * * * *"));
        }

        [Test]       
        public void TestWeekdaysAtTime()
        {
            Assert.AreEqual("Um 11:30, Montag bis Freitag", ExpressionDescriptor.GetDescription("30 11 * * 1-5"));
        }

        [Test]       
        public void TestDailyAtTime()
        {
            Assert.AreEqual("Um 11:30", ExpressionDescriptor.GetDescription("30 11 * * *"));
        }

        [Test]       
        public void TestMinuteSpan()
        {
            Assert.AreEqual("Jede Minute zwischen 11:00 und 11:10", ExpressionDescriptor.GetDescription("0-10 11 * * *"));
        }

        [Test]       
        public void TestOneMonthOnly()
        {
            Assert.AreEqual("Jede Minute, nur im März", ExpressionDescriptor.GetDescription("* * * 3 *"));
        }

        [Test]       
        public void TestTwoMonthsOnly()
        {
            Assert.AreEqual("Jede Minute, nur im März und Juni", ExpressionDescriptor.GetDescription("* * * 3,6 *"));
        }

        [Test]       
        public void TestTwoTimesEachAfternoon()
        {
            Assert.AreEqual("Um 14:30 und 16:30", ExpressionDescriptor.GetDescription("30 14,16 * * *"));
        }

        [Test]       
        public void TestThreeTimesDaily()
        {
            Assert.AreEqual("Um 06:30, 14:30 und 16:30", ExpressionDescriptor.GetDescription("30 6,14,16 * * *"));
        }

        [Test]       
        public void TestOnceAWeek()
        {
            Assert.AreEqual("Um 09:46, nur am Montag", ExpressionDescriptor.GetDescription("46 9 * * 1"));
        }

        [Test]       
        public void TestDayOfMonth()
        {
            Assert.AreEqual("Um 12:23, am 15 Tag des Monats", ExpressionDescriptor.GetDescription("23 12 15 * *"));
        }

        [Test]       
        public void TestMonthName()
        {
            Assert.AreEqual("Um 12:23, nur im Januar", ExpressionDescriptor.GetDescription("23 12 * JAN *"));
        }

        [Test]       
        public void TestDayOfMonthWithQuestionMark()
        {
            Assert.AreEqual("Um 12:23, nur im Januar", ExpressionDescriptor.GetDescription("23 12 ? JAN *"));
        }

        [Test]       
        public void TestMonthNameRange2()
        {
            Assert.AreEqual("Um 12:23, Januar bis Februar", ExpressionDescriptor.GetDescription("23 12 * JAN-FEB *"));
        }

        [Test]       
        public void TestMonthNameRange3()
        {
            Assert.AreEqual("Um 12:23, Januar bis März", ExpressionDescriptor.GetDescription("23 12 * JAN-MAR *"));
        }

        [Test]       
        public void TestDayOfWeekName()
        {
            Assert.AreEqual("Um 12:23, nur am Sonntag", ExpressionDescriptor.GetDescription("23 12 * * SUN"));
        }

        [Test]       
        public void TestDayOfWeekRange()
        {
            Assert.AreEqual("Alle 5 Minuten, um 15:00, Montag bis Freitag", ExpressionDescriptor.GetDescription("*/5 15 * * MON-FRI"));
        }

        [Test]       
        public void TestDayOfWeekOnceInMonth()
        {
            Assert.AreEqual("Jede Minute, am dritten Montag des Monats", ExpressionDescriptor.GetDescription("* * * * MON#3"));
        }

        [Test]       
        public void TestLastDayOfTheWeekOfTheMonth()
        {
            Assert.AreEqual("Jede Minute, am letzten Donnerstag des Monats", ExpressionDescriptor.GetDescription("* * * * 4L"));
        }

        [Test]       
        public void TestLastDayOfTheMonth()
        {
            Assert.AreEqual("Alle 5 Minuten, am letzten Tag des Monats, nur im Januar", ExpressionDescriptor.GetDescription("*/5 * L JAN *"));
        }

        [Test]       
        public void TestLastWeekdayOfTheMonth()
        {
            Assert.AreEqual("Jede Minute, am letzten Werktag des Monats", ExpressionDescriptor.GetDescription("* * LW * *"));
        }

        [Test]       
        public void TestLastWeekdayOfTheMonth2()
        {
            Assert.AreEqual("Jede Minute, am letzten Werktag des Monats", ExpressionDescriptor.GetDescription("* * WL * *"));
        }

        [Test]       
        public void TestFirstWeekdayOfTheMonth()
        {
            Assert.AreEqual("Jede Minute, am ersten Werktag des Monats", ExpressionDescriptor.GetDescription("* * 1W * *"));
        }

        [Test]       
        public void TestFirstWeekdayOfTheMonth2()
        {
            Assert.AreEqual("Jede Minute, am ersten Werktag des Monats", ExpressionDescriptor.GetDescription("* * W1 * *"));
        }

        [Test]       
        public void TestParticularWeekdayOfTheMonth()
        {
            Assert.AreEqual("Jede Minute, am Werktag am nächsten zum 5 Tag des Monats", ExpressionDescriptor.GetDescription("* * 5W * *"));
        }

        [Test]       
        public void TestParticularWeekdayOfTheMonth2()
        {
            Assert.AreEqual("Jede Minute, am Werktag am nächsten zum 5 Tag des Monats", ExpressionDescriptor.GetDescription("* * W5 * *"));
        }

        [Test]       
        public void TestTimeOfDayWithSeconds()
        {
            Assert.AreEqual("Um 14:02:30", ExpressionDescriptor.GetDescription("30 02 14 * * *"));
        }

        [Test]       
        public void TestSecondInternvals()
        {
            Assert.AreEqual("Sekunden 5 bis 10", ExpressionDescriptor.GetDescription("5-10 * * * * *"));
        }

        [Test]       
        public void TestSecondMinutesHoursIntervals()
        {
            Assert.AreEqual("Sekunden 5 bis 10, Minuten 30 bis 35, zwischen 10:00 und 12:59", ExpressionDescriptor.GetDescription("5-10 30-35 10-12 * * *"));
        }

        [Test]       
        public void TestEvery5MinutesAt30Seconds()
        {
            Assert.AreEqual("Bei Sekunde 30, alle 5 Minuten", ExpressionDescriptor.GetDescription("30 */5 * * * *"));
        }

        [Test]       
        public void TestMinutesPastTheHourRange()
        {
            Assert.AreEqual("Bei Minute 30, zwischen 10:00 und 13:59, nur am Mittwoch und Freitag", ExpressionDescriptor.GetDescription("0 30 10-13 ? * WED,FRI"));
        }

        [Test]       
        public void TestSecondsPastTheMinuteInterval()
        {
            Assert.AreEqual("Bei Sekunde 10, alle 5 Minuten", ExpressionDescriptor.GetDescription("10 0/5 * * * ?"));
        }

        [Test]       
        public void TestBetweenWithInterval()
        {
            Assert.AreEqual("Alle 3 Minuten, Minuten 2 bis 59, um 01:00, 09:00, und 22:00, zwischen Tag 11 und 26 des Monats, Januar bis Juni", ExpressionDescriptor.GetDescription("2-59/3 1,9,22 11-26 1-6 ?"));
        }

        [Test]       
        public void TestRecurringFirstOfMonth()
        {
            Assert.AreEqual("Um 06:00", ExpressionDescriptor.GetDescription("0 0 6 1/1 * ?"));
        }

        [Test]       
        public void TestMinutesPastTheHour()
        {
            Assert.AreEqual("Bei Minute 5", ExpressionDescriptor.GetDescription("0 5 0/1 * * ?"));
        }

        [Test]       
        public void TestOneYearOnlyWithSeconds()
        {
            Assert.AreEqual("Jede Sekunde, nur im 2013", ExpressionDescriptor.GetDescription("* * * * * * 2013"));
        }

        [Test]       
        public void TestOneYearOnlyWithoutSeconds()
        {
            Assert.AreEqual("Jede Minute, nur im 2013", ExpressionDescriptor.GetDescription("* * * * * 2013"));
        }

        [Test]       
        public void TestTwoYearsOnly()
        {
            Assert.AreEqual("Jede Minute, nur im 2013 und 2014", ExpressionDescriptor.GetDescription("* * * * * 2013,2014"));
        }

        [Test]       
        public void TestYearRange2()
        {
            Assert.AreEqual("Um 12:23, Januar bis Februar, 2013 bis 2014", ExpressionDescriptor.GetDescription("23 12 * JAN-FEB * 2013-2014"));
        }

        [Test]       
        public void TestYearRange3()
        {
            Assert.AreEqual("Um 12:23, Januar bis März, 2013 bis 2015", ExpressionDescriptor.GetDescription("23 12 * JAN-MAR * 2013-2015"));
        }

        [Test]       
        public void TestHourRange()
        {
            Assert.AreEqual("Alle 30 Minuten, zwischen 08:00 und 09:59, am 5 und 20 Tag des Monats", ExpressionDescriptor.GetDescription("0 0/30 8-9 5,20 * ?"));
        }

        [Test]       
        public void TestDayOfWeekModifier()
        {
            Assert.AreEqual("Um 12:23, am zweiten Sonntag des Monats", ExpressionDescriptor.GetDescription("23 12 * * SUN#2"));
        }

        [Test]       
        public void TestDayOfWeekModifierWithSundayStartOne()
        {
            Options options = new Options();
            options.DayOfWeekStartIndexZero = false;
            options.Use24HourTimeFormat = true;

            Assert.AreEqual("Um 12:23, am zweiten Sonntag des Monats", ExpressionDescriptor.GetDescription("23 12 * * 1#2", options));
        }

        [Test]       
        public void TestHourRangeWithEveryPortion()
        {
            Assert.AreEqual("Bei Minute 25, alle 13 Stunden, zwischen 07:00 und 19:59", ExpressionDescriptor.GetDescription("0 25 7-19/13 ? * *"));
        }

        [Test]       
        public void TestHourRangeWithTrailingZeroWithEveryPortion()
        {
            Assert.AreEqual("Bei Minute 25, alle 13 Stunden, zwischen 07:00 und 20:59", ExpressionDescriptor.GetDescription("0 25 7-20/13 ? * *"));
        }

        [Test]
        public void TestSecondsInternalWithStepValue()
        {
            // GitHub Issue #49: https://github.com/bradyholt/cron-expression-descriptor/issues/49
            Assert.AreEqual("Alle 30 Sekunden, beginnend bei Sekunde 5", ExpressionDescriptor.GetDescription("5/30 * * * * ?"));
        }

        [Test]
        public void TestMinutesInternalWithStepValue()
        {
            Assert.AreEqual("Alle 30 Minuten, beginnend bei Minute 5", ExpressionDescriptor.GetDescription("0 5/30 * * * ?"));
        }
        
        [Test]
        public void TestHoursInternalWithStepValue()
        {
            Assert.AreEqual("Jede Sekunde, alle 8 Stunden, beginnend um 05:00", ExpressionDescriptor.GetDescription("* * 5/8 * * ?"));
        }
        
        [Test]
        public void TestDayOfMonthInternalWithStepValue()
        {
            Assert.AreEqual("Um 07:05, alle 3 Tage, beginnend am 2 Tag des Monats", ExpressionDescriptor.GetDescription("0 5 7 2/3 * ? *"));
        }
        
        [Test]
        public void TestMonthInternalWithStepValue()
        {
            Assert.AreEqual("Um 07:05, alle 2 Monate, März bis Dezember", ExpressionDescriptor.GetDescription("0 5 7 ? 3/2 ? *"));
        }
        
        [Test]
        public void TestDayOfWeekInternalWithStepValue()
        {
            Assert.AreEqual("Um 07:05, every 3 days of the week, Dienstag bis Samstag", ExpressionDescriptor.GetDescription("0 5 7 ? * 2/3 *"));
        }
                
        [Test]
        public void TestYearInternalWithStepValue()
        {
            Assert.AreEqual("Um 07:05, alle 4 Jahre, 2016 bis 9999", ExpressionDescriptor.GetDescription("0 5 7 ? * ? 2016/4"));
        }
    }
}