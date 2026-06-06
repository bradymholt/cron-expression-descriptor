using Xunit;
using Assert = CronExpressionDescriptor.Test.Support.AssertExtensions;

namespace CronExpressionDescriptor.Test
{
  /// <summary>
  /// Tests for Kyrgyz translation
  /// </summary>
  public class TestFormatsKY : Support.BaseTestFormats
  {
    protected override string GetLocale()
    {
      return "ky-KG";
    }

    [Fact]
    public void TestEveryMinute()
    {
      Assert.EqualsCaseInsensitive("Ар бир мүнөт сайын", GetDescription("* * * * *"));
    }

    [Fact]
    public void TestEvery1Minute()
    {
      Assert.EqualsCaseInsensitive("Ар бир мүнөт сайын", GetDescription("*/1 * * * *"));
      Assert.EqualsCaseInsensitive("Ар бир мүнөт сайын", GetDescription("0 0/1 * * * ?"));
    }

    [Fact]
    public void TestEveryHour()
    {
      Assert.EqualsCaseInsensitive("Ар саат сайын", GetDescription("0 0 * * * ?"));
      Assert.EqualsCaseInsensitive("Ар саат сайын", GetDescription("0 0 0/1 * * ?"));
    }

    [Fact]
    public void TestTimeOfDayCertainDaysOfWeek()
    {
      Assert.EqualsCaseInsensitive("Саат 23:00, дүйшөмбү-жума", GetDescription("0 23 ? * MON-FRI"));
    }

    [Fact]
    public void TestEverySecond()
    {
      Assert.EqualsCaseInsensitive("Ар бир секунд сайын", GetDescription("* * * * * *"));
    }

    [Fact]
    public void TestEvery45Seconds()
    {
      Assert.EqualsCaseInsensitive("Ар бир 45 секунд сайын", GetDescription("*/45 * * * * *"));
    }

    [Fact]
    public void TestEvery5Minutes()
    {
      Assert.EqualsCaseInsensitive("Ар бир 5 мүнөт сайын", GetDescription("*/5 * * * *"));
      Assert.EqualsCaseInsensitive("Ар бир 10 мүнөт сайын", GetDescription("0 0/10 * * * ?"));
    }

    [Fact]
    public void TestEvery5MinutesOnTheSecond()
    {
      Assert.EqualsCaseInsensitive("Ар бир 5 мүнөт сайын", GetDescription("0 */5 * * * *"));
    }

    [Fact]
    public void TestWeekdaysAtTime()
    {
      Assert.EqualsCaseInsensitive("Саат 11:30, дүйшөмбү-жума", GetDescription("30 11 * * 1-5"));
    }

    [Fact]
    public void TestDailyAtTime()
    {
      Assert.EqualsCaseInsensitive("Саат 11:30", GetDescription("30 11 * * *"));
    }

    [Fact]
    public void TestMinuteSpan()
    {
      Assert.EqualsCaseInsensitive("11:00 жана 11:10 аралыгында ар бир мүнөт сайын", GetDescription("0-10 11 * * *"));
    }

    [Fact]
    public void TestOneMonthOnly()
    {
      Assert.EqualsCaseInsensitive("Ар бир мүнөт сайын, бир гана Март ичинде", GetDescription("* * * 3 *"));
    }

    [Fact]
    public void TestTwoMonthsOnly()
    {
      Assert.EqualsCaseInsensitive("Ар бир мүнөт сайын, бир гана Март жана Июнь ичинде", GetDescription("* * * 3,6 *"));
    }

    [Fact]
    public void TestTwoTimesEachAfternoon()
    {
      Assert.EqualsCaseInsensitive("Саат 14:30 жана 16:30", GetDescription("30 14,16 * * *"));
    }

    [Fact]
    public void TestThreeTimesDaily()
    {
      Assert.EqualsCaseInsensitive("Саат 06:30, 14:30 жана 16:30", GetDescription("30 6,14,16 * * *"));
    }

    [Fact]
    public void TestOnceAWeek()
    {
      Assert.EqualsCaseInsensitive("Саат 09:46, бир гана дүйшөмбү күндөрү", GetDescription("46 9 * * 1"));
    }

    [Fact]
    public void TestDayOfMonth()
    {
      Assert.EqualsCaseInsensitive("Саат 12:23, айдын 15-күнүндө", GetDescription("23 12 15 * *"));
    }

    [Fact]
    public void TestMonthName()
    {
      Assert.EqualsCaseInsensitive("Саат 12:23, бир гана Январь ичинде", GetDescription("23 12 * JAN *"));
    }

    [Fact]
    public void TestDayOfMonthWithQuestionMark()
    {
      Assert.EqualsCaseInsensitive("Саат 12:23, бир гана Январь ичинде", GetDescription("23 12 ? JAN *"));
    }

    [Fact]
    public void TestMonthNameRange2()
    {
      Assert.EqualsCaseInsensitive("Саат 12:23, Январь-Февраль", GetDescription("23 12 * JAN-FEB *"));
    }

