using Xunit;

namespace CronExpressionDescriptor.Test
{
  /// <summary>
  /// Tests for Persian (Farsi) translation
  /// </summary>
  public class TestFormatsFA : Support.BaseTestFormats
  {
    protected override string GetLocale()
    {
      return "fa";
    }

    [Fact]

    public void TestEveryMinute()
    {
      Assert.Equal("هر دقیقه", GetDescription("* * * * *"));
    }
  }
}
