namespace CronExpressionDescriptor.Test
{
    using NUnit.Framework;
    using System.Globalization;
    using System.Threading;

    /// <summary>
    /// Tests for Romanian language
    /// </summary>
    [TestFixture]
#if __MonoCS__
        [Ignore("Mono issues")]
#endif
    public class TestFormatsRO
    {
        static readonly Options _verbose = new Options() { Verbose = true };

        [TestFixtureSetUp]
        public void SetUp()
        {
            CultureInfo myCultureInfo = new CultureInfo("ro-RO");
            Thread.CurrentThread.CurrentCulture = myCultureInfo;
            Thread.CurrentThread.CurrentUICulture = myCultureInfo;
        }

        void Harness (string cron, string expected, string expectedVerbose)
        {
            Assert.AreEqual(expected, ExpressionDescriptor.GetDescription(cron));
            Assert.AreEqual(expectedVerbose, ExpressionDescriptor.GetDescription(cron, _verbose));
        }

        [Test]
        public void TestEveryMinute()
        {
            Harness (cron: "* * * * *", 
                expected: "În fiecare minut", 
                expectedVerbose: "În fiecare minut, în fiecare oră, în fiecare zi, în fiecare zi");
        }

        [Test]
        public void TestEvery1Minute()
        {
            Harness(cron: "*/1 * * * *"  , expected: "În fiecare minut", expectedVerbose: "În fiecare minut, în fiecare oră, în fiecare zi, în fiecare zi");
            Harness(cron: "0 0/1 * * * ?", expected: "În fiecare minut", expectedVerbose: "În fiecare minut, în fiecare oră, în fiecare zi, în fiecare zi");            
        }

        [Test]
        public void TestEveryHour()
        {
            Harness(cron: "0 0 * * * ?", expected: "În fiecare oră", expectedVerbose: "În fiecare oră, în fiecare zi, în fiecare zi");
            Harness(cron: "0 0 0/1 * * ?", expected: "În fiecare oră", expectedVerbose: "În fiecare oră, în fiecare zi, în fiecare zi");
        }

        [Test]
        public void TestTimeOfDayCertainDaysOfWeek()
        {
           Harness(cron: "0 23 ? * MON-FRI", expected: "La 23:00, de luni până vineri"
               , expectedVerbose: "La 11:00 PM, în fiecare zi, de luni până vineri");            
        }

        [Test]
        public void TestEverySecond()
        {
            Harness(cron: "* * * * * *", expected: "În fiecare secundă"
                , expectedVerbose: "În fiecare secundă, în fiecare minut, în fiecare oră, în fiecare zi, în fiecare zi");
        }

        [Test]
        public void TestEvery45Seconds()
        {
            Harness(cron: "*/45 * * * * *",
                expected: "La fiecare 45 secunde", 
                expectedVerbose: "La fiecare 45 secunde, în fiecare minut, în fiecare oră, în fiecare zi, în fiecare zi"); 
        }

        [Test]
        public void TestEvery5Minutes()
        {
            Harness(cron: "*/5 * * * *",
                expected: "La fiecare 5 minute",
                expectedVerbose: "La fiecare 5 minute, în fiecare oră, în fiecare zi, în fiecare zi");

            Harness(cron: "0 0/10 * * * ?",
                expected: "La fiecare 10 minute",
                expectedVerbose: "La fiecare 10 minute, în fiecare oră, în fiecare zi, în fiecare zi");
        }

        [Test]
        public void TestEvery5MinutesOnTheSecond()
        {
            Harness(cron: "0 */5 * * * *", expected: "La fiecare 5 minute", 
                expectedVerbose: "La fiecare 5 minute, în fiecare oră, în fiecare zi, în fiecare zi");
        }

        [Test]
        public void TestWeekdaysAtTime()
        {
            Harness (cron:"30 11 * * 1-5", 
                expected:  "La 11:30, de luni până vineri",
                expectedVerbose:  "La 11:30 AM, în fiecare zi, de luni până vineri");
        }

