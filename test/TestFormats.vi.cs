using Xunit;

namespace CronExpressionDescriptor.Test
{
  public class TestFormatsVI : Support.BaseTestFormats
  {
    protected override string GetLocale()
    {
      return "vi";
    }

    [Fact]
    public void TestEveryMinute()
    {
      Assert.Equal("Mỗi phút", GetDescription("* * * * *"));
    }

    [Fact]
    public void TestEvery5Minutes()
    {
      Assert.Equal("Mỗi 5 phút", GetDescription("*/5 * * * *"));
    }

    [Fact]
    public void TestTimeOfDay()
    {
      Assert.Equal("Tại 11:30 AM", GetDescription("30 11 * * *"));
    }
  }
}
