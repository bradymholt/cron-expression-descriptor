using Xunit;

namespace CronExpressionDescriptor.Test
{
    /// <summary>
    /// Tests for Romanian translation
    /// </summary>
    public class TestFormatsRO : Support.BaseTestFormats
    {
        static readonly Options _verbose = new Options() { Verbose = true, Use24HourTimeFormat = true };

        protected override string GetLocale()
        {
            return "ro-RO";
        }

        void Harness(string cron, string expected, string expectedVerbose)
        {
            Assert.Equal(expected, GetDescription(cron));
            Assert.Equal(expectedVerbose, GetDescription(cron, _verbose));
        }

        [Fact]
        public void TestEveryMinute()
        {
            Harness (cron: "* * * * *", 
                expected: "În fiecare minut", 
                expectedVerbose: "În fiecare minut, în fiecare oră, în fiecare zi");
        }

        [Fact]
        public void TestEvery1Minute()
        {
            Harness(cron: "*/1 * * * *"  , expected: "În fiecare minut", expectedVerbose: "În fiecare minut, în fiecare oră, în fiecare zi");
            Harness(cron: "0 0/1 * * * ?", expected: "În fiecare minut", expectedVerbose: "În fiecare minut, în fiecare oră, în fiecare zi");            
        }

        [Fact]
        public void TestEveryHour()
        {
            Harness(cron: "0 0 * * * ?", expected: "În fiecare oră", expectedVerbose: "În fiecare oră, în fiecare zi");
            Harness(cron: "0 0 0/1 * * ?", expected: "În fiecare oră", expectedVerbose: "În fiecare oră, în fiecare zi");
        }

        [Fact]
        public void TestTimeOfDayCertainDaysOfWeek()
        {
            Harness(cron: "0 23 ? * MON-FRI", expected: "La 23:00, de luni până vineri"
                , expectedVerbose: "La 23:00, de luni până vineri");
        }

        [Fact]
        public void TestEverySecond()
        {
            Harness(cron: "* * * * * *", expected: "În fiecare secundă"
                , expectedVerbose: "În fiecare secundă, în fiecare minut, în fiecare oră, în fiecare zi");
        }

        [Fact]
        public void TestEvery45Seconds()
        {
            Harness(cron: "*/45 * * * * *",
                expected: "La fiecare 45 secunde", 
                expectedVerbose: "La fiecare 45 secunde, în fiecare minut, în fiecare oră, în fiecare zi"); 
        }

        [Fact]
        public void TestEvery5Minutes()
        {
            Harness(cron: "*/5 * * * *",
                expected: "La fiecare 5 minute",
                expectedVerbose: "La fiecare 5 minute, în fiecare oră, în fiecare zi");

            Harness(cron: "0 0/10 * * * ?",
                expected: "La fiecare 10 minute",
                expectedVerbose: "La fiecare 10 minute, în fiecare oră, în fiecare zi");
        }

        [Fact]
        public void TestEvery5MinutesOnTheSecond()
        {
            Harness(cron: "0 */5 * * * *", expected: "La fiecare 5 minute", expectedVerbose: "La fiecare 5 minute, în fiecare oră, în fiecare zi");
        }

        [Fact]
        public void TestWeekdaysAtTime()
        {
            Harness(cron: "30 11 * * 1-5",
                expected: "La 11:30, de luni până vineri",
                expectedVerbose: "La 11:30, de luni până vineri");
        }

        [Fact]
        public void TestDailyAtTime()
        {
            Harness(cron: "30 11 * * *"
            , expected: "La 11:30"
            , expectedVerbose: "La 11:30, în fiecare zi");
        }

        [Fact]
        public void TestMinuteSpan()
        {
            Harness("0-10 11 * * *", expected: "În fiecare minut între 11:00 și 11:10", expectedVerbose: "În fiecare minut între 11:00 și 11:10, în fiecare zi");
        }

        [Fact]
        public void TestOneMonthOnly()
        {
            Harness (cron:"* * * 3 *", expected:"În fiecare minut, doar în martie", 
                expectedVerbose:"În fiecare minut, în fiecare oră, în fiecare zi, doar în martie");
        }

