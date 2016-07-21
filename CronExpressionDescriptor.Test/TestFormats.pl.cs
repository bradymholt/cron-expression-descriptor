using NUnit.Framework;
using System.Globalization;
using System.Threading;

namespace CronExpressionDescriptor.Test
{
    [TestFixture]
    public class TestFormatsPL
    {
        [TestFixtureSetUp]
        public void SetUp()
        {
            CultureInfo myCultureInfo = new CultureInfo("pl-PL");
            Thread.CurrentThread.CurrentCulture = myCultureInfo;
            Thread.CurrentThread.CurrentUICulture = myCultureInfo;
        }

        [Test]
        public void TestEveryMinute()
        {
           Assert.AreEqual("Co minutę", ExpressionDescriptor.GetDescription("* * * * *"));
        }

        [Test]
        public void TestEvery1Minute()
        {
            Assert.AreEqual("Co minutę", ExpressionDescriptor.GetDescription("*/1 * * * *"));
            Assert.AreEqual("Co minutę", ExpressionDescriptor.GetDescription("0 0/1 * * * ?"));
        }

        [Test]
        public void TestEveryHour()
        {
            Assert.AreEqual("Co godzinę", ExpressionDescriptor.GetDescription("0 0 * * * ?"));
            Assert.AreEqual("Co godzinę", ExpressionDescriptor.GetDescription("0 0 0/1 * * ?"));
        }

        [Test]
        public void TestTimeOfDayCertainDaysOfWeek()
        {
            Assert.AreEqual("O 23:00, od poniedziałek do piątek", ExpressionDescriptor.GetDescription("0 23 ? * MON-FRI"));
        }

        [Test]
        public void TestEverySecond()
        {
            Assert.AreEqual("Co sekundę", ExpressionDescriptor.GetDescription("* * * * * *"));
        }

        [Test]
        public void TestEvery45Seconds()
        {
            Assert.AreEqual("Co 45 sekund", ExpressionDescriptor.GetDescription("*/45 * * * * *"));
        }

        [Test]
        public void TestEvery5Minutes()
        {
            Assert.AreEqual("Co 5 minut", ExpressionDescriptor.GetDescription("*/5 * * * *"));
            Assert.AreEqual("Co 10 minut", ExpressionDescriptor.GetDescription("0 0/10 * * * ?"));
        }

        [Test]
        public void TestEvery5MinutesOnTheSecond()
        {
            Assert.AreEqual("Co 5 minut", ExpressionDescriptor.GetDescription("0 */5 * * * *"));
        }

        [Test]
        public void TestWeekdaysAtTime()
        {
            Assert.AreEqual("O 11:30, od poniedziałek do piątek", ExpressionDescriptor.GetDescription("30 11 * * 1-5"));
        }

        [Test]
        public void TestDailyAtTime()
        {
            Assert.AreEqual("O 11:30", ExpressionDescriptor.GetDescription("30 11 * * *"));
        }

        [Test]
        public void TestMinuteSpan()
        {
            Assert.AreEqual("Co minutę od 11:00 do 11:10", ExpressionDescriptor.GetDescription("0-10 11 * * *"));
        }

        [Test]
        public void TestOneMonthOnly()
        {
            Assert.AreEqual("Co minutę, tylko marzec", ExpressionDescriptor.GetDescription("* * * 3 *"));
        }

        [Test]
        public void TestTwoMonthsOnly()
        {
            Assert.AreEqual("Co minutę, tylko marzec i czerwiec", ExpressionDescriptor.GetDescription("* * * 3,6 *"));
        }

        [Test]
        public void TestTwoTimesEachAfternoon()
        {
            Assert.AreEqual("O 14:30 i 16:30", ExpressionDescriptor.GetDescription("30 14,16 * * *"));
        }

        [Test]
        public void TestThreeTimesDaily()
        {
            Assert.AreEqual("O 06:30, 14:30 i 16:30", ExpressionDescriptor.GetDescription("30 6,14,16 * * *"));
        }

        [Test]
        public void TestOnceAWeek()
        {
            Assert.AreEqual("O 09:46, tylko poniedziałek", ExpressionDescriptor.GetDescription("46 9 * * 1"));
        }

        [Test]
        public void TestDayOfMonth()
        {
            Assert.AreEqual("O 12:23, 15-ego dnia miesiąca", ExpressionDescriptor.GetDescription("23 12 15 * *"));
        }

