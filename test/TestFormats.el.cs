using Xunit;
using Assert = CronExpressionDescriptor.Test.Support.AssertExtensions;

namespace CronExpressionDescriptor.Test
{
  /// <summary>
  /// Tests for Greek
  /// </summary>
  public class TestFormatsEl : Support.BaseTestFormats
  {

    protected override string GetLocale()
    {
      return "el-GR";
    }

    [Fact]
    public void TestEveryMinute()
    {
      Assert.EqualsCaseInsensitive("Κάθε λεπτό", GetDescription("* * * * *"));
    }

    [Fact]
    public void TestEvery1Minute()
    {
      Assert.EqualsCaseInsensitive("Κάθε λεπτό", GetDescription("*/1 * * * *"));
      Assert.EqualsCaseInsensitive("Κάθε λεπτό", GetDescription("0 0/1 * * * ?"));
    }

    [Fact]
    public void TestEveryHour()
    {
      Assert.EqualsCaseInsensitive("Κάθε ώρα", GetDescription("0 0 * * * ?"));
      Assert.EqualsCaseInsensitive("Κάθε ώρα", GetDescription("0 0 0/1 * * ?"));
    }

    [Fact]
    public void TestTimeOfDayCertainDaysOfWeek()
    {
      Assert.EqualsCaseInsensitive("Στις 11:00 μμ, Δευτέρα έως Παρασκευή", GetDescription("0 23 ? * MON-FRI"));
    }

    [Fact]
    public void TestEverySecond()
    {
      Assert.EqualsCaseInsensitive("Κάθε δευτερόλεπτο", GetDescription("* * * * * *"));
    }

    [Fact]
    public void TestEvery45Seconds()
    {
      Assert.EqualsCaseInsensitive("Κάθε 45 δευτερόλεπτα", GetDescription("*/45 * * * * *"));
    }

    [Fact]
    public void TestEvery5Minutes()
    {
      Assert.EqualsCaseInsensitive("Κάθε 5 λεπτά", GetDescription("*/5 * * * *"));
      Assert.EqualsCaseInsensitive("Κάθε 10 λεπτά", GetDescription("0 0/10 * * * ?"));
    }

    [Fact]
    public void TestEvery5MinutesOnTheSecond()
    {
      Assert.EqualsCaseInsensitive("Κάθε 5 λεπτά", GetDescription("0 */5 * * * *"));
    }

    [Fact]
    public void TestWeekdaysAtTime()
    {
      Assert.EqualsCaseInsensitive("Στις 11:30 π.μ, Δευτέρα έως Παρασκευή", GetDescription("30 11 * * 1-5"));
    }

    [Fact]
    public void TestDailyAtTime()
    {
      Assert.EqualsCaseInsensitive("Στις 11:30 π.μ", GetDescription("30 11 * * *"));
    }

    [Fact]
    public void TestMinuteSpan()
    {
      Assert.EqualsCaseInsensitive("Κάθε λεπτό μεταξύ 11:00 π.μ και 11:10 π.μ", GetDescription("0-10 11 * * *"));
    }

    [Fact]
    public void TestOneMonthOnly()
    {
      Assert.EqualsCaseInsensitive("Κάθε λεπτό, μόνο τον Μάρτιος", GetDescription("* * * 3 *"));
    }

    [Fact]
    public void TestTwoMonthsOnly()
    {
      Assert.EqualsCaseInsensitive("Κάθε λεπτό, μόνο τον Μάρτιος και Ιούνιος", GetDescription("* * * 3,6 *"));
    }

    [Fact]
    public void TestTwoTimesEachAfternoon()
    {
      Assert.EqualsCaseInsensitive("Στις 02:30 μμ και 04:30 μμ", GetDescription("30 14,16 * * *"));
    }

    [Fact]
    public void TestThreeTimesDaily()
    {
      Assert.EqualsCaseInsensitive("Στις 06:30 π.μ, 02:30 μμ και 04:30 μμ", GetDescription("30 6,14,16 * * *"));
    }