        [Test]
        public void TestDailyAtTime()
        {
            Harness(cron: "30 11 * * *", expected: "La 11:30", expectedVerbose: "La 11:30 AM, în fiecare zi, în fiecare zi");
        }

        [Test]
        public void TestMinuteSpan()
        {
            Harness("0-10 11 * * *", expected: "În fiecare minut între 11:00 și 11:10",
                expectedVerbose: "În fiecare minut între 11:00 AM și 11:10 AM, în fiecare zi, în fiecare zi");
        }

        [Test]
        public void TestOneMonthOnly()
        {
            Harness (cron:"* * * 3 *", expected:"În fiecare minut, doar în Martie", 
                expectedVerbose:"În fiecare minut, în fiecare oră, în fiecare zi, în fiecare zi, doar în Martie");
        }

        [Test]
        public void TestTwoMonthsOnly()
        {
            Harness ( cron:"* * * 3,6 *",
                expected: "În fiecare minut, doar în Martie și Iunie",
                expectedVerbose: "În fiecare minut, în fiecare oră, în fiecare zi, în fiecare zi, doar în Martie și Iunie");
        }

        [Test]
        public void TestTwoTimesEachAfternoon()
        {
            Harness(cron: "30 14,16 * * *", expected: "La 14:30 și 16:30",
                expectedVerbose: "La 02:30 PM și 04:30 PM, în fiecare zi, în fiecare zi");  
        }

        [Test]
        public void TestThreeTimesDaily()
        {
            Harness(cron:"30 6,14,16 * * *",
                expected:"La 06:30, 14:30 și 16:30",
                expectedVerbose: "La 06:30 AM, 02:30 PM și 04:30 PM, în fiecare zi, în fiecare zi");
        }

        [Test]
        public void TestOnceAWeek()
        {
            Harness(cron: "46 9 * * 1", expected: "La 09:46, doar luni", expectedVerbose: "La 09:46 AM, în fiecare zi, doar luni");
        }

        [Test]
        public void TestDayOfMonth()
        {
            Harness(cron: "23 12 15 * *", 
                expected: "La 12:23, în ziua 15 a lunii", 
                expectedVerbose: "La 12:23 PM, în ziua 15 a lunii, în fiecare zi");
        }

        [Test]
        public void TestMonthName()
        {
            Harness(cron: "23 12 * JAN *", expected: "La 12:23, doar în Ianuarie",
                expectedVerbose: "La 12:23 PM, în fiecare zi, în fiecare zi, doar în Ianuarie");
        }

        [Test]
        public void TestDayOfMonthWithQuestionMark()
        {
            Harness(cron: "23 12 ? JAN *", expected: "La 12:23, doar în Ianuarie", expectedVerbose: "La 12:23 PM, în fiecare zi, în fiecare zi, doar în Ianuarie");
        }

        [Test]
        public void TestMonthNameRange2()
        {
            Harness(cron:"23 12 * JAN-FEB *",
                expected: "La 12:23, din Ianuarie până în Februarie",
                expectedVerbose: "La 12:23 PM, în fiecare zi, în fiecare zi, din Ianuarie până în Februarie");
        }

        [Test]
        public void TestMonthNameRange3()
        {
            Harness(cron: "23 12 * JAN-MAR *", expected: "La 12:23, din Ianuarie până în Martie",
                expectedVerbose: "La 12:23 PM, în fiecare zi, în fiecare zi, din Ianuarie până în Martie");
        }

        [Test]
        public void TestDayOfWeekName()
        {
            Harness(cron: "23 12 * * SUN", expected: "La 12:23, doar duminică", expectedVerbose: "La 12:23 PM, în fiecare zi, doar duminică");
        }

