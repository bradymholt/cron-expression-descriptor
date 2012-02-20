using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CronExpressionDescriptor.Test
{
    [TestClass]
    public class TestExceptions
    {
        [TestMethod]
        [ExpectedException(typeof(MissingFieldException))]
        public void TestNullCronExpression()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor(null);
        }

        [TestMethod]
        [ExpectedException(typeof(MissingFieldException))]
        public void TestEmptyCronExpression()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestInvalidCronExpression()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("INVALID");
            string result = ceh.FullDescription;
        }
    }
}