    [Fact]
    public void TestMonthNameRange3()
    {
      Assert.EqualsCaseInsensitive("Саат 12:23, Январь-Март", GetDescription("23 12 * JAN-MAR *"));
    }

    [Fact]
    public void TestDayOfWeekName()
    {
      Assert.EqualsCaseInsensitive("Саат 12:23, бир гана жекшемби күндөрү", GetDescription("23 12 * * SUN"));
    }

    [Fact]
    public void TestDayOfWeekRange()
    {
      Assert.EqualsCaseInsensitive("Ар бир 5 мүнөт сайын, 15:00 жана 15:59 аралыгында, дүйшөмбү-жума", GetDescription("*/5 15 * * MON-FRI"));
    }

    [Fact]
    public void TestDayOfWeekOnceInMonth()
    {
      Assert.EqualsCaseInsensitive("Ар бир мүнөт сайын, ушул убакта: үчүнчү айдын дүйшөмбү", GetDescription("* * * * MON#3"));
    }

    [Fact]
    public void TestLastDayOfTheWeekOfTheMonth()
    {
      Assert.EqualsCaseInsensitive("Ар бир мүнөт сайын, айдын акыркы бейшемби күнүндө", GetDescription("* * * * 4L"));
    }

    [Fact]
    public void TestLastDayOfTheMonth()
    {
      Assert.EqualsCaseInsensitive("Ар бир 5 мүнөт сайын, айдын акыркы күнүндө, бир гана Январь ичинде", GetDescription("*/5 * L JAN *"));
    }

    [Fact]
    public void TestLastWeekdayOfTheMonth()
    {
      Assert.EqualsCaseInsensitive("Ар бир мүнөт сайын, айдын акыркы иш күнүндө", GetDescription("* * LW * *"));
    }

    [Fact]
    public void TestLastWeekdayOfTheMonth2()
    {
      Assert.EqualsCaseInsensitive("Ар бир мүнөт сайын, айдын акыркы иш күнүндө", GetDescription("* * WL * *"));
    }

    [Fact]
    public void TestFirstWeekdayOfTheMonth()
    {
      Assert.EqualsCaseInsensitive("Ар бир мүнөт сайын, айдын биринчи иш күнү күнүндө", GetDescription("* * 1W * *"));
    }

    [Fact]
    public void TestFirstWeekdayOfTheMonth2()
    {
      Assert.EqualsCaseInsensitive("Ар бир мүнөт сайын, айдын биринчи иш күнү күнүндө", GetDescription("* * W1 * *"));
    }

    [Fact]
    public void TestParticularWeekdayOfTheMonth()
    {
      Assert.EqualsCaseInsensitive("Ар бир мүнөт сайын, айдын 5-күнгө эң жакын иш күнү күнүндө", GetDescription("* * 5W * *"));
    }

    [Fact]
    public void TestParticularWeekdayOfTheMonth2()
    {
      Assert.EqualsCaseInsensitive("Ар бир мүнөт сайын, айдын 5-күнгө эң жакын иш күнү күнүндө", GetDescription("* * W5 * *"));
    }

    [Fact]
    public void TestTimeOfDayWithSeconds()
    {
      Assert.EqualsCaseInsensitive("Саат 14:02:30", GetDescription("30 02 14 * * *"));
    }

    [Fact]
    public void TestSecondInternvals()
    {
      Assert.EqualsCaseInsensitive("Мүнөттүн 5-10 секунддарында", GetDescription("5-10 * * * * *"));
    }

    [Fact]
    public void TestSecondMinutesHoursIntervals()
    {
      Assert.EqualsCaseInsensitive("Мүнөттүн 5-10 секунддарында, сааттын 30-35 мүнөттөрүндө, 10:00 жана 12:59 аралыгында", GetDescription("5-10 30-35 10-12 * * *"));
    }

    [Fact]
    public void TestEvery5MinutesAt30Seconds()
    {
      Assert.EqualsCaseInsensitive("Мүнөттүн 30-секундунда, ар бир 5 мүнөт сайын", GetDescription("30 */5 * * * *"));
    }

    [Fact]
    public void TestMinutesPastTheHourRange()
    {
      Assert.EqualsCaseInsensitive("Сааттын 30-мүнөтүндө, 10:00 жана 13:59 аралыгында, бир гана шаршемби жана жума күндөрү", GetDescription("0 30 10-13 ? * WED,FRI"));
    }

    [Fact]
    public void TestSecondsPastTheMinuteInterval()
    {
      Assert.EqualsCaseInsensitive("Мүнөттүн 10-секундунда, ар бир 5 мүнөт сайын", GetDescription("10 0/5 * * * ?"));
    }

    [Fact]
    public void TestBetweenWithInterval()
    {
      Assert.EqualsCaseInsensitive("Ар бир 3 мүнөт сайын, сааттын 2-59 мүнөттөрүндө, саат 01:00, 09:00, жана 22:00 өзүндө, айдын 11 жана 26 күндөрүнүн аралыгында, Январь-Июнь", GetDescription("2-59/3 1,9,22 11-26 1-6 ?"));
    }