        [Fact]
        public void TestTwoMonthsOnly()
        {
            Harness ( cron:"* * * 3,6 *",
                expected: "În fiecare minut, doar în martie și iunie",
                expectedVerbose: "În fiecare minut, în fiecare oră, în fiecare zi, doar în martie și iunie");
        }

        [Fact]
        public void TestTwoTimesEachAfternoon()
        {
            Harness(cron: "30 14,16 * * *", expected: "La 14:30 și 16:30", expectedVerbose: "La 14:30 și 16:30, în fiecare zi");  
        }

        [Fact]
        public void TestThreeTimesDaily()
        {
            Harness (cron:"30 6,14,16 * * *", expected:"La 06:30, 14:30 și 16:30", expectedVerbose: "La 06:30, 14:30 și 16:30, în fiecare zi");
        }

        [Fact]
        public void TestOnceAWeek()
        {
            Harness(cron: "46 9 * * 1", expected: "La 09:46, doar luni", expectedVerbose: "La 09:46, doar luni");
        }

        [Fact]
        public void TestDayOfMonth()
        {
            Harness(cron: "23 12 15 * *", 
                expected: "La 12:23, în ziua 15 a lunii", 
                expectedVerbose: "La 12:23, în ziua 15 a lunii");
        }

        [Fact]
        public void TestMonthName()
        {
            Harness(cron: "23 12 * JAN *", expected: "La 12:23, doar în ianuarie", expectedVerbose: "La 12:23, în fiecare zi, doar în ianuarie");
        }

        [Fact]
        public void TestDayOfMonthWithQuestionMark()
        {
            Harness(cron: "23 12 ? JAN *", expected: "La 12:23, doar în ianuarie", expectedVerbose: "La 12:23, în fiecare zi, doar în ianuarie");
        }

        [Fact]
        public void TestMonthNameRange2()
        {
            Harness(cron:"23 12 * JAN-FEB *",
                expected: "La 12:23, din ianuarie până în februarie",
                expectedVerbose: "La 12:23, în fiecare zi, din ianuarie până în februarie");
        }

        [Fact]
        public void TestMonthNameRange3()
        {
            Harness(
              cron: "23 12 * JAN-MAR *", 
              expected: "La 12:23, din ianuarie până în martie",
              expectedVerbose: "La 12:23, în fiecare zi, din ianuarie până în martie");
        }

        [Fact]
        public void TestDayOfWeekName()
        {
            Harness(cron: "23 12 * * SUN", expected: "La 12:23, doar duminică", expectedVerbose: "La 12:23, doar duminică");
        }

        [Fact]
        public void TestDayOfWeekRange()
        {
            Harness(cron: "*/5 15 * * MON-FRI", 
                expected: "La fiecare 5 minute, între 15:00 și 15:59, de luni până vineri",
                expectedVerbose: "La fiecare 5 minute, între 15:00 și 15:59, de luni până vineri");
        }

        [Fact]
        public void TestDayOfWeekOnceInMonth()
        {
            Harness(cron: "* * * * MON#3", 
                expected: "În fiecare minut, în a treia luni a lunii", 
                expectedVerbose: "În fiecare minut, în fiecare oră, în a treia luni a lunii");
        }

        [Fact]
        public void TestLastDayOfTheWeekOfTheMonth()
        {
            Harness(cron: "* * * * 4L",
                expected: "În fiecare minut, în ultima joi a lunii",
                expectedVerbose: "În fiecare minut, în fiecare oră, în ultima joi a lunii");
        }

        [Fact]
        public void TestLastDayOfTheMonth()
        {
            Harness(
              cron: "*/5 * L JAN *", 
              expected: "La fiecare 5 minute, în ultima zi a lunii, doar în ianuarie",
              expectedVerbose: "La fiecare 5 minute, în fiecare oră, în ultima zi a lunii, doar în ianuarie");
        }

        [Fact]
        public void TestLastWeekdayOfTheMonth()
        {
            Harness(cron: "* * LW * *",
                expected: "În fiecare minut, în ultima zi lucrătoare a lunii",
                expectedVerbose: "În fiecare minut, în fiecare oră, în ultima zi lucrătoare a lunii");
        }

        [Fact]
        public void TestLastWeekdayOfTheMonth2()
        {
            Harness(cron: "* * WL * *",
                expected: "În fiecare minut, în ultima zi lucrătoare a lunii",
                expectedVerbose: "În fiecare minut, în fiecare oră, în ultima zi lucrătoare a lunii");
        }

