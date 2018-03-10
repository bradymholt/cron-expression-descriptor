using Xunit;

namespace CronExpressionDescriptor.Test
{
    public class TestParsing
    {
        [Fact]
        public void TestWeekDayAndMonthParsing()
        {
            var expression = "0 59 23 31 dEc frI *";
            var options = new Options
            {
                Locale = "en"
            };

            var res = ExpressionDescriptor.GetDescription(expression, options);
            
            Assert.Equal("At 11:59 PM, on day 31 of the month, only on Friday, only in December", res);
        }
    }
}
