using Xunit;

namespace CronExpressionDescriptor.Test
{
    public class TestVerbosity
    {
        [Fact]
        public void TestSimpleExpression()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("30 4 1 * *", new Options() { Verbose = true, Locale = "en-US" });
            Assert.Equal("At 04:30 AM, on day 1 of the month", ceh.GetDescription(DescriptionTypeEnum.FULL));
        }

        [Fact]
        public void TestEveryMinuteSimpleExpression()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("* * * * *", new Options() { Verbose = true, Locale = "en-US" });
            Assert.Equal("Every minute, every hour, every day", ceh.GetDescription(DescriptionTypeEnum.FULL));
        }
    }
}
