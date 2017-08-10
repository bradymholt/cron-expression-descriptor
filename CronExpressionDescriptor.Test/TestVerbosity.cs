using Xunit;

namespace CronExpressionDescriptor.Test
{
    public class TestVerbosity
    {
        [Fact]
        public void TestSimpleExpression()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("30 4 1 * *", new Options() { Verbose = true });
            Assert.Equal("At 04:30 AM, on day 1 of the month", ceh.GetDescription(DescriptionTypeEnum.FULL));
        }
    }
}