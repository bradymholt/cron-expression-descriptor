using Xunit;

namespace CronExpressionDescriptor.Test
{
  public class TestFormatsCS : Support.BaseTestFormats
  {
    protected override string GetLocale()
    {
      return "cs";
    }

    [Fact]
    public void TestEveryMinute()
    {
      Assert.Equal("Každou minutu", GetDescription("* * * * *"));
    }

    [Fact]
    public void TestEvery5Minutes()
    {
      Assert.Equal("Každých 5 minut", GetDescription("*/5 * * * *"));
    }

    [Fact]
    public void TestTimeOfDay()
    {
      Assert.Equal("V 11:30", GetDescription("30 11 * * *"));
    }
  }
}
