using Xunit;

namespace CronExpressionDescriptor.Test
{
    public class TestVerbosity : Support.BaseTestFormats
    {

        protected override string GetLocale()
        {
            return "en-US";
        }

        [Fact]
        public void TestSimpleExpression()
        {
            Assert.Equal("At 04:30 AM, on day 1 of the month", GetDescription("30 4 1 * *", true));
        }

        [Fact]
        public void TestEveryMinuteSimpleExpression()
        {
            Assert.Equal("Every minute, every hour, every day", GetDescription("* * * * *", true));
        }

        [Fact]
        public void TestSingleDayOfTheWeek()
        {
            Assert.Equal("At 09:00 AM, only on Tuesday", GetDescription("0 9 * * 2", true));
        }
    }
}
