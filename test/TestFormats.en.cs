using Xunit;
using Assert = CronExpressionDescriptor.Test.Support.AssertExtensions;

namespace CronExpressionDescriptor.Test
{
  /// <summary>
  /// Tests for English
  /// </summary>
  public class TestFormatsEn : Support.BaseTestFormats
  {
    protected override string GetLocale()
    {
      return "en-US";
    }

    [Fact]
    public void TestEveryMinute()
    {
      Assert.Equal("Every minute", GetDescription("* * * * *"));
    }

    [Fact]
    public void TestEvery1Minute()
    {
      Assert.Equal("Every minute", GetDescription("*/1 * * * *"));
      Assert.Equal("Every minute", GetDescription("0 0/1 * * * ?"));
    }

    [Fact]
    public void TestEveryHour()
    {
      Assert.Equal("Every hour", GetDescription("0 0 * * * ?"));
      Assert.Equal("Every hour", GetDescription("0 0 0/1 * * ?"));
    }

    [Fact]
    public void TestTimeOfDayCertainDaysOfWeek()
    {
      Assert.Equal("At 11:00 PM, Monday through Friday", GetDescription("0 23 ? * MON-FRI"));
    }

    [Fact]
    public void TestEverySecond()
    {
      Assert.Equal("Every second", GetDescription("* * * * * *"));
    }

    [Fact]
    public void TestEvery45Seconds()
    {
      Assert.Equal("Every 45 seconds", GetDescription("*/45 * * * * *"));
    }

    [Fact]
    public void TestEvery5Minutes()
    {
      Assert.Equal("Every 5 minutes", GetDescription("*/5 * * * *"));
      Assert.Equal("Every 10 minutes", GetDescription("0 0/10 * * * ?"));
    }

    [Fact]
    public void TestEvery5MinutesOnTheSecond()
    {
      Assert.Equal("Every 5 minutes", GetDescription("0 */5 * * * *"));
    }

    [Fact]
    public void TestWeekdaysAtTime()
    {
      Assert.Equal("At 11:30 AM, Monday through Friday", GetDescription("30 11 * * 1-5"));
    }

    [Fact]
    public void TestDailyAtTime()
    {
      Assert.Equal("At 11:30 AM", GetDescription("30 11 * * *"));
    }

    [Fact]
    public void TestMinuteSpan()
    {
      Assert.Equal("Every minute between 11:00 AM and 11:10 AM", GetDescription("0-10 11 * * *"));
    }

    [Fact]
    public void TestOneMonthOnly()
    {
      Assert.Equal("Every minute, only in March", GetDescription("* * * 3 *"));
    }

    [Fact]
    public void TestTwoMonthsOnly()
    {
      Assert.Equal("Every minute, only in March and June", GetDescription("* * * 3,6 *"));
    }

    [Fact]
    public void TestTwoTimesEachAfternoon()
    {
      Assert.Equal("At 02:30 PM and 04:30 PM", GetDescription("30 14,16 * * *"));
    }

    [Fact]
    public void TestThreeTimesDaily()
    {
      Assert.Equal("At 06:30 AM, 02:30 PM and 04:30 PM", GetDescription("30 6,14,16 * * *"));
    }

    [Fact]
    public void TestOnceAWeek()
    {
      Assert.Equal("At 09:46 AM, only on Monday", GetDescription("46 9 * * 1"));
    }

    [Fact]
    public void TestDayOfMonth()
    {
      Assert.Equal("At 12:23 PM, on day 15 of the month", GetDescription("23 12 15 * *"));
    }

    [Fact]
    public void TestMonthName()
    {
      Assert.Equal("At 12:23 PM, only in January", GetDescription("23 12 * JAN *"));
    }

    [Fact]
    public void TestLowerCaseMonthName()
    {
      Assert.Equal("At 12:23 PM, only in January", GetDescription("23 12 * jan *"));
    }