        [Test]
        public void TestDayOfWeekRange()
        {
            Harness(cron: "*/5 15 * * MON-FRI", 
                expected: "La fiecare 5 minute, la 15:00, de luni până vineri",
                expectedVerbose: "La fiecare 5 minute, la 03:00 PM, în fiecare zi, de luni până vineri");
        }

        [Test]
        public void TestDayOfWeekOnceInMonth()
        {
            Harness(cron: "* * * * MON#3", 
                expected: "În fiecare minut, în a treia luni a lunii", 
                expectedVerbose: "În fiecare minut, în fiecare oră, în fiecare zi, în a treia luni a lunii");
        }

        [Test]
        public void TestLastDayOfTheWeekOfTheMonth()
        {
            Harness(cron: "* * * * 4L", 
                expected: "În fiecare minut, în ultima joi a lunii",
                expectedVerbose: "În fiecare minut, în fiecare oră, în fiecare zi, în ultima joi a lunii");
        }

        [Test]
        public void TestLastDayOfTheMonth()
        {
            Harness(cron: "*/5 * L JAN *", expected: "La fiecare 5 minute, în ultima zi a lunii, doar în Ianuarie",
                expectedVerbose: "La fiecare 5 minute, în fiecare oră, în ultima zi a lunii, în fiecare zi, doar în Ianuarie");
        }

        [Test]
        public void TestLastWeekdayOfTheMonth()
        {
            Harness(cron: "* * LW * *", 
                expected: "În fiecare minut, în ultima zi lucrătoare a lunii",
                expectedVerbose: "În fiecare minut, în fiecare oră, în ultima zi lucrătoare a lunii, în fiecare zi");
        }

        [Test]
        public void TestLastWeekdayOfTheMonth2()
        {
            Harness(cron: "* * WL * *",
                expected: "În fiecare minut, în ultima zi lucrătoare a lunii",
                expectedVerbose: "În fiecare minut, în fiecare oră, în ultima zi lucrătoare a lunii, în fiecare zi");
        }

        [Test]
        public void TestFirstWeekdayOfTheMonth()
        {
            Harness(cron: "* * 1W * *", expected: "În fiecare minut, în prima zi a săptămânii a lunii"
                , expectedVerbose: "În fiecare minut, în fiecare oră, în prima zi a săptămânii a lunii, în fiecare zi");
           }

        [Test]
        public void TestThirteenthWeekdayOfTheMonth()
        {
            Harness(cron: "* * 13W * *", 
                expected: "În fiecare minut, în cea mai apropiată zi a săptămânii de ziua 13 a lunii",
                expectedVerbose: "În fiecare minut, în fiecare oră, în cea mai apropiată zi a săptămânii de ziua 13 a lunii, în fiecare zi");
        }

        [Test]
        public void TestFirstWeekdayOfTheMonth2()
        {
            Harness(cron: "* * W1 * *", expected: "În fiecare minut, în prima zi a săptămânii a lunii"
               , expectedVerbose: "În fiecare minut, în fiecare oră, în prima zi a săptămânii a lunii, în fiecare zi");
        }

        [Test]
        public void TestParticularWeekdayOfTheMonth()
        {
            Harness(cron: "* * 5W * *",
                expected: "În fiecare minut, în cea mai apropiată zi a săptămânii de ziua 5 a lunii", 
                expectedVerbose: "În fiecare minut, în fiecare oră, în cea mai apropiată zi a săptămânii de ziua 5 a lunii, în fiecare zi");
        }

        [Test]
        public void TestParticularWeekdayOfTheMonth2()
        {
            Harness(cron: "* * W5 * *",
                expected: "În fiecare minut, în cea mai apropiată zi a săptămânii de ziua 5 a lunii",
                expectedVerbose: "În fiecare minut, în fiecare oră, în cea mai apropiată zi a săptămânii de ziua 5 a lunii, în fiecare zi");
        }

