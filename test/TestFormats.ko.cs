using Xunit;
using Assert = CronExpressionDescriptor.Test.Support.AssertExtensions;

namespace CronExpressionDescriptor.Test
{
    /// <summary>
    /// Tests for Korean translation
    /// </summary>
    public class TestFormatsKO : Support.BaseTestFormats
    {
        protected override string GetLocale()
        {
            return "ko-KR";
        }

        [Fact]
        public void TestEveryMinute()
        {
            Assert.ContainsCaseInsensitive("매분", GetDescription("* * * * *"));
        }

        [Fact]
        public void TestEvery1Minute()
        {
            Assert.ContainsCaseInsensitive("매분", GetDescription("*/1 * * * *"));
            Assert.ContainsCaseInsensitive("매분", GetDescription("0 0/1 * * * ?"));
        }

        [Fact]
        public void TestEveryHour()
        {
            Assert.ContainsCaseInsensitive("매시간", GetDescription("0 0 * * * ?"));
            Assert.ContainsCaseInsensitive("매시간", GetDescription("0 0 0/1 * * ?"));
        }

        [Fact]
        public void TestTimeOfDayCertainDaysOfWeek()
        {
            Assert.ContainsCaseInsensitive("시간 11:00 오후, 월요일~금요일", GetDescription("0 23 ? * MON-FRI"));
        }

        [Fact]
        public void TestEverySecond()
        {
            Assert.ContainsCaseInsensitive("매초", GetDescription("* * * * * *"));
        }

        [Fact]
        public void TestEvery45Seconds()
        {
            Assert.ContainsCaseInsensitive("매 45초", GetDescription("*/45 * * * * *"));
        }

        [Fact]
        public void TestEvery5Minutes()
        {
            Assert.ContainsCaseInsensitive("매 5분", GetDescription("*/5 * * * *"));
            Assert.ContainsCaseInsensitive("매 10분", GetDescription("0 0/10 * * * ?"));
        }

        [Fact]
        public void TestEvery5MinutesOnTheSecond()
        {
            Assert.ContainsCaseInsensitive("매 5분", GetDescription("0 */5 * * * *"));
        }

        [Fact]
        public void TestWeekdaysAtTime()
        {
            Assert.ContainsCaseInsensitive("시간 11:30 오전, 월요일~금요일", GetDescription("30 11 * * 1-5"));
        }

        [Fact]
        public void TestDailyAtTime()
        {
            Assert.ContainsCaseInsensitive("시간 11:30 오전", GetDescription("30 11 * * *"));
        }

        [Fact]
        public void TestMinuteSpan()
        {
            Assert.ContainsCaseInsensitive("매분 11:00 오전~11:10 오전", GetDescription("0-10 11 * * *"));
        }

        [Fact]
        public void TestMinuteSpanWith24HourFormat()
        {
            var options = new Options
            {
                DayOfWeekStartIndexZero = false,
                Use24HourTimeFormat = true
            };
            Assert.ContainsCaseInsensitive("매분 11:00~11:10", GetDescription("0-10 11 * * *", options));
        }

        [Fact]
        public void TestOneMonthOnly()
        {
            Assert.ContainsCaseInsensitive("매분, 3월에만", GetDescription("* * * 3 *"));
        }

        [Fact]
        public void TestTwoMonthsOnly()
        {
            Assert.ContainsCaseInsensitive("매분, 3월 및 6월에만", GetDescription("* * * 3,6 *"));
        }

        [Fact]
        public void TestTwoTimesEachAfternoon()
        {
            Assert.ContainsCaseInsensitive("시간 02:30 오후 및 04:30 오후", GetDescription("30 14,16 * * *"));
        }

        [Fact]
        public void TestThreeTimesDaily()
        {
            Assert.ContainsCaseInsensitive("시간 06:30 오전, 02:30 오후 및 04:30 오후", GetDescription("30 6,14,16 * * *"));
        }

        [Fact]
        public void TestOnceAWeek()
        {
            Assert.ContainsCaseInsensitive("시간 09:46 오전, 월요일에만", GetDescription("46 9 * * 1"));
        }

