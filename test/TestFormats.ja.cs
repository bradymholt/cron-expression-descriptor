using Xunit;

namespace CronExpressionDescriptor.Test
{
  public class TestFormatsJA : Support.BaseTestFormats
  {
    protected override string GetLocale()
    {
      return "ja";
    }

    [Fact]
    public void TestEveryMinute()
    {
      Assert.Equal("毎分", GetDescription("* * * * *"));
    }

    [Fact]
    public void TestEvery5Minutes()
    {
      Assert.Equal("5 分ごと", GetDescription("*/5 * * * *"));
    }

    [Fact]
    public void TestTimeOfDay()
    {
      Assert.Equal("11:30 午前", GetDescription("30 11 * * *"));
    }
  }
}