        [Test]
        public void TestTimeOfDayWithSeconds()
        {
            Harness(cron: "30 02 14 * * *",
                expected: "La 14:02:30",
                expectedVerbose: "La 02:02:30 PM, în fiecare zi, în fiecare zi");
        }

        [Test]
        public void TestSecondInternvals()
        {
            Harness(cron: "5-10 * * * * *", 
                expected: "Între secunda 5 și secunda 10",
                expectedVerbose: "Între secunda 5 și secunda 10, în fiecare minut, în fiecare oră, în fiecare zi, în fiecare zi");
        }

        [Test]
        public void TestSecondMinutesHoursIntervals()
        {
            Harness(cron: "5-10 30-35 10-12 * * *",
                expected: "Între secunda 5 și secunda 10, între minutele 30 și 35, între 10:00 și 12:59",
                expectedVerbose: "Între secunda 5 și secunda 10, între minutele 30 și 35, între 10:00 AM și 12:59 PM, în fiecare zi, în fiecare zi");
        }

        [Test]
        public void TestEvery5MinutesAt30Seconds()
        {
            Harness(cron: "30 */5 * * * *",
                expected: "La și 30 de secunde, la fiecare 5 minute",
                expectedVerbose: "La și 30 de secunde, la fiecare 5 minute, în fiecare oră, în fiecare zi, în fiecare zi");
        }

        [Test]
        public void TestMinutesPastTheHourRange()
        {
            Harness(cron: "0 30 10-13 ? * WED,FRI", 
                expected: "La și 30 de minute, între 10:00 și 13:59, doar miercuri și vineri",
                expectedVerbose: "La și 30 de minute, între 10:00 AM și 01:59 PM, în fiecare zi, doar miercuri și vineri");            
        }

        [Test]
        public void TestSecondsPastTheMinuteInterval()
        {
            Harness (cron:"10 0/5 * * * ?", 
                expected: "La și 10 secunde, la fiecare 5 minute",
                expectedVerbose: "La și 10 secunde, la fiecare 5 minute, în fiecare oră, în fiecare zi, în fiecare zi");
        }

        [Test]
        public void TestBetweenWithInterval()
        {
            //"Every 03 minutes, minutes 2 through 59 past the hour, at 01:00 AM, 09:00 AM, and 10:00 PM, between day 11 and 26 of the month, January through June"
            Harness( cron: "2-59/3 1,9,22 11-26 1-6 ?",
                expected: "La fiecare 3 minute, între minutele 2 și 59, la 01:00, 09:00, și 22:00, între zilele 11 și 26 ale lunii, din Ianuarie până în Iunie", 
                expectedVerbose: "La fiecare 3 minute, între minutele 2 și 59, la 01:00 AM, 09:00 AM, și 10:00 PM, între zilele 11 și 26 ale lunii, în fiecare zi, din Ianuarie până în Iunie");
        }

        [Test]
        public void TestRecurringFirstOfMonth()
        {
            Harness(cron: "0 0 6 1/1 * ?", expected: "La 06:00", expectedVerbose: "La 06:00 AM, în fiecare zi, în fiecare zi");
        }

        [Test]
        public void TestMinutesPastTheHour()
        {
            Harness (cron:"0 5 0/1 * * ?", 
                expected: "La și 5 minute",
                expectedVerbose: "La și 5 minute, în fiecare oră, în fiecare zi, în fiecare zi");
        }

        [Test]
        public void TestOneYearOnlyWithSeconds()
        {
            Harness(cron: "* * * * * * 2013", expected: "În fiecare secundă, doar în 2013",
                expectedVerbose: "În fiecare secundă, în fiecare minut, în fiecare oră, în fiecare zi, în fiecare zi, doar în 2013");
        }

        [Test]
        public void TestOneYearOnlyWithoutSeconds()
        {
            Harness(cron:"* * * * * 2013", expected:"În fiecare minut, doar în 2013",
                expectedVerbose: "În fiecare minut, în fiecare oră, în fiecare zi, în fiecare zi, doar în 2013");
        }