    [Fact]
    public void TestDayOfMonthWithQuestionMark()
    {
      Assert.Equal("At 12:23 PM, only in January", GetDescription("23 12 ? JAN *"));
    }

    [Fact]
    public void TestMonthNameRange2()
    {
      Assert.Equal("At 12:23 PM, January through February", GetDescription("23 12 * JAN-FEB *"));
    }

    [Fact]
    public void TestMonthNameRange3()
    {
      Assert.Equal("At 12:23 PM, January through March", GetDescription("23 12 * JAN-MAR *"));
    }

    [Fact]
    public void TestDayOfWeekName()
    {
      Assert.Equal("At 12:23 PM, only on Sunday", GetDescription("23 12 * * SUN"));
    }

    [Fact]
    public void TestDayOfWeekRange()
    {
      Assert.Equal("Every 5 minutes, between 03:00 PM and 03:59 PM, Monday through Friday", GetDescription("*/5 15 * * MON-FRI"));
    }

    [Fact]
    public void TestDayOfWeekRangeWithDOWLowerCased()
    {
      Assert.Equal("Every 5 minutes, between 03:00 PM and 03:59 PM, Monday through Friday", GetDescription("*/5 15 * * MoN-fri"));
    }

    [Fact]
    public void TestDayOfWeekOnceInMonth()
    {
      Assert.Equal("Every minute, on the third Monday of the month", GetDescription("* * * * MON#3"));
    }

    [Fact]
    public void TestLastDayOfTheWeekOfTheMonth()
    {
      Assert.Equal("Every minute, on the last Thursday of the month", GetDescription("* * * * 4L"));
    }

    [Fact]
    public void TestLastDayOfTheMonth()
    {
      Assert.Equal("Every 5 minutes, on the last day of the month, only in January", GetDescription("*/5 * L JAN *"));
    }

    [Fact]
    public void TestLastDayOffset()
    {
      Assert.Equal("At 12:00 AM, 5 days before the last day of the month", GetDescription("0 0 0 L-5 * ?"));
    }

    [Fact]
    public void TestLastWeekdayOfTheMonth()
    {
      Assert.Equal("Every minute, on the last weekday of the month", GetDescription("* * LW * *"));
    }

    [Fact]
    public void TestLastWeekdayOfTheMonth2()
    {
      Assert.Equal("Every minute, on the last weekday of the month", GetDescription("* * WL * *"));
    }

    [Fact]
    public void TestFirstWeekdayOfTheMonth()
    {
      Assert.Equal("Every minute, on the first weekday of the month", GetDescription("* * 1W * *"));
    }

    [Fact]
    public void TestThirteenthWeekdayOfTheMonth()
    {
      Assert.Equal("Every minute, on the weekday nearest day 13 of the month", GetDescription("* * 13W * *"));
    }

    [Fact]
    public void TestFirstWeekdayOfTheMonth2()
    {
      Assert.Equal("Every minute, on the first weekday of the month", GetDescription("* * W1 * *"));
    }

    [Fact]
    public void TestParticularWeekdayOfTheMonth()
    {
      Assert.Equal("Every minute, on the weekday nearest day 5 of the month", GetDescription("* * 5W * *"));
    }

    [Fact]
    public void TestParticularWeekdayOfTheMonth2()
    {
      Assert.Equal("Every minute, on the weekday nearest day 5 of the month", GetDescription("* * W5 * *"));
    }

    [Fact]
    public void TestTimeOfDayWithSeconds()
    {
      Assert.Equal("At 02:02:30 PM", GetDescription("30 02 14 * * *"));
    }

    [Fact]
    public void TestSecondInternvals()
    {
      Assert.Equal("Seconds 5 through 10 past the minute", GetDescription("5-10 * * * * *"));
    }

    [Fact]
    public void TestMultiPartSecond()
    {
      Assert.Equal("At 15 and 45 seconds past the minute", GetDescription("15,45 * * * * *"));
    }