        [Fact]
        public void TestFirstWeekdayOfTheMonth()
        {
            Harness(cron: "* * 1W * *", expected: "În fiecare minut, în prima zi a săptămânii a lunii"
                , expectedVerbose: "În fiecare minut, în fiecare oră, în prima zi a săptămânii a lunii");
        }

        [Fact]
        public void TestThirteenthWeekdayOfTheMonth()
        {
            Harness(cron: "* * 13W * *",
                expected: "În fiecare minut, în cea mai apropiată zi a săptămânii de ziua 13 a lunii",
                expectedVerbose: "În fiecare minut, în fiecare oră, în cea mai apropiată zi a săptămânii de ziua 13 a lunii");
        }

        [Fact]
        public void TestFirstWeekdayOfTheMonth2()
        {
            Harness(cron: "* * W1 * *", expected: "În fiecare minut, în prima zi a săptămânii a lunii"
               , expectedVerbose: "În fiecare minut, în fiecare oră, în prima zi a săptămânii a lunii");
        }

        [Fact]
        public void TestParticularWeekdayOfTheMonth()
        {
            Harness(cron: "* * 5W * *",
                expected: "În fiecare minut, în cea mai apropiată zi a săptămânii de ziua 5 a lunii", 
                expectedVerbose: "În fiecare minut, în fiecare oră, în cea mai apropiată zi a săptămânii de ziua 5 a lunii");
        }

        [Fact]
        public void TestParticularWeekdayOfTheMonth2()
        {
            Harness(cron: "* * W5 * *",
                expected: "În fiecare minut, în cea mai apropiată zi a săptămânii de ziua 5 a lunii",
                expectedVerbose: "În fiecare minut, în fiecare oră, în cea mai apropiată zi a săptămânii de ziua 5 a lunii");
        }

        [Fact]
        public void TestTimeOfDayWithSeconds()
        {
            Harness(cron: "30 02 14 * * *", expected: "La 14:02:30", expectedVerbose: "La 14:02:30, în fiecare zi");
        }

        [Fact]
        public void TestSecondsInterval()
        {
            Harness(cron: "5-10 * * * * *", 
                expected: "Între secunda 5 și secunda 10",
                expectedVerbose: "Între secunda 5 și secunda 10, în fiecare minut, în fiecare oră, în fiecare zi");
        }

        [Fact]
        public void TestSecondMinutesHoursIntervals()
        {
            Harness(cron: "5-10 30-35 10-12 * * *",
                expected: "Între secunda 5 și secunda 10, între minutele 30 și 35, între 10:00 și 12:59",
                expectedVerbose: "Între secunda 5 și secunda 10, între minutele 30 și 35, între 10:00 și 12:59, în fiecare zi");
        }

        [Fact]
        public void TestEvery5MinutesAt30Seconds()
        {
            Harness(cron: "30 */5 * * * *",
                expected: "La și 30 de secunde, la fiecare 5 minute",
                expectedVerbose: "La și 30 de secunde, la fiecare 5 minute, în fiecare oră, în fiecare zi");
        }

        [Fact]
        public void TestMinutesPastTheHourRange()
        {
            Harness(
              cron: "0 30 10-13 ? * WED,FRI",
              expected: "La și 30 de minute, între 10:00 și 13:59, doar miercuri și vineri",
              expectedVerbose: "La și 30 de minute, între 10:00 și 13:59, doar miercuri și vineri");            
        }

        [Fact]
        public void TestSecondsPastTheMinuteInterval()
        {
            Harness (cron:"10 0/5 * * * ?", 
                expected: "La și 10 secunde, la fiecare 5 minute",
                expectedVerbose: "La și 10 secunde, la fiecare 5 minute, în fiecare oră, în fiecare zi");
        }

        [Fact]
        public void TestBetweenWithInterval()
        {
           //"Every 03 minutes, minutes 02 through 59 past the hour, at 01:00, 09:00, and 10:00, between day 11 and 26 of the month, January through June"
           // , în fiecare zi
            Harness (
              cron: "2-59/3 1,9,22 11-26 1-6 ?",
              expected: "La fiecare 3 minute, între minutele 2 și 59, la 01:00, 09:00, și 22:00, între zilele 11 și 26 ale lunii, din ianuarie până în iunie",
              expectedVerbose: "La fiecare 3 minute, între minutele 2 și 59, la 01:00, 09:00, și 22:00, între zilele 11 și 26 ale lunii, din ianuarie până în iunie");
        }