        [Test]
        public void TestTwoYearsOnly()
        {
            Harness (cron:"* * * * * 2013,2014",
                expected: "În fiecare minut, doar în 2013 și 2014",
                expectedVerbose: "În fiecare minut, în fiecare oră, în fiecare zi, în fiecare zi, doar în 2013 și 2014");
        }

        [Test]
        public void TestYearRange2()
        {
            Harness (cron:"23 12 * JAN-FEB * 2013-2014",
                expected:"La 12:23, din Ianuarie până în Februarie, din 2013 până în 2014",
                expectedVerbose:"La 12:23 PM, în fiecare zi, în fiecare zi, din Ianuarie până în Februarie, din 2013 până în 2014");
        }

        [Test]
        public void TestYearRange3()
        {
            Harness (cron:"23 12 * JAN-MAR * 2013-2015",
                expected: "La 12:23, din Ianuarie până în Martie, din 2013 până în 2015",
                expectedVerbose: "La 12:23 PM, în fiecare zi, în fiecare zi, din Ianuarie până în Martie, din 2013 până în 2015");
        }

        [Test]
        public void TestHourRange()
        {
            Harness(cron: "0 0/30 8-9 5,20 * ?",
                expected: "La fiecare 30 minute, între 08:00 și 09:59, în ziua 5 și 20 a lunii",
                expectedVerbose: "La fiecare 30 minute, între 08:00 AM și 09:59 AM, în ziua 5 și 20 a lunii, în fiecare zi");
        }

        [Test]
        public void TestDayOfWeekModifier()
        {
            Harness(cron: "23 12 * * SUN#2", 
                expected: "La 12:23, în a doua duminică a lunii", 
                expectedVerbose: "La 12:23 PM, în fiecare zi, în a doua duminică a lunii");
        }

        [Test]
        public void TestDayOfWeekModifierWithSundayStartOne()
        {
            Assert.AreEqual("La 12:23, în a doua duminică a lunii",
                ExpressionDescriptor.GetDescription("23 12 * * 1#2", 
                    new Options() { DayOfWeekStartIndexZero = false }));
        }

        [Test]
        public void TestHourRangeWithEveryPortion()
        {
            Harness(cron: "0 25 7-19/13 ? * *", 
                expected: "La și 25 de minute, la fiecare 13 ore, între 07:00 și 19:59",
                expectedVerbose: "La și 25 de minute, la fiecare 13 ore, între 07:00 AM și 07:59 PM, în fiecare zi, în fiecare zi");
        }

        [Test]
        public void TestHourRangeWithTrailingZeroWithEveryPortion()
        {
            Harness(cron: "0 25 7-20/13 ? * *",
               expected: "La și 25 de minute, la fiecare 13 ore, între 07:00 și 20:59",
               expectedVerbose: "La și 25 de minute, la fiecare 13 ore, între 07:00 AM și 08:59 PM, în fiecare zi, în fiecare zi");
        }

        [Test]
        public void TestEvery3Day()
        {
            Harness(cron: "0 0 8 1/3 * ? *", 
                expected: "La 08:00, la fiecare 3 zile",
                expectedVerbose: "La 08:00 AM, la fiecare 3 zile, în fiecare zi");
        }

        [Test]
        public void TestsEvery3DayOfTheWeek()
        {
            Harness(cron: "0 15 10 ? * */3",
                expected: "La 10:15, la fiecare a 3-a zi a săptămânii",
                expectedVerbose: "La 10:15 AM, în fiecare zi, la fiecare a 3-a zi a săptămânii");
        }

        [Test]
        public void TestEvery3Month()
        {
            Harness(cron: "0 5 7 2 1/3 ? *", 
                expected: "La 07:05, în ziua 2 a lunii, la fiecare 3 luni",
                expectedVerbose: "La 07:05 AM, în ziua 2 a lunii, în fiecare zi, la fiecare 3 luni");
        }

