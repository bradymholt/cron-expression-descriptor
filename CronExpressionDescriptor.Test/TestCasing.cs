using System;
using System.Globalization;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CronExpressionDescriptor;

namespace CronExpressionDescriptor.Test
{
    [TestClass]
    public class TestCasing
    {
        [TestInitialize]
        public void SetUp()
        {
            CultureInfo myCultureInfo = new CultureInfo("en");
            Thread.CurrentThread.CurrentCulture = myCultureInfo;
            Thread.CurrentThread.CurrentUICulture = myCultureInfo;
        }

        [TestMethod]
        public void TestSentenceCasing()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("* * * * *", new Options() { CasingType = CasingTypeEnum.Sentence });
            Assert.AreEqual("Every minute", ceh.GetDescription(DescriptionTypeEnum.FULL));
        }

        [TestMethod]
        public void TestTitleCasing()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("* * * * *", new Options() { CasingType = CasingTypeEnum.Title });
            Assert.AreEqual("Every Minute", ceh.GetDescription(DescriptionTypeEnum.FULL));
        }

        [TestMethod]
        public void TestLowerCasing()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("* * * * *", new Options() { CasingType = CasingTypeEnum.LowerCase });
            Assert.AreEqual("every minute", ceh.GetDescription(DescriptionTypeEnum.FULL));
        }
    }
}