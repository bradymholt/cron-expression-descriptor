using Xunit;

namespace CronExpressionDescriptor.Test
{
  public class TestFormatsHEIL : Support.BaseTestFormats
  {
    protected override string GetLocale()
    {
      return "he-IL";
    }

    [Fact]
    public void TestEveryMinute()
    {
      Assert.Equal("כל דקה", GetDescription("* * * * *"));
    }

    [Fact]
    public void TestEvery5Minutes()
    {
      Assert.Equal("כל 5 דקות", GetDescription("*/5 * * * *"));
    }

    [Fact]
    public void TestTimeOfDay()
    {
      Assert.Equal("ב 11:30 AM", GetDescription("30 11 * * *"));
    }
  }
}
