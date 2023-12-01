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
            Assert.EqualsCaseInsensitive("매분", GetDescription("* * * * *"));
        }

        [Fact]
        public void TestEvery1Minute()
        {
            Assert.EqualsCaseInsensitive("매분", GetDescription("*/1 * * * *"));
            Assert.EqualsCaseInsensitive("매분", GetDescription("0 0/1 * * * ?"));
        }

        [Fact]
        public void TestEveryHour()
        {
            Assert.EqualsCaseInsensitive("매시간", GetDescription("0 0 * * * ?"));
            Assert.EqualsCaseInsensitive("매시간", GetDescription("0 0 0/1 * * ?"));
        }

        [Fact]
        public void TestTimeOfDayCertainDaysOfWeek()
        {
            Assert.EqualsCaseInsensitive("시간 11:00 오후, 월요일~금요일", GetDescription("0 23 ? * MON-FRI"));
        }

        [Fact]
        public void TestEverySecond()
        {
            Assert.EqualsCaseInsensitive("매초", GetDescription("* * * * * *"));
        }

        [Fact]
        public void TestEvery45Seconds()
        {
            Assert.EqualsCaseInsensitive("매 45초", GetDescription("*/45 * * * * *"));
        }

        [Fact]
        public void TestEvery5Minutes()
        {
            Assert.EqualsCaseInsensitive("매 5분", GetDescription("*/5 * * * *"));
            Assert.EqualsCaseInsensitive("매 10분", GetDescription("0 0/10 * * * ?"));
        }

        [Fact]
        public void TestEvery5MinutesOnTheSecond()
        {
            Assert.EqualsCaseInsensitive("매 5분", GetDescription("0 */5 * * * *"));
        }

        [Fact]
        public void TestWeekdaysAtTime()
        {
            Assert.EqualsCaseInsensitive("시간 11:30 오전, 월요일~금요일", GetDescription("30 11 * * 1-5"));
        }

        [Fact]
        public void TestDailyAtTime()
        {
            Assert.EqualsCaseInsensitive("시간 11:30 오전", GetDescription("30 11 * * *"));
        }

        [Fact]
        public void TestMinuteSpan()
        {
            Assert.EqualsCaseInsensitive("11:00 오전~11:10 오전 사이 매분", GetDescription("0-10 11 * * *"));
        }

        [Fact]
        public void TestOneMonthOnly()
        {
            Assert.EqualsCaseInsensitive("매분, 3월에만", GetDescription("* * * 3 *"));
        }

        [Fact]
        public void TestTwoMonthsOnly()
        {
            Assert.EqualsCaseInsensitive("매분, 3월 및 6월에만", GetDescription("* * * 3,6 *"));
        }

        [Fact]
        public void TestTwoTimesEachAfternoon()
        {
            Assert.EqualsCaseInsensitive("시간 02:30 오후 및 04:30 오후", GetDescription("30 14,16 * * *"));
        }

        [Fact]
        public void TestThreeTimesDaily()
        {
            Assert.EqualsCaseInsensitive("시간 06:30 오전, 02:30 오후 및 04:30 오후", GetDescription("30 6,14,16 * * *"));
        }

        [Fact]
        public void TestOnceAWeek()
        {
            Assert.EqualsCaseInsensitive("시간 09:46 오전, 월요일에만", GetDescription("46 9 * * 1"));
        }

        [Fact]
        public void TestDayOfMonth()
        {
            Assert.EqualsCaseInsensitive("시간 12:23 오후, 월의 15일에", GetDescription("23 12 15 * *"));
        }

        [Fact]
        public void TestMonthName()
        {
            Assert.EqualsCaseInsensitive("시간 12:23 오후, 1월에만", GetDescription("23 12 * JAN *"));
        }


        [Fact]
        public void TestDayOfMonthWithQuestionMark()
        {
            Assert.EqualsCaseInsensitive("시간 12:23 오후, 1월에만", GetDescription("23 12 ? JAN *"));
        }

        [Fact]
        public void TestMonthNameRange2()
        {
            Assert.EqualsCaseInsensitive("시간 12:23 오후, 1월~2월", GetDescription("23 12 * JAN-FEB *"));
        }

        [Fact]
        public void TestMonthNameRange3()
        {
            Assert.EqualsCaseInsensitive("시간 12:23 오후, 1월~3월", GetDescription("23 12 * JAN-MAR *"));
        }

        [Fact]
        public void TestDayOfWeekName()
        {
            Assert.EqualsCaseInsensitive("시간 12:23 오후, 일요일에만", GetDescription("23 12 * * SUN"));
        }

        [Fact]
        public void TestDayOfWeekRange()
        {
            Assert.EqualsCaseInsensitive("매 5분, 03:00 오후~03:59 오후 사이, 월요일~금요일", GetDescription("*/5 15 * * MON-FRI"));
        }

        [Fact]
        public void TestDayOfWeekOnceInMonth()
        {
            Assert.EqualsCaseInsensitive("매분, 날짜 세 번째 월의 월요일", GetDescription("* * * * MON#3"));
        }

        [Fact]
        public void TestLastDayOfTheWeekOfTheMonth()
        {
            Assert.EqualsCaseInsensitive("매분, 월의 마지막 목요일", GetDescription("* * * * 4L"));
        }

        [Fact]
        public void TestLastDayOfTheMonth()
        {
            Assert.EqualsCaseInsensitive("매 5분, 월의 마지막 날에, 1월에만", GetDescription("*/5 * L JAN *"));
        }

        [Fact]
        public void TestLastWeekdayOfTheMonth()
        {
            Assert.EqualsCaseInsensitive("매분, 월의 마지막 평일에", GetDescription("* * LW * *"));
        }

        [Fact]
        public void TestLastWeekdayOfTheMonth2()
        {
            Assert.EqualsCaseInsensitive("매분, 월의 마지막 평일에", GetDescription("* * WL * *"));
        }

        [Fact]
        public void TestFirstWeekdayOfTheMonth()
        {
            Assert.EqualsCaseInsensitive("매분, 월의 첫 번째 평일에", GetDescription("* * 1W * *"));
        }

        [Fact]
        public void TestFirstWeekdayOfTheMonth2()
        {
            Assert.EqualsCaseInsensitive("매분, 월의 첫 번째 평일에", GetDescription("* * W1 * *"));
        }

        [Fact]
        public void TestParticularWeekdayOfTheMonth()
        {
            Assert.EqualsCaseInsensitive("매분, 월의 5일에 가장 가까운 평일에", GetDescription("* * 5W * *"));
        }

        [Fact]
        public void TestParticularWeekdayOfTheMonth2()
        {
            Assert.EqualsCaseInsensitive("매분, 월의 5일에 가장 가까운 평일에", GetDescription("* * W5 * *"));
        }

        [Fact]
        public void TestTimeOfDayWithSeconds()
        {
            Assert.EqualsCaseInsensitive("시간 02:02:30 오후", GetDescription("30 02 14 * * *"));
        }

        [Fact]
        public void TestSecondInternvals()
        {
            Assert.EqualsCaseInsensitive("분 이후 5~10초", GetDescription("5-10 * * * * *"));
        }

        [Fact]
        public void TestSecondMinutesHoursIntervals()
        {
            Assert.EqualsCaseInsensitive("분 이후 5~10초, 시간 이후 30~35분, 10:00 오전~12:59 오후 사이", GetDescription("5-10 30-35 10-12 * * *"));
        }

        [Fact]
        public void TestEvery5MinutesAt30Seconds()
        {
            Assert.EqualsCaseInsensitive("분 이후 30초, 매 5분", GetDescription("30 */5 * * * *"));
        }

        [Fact]
        public void TestMinutesPastTheHourRange()
        {
            Assert.EqualsCaseInsensitive("시간 이후 30분, 10:00 오전~01:59 오후 사이, 수요일 및 금요일에만", GetDescription("0 30 10-13 ? * WED,FRI"));
        }

        [Fact]
        public void TestSecondsPastTheMinuteInterval()
        {
            Assert.EqualsCaseInsensitive("분 이후 10초, 매 5분", GetDescription("10 0/5 * * * ?"));
        }

        [Fact]
        public void TestBetweenWithInterval()
        {
            Assert.EqualsCaseInsensitive("매 3분, 시간 이후 2~59분, 01:00 오전, 09:00 오전, 및 10:00 오후, 월의 11~26일 사이, 1월~6월", GetDescription("2-59/3 1,9,22 11-26 1-6 ?"));
        }

        [Fact]
        public void TestRecurringFirstOfMonth()
        {
            Assert.EqualsCaseInsensitive("시간 06:00 오전", GetDescription("0 0 6 1/1 * ?"));
        }

        [Fact]
        public void TestMinutesPastTheHour()
        {
            Assert.EqualsCaseInsensitive("시간 이후 5분", GetDescription("0 5 0/1 * * ?"));
        }

        [Fact]
        public void TestOneYearOnlyWithSeconds()
        {
            Assert.EqualsCaseInsensitive("매초, 2013년에만", GetDescription("* * * * * * 2013"));
        }

        [Fact]
        public void TestOneYearOnlyWithoutSeconds()
        {
            Assert.EqualsCaseInsensitive("매분, 2013년에만", GetDescription("* * * * * 2013"));
        }

        [Fact]
        public void TestTwoYearsOnly()
        {
            Assert.EqualsCaseInsensitive("매분, 2013 및 2014년에만", GetDescription("* * * * * 2013,2014"));
        }

        [Fact]
        public void TestYearRange2()
        {
            Assert.EqualsCaseInsensitive("시간 12:23 오후, 1월~2월, 2013~2014", GetDescription("23 12 * JAN-FEB * 2013-2014"));
        }

        [Fact]
        public void TestYearRange3()
        {
            Assert.EqualsCaseInsensitive("시간 12:23 오후, 1월~3월, 2013~2015", GetDescription("23 12 * JAN-MAR * 2013-2015"));
        }

        [Fact]
        public void TestSecondsInternalWithStepValue()
        {
            // GitHub Issue #49: https://github.com/bradymholt/cron-expression-descriptor/issues/49
            Assert.EqualsCaseInsensitive("매 30초, 분 이후 5초부터", GetDescription("5/30 * * * * ?"));
        }

        [Fact]
        public void TestMinutesInternalWithStepValue()
        {
            Assert.EqualsCaseInsensitive("매 30분, 시간 이후 5분부터", GetDescription("0 5/30 * * * ?"));
        }

        [Fact]
        public void TestHoursInternalWithStepValue()
        {
            Assert.EqualsCaseInsensitive("매초, 매 8시간, 05:00 오전부터", GetDescription("* * 5/8 * * ?"));
        }

        [Fact]
        public void TestDayOfMonthInternalWithStepValue()
        {
            Assert.EqualsCaseInsensitive("시간 07:05 오전, 3일마다, 월의 2일에부터", GetDescription("0 5 7 2/3 * ? *"));
        }

        [Fact]
        public void TestMonthInternalWithStepValue()
        {
            Assert.EqualsCaseInsensitive("시간 07:05 오전, 2개월마다, 3월~12월", GetDescription("0 5 7 ? 3/2 ? *"));
        }

        [Fact]
        public void TestDayOfWeekInternalWithStepValue()
        {
            Assert.EqualsCaseInsensitive("시간 07:05 오전, 주 중 3일마다, 화요일~토요일", GetDescription("0 5 7 ? * 2/3 *"));
        }

        [Fact]
        public void TestYearInternalWithStepValue()
        {
            Assert.EqualsCaseInsensitive("시간 07:05 오전, 4년마다, 2016~9999", GetDescription("0 5 7 ? * ? 2016/4"));
        }
    }
}
