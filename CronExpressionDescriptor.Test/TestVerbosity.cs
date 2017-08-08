using System;
using System.Globalization;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using CronExpressionDescriptor;

namespace CronExpressionDescriptor.Test
{
    [TestFixture]
    public class TestVerbosity
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            ExpressionDescriptor.SetDefaultLocale("en-US");
        }

        [Test]
        public void TestSimpleExpression()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("30 4 1 * *", new Options() { Verbose = true});
            Assert.AreEqual("At 04:30 AM, on day 1 of the month", ceh.GetDescription(DescriptionTypeEnum.FULL));
        }
    }
}