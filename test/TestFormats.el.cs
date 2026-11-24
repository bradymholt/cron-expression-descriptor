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
      Assert.ContainsCaseInsensitive("Κάθε λεπτό", GetDescription("* * * * *"));
    }

    [Fact]
    public void TestEvery1Minute()
    {
      Assert.ContainsCaseInsensitive("Κάθε λεπτό", GetDescription("*/1 * * * *"));
      Assert.ContainsCaseInsensitive("Κάθε λεπτό", GetDescription("0 0/1 * * * ?"));
    }

    [Fact]
    public void TestEveryHour()
    {
      Assert.ContainsCaseInsensitive("Κάθε ώρα", GetDescription("0 0 * * * ?"));
      Assert.ContainsCaseInsensitive("Κάθε ώρα", GetDescription("0 0 0/1 * * ?"));
    }

    [Fact]
    public void TestTimeOfDayCertainDaysOfWeek()
    {
      Assert.ContainsCaseInsensitive("Στις 11:00 μμ, Δευτέρα έως Παρασκευή", GetDescription("0 23 ? * MON-FRI"));
    }

    [Fact]
    public void TestEverySecond()
    {
      Assert.ContainsCaseInsensitive("Κάθε δευτερόλεπτο", GetDescription("* * * * * *"));
    }

    [Fact]
    public void TestEvery45Seconds()
    {
      Assert.ContainsCaseInsensitive("Κάθε 45 δευτερόλεπτα", GetDescription("*/45 * * * * *"));
    }

    [Fact]
    public void TestEvery5Minutes()
    {
      Assert.ContainsCaseInsensitive("Κάθε 5 λεπτά", GetDescription("*/5 * * * *"));
      Assert.ContainsCaseInsensitive("Κάθε 10 λεπτά", GetDescription("0 0/10 * * * ?"));
    }

    [Fact]
    public void TestEvery5MinutesOnTheSecond()
    {
      Assert.ContainsCaseInsensitive("Κάθε 5 λεπτά", GetDescription("0 */5 * * * *"));
    }

    [Fact]
    public void TestWeekdaysAtTime()
    {
      Assert.ContainsCaseInsensitive("Στις 11:30 π.μ, Δευτέρα έως Παρασκευή", GetDescription("30 11 * * 1-5"));
    }

    [Fact]
    public void TestDailyAtTime()
    {
      Assert.ContainsCaseInsensitive("Στις 11:30 π.μ", GetDescription("30 11 * * *"));
    }

    [Fact]
    public void TestMinuteSpan()
    {
      Assert.ContainsCaseInsensitive("Κάθε λεπτό μεταξύ 11:00 π.μ και 11:10 π.μ", GetDescription("0-10 11 * * *"));
    }

    [Fact]
    public void TestOneMonthOnly()
    {
      Assert.ContainsCaseInsensitive("Κάθε λεπτό, μόνο το Μάρτιος", GetDescription("* * * 3 *"));
    }

    [Fact]
    public void TestTwoMonthsOnly()
    {
      Assert.ContainsCaseInsensitive("Κάθε λεπτό, μόνο το Μάρτιος και Ιούνιος", GetDescription("* * * 3,6 *"));
    }

    [Fact]
    public void TestTwoTimesEachAfternoon()
    {
      Assert.ContainsCaseInsensitive("Στις 02:30 μμ και 04:30 μμ", GetDescription("30 14,16 * * *"));
    }

    [Fact]
    public void TestThreeTimesDaily()
    {
      Assert.ContainsCaseInsensitive("Στις 06:30 π.μ, 02:30 μμ και 04:30 μμ", GetDescription("30 6,14,16 * * *"));
    }

    [Fact]
    public void TestOnceAWeek()
    {
      Assert.ContainsCaseInsensitive("Στις 09:46 π.μ, μόνο το Δευτέρα", GetDescription("46 9 * * 1"));
    }

    [Fact]
    public void TestDayOfMonth()
    {
      Assert.ContainsCaseInsensitive("Στις 12:23 μμ, την 15 ημέρα του μήνα", GetDescription("23 12 15 * *"));
    }

    [Fact]
    public void TestMonthName()
    {
      Assert.ContainsCaseInsensitive("Στις 12:23 μμ, μόνο το Ιανουάριος", GetDescription("23 12 * JAN *"));
    }

    [Fact]
    public void TestDayOfMonthWithQuestionMark()
    {
      Assert.ContainsCaseInsensitive("Στις 12:23 μμ, μόνο το Ιανουάριος", GetDescription("23 12 ? JAN *"));
    }

    [Fact]
    public void TestMonthNameRange2()
    {
      Assert.ContainsCaseInsensitive("Στις 12:23 μμ, Ιανουάριος έως Φεβρουάριος", GetDescription("23 12 * JAN-FEB *"));
    }

    [Fact]
    public void TestMonthNameRange3()
    {
      Assert.ContainsCaseInsensitive("Στις 12:23 μμ, Ιανουάριος έως Μάρτιος", GetDescription("23 12 * JAN-MAR *"));
    }

    [Fact]
    public void TestDayOfWeekName()
    {
      Assert.ContainsCaseInsensitive("Στις 12:23 μμ, μόνο το Κυριακή", GetDescription("23 12 * * SUN"));
    }

    [Fact]
    public void TestDayOfWeekRange()
    {
      Assert.ContainsCaseInsensitive("Κάθε 5 λεπτά, μεταξύ 03:00 μμ και 03:59 μμ, Δευτέρα έως Παρασκευή", GetDescription("*/5 15 * * MON-FRI"));
    }

    [Fact]
    public void TestDayOfWeekOnceInMonth()
    {
      Assert.ContainsCaseInsensitive("Κάθε λεπτό, τηντρίτος Δευτέρα του μήνα", GetDescription("* * * * MON#3"));
    }

    [Fact]
    public void TestLastDayOfTheWeekOfTheMonth()
    {
      Assert.ContainsCaseInsensitive("Κάθε λεπτό, την τελευταία Πέμπτη του μήνα", GetDescription("* * * * 4L"));
    }

    [Fact]
    public void TestLastDayOfTheMonth()
    {
      Assert.ContainsCaseInsensitive("Κάθε 5 λεπτά, την τελευταία ημέρα του μήνα, μόνο το Ιανουάριος", GetDescription("*/5 * L JAN *"));
    }

    [Fact]
    public void TestLastWeekdayOfTheMonth()
    {
      Assert.ContainsCaseInsensitive("Κάθε λεπτό, την τελευταία εργάσιμη ημέρα του μήνα", GetDescription("* * LW * *"));
    }

    [Fact]
    public void TestLastWeekdayOfTheMonth2()
    {
      Assert.ContainsCaseInsensitive("Κάθε λεπτό, την τελευταία εργάσιμη ημέρα του μήνα", GetDescription("* * WL * *"));
    }

    [Fact]
    public void TestFirstWeekdayOfTheMonth()
    {
      Assert.ContainsCaseInsensitive("Κάθε λεπτό, την πρώτη εργάσιμη ημέρα του μήνα", GetDescription("* * 1W * *"));
    }

    [Fact]
    public void TestFirstWeekdayOfTheMonth2()
    {
      Assert.ContainsCaseInsensitive("Κάθε λεπτό, την πρώτη εργάσιμη ημέρα του μήνα", GetDescription("* * W1 * *"));
    }

    [Fact]
    public void TestParticularWeekdayOfTheMonth()
    {
      Assert.ContainsCaseInsensitive("Κάθε λεπτό, την εργάσιμη ημέρα κοντά στην ημέρα 5 του μήνα", GetDescription("* * 5W * *"));
    }

    [Fact]
    public void TestParticularWeekdayOfTheMonth2()
    {
      Assert.ContainsCaseInsensitive("Κάθε λεπτό, την εργάσιμη ημέρα κοντά στην ημέρα 5 του μήνα", GetDescription("* * W5 * *"));
    }

    [Fact]
    public void TestTimeOfDayWithSeconds()
    {
      Assert.ContainsCaseInsensitive("Στις 02:02:30 μμ", GetDescription("30 02 14 * * *"));
    }

    [Fact]
    public void TestSecondInternvals()
    {
      Assert.ContainsCaseInsensitive("Δευτερόλεπτα 5 έως 10 μετά το λεπτό", GetDescription("5-10 * * * * *"));
    }

    [Fact]
    public void TestSecondMinutesHoursIntervals()
    {
      Assert.ContainsCaseInsensitive("Δευτερόλεπτα 5 έως 10 μετά το λεπτό, λεπτά 30 έως 35 μετά την ώρα, μεταξύ 10:00 π.μ και 12:59 μμ", GetDescription("5-10 30-35 10-12 * * *"));
    }

    [Fact]
    public void TestEvery5MinutesAt30Seconds()
    {
      Assert.ContainsCaseInsensitive("Στις 30 δευτερόλεπτα μετά το λεπτό, κάθε 5 λεπτά", GetDescription("30 */5 * * * *"));
    }

    [Fact]
    public void TestMinutesPastTheHourRange()
    {
      Assert.ContainsCaseInsensitive("Στις 30 λεπτά μετά την ώρα, μεταξύ 10:00 π.μ και 01:59 μμ, μόνο το Τετάρτη και Παρασκευή", GetDescription("0 30 10-13 ? * WED,FRI"));
    }

    [Fact]
    public void TestSecondsPastTheMinuteInterval()
    {
      Assert.ContainsCaseInsensitive("Στις 10 δευτερόλεπτα μετά το λεπτό, κάθε 5 λεπτά", GetDescription("10 0/5 * * * ?"));
    }

    [Fact]
    public void TestBetweenWithInterval()
    {
      Assert.ContainsCaseInsensitive("Κάθε 3 λεπτά, λεπτά 2 έως 59 μετά την ώρα, στις 01:00 π.μ, 09:00 π.μ, και 10:00 μμ, μεταξύ 11 και 26 του μήνα, Ιανουάριος έως Ιούνιος", GetDescription("2-59/3 1,9,22 11-26 1-6 ?"));
    }

    [Fact]
    public void TestRecurringFirstOfMonth()
    {
      Assert.ContainsCaseInsensitive("Στις 06:00 π.μ", GetDescription("0 0 6 1/1 * ?"));
    }

    [Fact]
    public void TestMinutesPastTheHour()
    {
      Assert.ContainsCaseInsensitive("Στις 5 λεπτά", GetDescription("0 5 0/1 * * ?"));
    }

    [Fact]
    public void TestOneYearOnlyWithSeconds()
    {
      Assert.ContainsCaseInsensitive("Κάθε δευτερόλεπτο, μόνο το 2013", GetDescription("* * * * * * 2013"));
    }

    [Fact]
    public void TestOneYearOnlyWithoutSeconds()
    {
      Assert.ContainsCaseInsensitive("Κάθε λεπτό, μόνο το 2013", GetDescription("* * * * * 2013"));
    }

    [Fact]
    public void TestTwoYearsOnly()
    {
      Assert.ContainsCaseInsensitive("Κάθε λεπτό, μόνο το 2013 και 2014", GetDescription("* * * * * 2013,2014"));
    }

    [Fact]
    public void TestYearRange2()
    {
      Assert.ContainsCaseInsensitive("Στις 12:23 μμ, Ιανουάριος έως Φεβρουάριος, 2013 έως 2014", GetDescription("23 12 * JAN-FEB * 2013-2014"));
    }

    [Fact]
    public void TestYearRange3()
    {
      Assert.ContainsCaseInsensitive("Στις 12:23 μμ, Ιανουάριος έως Μάρτιος, 2013 έως 2015", GetDescription("23 12 * JAN-MAR * 2013-2015"));
    }

    [Fact]
    public void TestHourRange()
    {
      Assert.ContainsCaseInsensitive("Κάθε 30 λεπτά, μεταξύ 08:00 π.μ και 09:59 π.μ, την 5 και 20 ημέρα του μήνα", GetDescription("0 0/30 8-9 5,20 * ?"));
    }

    [Fact]
    public void TestDayOfWeekModifier()
    {
      Assert.ContainsCaseInsensitive("Στις 12:23 μμ, τηνδεύτερος Κυριακή του μήνα", GetDescription("23 12 * * SUN#2"));
    }

    [Fact]
    public void TestDayOfWeekModifierWithSundayStartOne()
    {
      Options options = new Options();
      options.DayOfWeekStartIndexZero = false;

      Assert.ContainsCaseInsensitive("Στις 12:23 μμ, τηνδεύτερος Κυριακή του μήνα", GetDescription("23 12 * * 1#2", options));
    }

    [Fact]
    public void TestHourRangeWithEveryPortion()
    {
      Assert.ContainsCaseInsensitive("Στις 25 λεπτά μετά την ώρα, κάθε 13 ώρες, μεταξύ 07:00 π.μ και 07:59 μμ", GetDescription("0 25 7-19/13 ? * *"));
    }

    [Fact]
    public void TestHourRangeWithTrailingZeroWithEveryPortion()
    {
      Assert.ContainsCaseInsensitive("Στις 25 λεπτά μετά την ώρα, κάθε 13 ώρες, μεταξύ 07:00 π.μ και 08:59 μμ", GetDescription("0 25 7-20/13 ? * *"));
    }

    [Fact]
    public void TestSecondsInternalWithStepValue()
    {
      Assert.ContainsCaseInsensitive("Κάθε 30 δευτερόλεπτα, ξεκινώντας στις 5 δευτερόλεπτα", GetDescription("5/30 * * * * ?"));
    }

    [Fact]
    public void TestMinutesInternalWithStepValue()
    {
      Assert.ContainsCaseInsensitive("Κάθε 30 λεπτά, ξεκινώντας στις 5 λεπτά", GetDescription("0 5/30 * * * ?"));
    }

    [Fact]
    public void TestHoursInternalWithStepValue()
    {
      Assert.ContainsCaseInsensitive("Κάθε δευτερόλεπτο, κάθε 8 ώρες, ξεκινώντας στις 05:00 π.μ", GetDescription("* * 5/8 * * ?"));
    }

    [Fact]
    public void TestDayOfMonthInternalWithStepValue()
    {
      Assert.ContainsCaseInsensitive("Στις 07:05 π.μ, κάθε 3 ημέρες, ξεκινώντας την 2 ημέρα του μήνα", GetDescription("0 5 7 2/3 * ? *"));
    }

    [Fact]
    public void TestMonthInternalWithStepValue()
    {
      Assert.ContainsCaseInsensitive("Στις 07:05 π.μ, κάθε 2 μήνες, Μάρτιος έως Δεκέμβριος", GetDescription("0 5 7 ? 3/2 ? *"));
    }

    [Fact]
    public void TestDayOfWeekInternalWithStepValue()
    {
      Assert.ContainsCaseInsensitive("Στις 07:05 π.μ, κάθε 3 ημέρες της εβδομάδας, Τρίτη έως Σάββατο", GetDescription("0 5 7 ? * 2/3 *"));
    }

    [Fact]
    public void TestYearInternalWithStepValue()
    {
      Assert.ContainsCaseInsensitive("Στις 07:05 π.μ, κάθε 4 χρόνια, 2016 έως 9999", GetDescription("0 5 7 ? * ? 2016/4"));
    }
  }
}