    [Fact]
    public void TestOnceAWeek()
    {
      Assert.EqualsCaseInsensitive("Στις 09:46 π.μ, μόνο την Δευτέρα", GetDescription("46 9 * * 1"));
    }

    [Fact]
    public void TestDayOfMonth()
    {
      Assert.EqualsCaseInsensitive("Στις 12:23 μμ, την 15η ημέρα του μήνα", GetDescription("23 12 15 * *"));
    }

    [Fact]
    public void TestMonthName()
    {
      Assert.EqualsCaseInsensitive("Στις 12:23 μμ, μόνο τον Ιανουάριος", GetDescription("23 12 * JAN *"));
    }

    [Fact]
    public void TestDayOfMonthWithQuestionMark()
    {
      Assert.EqualsCaseInsensitive("Στις 12:23 μμ, μόνο τον Ιανουάριος", GetDescription("23 12 ? JAN *"));
    }

    [Fact]
    public void TestMonthNameRange2()
    {
      Assert.EqualsCaseInsensitive("Στις 12:23 μμ, Ιανουάριος έως Φεβρουάριος", GetDescription("23 12 * JAN-FEB *"));
    }

    [Fact]
    public void TestMonthNameRange3()
    {
      Assert.EqualsCaseInsensitive("Στις 12:23 μμ, Ιανουάριος έως Μάρτιος", GetDescription("23 12 * JAN-MAR *"));
    }

    [Fact]
    public void TestDayOfWeekName()
    {
      Assert.EqualsCaseInsensitive("Στις 12:23 μμ, μόνο την Κυριακή", GetDescription("23 12 * * SUN"));
    }

    [Fact]
    public void TestDayOfWeekRange()
    {
      Assert.EqualsCaseInsensitive("Κάθε 5 λεπτά, μεταξύ 03:00 μμ και 03:59 μμ, Δευτέρα έως Παρασκευή", GetDescription("*/5 15 * * MON-FRI"));
    }

    [Fact]
    public void TestDayOfWeekOnceInMonth()
    {
      Assert.EqualsCaseInsensitive("Κάθε λεπτό, в τρίτοςΔευτέρα του μήνα", GetDescription("* * * * MON#3"));
    }

    [Fact]
    public void TestLastDayOfTheWeekOfTheMonth()
    {
      Assert.EqualsCaseInsensitive("Κάθε λεπτό, την τελευταία Πέμπτη του μήνα", GetDescription("* * * * 4L"));
    }

    [Fact]
    public void TestLastDayOfTheMonth()
    {
      Assert.EqualsCaseInsensitive("Κάθε 5 λεπτά, την τελευταία μέρα του μήνα, μόνο τον Ιανουάριος", GetDescription("*/5 * L JAN *"));
    }

    [Fact]
    public void TestLastWeekdayOfTheMonth()
    {
      Assert.EqualsCaseInsensitive("Κάθε λεπτό, την τελευταία εργάσιμη ημέρα του μήνα", GetDescription("* * LW * *"));
    }

    [Fact]
    public void TestLastWeekdayOfTheMonth2()
    {
      Assert.EqualsCaseInsensitive("Κάθε λεπτό, την τελευταία εργάσιμη ημέρα του μήνα", GetDescription("* * WL * *"));
    }

    [Fact]
    public void TestFirstWeekdayOfTheMonth()
    {
      Assert.EqualsCaseInsensitive("Κάθε λεπτό, την πρώτη εργάσιμη ημέρα του μήνα", GetDescription("* * 1W * *"));
    }

    [Fact]
    public void TestFirstWeekdayOfTheMonth2()
    {
      Assert.EqualsCaseInsensitive("Κάθε λεπτό, την πρώτη εργάσιμη ημέρα του μήνα", GetDescription("* * W1 * *"));
    }

