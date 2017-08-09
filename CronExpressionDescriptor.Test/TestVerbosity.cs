using System;
using System.Globalization;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Xunit;
using CronExpressionDescriptor;

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