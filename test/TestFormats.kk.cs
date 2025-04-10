using Xunit;
using Assert = CronExpressionDescriptor.Test.Support.AssertExtensions;

namespace CronExpressionDescriptor.Test
{
  /// <summary>
  /// Tests for Kazakh translation
  /// </summary>
  public class TestFormatsKK : Support.BaseTestFormats
  {
    protected override string GetLocale()
    {
      return "kk-KZ";
    }

    [Fact]
    public void TestEveryMinute()
    {
      Assert.EqualsCaseInsensitive("Әрбір минут сайын", GetDescription("* * * * *"));
    }

    [Fact]
    public void TestEvery1Minute()
    {
      Assert.EqualsCaseInsensitive("Әрбір минут сайын", GetDescription("*/1 * * * *"));
      Assert.EqualsCaseInsensitive("Әрбір минут сайын", GetDescription("0 0/1 * * * ?"));
    }

    [Fact]
    public void TestEveryHour()
    {
      Assert.EqualsCaseInsensitive("Әрбір сағат сайын", GetDescription("0 0 * * * ?"));
      Assert.EqualsCaseInsensitive("Әрбір сағат сайын", GetDescription("0 0 0/1 * * ?"));
    }

    [Fact]
    public void TestTimeOfDayCertainDaysOfWeek()
    {
      Assert.EqualsCaseInsensitive("Сағат 11:00, дүйсенбі-жұма", GetDescription("0 23 ? * MON-FRI"));
    }

    [Fact]
    public void TestEverySecond()
    {
      Assert.EqualsCaseInsensitive("Әрбір секунд сайын", GetDescription("* * * * * *"));
    }

    [Fact]
    public void TestEvery45Seconds()
    {
      Assert.EqualsCaseInsensitive("Әрбір 45 секунд", GetDescription("*/45 * * * * *"));
    }

    [Fact]
    public void TestEvery5Minutes()
    {
      Assert.EqualsCaseInsensitive("Әрбір 5 минут", GetDescription("*/5 * * * *"));
      Assert.EqualsCaseInsensitive("Әрбір 10 минут", GetDescription("0 0/10 * * * ?"));
    }

    [Fact]
    public void TestEvery5MinutesOnTheSecond()
    {
      Assert.EqualsCaseInsensitive("Әрбір 5 минут", GetDescription("0 */5 * * * *"));
    }

    [Fact]
    public void TestWeekdaysAtTime()
    {
      Assert.EqualsCaseInsensitive("Сағат 11:30, дүйсенбі-жұма", GetDescription("30 11 * * 1-5"));
    }

    [Fact]
    public void TestDailyAtTime()
    {
      Assert.EqualsCaseInsensitive("Сағат 11:30", GetDescription("30 11 * * *"));
    }

    [Fact]
    public void TestMinuteSpan()
    {
      Assert.EqualsCaseInsensitive("Әрбір минут арасында 11:00 және 11:10", GetDescription("0-10 11 * * *"));
    }

    [Fact]
    public void TestOneMonthOnly()
    {
      Assert.EqualsCaseInsensitive("Әрбір минут сайын, тек Наурыз", GetDescription("* * * 3 *"));
    }

    [Fact]
    public void TestTwoMonthsOnly()
    {
      Assert.EqualsCaseInsensitive("Әрбір минут сайын, тек Наурыз және Маусым", GetDescription("* * * 3,6 *"));
    }

    [Fact]
    public void TestTwoTimesEachAfternoon()
    {
      Assert.EqualsCaseInsensitive("Сағат 02:30 және 04:30", GetDescription("30 14,16 * * *"));
    }

    [Fact]
    public void TestThreeTimesDaily()
    {
      Assert.EqualsCaseInsensitive("Сағат 06:30, 02:30 және 04:30", GetDescription("30 6,14,16 * * *"));
    }

    [Fact]
    public void TestOnceAWeek()
    {
      Assert.EqualsCaseInsensitive("Сағат 09:46, тек дүйсенбі", GetDescription("46 9 * * 1"));
    }

    [Fact]
    public void TestDayOfMonth()
    {
      Assert.EqualsCaseInsensitive("Сағат 12:23, 15-ші күні ай", GetDescription("23 12 15 * *"));
    }

    [Fact]
    public void TestMonthName()
    {
      Assert.EqualsCaseInsensitive("Сағат 12:23, тек Қаңтар", GetDescription("23 12 * JAN *"));
    }

    [Fact]
    public void TestDayOfMonthWithQuestionMark()
    {
      Assert.EqualsCaseInsensitive("Сағат 12:23, тек Қаңтар", GetDescription("23 12 ? JAN *"));
    }

    [Fact]
    public void TestMonthNameRange2()
    {
      Assert.EqualsCaseInsensitive("Сағат 12:23, Қаңтар-Ақпан", GetDescription("23 12 * JAN-FEB *"));
    }