        [Fact]
        public void TestRecurringFirstOfMonth()
        {
            Harness(cron: "0 0 6 1/1 * ?", expected: "La 06:00", expectedVerbose: "La 06:00, în fiecare zi");
        }

        [Fact]
        public void TestMinutesPastTheHour()
        {
            Harness (cron:"0 5 0/1 * * ?", 
                expected: "La și 5 minute",
                expectedVerbose: "La și 5 minute, în fiecare oră, în fiecare zi");
        }

        [Fact]
        public void TestOneYearOnlyWithSeconds()
        {
            Harness(cron: "* * * * * * 2013", expected: "În fiecare secundă, doar în 2013",
                expectedVerbose: "În fiecare secundă, în fiecare minut, în fiecare oră, în fiecare zi, doar în 2013");
        }

        [Fact]
        public void TestOneYearOnlyWithoutSeconds()
        {
            Harness(cron:"* * * * * 2013", expected:"În fiecare minut, doar în 2013",
                expectedVerbose: "În fiecare minut, în fiecare oră, în fiecare zi, doar în 2013");
        }

        [Fact]
        public void TestTwoYearsOnly()
        {
            Harness (cron:"* * * * * 2013,2014",
                expected: "În fiecare minut, doar în 2013 și 2014",
                expectedVerbose: "În fiecare minut, în fiecare oră, în fiecare zi, doar în 2013 și 2014");
        }

        [Fact]
        public void TestYearRange2()
        {
            Harness (cron:"23 12 * JAN-FEB * 2013-2014",
                expected:"La 12:23, din ianuarie până în februarie, din 2013 până în 2014",
                expectedVerbose:"La 12:23, în fiecare zi, din ianuarie până în februarie, din 2013 până în 2014");
        }

        [Fact]
        public void TestYearRange3()
        {
            Harness (
              cron:"23 12 * JAN-MAR * 2013-2015",
              expected: "La 12:23, din ianuarie până în martie, din 2013 până în 2015",
              expectedVerbose: "La 12:23, în fiecare zi, din ianuarie până în martie, din 2013 până în 2015" );
        }

        [Fact]
        public void TestHourRange()
        {
            Harness (
              cron: "0 0/30 8-9 5,20 * ?",
              expected: "La fiecare 30 minute, între 08:00 și 09:59, în ziua 5 și 20 a lunii",
              expectedVerbose: "La fiecare 30 minute, între 08:00 și 09:59, în ziua 5 și 20 a lunii" );
        }

        [Fact]
        public void TestDayOfWeekModifier()
        {
            Harness(cron: "23 12 * * SUN#2", 
                expected: "La 12:23, în a doua duminică a lunii", 
                expectedVerbose: "La 12:23, în a doua duminică a lunii");
        }

        [Fact]
        public void TestDayOfWeekModifierWithSundayStartOne()
        {
            Assert.Equal("La 12:23, în a doua duminică a lunii",
                GetDescription("23 12 * * 1#2",
                    new Options() { DayOfWeekStartIndexZero = false }));
        }

        [Fact]
        public void TestHourRangeWithEveryPortion()
        {
            Harness(cron: "0 25 7-19/13 ? * *",
                expected: "La și 25 de minute, la fiecare 13 ore, între 07:00 și 19:59",
                expectedVerbose: "La și 25 de minute, la fiecare 13 ore, între 07:00 și 19:59, în fiecare zi");
        }

        [Fact]
        public void TestHourRangeWithTrailingZeroWithEveryPortion()
        {
            Harness(cron: "0 25 7-20/13 ? * *",
               expected: "La și 25 de minute, la fiecare 13 ore, între 07:00 și 20:59",
               expectedVerbose: "La și 25 de minute, la fiecare 13 ore, între 07:00 și 20:59, în fiecare zi");
        }

        [Fact]
        public void TestEvery3Day()
        {
            Harness(cron: "0 0 8 1/3 * ? *", expected: "La 08:00, la fiecare 3 zile", expectedVerbose: "La 08:00, la fiecare 3 zile");
        }