        [Test]
        public void TestMonthName()
        {
            Assert.AreEqual("O 12:23, tylko styczeń", ExpressionDescriptor.GetDescription("23 12 * JAN *"));
        }

        [Test]
        public void TestDayOfMonthWithQuestionMark()
        {
            Assert.AreEqual("O 12:23, tylko styczeń", ExpressionDescriptor.GetDescription("23 12 ? JAN *"));
        }

        [Test]
        public void TestMonthNameRange2()
        {
            Assert.AreEqual("O 12:23, od styczeń do luty", ExpressionDescriptor.GetDescription("23 12 * JAN-FEB *"));
        }

        [Test]
        public void TestMonthNameRange3()
        {
            Assert.AreEqual("O 12:23, od styczeń do marzec", ExpressionDescriptor.GetDescription("23 12 * JAN-MAR *"));
        }

        [Test]
        public void TestDayOfWeekName()
        {
            Assert.AreEqual("O 12:23, tylko niedziela", ExpressionDescriptor.GetDescription("23 12 * * SUN"));
        }

        [Test]
        public void TestDayOfWeekRange()
        {
            Assert.AreEqual("Co 5 minut, o 15:00, od poniedziałek do piątek", ExpressionDescriptor.GetDescription("*/5 15 * * MON-FRI"));
        }

        [Test]
        public void TestDayOfWeekOnceInMonth()
        {
            Assert.AreEqual("Co minutę, trzeci poniedziałek miesiąca", ExpressionDescriptor.GetDescription("* * * * MON#3"));
        }

        [Test]
        public void TestLastDayOfTheWeekOfTheMonth()
        {
            Assert.AreEqual("Co minutę, ostatni czwartek miesiąca", ExpressionDescriptor.GetDescription("* * * * 4L"));
        }

        [Test]
        public void TestLastDayOfTheMonth()
        {
            Assert.AreEqual("Co 5 minut, ostatni dzień miesiąca, tylko styczeń", ExpressionDescriptor.GetDescription("*/5 * L JAN *"));
        }

        [Test]
        public void TestLastWeekdayOfTheMonth()
        {
            Assert.AreEqual("Co minutę, ostatni dzień roboczy miesiąca", ExpressionDescriptor.GetDescription("* * LW * *"));
        }

        [Test]
        public void TestLastWeekdayOfTheMonth2()
        {
            Assert.AreEqual("Co minutę, ostatni dzień roboczy miesiąca", ExpressionDescriptor.GetDescription("* * WL * *"));
        }

        [Test]
        public void TestFirstWeekdayOfThseMonth()
        {
            Assert.AreEqual("Co minutę, pierwszy dzień roboczy miesiąca", ExpressionDescriptor.GetDescription("* * 1W * *"));
        }

        [Test]
        public void TestThirteenthWeekdayOfTheMonth()
        {
            Assert.AreEqual("Co minutę, dzień roboczy najbliższy 13-ego dnia miesiąca", ExpressionDescriptor.GetDescription("* * 13W * *"));
        }

        [Test]
        public void TestFirstWeekdayOfTheMonth2()
        {
            Assert.AreEqual("Co minutę, pierwszy dzień roboczy miesiąca", ExpressionDescriptor.GetDescription("* * W1 * *"));
        }

        [Test]
        public void TestParticularWeekdayOfTheMonth()
        {
            Assert.AreEqual("Co minutę, dzień roboczy najbliższy 5-ego dnia miesiąca", ExpressionDescriptor.GetDescription("* * 5W * *"));
        }

        [Test]
        public void TestParticularWeekdayOfTheMonth2()
        {
            Assert.AreEqual("Co minutę, dzień roboczy najbliższy 5-ego dnia miesiąca", ExpressionDescriptor.GetDescription("* * W5 * *"));
        }

        [Test]
        public void TestTimeOfDayWithSeconds()
        {
            Assert.AreEqual("O 14:02:30", ExpressionDescriptor.GetDescription("30 02 14 * * *"));
        }

        [Test]
        public void TestSecondInternvals()
        {
            Assert.AreEqual("Sekundy od 5 do 10", ExpressionDescriptor.GetDescription("5-10 * * * * *"));
        }

        [Test]
        public void TestSecondMinutesHoursIntervals()
        {
            Assert.AreEqual("Sekundy od 5 do 10, minuty od 30 do 35, od 10:00 do 12:59", ExpressionDescriptor.GetDescription("5-10 30-35 10-12 * * *"));
        }

