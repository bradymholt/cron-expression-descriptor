using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CronExpressionDescriptor;

namespace CronExpressionDescriptor.Test
{
    [TestClass]
    public class TestCasing
    {
        [TestMethod]
        public void TestSentenceCasing()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("* * * * *", new Options() { CasingType = CasingTypeEnum.Sentence });
            Assert.AreEqual("Every minute", ceh.GetDescription());
        }

        [TestMethod]
        public void TestTitleCasing()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("* * * * *", new Options() { CasingType = CasingTypeEnum.Title });
            Assert.AreEqual("Every Minute", ceh.GetDescription());
        }

        [TestMethod]
        public void TestLowerCasing()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("* * * * *", new Options() { CasingType = CasingTypeEnum.LowerCase });
            Assert.AreEqual("every minute", ceh.GetDescription());
        }
    }
}