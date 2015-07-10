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
    public class TestCasing
    {
        [TestFixtureSetUp]
        public void SetUp()
        {
            CultureInfo myCultureInfo = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = myCultureInfo;
            Thread.CurrentThread.CurrentUICulture = myCultureInfo;
        }

        [Test]
        public void TestSentenceCasing()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("* * * * *", new Options() { CasingType = CasingTypeEnum.Sentence });
            Assert.AreEqual("Every minute", ceh.GetDescription(DescriptionTypeEnum.FULL));
        }

        [Test]
        public void TestTitleCasing()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("* * * * *", new Options() { CasingType = CasingTypeEnum.Title });
            Assert.AreEqual("Every Minute", ceh.GetDescription(DescriptionTypeEnum.FULL));
        }

        [Test]
        public void TestLowerCasing()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("* * * * *", new Options() { CasingType = CasingTypeEnum.LowerCase });
            Assert.AreEqual("every minute", ceh.GetDescription(DescriptionTypeEnum.FULL));
        }
    }
}