    [Fact]
    public void TestMonthNameRange3()
    {
      Assert.EqualsCaseInsensitive("Сағат 12:23, Қаңтар-Наурыз", GetDescription("23 12 * JAN-MAR *"));
    }

    [Fact]
    public void TestDayOfWeekName()
    {
      Assert.EqualsCaseInsensitive("Сағат 12:23, тек жексенбі", GetDescription("23 12 * * SUN"));
    }

    [Fact]
    public void TestDayOfWeekRange()
    {
      Assert.EqualsCaseInsensitive("Әрбір 5 минут, арасында 03:00 және 03:59, дүйсенбі-жұма", GetDescription("*/5 15 * * MON-FRI"));
    }

    [Fact]
    public void TestDayOfWeekOnceInMonth()
    {
      Assert.EqualsCaseInsensitive("Әрбір минут сайын, үшінші дүйсенбі ай", GetDescription("* * * * MON#3"));
    }

    [Fact]
    public void TestLastDayOfTheWeekOfTheMonth()
    {
      Assert.EqualsCaseInsensitive("Әрбір минут сайын, әрбір айдың соңғы бейсенбі", GetDescription("* * * * 4L"));
    }

    [Fact]
    public void TestLastDayOfTheMonth()
    {
      Assert.EqualsCaseInsensitive("Әрбір 5 минут, айдың соңғы күні, тек Қаңтар", GetDescription("*/5 * L JAN *"));
    }

    [Fact]
    public void TestLastWeekdayOfTheMonth()
    {
      Assert.EqualsCaseInsensitive("Әрбір минут сайын, соңғы жұмыс күні ай", GetDescription("* * LW * *"));
    }

    [Fact]
    public void TestLastWeekdayOfTheMonth2()
    {
      Assert.EqualsCaseInsensitive("Әрбір минут сайын, соңғы жұмыс күні ай", GetDescription("* * WL * *"));
    }

    [Fact]
    public void TestFirstWeekdayOfTheMonth()
    {
      Assert.EqualsCaseInsensitive("Әрбір минут сайын, бірінші жұмыс күні-айдың", GetDescription("* * 1W * *"));
    }

    [Fact]
    public void TestFirstWeekdayOfTheMonth2()
    {
      Assert.EqualsCaseInsensitive("Әрбір минут сайын, бірінші жұмыс күні-айдың", GetDescription("* * W1 * *"));
    }

    [Fact]
    public void TestParticularWeekdayOfTheMonth()
    {
      Assert.EqualsCaseInsensitive("Әрбір минут сайын, жақында 5-ші күні-айдың", GetDescription("* * 5W * *"));
    }

    [Fact]
    public void TestParticularWeekdayOfTheMonth2()
    {
      Assert.EqualsCaseInsensitive("Әрбір минут сайын, жақында 5-ші күні-айдың", GetDescription("* * W5 * *"));
    }

    [Fact]
    public void TestTimeOfDayWithSeconds()
    {
      Assert.EqualsCaseInsensitive("Сағат 02:02:30", GetDescription("30 02 14 * * *"));
    }

    [Fact]
    public void TestSecondInternvals()
    {
      Assert.EqualsCaseInsensitive("Секунд 5 жөніндегі 10 минутына", GetDescription("5-10 * * * * *"));
    }

    [Fact]
    public void TestSecondMinutesHoursIntervals()
    {
      Assert.EqualsCaseInsensitive("Секунд 5 жөніндегі 10 минутына, минут 30-35, арасында 10:00 және 12:59", GetDescription("5-10 30-35 10-12 * * *"));
    }

    [Fact]
    public void TestEvery5MinutesAt30Seconds()
    {
      Assert.EqualsCaseInsensitive("30 секундтан кейін басталғаннан кейін минут, әрбір 5 минут", GetDescription("30 */5 * * * *"));
    }

    [Fact]
    public void TestMinutesPastTheHourRange()
    {
      Assert.EqualsCaseInsensitive("30 минуттан кейін сағат, арасында 10:00 және 01:59, тек сәрсенбі және жұма", GetDescription("0 30 10-13 ? * WED,FRI"));
    }

    [Fact]
    public void TestSecondsPastTheMinuteInterval()
    {
      Assert.EqualsCaseInsensitive("10 секундтан кейін басталғаннан кейін минут, әрбір 5 минут", GetDescription("10 0/5 * * * ?"));
    }

    [Fact]
    public void TestBetweenWithInterval()
    {
      Assert.EqualsCaseInsensitive("Әрбір 3 минут, минут 2-59, сағат 01:00, 09:00, және 10:00, арасында 11 және 26-күндіз ай, Қаңтар-Маусым", GetDescription("2-59/3 1,9,22 11-26 1-6 ?"));
    }