        [Test]
        public void TestEvery2Years()
        {
            Harness(cron: "0 15 6 1 1 ? 1/2",
                expected: "La 06:15, în ziua 1 a lunii, doar în Ianuarie, o dată la 2 ani",
                expectedVerbose: "La 06:15 AM, în ziua 1 a lunii, în fiecare zi, doar în Ianuarie, o dată la 2 ani");
        }

        [Test]
        public void TestMutiPartRangeSeconds()
        {
            Harness (cron:"2,4-5 1 * * *",
                expected: "La și 2 și de 4 până 5 minute, la 01:00",
                expectedVerbose: "La și 2 și de 4 până 5 minute, la 01:00 AM, în fiecare zi, în fiecare zi");
        }

        [Test]
        public void TestMutiPartRangeSeconds2()
        {
            Harness(cron: "2,26-28 18 * * *",
                expected: "La și 2 și de 26 până 28 minute, la 18:00",
                expectedVerbose: "La și 2 și de 26 până 28 minute, la 06:00 PM, în fiecare zi, în fiecare zi");            
        }

        [Test]
        public void TrailingSpaceDoesNotCauseAWrongDescription()
        {
            // GitHub Issue #51: https://github.com/bradyholt/cron-expression-descriptor/issues/51
            Harness(cron: "0 7 * * * ", expected: "La 07:00", expectedVerbose: "La 07:00 AM, în fiecare zi, în fiecare zi");
        }

        [Test]
        public void TestMultiPartDayOfTheWeek()
        {
            // GitHub Issue #44: https://github.com/bradyholt/cron-expression-descriptor/issues/44
            Harness (cron:"0 00 10 ? * MON-THU,SUN *",
                expected: "La 10:00, doar de luni până joi și duminică",
                expectedVerbose: "La 10:00 AM, în fiecare zi, doar de luni până joi și duminică");
        }

        [Test]
        public void TestSecondsInternalWithStepValue()
        {
            // GitHub Issue #49: https://github.com/bradyholt/cron-expression-descriptor/issues/49
            Assert.AreEqual("La fiecare 30 secunde, pornire la și 5 secunde", ExpressionDescriptor.GetDescription("5/30 * * * * ?"));
        }

        [Test]
        public void TestMinutesInternalWithStepValue()
        {
            Assert.AreEqual("La fiecare 30 minute, pornire la și 5 minute", ExpressionDescriptor.GetDescription("0 5/30 * * * ?"));
        }

        [Test]
        public void TestHoursInternalWithStepValue()
        {
            Assert.AreEqual("În fiecare secundă, la fiecare 8 ore, pornire la 05:00", ExpressionDescriptor.GetDescription(" * * 5/8 * * ?"));
        }

        [Test]
        public void TestDayOfMonthInternalWithStepValue()
        {
            Assert.AreEqual("La 07:05, la fiecare 3 zile, pornire în ziua 2 a lunii", ExpressionDescriptor.GetDescription("0 5 7 2/3 * ? *"));
        }

        [Test]
        public void TestMonthInternalWithStepValue()
        {
            Assert.AreEqual("La 07:05, la fiecare 2 luni, din Martie până în Decembrie", ExpressionDescriptor.GetDescription("0 5 7 ? 3/2 ? *"));
        }

        [Test]
        public void TestDayOfWeekInternalWithStepValue()
        {
            Assert.AreEqual("La 07:05, la fiecare a 3-a zi a săptămânii, de marți până sâmbătă", ExpressionDescriptor.GetDescription("0 5 7 ? * 2/3 *"));
        }

        [Test]
        public void TestYearInternalWithStepValue()
        {
            Assert.AreEqual("La 07:05, o dată la 4 ani, din 2016 până în 9999", ExpressionDescriptor.GetDescription("0 5 7 ? * ? 2016/4"));
        }
    }
}