        [Test]
        public void TestEvery5MinutesAt30Seconds()
        {
            Assert.AreEqual("W 30 sekundzie, co 5 minut", ExpressionDescriptor.GetDescription("30 */5 * * * *"));
        }

        [Test]
        public void TestMinutesPastTheHourRange()
        {
            Assert.AreEqual("W 30 minucie, od 10:00 do 13:59, tylko środa i piątek", ExpressionDescriptor.GetDescription("0 30 10-13 ? * WED,FRI"));
        }

        [Test]
        public void TestSecondsPastTheMinuteInterval()
        {
            Assert.AreEqual("W 10 sekundzie, co 5 minut", ExpressionDescriptor.GetDescription("10 0/5 * * * ?"));
        }

        [Test]
        public void TestBetweenWithInterval()
        {
            Assert.AreEqual("Co 3 minut, minuty od 2 do 59, o 01:00, 09:00, i 22:00, od 11-ego do 26-ego dnia miesiąca, od styczeń do czerwiec",
                ExpressionDescriptor.GetDescription("2-59/3 1,9,22 11-26 1-6 ?"));
        }

        [Test]
        public void TestRecurringFirstOfMonth()
        {
            Assert.AreEqual("O 06:00", ExpressionDescriptor.GetDescription("0 0 6 1/1 * ?"));
        }

        [Test]
        public void TestMinutesPastTheHour()
        {
            Assert.AreEqual("W 5 minucie", ExpressionDescriptor.GetDescription("0 5 0/1 * * ?"));
        }

        [Test]
        public void TestOneYearOnlyWithSeconds()
        {
            Assert.AreEqual("Co sekundę, tylko 2013", ExpressionDescriptor.GetDescription("* * * * * * 2013"));
        }
        
        [Test]
        public void TestOneYearOnlyWithoutSeconds()
        {
            Assert.AreEqual("Co minutę, tylko 2013", ExpressionDescriptor.GetDescription("* * * * * 2013"));
        }

        [Test]
        public void TestTwoYearsOnly()
        {
            Assert.AreEqual("Co minutę, tylko 2013 i 2014", ExpressionDescriptor.GetDescription("* * * * * 2013,2014"));
        }

        [Test]
        public void TestYearRange2()
        {
            Assert.AreEqual("O 12:23, od styczeń do luty, od 2013 do 2014", ExpressionDescriptor.GetDescription("23 12 * JAN-FEB * 2013-2014"));
        }

        [Test]
        public void TestYearRange3()
        {
            Assert.AreEqual("O 12:23, od styczeń do marzec, od 2013 do 2015", ExpressionDescriptor.GetDescription("23 12 * JAN-MAR * 2013-2015"));
        }

        [Test]
        public void TestHourRange()
        {
            Assert.AreEqual("Co 30 minut, od 08:00 do 09:59, 5 i 20-ego dnia miesiąca", ExpressionDescriptor.GetDescription("0 0/30 8-9 5,20 * ?"));
        }

        [Test]
        public void TestDayOfWeekModifier()
        {
            Assert.AreEqual("O 12:23, drugi niedziela miesiąca", ExpressionDescriptor.GetDescription("23 12 * * SUN#2"));
        }

        [Test]
        public void TestDayOfWeekModifierWithSundayStartOne()
        {
            Options options = new Options();
            options.DayOfWeekStartIndexZero = false;

            Assert.AreEqual("O 12:23, drugi niedziela miesiąca", ExpressionDescriptor.GetDescription("23 12 * * 1#2", options));
        }

        [Test]
        public void TestHourRangeWithEveryPortion()
        {
            Assert.AreEqual("W 25 minucie, co 13 godzin, od 07:00 do 19:59", ExpressionDescriptor.GetDescription("0 25 7-19/13 ? * *"));
        }

        [Test]
        public void TestHourRangeWithTrailingZeroWithEveryPortion()
        {
            Assert.AreEqual("W 25 minucie, co 13 godzin, od 07:00 do 20:59", ExpressionDescriptor.GetDescription("0 25 7-20/13 ? * *"));
        }

        [Test]
        public void TestEvery3Day()
        {
            Assert.AreEqual("O 08:00, co 3 dni", ExpressionDescriptor.GetDescription("0 0 8 1/3 * ? *"));
        }

        [Test]
        public void TestsEvery3DayOfTheWeek()
        {
            Assert.AreEqual("O 10:15, co 3 dni tygodnia", ExpressionDescriptor.GetDescription("0 15 10 ? * */3"));
        }