        [Fact]
        public void TestDayOfMonth()
        {
            Assert.ContainsCaseInsensitive("시간 12:23 오후, 매월 15일", GetDescription("23 12 15 * *"));
        }

        [Fact]
        public void TestMonthName()
        {
            Assert.ContainsCaseInsensitive("시간 12:23 오후, 1월에만", GetDescription("23 12 * JAN *"));
        }


        [Fact]
        public void TestDayOfMonthWithQuestionMark()
        {
            Assert.ContainsCaseInsensitive("시간 12:23 오후, 1월에만", GetDescription("23 12 ? JAN *"));
        }

        [Fact]
        public void TestMonthNameRange2()
        {
            Assert.ContainsCaseInsensitive("시간 12:23 오후, 1월~2월", GetDescription("23 12 * JAN-FEB *"));
        }

        [Fact]
        public void TestMonthNameRange3()
        {
            Assert.ContainsCaseInsensitive("시간 12:23 오후, 1월~3월", GetDescription("23 12 * JAN-MAR *"));
        }

        [Fact]
        public void TestDayOfWeekName()
        {
            Assert.ContainsCaseInsensitive("시간 12:23 오후, 일요일에만", GetDescription("23 12 * * SUN"));
        }

        [Fact]
        public void TestDayOfWeekRange()
        {
            Assert.ContainsCaseInsensitive("매 5분, 03:00 오후~03:59 오후 사이, 월요일~금요일", GetDescription("*/5 15 * * MON-FRI"));
        }

        [Fact]
        public void TestDayOfWeekOnceInMonth()
        {
            Assert.ContainsCaseInsensitive("매분, 매월 세 번째 월요일", GetDescription("* * * * MON#3"));
        }

        [Fact]
        public void TestLastDayOfTheWeekOfTheMonth()
        {
            Assert.ContainsCaseInsensitive("매분, 월의 마지막 목요일", GetDescription("* * * * 4L"));
        }

        [Fact]
        public void TestLastDayOfTheMonth()
        {
            Assert.ContainsCaseInsensitive("매 5분, 월의 마지막 날에, 1월에만", GetDescription("*/5 * L JAN *"));
        }

        [Fact]
        public void TestLastWeekdayOfTheMonth()
        {
            Assert.ContainsCaseInsensitive("매분, 매월 마지막 평일", GetDescription("* * LW * *"));
        }

        [Fact]
        public void TestLastWeekdayOfTheMonth2()
        {
            Assert.ContainsCaseInsensitive("매분, 매월 마지막 평일", GetDescription("* * WL * *"));
        }

        [Fact]
        public void TestFirstWeekdayOfTheMonth()
        {
            Assert.ContainsCaseInsensitive("매분, 매월 첫 번째 평일", GetDescription("* * 1W * *"));
        }

        [Fact]
        public void TestFirstWeekdayOfTheMonth2()
        {
            Assert.ContainsCaseInsensitive("매분, 매월 첫 번째 평일", GetDescription("* * W1 * *"));
        }

        [Fact]
        public void TestParticularWeekdayOfTheMonth()
        {
            Assert.ContainsCaseInsensitive("매분, 매월 5일에 가장 가까운 평일", GetDescription("* * 5W * *"));
        }

        [Fact]
        public void TestParticularWeekdayOfTheMonth2()
        {
            Assert.ContainsCaseInsensitive("매분, 매월 5일에 가장 가까운 평일", GetDescription("* * W5 * *"));
        }

        [Fact]
        public void TestTimeOfDayWithSeconds()
        {
            Assert.ContainsCaseInsensitive("시간 02:02:30 오후", GetDescription("30 02 14 * * *"));
        }

        [Fact]
        public void TestSecondInternvals()
        {
            Assert.ContainsCaseInsensitive("5~10초", GetDescription("5-10 * * * * *"));
        }

        [Fact]
        public void TestSecondMinutesHoursIntervals()
        {
            Assert.ContainsCaseInsensitive("5~10초, 30~35분, 10:00 오전~12:59 오후 사이", GetDescription("5-10 30-35 10-12 * * *"));
        }

        [Fact]
        public void TestEvery5MinutesAt30Seconds()
        {
            Assert.ContainsCaseInsensitive("30초, 매 5분", GetDescription("30 */5 * * * *"));
        }