        [Fact]
        public void TestsEvery3DayOfTheWeek()
        {
            Harness(cron: "0 15 10 ? * */3",
                expected: "La 10:15, la fiecare a 3-a zi a săptămânii",
                expectedVerbose: "La 10:15, la fiecare a 3-a zi a săptămânii");
        }

        [Fact]
        public void TestEvery3Month()
        {
            Harness(cron: "0 5 7 2 1/3 ? *",
                expected: "La 07:05, în ziua 2 a lunii, la fiecare 3 luni",
                expectedVerbose: "La 07:05, în ziua 2 a lunii, la fiecare 3 luni");
        }

        [Fact]
        public void TestEvery2Years()
        {
            Harness(cron: "0 15 6 1 1 ? 1/2",
                expected: "La 06:15, în ziua 1 a lunii, doar în ianuarie, o dată la 2 ani",
                expectedVerbose: "La 06:15, în ziua 1 a lunii, doar în ianuarie, o dată la 2 ani");
        }

        [Fact]
        public void TestMutiPartRangeSeconds()
        {
            Harness (cron:"2,4-5 1 * * *",
                expected: "La și 2 și de la 4 până la 5 minute, la 01:00",
                expectedVerbose: "La și 2 și de la 4 până la 5 minute, la 01:00, în fiecare zi");
        }

        [Fact]
        public void TestMutiPartRangeSeconds2()
        {
            Harness(cron: "2,26-28 18 * * *",
                expected: "La și 2 și de la 26 până la 28 minute, la 18:00",
                expectedVerbose: "La și 2 și de la 26 până la 28 minute, la 18:00, în fiecare zi");
        }

        [Fact]
        public void TrailingSpaceDoesNotCauseAWrongDescription()
        {
            // GitHub Issue #51: https://github.com/bradymholt/cron-expression-descriptor/issues/51
            Harness(cron: "0 7 * * * ", expected: "La 07:00", expectedVerbose: "La 07:00, în fiecare zi");
        }

        [Fact]
        public void TestMultiPartDayOfTheWeek()
        {
            // GitHub Issue #44: https://github.com/bradymholt/cron-expression-descriptor/issues/44
            Harness(cron: "0 00 10 ? * MON-THU,SUN *",
                expected: "La 10:00, doar de luni până joi și duminică",
                expectedVerbose: "La 10:00, doar de luni până joi și duminică");
        }

        [Fact]
        public void TestSecondsInternalWithStepValue()
        {
            // GitHub Issue #49: https://github.com/bradymholt/cron-expression-descriptor/issues/49
            Assert.Equal("La fiecare 30 secunde, începând la și 5 secunde", GetDescription("5/30 * * * * ?"));
        }

        [Fact]
        public void TestMinutesInternalWithStepValue()
        {
            Assert.Equal("La fiecare 30 minute, începând la și 5 minute", GetDescription("0 5/30 * * * ?"));
        }

        [Fact]
        public void TestHoursInternalWithStepValue()
        {
            Assert.Equal("În fiecare secundă, la fiecare 8 ore, începând la 05:00", GetDescription(" * * 5/8 * * ?"));
        }

        [Fact]
        public void TestDayOfMonthInternalWithStepValue()
        {
            // 'începând cu a doua zi a lunii' would be more appropriate
            Assert.Equal("La 07:05, la fiecare 3 zile, începând în ziua 2 a lunii", GetDescription("0 5 7 2/3 * ? *"));
        }

        [Fact]
        public void TestMonthInternalWithStepValue()
        {
            Assert.Equal("La 07:05, la fiecare 2 luni, din martie până în decembrie", GetDescription("0 5 7 ? 3/2 ? *"));
        }

        [Fact]
        public void TestDayOfWeekInternalWithStepValue()
        {
            Assert.Equal("La 07:05, la fiecare a 3-a zi a săptămânii, de marți până sâmbătă", GetDescription("0 5 7 ? * 2/3 *"));
        }

        [Fact]
        public void TestYearInternalWithStepValue()
        {
            Assert.Equal("La 07:05, o dată la 4 ani, din 2016 până în 9999", GetDescription("0 5 7 ? * ? 2016/4"));
        }
    }
}