    [Fact]
    public void TestSecondMinutesHoursIntervals()
    {
      Assert.Equal("Seconds 5 through 10 past the minute, minutes 30 through 35 past the hour, between 10:00 AM and 12:59 PM", GetDescription("5-10 30-35 10-12 * * *"));
    }

    [Fact]
    public void TestEvery5MinutesAt30Seconds()
    {
      Assert.Equal("At 30 seconds past the minute, every 5 minutes", GetDescription("30 */5 * * * *"));
    }

    [Fact]
    public void TestMinutesPastTheHourRange()
    {
      Assert.Equal("At 30 minutes past the hour, between 10:00 AM and 01:59 PM, only on Wednesday and Friday", GetDescription("0 30 10-13 ? * WED,FRI"));
    }

    [Fact]
    public void TestSecondsPastTheMinuteInterval()
    {
      Assert.Equal("At 10 seconds past the minute, every 5 minutes", GetDescription("10 0/5 * * * ?"));
    }

    [Fact]
    public void TestBetweenWithInterval()
    {
      Assert.Equal("Every 3 minutes, minutes 2 through 59 past the hour, at 01:00 AM, 09:00 AM, and 10:00 PM, between day 11 and 26 of the month, January through June", GetDescription("2-59/3 1,9,22 11-26 1-6 ?"));
    }

    [Fact]
    public void TestRecurringFirstOfMonth()
    {
      Assert.Equal("At 06:00 AM", GetDescription("0 0 6 1/1 * ?"));
    }

    [Fact]
    public void TestMinutesPastTheHour()
    {
      Assert.Equal("At 5 minutes past the hour", GetDescription("0 5 0/1 * * ?"));
    }

    [Fact]
    public void TestOneYearOnlyWithSeconds()
    {
      Assert.Equal("Every second, only in 2013", GetDescription("* * * * * * 2013"));
    }

    [Fact]
    public void TestOneYearOnlyWithoutSeconds()
    {
      Assert.Equal("Every minute, only in 2013", GetDescription("* * * * * 2013"));
    }

    [Fact]
    public void TestTwoYearsOnly()
    {
      Assert.Equal("Every minute, only in 2013 and 2014", GetDescription("* * * * * 2013,2014"));
    }

    [Fact]
    public void TestYearRange2()
    {
      Assert.Equal("At 12:23 PM, January through February, 2013 through 2014", GetDescription("23 12 * JAN-FEB * 2013-2014"));
    }

    [Fact]
    public void TestYearRange3()
    {
      Assert.Equal("At 12:23 PM, January through March, 2013 through 2015", GetDescription("23 12 * JAN-MAR * 2013-2015"));
    }

    [Fact]
    public void TestHourRange()
    {
      Assert.Equal("Every 30 minutes, between 08:00 AM and 09:59 AM, on day 5 and 20 of the month", GetDescription("0 0/30 8-9 5,20 * ?"));
    }

    [Fact]
    public void TestDayOfWeekModifier()
    {
      Assert.Equal("At 12:23 PM, on the second Sunday of the month", GetDescription("23 12 * * SUN#2"));
    }

    [Fact]
    public void TestDayOfWeekModifierWithSundayStartOne()
    {
      Options options = new Options();
      options.DayOfWeekStartIndexZero = false;

      Assert.Equal("At 12:23 PM, on the second Sunday of the month", GetDescription("23 12 * * 1#2", options));
    }

    [Fact]
    public void TestHourRangeWithEveryPortion()
    {
      Assert.Equal("At 25 minutes past the hour, every 8 hours, between 07:00 AM and 07:59 PM", GetDescription("0 25 7-19/8 ? * *"));
    }

    [Fact]
    public void TestHourRangeWithTrailingZeroWithEveryPortion()
    {
      Assert.Equal("At 25 minutes past the hour, every 13 hours, between 07:00 AM and 08:59 PM", GetDescription("0 25 7-20/13 ? * *"));
    }