        [Fact]
        public void TestMinutesPastTheHourRange()
        {
            Assert.ContainsCaseInsensitive("30분, 10:00 오전~01:59 오후 사이, 수요일 및 금요일에만", GetDescription("0 30 10-13 ? * WED,FRI"));
        }

        [Fact]
        public void TestSecondsPastTheMinuteInterval()
        {
            Assert.ContainsCaseInsensitive("10초, 매 5분", GetDescription("10 0/5 * * * ?"));
        }

        [Fact]
        public void TestBetweenWithInterval()
        {
            Assert.ContainsCaseInsensitive("매 3분, 2~59분, 01:00 오전, 09:00 오전, 및 10:00 오후, 월의 11~26일 사이, 1월~6월", GetDescription("2-59/3 1,9,22 11-26 1-6 ?"));
        }

        [Fact]
        public void TestRecurringFirstOfMonth()
        {
            Assert.ContainsCaseInsensitive("시간 06:00 오전", GetDescription("0 0 6 1/1 * ?"));
        }

        [Fact]
        public void TestMinutesPastTheHour()
        {
            Assert.ContainsCaseInsensitive("5분", GetDescription("0 5 0/1 * * ?"));
        }

        [Fact]
        public void TestOneYearOnlyWithSeconds()
        {
            Assert.ContainsCaseInsensitive("매초, 2013년에만", GetDescription("* * * * * * 2013"));
        }

        [Fact]
        public void TestOneYearOnlyWithoutSeconds()
        {
            Assert.ContainsCaseInsensitive("매분, 2013년에만", GetDescription("* * * * * 2013"));
        }

        [Fact]
        public void TestTwoYearsOnly()
        {
            Assert.ContainsCaseInsensitive("매분, 2013 및 2014년에만", GetDescription("* * * * * 2013,2014"));
        }

        [Fact]
        public void TestYearRange2()
        {
            Assert.ContainsCaseInsensitive("시간 12:23 오후, 1월~2월, 2013~2014", GetDescription("23 12 * JAN-FEB * 2013-2014"));
        }

        [Fact]
        public void TestYearRange3()
        {
            Assert.ContainsCaseInsensitive("시간 12:23 오후, 1월~3월, 2013~2015", GetDescription("23 12 * JAN-MAR * 2013-2015"));
        }

        [Fact]
        public void TestSecondsInternalWithStepValue()
        {
            // GitHub Issue #49: https://github.com/bradymholt/cron-expression-descriptor/issues/49
            Assert.ContainsCaseInsensitive("매 30초, 5초부터", GetDescription("5/30 * * * * ?"));
        }

        [Fact]
        public void TestMinutesInternalWithStepValue()
        {
            Assert.ContainsCaseInsensitive("매 30분, 5분부터", GetDescription("0 5/30 * * * ?"));
        }

        [Fact]
        public void TestHoursInternalWithStepValue()
        {
            Assert.ContainsCaseInsensitive("매초, 매 8시간, 05:00 오전부터", GetDescription("* * 5/8 * * ?"));
        }

        [Fact]
        public void TestDayOfMonthInternalWithStepValue()
        {
            Assert.ContainsCaseInsensitive("시간 07:05 오전, 3일마다, 매월 2일부터", GetDescription("0 5 7 2/3 * ? *"));
        }

        [Fact]
        public void TestMonthInternalWithStepValue()
        {
            Assert.ContainsCaseInsensitive("시간 07:05 오전, 2개월마다, 3월~12월", GetDescription("0 5 7 ? 3/2 ? *"));
        }

        [Fact]
        public void TestDayOfWeekInternalWithStepValue()
        {
            Assert.ContainsCaseInsensitive("시간 07:05 오전, 주 중 3일마다, 화요일~토요일", GetDescription("0 5 7 ? * 2/3 *"));
        }

        [Fact]
        public void TestYearInternalWithStepValue()
        {
            Assert.ContainsCaseInsensitive("시간 07:05 오전, 4년마다, 2016~9999", GetDescription("0 5 7 ? * ? 2016/4"));
        }
    }
}
