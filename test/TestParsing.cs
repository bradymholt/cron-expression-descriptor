using System.Globalization;
using System.Threading;
using Xunit;

namespace CronExpressionDescriptor.Test
{
    public class TestParsing
    {
        [Fact]
        public void TestWeekDayAndMonthParsing()
        {
            const string expression = "0 59 23 31 DEC Fri *";

            var options = new Options
            {
                Locale = "en"
            };

            var oldCulture = Thread.CurrentThread.CurrentCulture;

            try
            {
                foreach (var culture in CultureInfo.GetCultures(CultureTypes.AllCultures))
                {
                    Thread.CurrentThread.CurrentCulture = culture;

                    var res = ExpressionDescriptor.GetDescription(expression, options);

                    Assert.Equal("At 11:59 PM, on day 31 of the month, only on Friday, only in December", res);
                }
            }
            finally
            {
                Thread.CurrentThread.CurrentCulture = oldCulture;
            }
        }
    }
}