    [Fact]
    public void TestParticularWeekdayOfTheMonth()
    {
      Assert.EqualsCaseInsensitive("Κάθε λεπτό, την καθημερινή πλησιέστερη ημέρα 5 του μήνα", GetDescription("* * 5W * *"));
    }

    [Fact]
    public void TestParticularWeekdayOfTheMonth2()
    {
      Assert.EqualsCaseInsensitive("Κάθε λεπτό, την καθημερινή πλησιέστερη ημέρα 5 του μήνα", GetDescription("* * W5 * *"));
    }

    [Fact]
    public void TestTimeOfDayWithSeconds()
    {
      Assert.EqualsCaseInsensitive("Στις 02:02:30 μμ", GetDescription("30 02 14 * * *"));
    }

    [Fact]
    public void TestSecondInternvals()
    {
      Assert.EqualsCaseInsensitive("Δευτερόλεπτα 5 έως 10 μετά το λεπτό", GetDescription("5-10 * * * * *"));
    }

    [Fact]
    public void TestSecondMinutesHoursIntervals()
    {
      Assert.EqualsCaseInsensitive("Δευτερόλεπτα 5 έως 10 μετά το λεπτό, λεπτά 30 έως 35 μετά την ώρα, μεταξύ 10:00 π.μ και 12:59 μμ", GetDescription("5-10 30-35 10-12 * * *"));
    }

    [Fact]
    public void TestEvery5MinutesAt30Seconds()
    {
      Assert.EqualsCaseInsensitive("Στις 30 δευτερόλεπτα, κάθε 5 λεπτά", GetDescription("30 */5 * * * *"));
    }

    [Fact]
    public void TestMinutesPastTheHourRange()
    {
      Assert.EqualsCaseInsensitive("Στις 30 λεπτά, μεταξύ 10:00 π.μ και 01:59 μμ, μόνο την Τετάρτη και Παρασκευή", GetDescription("0 30 10-13 ? * WED,FRI"));
    }

    [Fact]
    public void TestSecondsPastTheMinuteInterval()
    {
      Assert.EqualsCaseInsensitive("Στις 10 δευτερόλεπτα, κάθε 5 λεπτά", GetDescription("10 0/5 * * * ?"));
    }

    [Fact]
    public void TestBetweenWithInterval()
    {
      Assert.EqualsCaseInsensitive("Κάθε 3 λεπτά, λεπτά 2 έως 59 μετά την ώρα, στις 01:00 π.μ, 09:00 π.μ, και 10:00 μμ, μεταξύ 11 και 26 του μήνα, Ιανουάριος έως Ιούνιος", GetDescription("2-59/3 1,9,22 11-26 1-6 ?"));
    }

    [Fact]
    public void TestRecurringFirstOfMonth()
    {
      Assert.EqualsCaseInsensitive("Στις 06:00 π.μ", GetDescription("0 0 6 1/1 * ?"));
    }

    [Fact]
    public void TestMinutesPastTheHour()
    {
      Assert.EqualsCaseInsensitive("Στις 5 λεπτά", GetDescription("0 5 0/1 * * ?"));
    }

    [Fact]
    public void TestOneYearOnlyWithSeconds()
    {
      Assert.EqualsCaseInsensitive("Κάθε δευτερόλεπτο, μόλις το 2013", GetDescription("* * * * * * 2013"));
    }

    [Fact]
    public void TestOneYearOnlyWithoutSeconds()
    {
      Assert.EqualsCaseInsensitive("Κάθε λεπτό, μόλις το 2013", GetDescription("* * * * * 2013"));
    }

    [Fact]
    public void TestTwoYearsOnly()
    {
      Assert.EqualsCaseInsensitive("Κάθε λεπτό, μόλις το 2013 και 2014", GetDescription("* * * * * 2013,2014"));
    }

    [Fact]
    public void TestYearRange2()
    {
      Assert.EqualsCaseInsensitive("Στις 12:23 μμ, Ιανουάριος έως Φεβρουάριος, 2013 έως 2014", GetDescription("23 12 * JAN-FEB * 2013-2014"));
    }