    [Fact]
    public void TestRecurringFirstOfMonth()
    {
      Assert.EqualsCaseInsensitive("Саат 06:00", GetDescription("0 0 6 1/1 * ?"));
    }

    [Fact]
    public void TestMinutesPastTheHour()
    {
      Assert.EqualsCaseInsensitive("Сааттын 5-мүнөтүндө", GetDescription("0 5 0/1 * * ?"));
    }

    [Fact]
    public void TestOneYearOnlyWithSeconds()
    {
      Assert.EqualsCaseInsensitive("Ар бир секунд сайын, бир гана 2013-жылы", GetDescription("* * * * * * 2013"));
    }

    [Fact]
    public void TestOneYearOnlyWithoutSeconds()
    {
      Assert.EqualsCaseInsensitive("Ар бир мүнөт сайын, бир гана 2013-жылы", GetDescription("* * * * * 2013"));
    }

    [Fact]
    public void TestTwoYearsOnly()
    {
      Assert.EqualsCaseInsensitive("Ар бир мүнөт сайын, бир гана 2013 жана 2014-жылы", GetDescription("* * * * * 2013,2014"));
    }

    [Fact]
    public void TestYearRange2()
    {
      Assert.EqualsCaseInsensitive("Саат 12:23, Январь-Февраль, 2013-2014", GetDescription("23 12 * JAN-FEB * 2013-2014"));
    }

    [Fact]
    public void TestYearRange3()
    {
      Assert.EqualsCaseInsensitive("Саат 12:23, Январь-Март, 2013-2015", GetDescription("23 12 * JAN-MAR * 2013-2015"));
    }

    [Fact]
    public void TestHourRange()
    {
      Assert.EqualsCaseInsensitive("Ар бир 30 мүнөт сайын, 08:00 жана 09:59 аралыгында, айдын 5 жана 20-күнүндө", GetDescription("0 0/30 8-9 5,20 * ?"));
    }

    [Fact]
    public void TestDayOfWeekModifier()
    {
      Assert.EqualsCaseInsensitive("Саат 12:23, ушул убакта: экинчи айдын жекшемби", GetDescription("23 12 * * SUN#2"));
    }

    [Fact]
    public void TestDayOfWeekModifierWithSundayStartOne()
    {
      Options options = new Options();
      options.DayOfWeekStartIndexZero = false;

      Assert.EqualsCaseInsensitive("Саат 12:23, ушул убакта: экинчи айдын жекшемби", GetDescription("23 12 * * 1#2", options));
    }

    [Fact]
    public void TestHourRangeWithEveryPortion()
    {
      Assert.EqualsCaseInsensitive("Сааттын 25-мүнөтүндө, ар бир 13 саат сайын, 07:00 жана 19:59 аралыгында", GetDescription("0 25 7-19/13 ? * *"));
    }

    [Fact]
    public void TestHourRangeWithTrailingZeroWithEveryPortion()
    {
      Assert.EqualsCaseInsensitive("Сааттын 25-мүнөтүндө, ар бир 13 саат сайын, 07:00 жана 20:59 аралыгында", GetDescription("0 25 7-20/13 ? * *"));
    }

    [Fact]
    public void TestSecondsInternalWithStepValue()
    {
      // GitHub Issue #49: https://github.com/bradymholt/cron-expression-descriptor/issues/49
      Assert.EqualsCaseInsensitive("Ар бир 30 секунд сайын, мүнөттүн 5-секундунда баштап", GetDescription("5/30 * * * * ?"));
    }

    [Fact]
    public void TestMinutesInternalWithStepValue()
    {
      Assert.EqualsCaseInsensitive("Ар бир 30 мүнөт сайын, сааттын 5-мүнөтүндө баштап", GetDescription("0 5/30 * * * ?"));
    }

    [Fact]
    public void TestHoursInternalWithStepValue()
    {
      Assert.EqualsCaseInsensitive("Ар бир секунд сайын, ар бир 8 саат сайын, саат 05:00 өзүндө баштап", GetDescription("* * 5/8 * * ?"));
    }

    [Fact]
    public void TestDayOfMonthInternalWithStepValue()
    {
      Assert.EqualsCaseInsensitive("Саат 07:05, ар бир 3 күн сайын, айдын 2-күнүндө баштап", GetDescription("0 5 7 2/3 * ? *"));
    }

    [Fact]
    public void TestMonthInternalWithStepValue()
    {
      Assert.EqualsCaseInsensitive("Саат 07:05, ар бир 2 ай сайын, Март-Декабрь", GetDescription("0 5 7 ? 3/2 ? *"));
    }

    [Fact]
    public void TestDayOfWeekInternalWithStepValue()
    {
      Assert.EqualsCaseInsensitive("Саат 07:05, аптанын ар бир 3 күнү сайын, шейшемби-ишемби", GetDescription("0 5 7 ? * 2/3 *"));
    }

    [Fact]
    public void TestYearInternalWithStepValue()
    {
      Assert.EqualsCaseInsensitive("Саат 07:05, ар бир 4 жыл сайын, 2016-9999", GetDescription("0 5 7 ? * ? 2016/4"));
    }
  }
}