    [Fact]
    public void TestEvery3Day()
    {
      Assert.Equal("At 08:00 AM, every 3 days", GetDescription("0 0 8 1/3 * ? *"));
    }

    [Fact]
    public void TestsEvery3DayOfTheWeek()
    {
      Assert.Equal("At 10:15 AM, every 3 days of the week", GetDescription("0 15 10 ? * */3"));
    }

    [Fact]
    public void TestEvery2DayOfTheWeekInRange()
    {
      // GitHub Issue #58: https://github.com/bradymholt/cron-expression-descriptor/issues/58
      Assert.Equal("Every second, every 2 days of the week, Monday through Friday", GetDescription("* * * ? * 1-5/2"));
    }

    [Fact]
    public void TestEvery2DayOfTheWeekInRangeWithSundayStartOne()
    {
      // GitHub Issue #59: https://github.com/bradymholt/cron-expression-descriptor/issues/59

      var options = new Options { DayOfWeekStartIndexZero = false };

      Assert.Equal("Every second, every 2 days of the week, Monday through Friday",
          GetDescription("* * * ? * 2-6/2", options));
    }

    [Fact]
    public void TestMultiWithDayOfWeekStartIndexZeroFalse()
    {
      // Coverage for GitHub Issue #126: https://github.com/bradymholt/cron-expression-descriptor/issues/126
      var options = new Options { DayOfWeekStartIndexZero = false };

      Assert.Equal("Every second, only on Sunday, Monday, and Tuesday",
          GetDescription("* * * ? * 1,2,3", options));
    }

    [Fact]
    public void TestEvery3Month()
    {
      Assert.Equal("At 07:05 AM, on day 2 of the month, every 3 months", GetDescription("0 5 7 2 1/3 ? *"));
    }

    [Fact]
    public void TestEvery2Years()
    {
      Assert.Equal("At 06:15 AM, on day 1 of the month, only in January, every 2 years", GetDescription("0 15 6 1 1 ? 1/2"));
    }

    [Fact]
    public void TestMutiPartRangeMinutes()
    {
      Assert.Equal("At 2 and 4 through 5 minutes past the hour, at 01:00 AM", GetDescription("2,4-5 1 * * *"));
    }

    [Fact]
    public void TestMutiPartRangeMinutes2()
    {
      Assert.Equal("At 2 and 26 through 28 minutes past the hour, at 06:00 PM", GetDescription("2,26-28 18 * * *"));
    }

    [Fact]
    public void TrailingSpaceDoesNotCauseAWrongDescription()
    {
      // GitHub Issue #51: https://github.com/bradymholt/cron-expression-descriptor/issues/51
      Assert.Equal("At 07:00 AM", GetDescription("0 7 * * * "));
    }

    [Fact]
    public void TestMultiPartDayOfTheWeek()
    {
      // GitHub Issue #44: https://github.com/bradymholt/cron-expression-descriptor/issues/44
      Assert.Equal("At 10:00 AM, only on Monday through Thursday and Sunday", GetDescription("0 00 10 ? * MON-THU,SUN *"));
    }

    [Fact]
    public void TestDayOfWeekWithDayOfMonth()
    {
      // GitHub Issue #46: https://github.com/bradymholt/cron-expression-descriptor/issues/46
      Assert.Equal("At 12:00 AM, on day 1, 2, and 3 of the month, only on Wednesday and Friday", GetDescription("0 0 0 1,2,3 * WED,FRI"));
    }

    [Fact]
    public void TestSecondsInternalWithStepValue()
    {
      // GitHub Issue #49: https://github.com/bradymholt/cron-expression-descriptor/issues/49
      Assert.Equal("Every 30 seconds, starting at 5 seconds past the minute", GetDescription("5/30 * * * * ?"));
    }