    [Fact]
    public void TestYearRange3()
    {
      Assert.EqualsCaseInsensitive("Στις 12:23 μμ, Ιανουάριος έως Μάρτιος, 2013 έως 2015", GetDescription("23 12 * JAN-MAR * 2013-2015"));
    }

    [Fact]
    public void TestHourRange()
    {
      Assert.EqualsCaseInsensitive("Κάθε 30 λεπτά, μεταξύ 08:00 π.μ και 09:59 π.μ, την 5 και 20η ημέρα του μήνα", GetDescription("0 0/30 8-9 5,20 * ?"));
    }

    [Fact]
    public void TestDayOfWeekModifier()
    {
      Assert.EqualsCaseInsensitive("Στις 12:23 μμ, в δεύτεροςΚυριακή του μήνα", GetDescription("23 12 * * SUN#2"));
    }

    [Fact]
    public void TestDayOfWeekModifierWithSundayStartOne()
    {
      Options options = new Options();
      options.DayOfWeekStartIndexZero = false;

      Assert.EqualsCaseInsensitive("Στις 12:23 μμ, в δεύτεροςΚυριακή του μήνα", GetDescription("23 12 * * 1#2", options));
    }

    [Fact]
    public void TestHourRangeWithEveryPortion()
    {
      Assert.EqualsCaseInsensitive("Στις 25 λεπτά, κάθε 13 ώρες, μεταξύ 07:00 π.μ και 07:59 μμ", GetDescription("0 25 7-19/13 ? * *"));
    }

    [Fact]
    public void TestHourRangeWithTrailingZeroWithEveryPortion()
    {
      Assert.EqualsCaseInsensitive("Στις 25 λεπτά, κάθε 13 ώρες, μεταξύ 07:00 π.μ και 08:59 μμ", GetDescription("0 25 7-20/13 ? * *"));
    }

    [Fact]
    public void TestSecondsInternalWithStepValue()
    {
      Assert.EqualsCaseInsensitive("Κάθε 30 δευτερόλεπτα, ξεκινώντας στις 5 δευτερόλεπτα", GetDescription("5/30 * * * * ?"));
    }

    [Fact]
    public void TestMinutesInternalWithStepValue()
    {
      Assert.EqualsCaseInsensitive("Κάθε 30 λεπτά, ξεκινώντας στις 5 λεπτά", GetDescription("0 5/30 * * * ?"));
    }

    [Fact]
    public void TestHoursInternalWithStepValue()
    {
      Assert.EqualsCaseInsensitive("Κάθε δευτερόλεπτο, κάθε 8 ώρες, ξεκινώντας στις 05:00 π.μ", GetDescription("* * 5/8 * * ?"));
    }

    [Fact]
    public void TestDayOfMonthInternalWithStepValue()
    {
      Assert.EqualsCaseInsensitive("Στις 07:05 π.μ, κάθε 3 ημέρες, ξεκινώντας την 2η ημέρα του μήνα", GetDescription("0 5 7 2/3 * ? *"));
    }

    [Fact]
    public void TestMonthInternalWithStepValue()
    {
      Assert.EqualsCaseInsensitive("Στις 07:05 π.μ, κάθε 2 μήνες, Μάρτιος έως Δεκέμβριος", GetDescription("0 5 7 ? 3/2 ? *"));
    }

    [Fact]
    public void TestDayOfWeekInternalWithStepValue()
    {
      Assert.EqualsCaseInsensitive("Στις 07:05 π.μ, κάθε 3 ημέρες της εβδομάδας, Τρίτη έως Σάββατο", GetDescription("0 5 7 ? * 2/3 *"));
    }

    [Fact]
    public void TestYearInternalWithStepValue()
    {
      Assert.EqualsCaseInsensitive("Στις 07:05 π.μ, κάθε 4 χρόνια, 2016 έως 9999", GetDescription("0 5 7 ? * ? 2016/4"));
    }
  }
}
