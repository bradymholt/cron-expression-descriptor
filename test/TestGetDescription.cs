using CronExpressionDescriptor;
using System.Globalization;
using System.Threading;
using Xunit;

namespace CronExpressionDescriptor.Test
{
  public class TestGetDescription
  {

    [Fact]
    public void TestUnspecifiedSeconds()
    {
      const string expression = "0 59 23 31 DEC Fri *";

      var options = new Options
      {
        Locale = "en"
      };

      var oldCulture = Thread.CurrentThread.CurrentCulture;


      var expressionDescriptor = new ExpressionDescriptor(expression);
      try
      {
        foreach (var culture in CultureInfo.GetCultures(CultureTypes.AllCultures))
        {
          Thread.CurrentThread.CurrentCulture = culture;

          var res = expressionDescriptor.GetDescription(DescriptionTypeEnum.SECONDS);
          Assert.Equal("", res);
        }
      }
      finally
      {
        Thread.CurrentThread.CurrentCulture = oldCulture;
      }
    }
  }
}
