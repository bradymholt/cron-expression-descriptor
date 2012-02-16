using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CronExpressionDescripter.Test
{
    [TestClass]
    public class TestExceptions
    {
        [TestMethod]
        [ExpectedException(typeof(MissingFieldException))]
        public void TestNullCronExpression()
        {
            ExpressionDescripter ceh = new ExpressionDescripter(null);
        }

        [TestMethod]
        [ExpectedException(typeof(MissingFieldException))]
        public void TestEmptyCronExpression()
        {
            ExpressionDescripter ceh = new ExpressionDescripter("");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestInvalidCronExpression()
        {
            ExpressionDescripter ceh = new ExpressionDescripter("INVALID");
            string result = ceh.FullDescription;
        }
    }
}