    [Fact]
    public void TestRecurringFirstOfMonth()
    {
      Assert.EqualsCaseInsensitive("Сағат 06:00", GetDescription("0 0 6 1/1 * ?"));
    }

    [Fact]
    public void TestMinutesPastTheHour()
    {
      Assert.EqualsCaseInsensitive("5 минуттан кейін сағат", GetDescription("0 5 0/1 * * ?"));
    }

    [Fact]
    public void TestOneYearOnlyWithSeconds()
    {
      Assert.EqualsCaseInsensitive("Әрбір секунд сайын, тек 2013", GetDescription("* * * * * * 2013"));
    }

    [Fact]
    public void TestOneYearOnlyWithoutSeconds()
    {
      Assert.EqualsCaseInsensitive("Әрбір минут сайын, тек 2013", GetDescription("* * * * * 2013"));
    }

    [Fact]
    public void TestTwoYearsOnly()
    {
      Assert.EqualsCaseInsensitive("Әрбір минут сайын, тек 2013 және 2014", GetDescription("* * * * * 2013,2014"));
    }

    [Fact]
    public void TestYearRange2()
    {
      Assert.EqualsCaseInsensitive("Сағат 12:23, Қаңтар-Ақпан, 2013-2014", GetDescription("23 12 * JAN-FEB * 2013-2014"));
    }

    [Fact]
    public void TestYearRange3()
    {
      Assert.EqualsCaseInsensitive("Сағат 12:23, Қаңтар-Наурыз, 2013-2015", GetDescription("23 12 * JAN-MAR * 2013-2015"));
    }

    [Fact]
    public void TestHourRange()
    {
      Assert.EqualsCaseInsensitive("Әрбір 30 минут, арасында 08:00 және 09:59, 5 және 20-ші күні ай", GetDescription("0 0/30 8-9 5,20 * ?"));
    }

    [Fact]
    public void TestDayOfWeekModifier()
    {
      Assert.EqualsCaseInsensitive("Сағат 12:23, екінші жексенбі ай", GetDescription("23 12 * * SUN#2"));
    }

    [Fact]
    public void TestDayOfWeekModifierWithSundayStartOne()
    {
      Options options = new Options();
      options.DayOfWeekStartIndexZero = false;

      Assert.EqualsCaseInsensitive("Сағат 12:23, екінші жексенбі ай", GetDescription("23 12 * * 1#2", options));
    }

    [Fact]
    public void TestHourRangeWithEveryPortion()
    {
      Assert.EqualsCaseInsensitive("25 минуттан кейін сағат, әрбір 13 сағат, арасында 07:00 және 07:59", GetDescription("0 25 7-19/13 ? * *"));
    }

    [Fact]
    public void TestHourRangeWithTrailingZeroWithEveryPortion()
    {
      Assert.EqualsCaseInsensitive("25 минуттан кейін сағат, әрбір 13 сағат, арасында 07:00 және 08:59", GetDescription("0 25 7-20/13 ? * *"));
    }

    [Fact]
    public void TestSecondsInternalWithStepValue()
    {
      // GitHub Issue #49: https://github.com/bradymholt/cron-expression-descriptor/issues/49
      Assert.EqualsCaseInsensitive("Әрбір 30 секунд, бастап 5 секундтан кейін басталғаннан кейін минут", GetDescription("5/30 * * * * ?"));
    }

    [Fact]
    public void TestMinutesInternalWithStepValue()
    {
      Assert.EqualsCaseInsensitive("Әрбір 30 минут, бастап 5 минуттан кейін сағат", GetDescription("0 5/30 * * * ?"));
    }

    [Fact]
    public void TestHoursInternalWithStepValue()
    {
      Assert.EqualsCaseInsensitive("Әрбір секунд сайын, әрбір 8 сағат, бастап сағат 05:00", GetDescription("* * 5/8 * * ?"));
    }

    [Fact]
    public void TestDayOfMonthInternalWithStepValue()
    {
      Assert.EqualsCaseInsensitive("Сағат 07:05, әрбір 3 күн, бастап 2-ші күні ай", GetDescription("0 5 7 2/3 * ? *"));
    }

    [Fact]
    public void TestMonthInternalWithStepValue()
    {
      Assert.EqualsCaseInsensitive("Сағат 07:05, әрбір 2 ай сайын, Наурыз-Желтоқсан", GetDescription("0 5 7 ? 3/2 ? *"));
    }

    [Fact]
    public void TestDayOfWeekInternalWithStepValue()
    {
      Assert.EqualsCaseInsensitive("Сағат 07:05, әрбір 3 күн апта, сейсенбі-сенбі", GetDescription("0 5 7 ? * 2/3 *"));
    }

    [Fact]
    public void TestYearInternalWithStepValue()
    {
      Assert.EqualsCaseInsensitive("Сағат 07:05, әрбір 4 жыл сайын, 2016-9999", GetDescription("0 5 7 ? * ? 2016/4"));
    }
  }
}