        [Test]
        public void TestEvery2DayOfTheWeekInRange()
        {
            // GitHub Issue #58: https://github.com/bradyholt/cron-expression-descriptor/issues/58
            Assert.AreEqual("Co sekundę, co 2 dni tygodnia, od poniedziałek do piątek", ExpressionDescriptor.GetDescription("* * * ? * 1-5/2"));
        }

        [Test]
        public void TestEvery2DayOfTheWeekInRangeWithSundayStartOne()
        {
            // GitHub Issue #59: https://github.com/bradyholt/cron-expression-descriptor/issues/59

            var options = new Options { DayOfWeekStartIndexZero = false };

            Assert.AreEqual("Co sekundę, co 2 dni tygodnia, od poniedziałek do piątek",
                ExpressionDescriptor.GetDescription("* * * ? * 2-6/2", options));
        }

        [Test]
        public void TestEvery3Month()
        {
            Assert.AreEqual("O 07:05, 2-ego dnia miesiąca, co 3 miesięcy", ExpressionDescriptor.GetDescription("0 5 7 2 1/3 ? *"));
        }

        [Test]
        public void TestEvery2Years()
        {
            Assert.AreEqual("O 06:15, 1-ego dnia miesiąca, tylko styczeń, co 2 lat", ExpressionDescriptor.GetDescription("0 15 6 1 1 ? 1/2"));
        }

        [Test]
        public void TestMutiPartRangeSeconds()
        {
            Assert.AreEqual("W 2 i od 4 do 5 minucie, o 01:00", ExpressionDescriptor.GetDescription("2,4-5 1 * * *"));
        }

        [Test]
        public void TestMutiPartRangeSeconds2()
        {
            Assert.AreEqual("W 2 i od 26 do 28 minucie, o 18:00", ExpressionDescriptor.GetDescription("2,26-28 18 * * *"));
        }

        [Test]
        public void TrailingSpaceDoesNotCauseAWrongDescription()
        {
            // GitHub Issue #51: https://github.com/bradyholt/cron-expression-descriptor/issues/51
            Assert.AreEqual("O 07:00", ExpressionDescriptor.GetDescription("0 7 * * * "));
        }

        [Test]
        public void TestMultiPartDayOfTheWeek()
        {
            // GitHub Issue #44: https://github.com/bradyholt/cron-expression-descriptor/issues/44
            Assert.AreEqual("O 10:00, tylko od poniedziałek do czwartek i niedziela", ExpressionDescriptor.GetDescription("0 00 10 ? * MON-THU,SUN *"));
        }

        [Test]
        public void TestSecondsInternalWithStepValue()
        {
            // GitHub Issue #49: https://github.com/bradyholt/cron-expression-descriptor/issues/49
            Assert.AreEqual("Co 30 sekund, startowy w 5 sekundzie", ExpressionDescriptor.GetDescription("5/30 * * * * ?"));
        }

        [Test]
        public void TestMinutesInternalWithStepValue()
        {
            Assert.AreEqual("Co 30 minut, startowy w 5 minucie", ExpressionDescriptor.GetDescription("0 5/30 * * * ?"));
        }
        
        [Test]
        public void TestHoursInternalWithStepValue()
        {
            Assert.AreEqual("Co sekundę, co 8 godzin, startowy o 05:00", ExpressionDescriptor.GetDescription("* * 5/8 * * ?"));
        }
        
        [Test]
        public void TestDayOfMonthInternalWithStepValue()
        {
            Assert.AreEqual("O 07:05, co 3 dni, startowy 2-ego dnia miesiąca", ExpressionDescriptor.GetDescription("0 5 7 2/3 * ? *"));
        }
        
        [Test]
        public void TestMonthInternalWithStepValue()
        {
            Assert.AreEqual("O 07:05, co 2 miesięcy, od marzec do grudzień", ExpressionDescriptor.GetDescription("0 5 7 ? 3/2 ? *"));
        }
        
        [Test]
        public void TestDayOfWeekInternalWithStepValue()
        {
            Assert.AreEqual("O 07:05, co 3 dni tygodnia, od wtorek do sobota", ExpressionDescriptor.GetDescription("0 5 7 ? * 2/3 *"));
        }
                
        [Test]
        public void TestYearInternalWithStepValue()
        {
            Assert.AreEqual("O 07:05, co 4 lat, od 2016 do 9999", ExpressionDescriptor.GetDescription("0 5 7 ? * ? 2016/4"));
        }
    }
}