    [Fact]
    public void TestMinutesInternalWithStepValue()
    {
      Assert.Equal("Every 30 minutes, starting at 5 minutes past the hour", GetDescription("0 5/30 * * * ?"));
    }

    [Fact]
    public void TestHoursInternalWithStepValue()
    {
      Assert.Equal("Every second, every 8 hours, starting at 05:00 AM", GetDescription("* * 5/8 * * ?"));
    }

    [Fact]
    public void TestDayOfMonthInternalWithStepValue()
    {
      Assert.Equal("At 07:05 AM, every 3 days, starting on day 2 of the month", GetDescription("0 5 7 2/3 * ? *"));
    }

    [Fact]
    public void TestMonthInternalWithStepValue()
    {
      Assert.Equal("At 07:05 AM, every 2 months, March through December", GetDescription("0 5 7 ? 3/2 ? *"));
    }

    [Fact]
    public void TestDayOfWeekInternalWithStepValue()
    {
      Assert.Equal("At 07:05 AM, every 3 days of the week, Tuesday through Saturday", GetDescription("0 5 7 ? * 2/3 *"));
    }

    [Fact]
    public void TestYearInternalWithStepValue()
    {
      Assert.Equal("At 07:05 AM, every 4 years, 2016 through 9999", GetDescription("0 5 7 ? * ? 2016/4"));
    }

    [Fact]
    public void TestMinutesCombinedWithMultipleHourRanges()
    {
      Assert.Equal("At 1 minutes past the hour, at 01:00 AM and 03:00 AM through 04:59 AM", GetDescription("1 1,3-4 * * *"));
    }

    [Fact]
    public void TestMinuteRangeConbinedWithSecondRange()
    {
      Assert.Equal("Seconds 12 through 50 past the minute, minutes 0 through 10 past the hour, at 06:00 AM, only in 2022", GetDescription("12-50 0-10 6 * * * 2022"));
    }

    [Fact]
    public void TestSecondsExpressionCombinedWithHoursListAndSingleMinute()
    {
      Assert.Equal("At 5 seconds past the minute, at 30 minutes past the hour, at 06:00 AM, 02:00 PM, and 04:00 PM, on day 5 of the month", GetDescription("5 30 6,14,16 5 * *"));
    }

    [Fact]
    public void TestMinuteRangeWithInterval()
    {
      Assert.Equal("Every 3 minutes, minutes 0 through 20 past the hour, between 09:00 AM and 09:59 AM", GetDescription("0-20/3 9 * * *"));
    }

    [Fact]
    public void MinutesZero1()
    {
      Assert.Equal("Every second, at 0 minutes past the hour, every 4 hours", GetDescription("* 0 */4 * * *"));
    }

    [Fact]
    public void MinutesZero2()
    {
      Assert.Equal("Every 10 seconds, at 0 minutes past the hour", GetDescription("*/10 0 * * * *"));
    }

    [Fact]
    public void MinutesZero3()
    {
      Assert.Equal("Every second, at 0 minutes past the hour, between 12:00 AM and 12:59 AM", GetDescription("* 0 0 * * *"));
    }

    [Fact]
    public void MinutesZero4()
    {
      Assert.Equal("Every minute, between 12:00 AM and 12:59 AM", GetDescription("* 0 * * *"));
    }

    [Fact]
    public void MinutesZero5()
    {
      Assert.Equal("Every second, at 0 minutes past the hour", GetDescription("* 0 * * * *"));
    }

    [Fact]
    public void Sunday7()
    {
      Assert.Equal("At 09:00 AM, only on Sunday", GetDescription("0 0 9 ? * 7"));
    }

    [Fact]
    public void Tuesday9()
    {
      Assert.Equal("At 09:00 AM, only on Tuesday", GetDescription("0 9 * * 2"));
    }

    [Fact]
    public void EveryYear()
    {
      Assert.Equal("Every 10 minutes, Monday through Friday", GetDescription("0/10 * ? * MON-FRI *"));
    }
  }
}
