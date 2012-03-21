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
        public void TestNullCronExpressionException()
        {
            Options options = new Options() { ThrowExceptionOnParseError = true };
            ExpressionDescriptor ceh = new ExpressionDescriptor(null, options);
            ceh.GetDescription();
        }

        [TestMethod]
        [ExpectedException(typeof(MissingFieldException))]
        public void TestEmptyCronExpressionException()
        {
            Options options = new Options() { ThrowExceptionOnParseError = true };
            ExpressionDescriptor ceh = new ExpressionDescriptor(null, options);
            ceh.GetDescription();
        }

        [TestMethod]
        public void TestNullCronExpressionError()
        {
            Options options = new Options() { ThrowExceptionOnParseError = false };
            ExpressionDescriptor ceh = new ExpressionDescriptor(null, options);
            string description = ceh.GetDescription();
            Assert.AreEqual("Error: Expression is missing.", ceh.GetDescription());
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestInvalidCronExpressionException()
        {
            Options options = new Options() { ThrowExceptionOnParseError = true };
            ExpressionDescriptor ceh = new ExpressionDescriptor("INVALID", options);
            ceh.GetDescription();
        }

        [TestMethod]
        public void TestInvalidCronExpressionError()
        {
            Options options = new Options() { ThrowExceptionOnParseError = false };
            ExpressionDescriptor ceh = new ExpressionDescriptor("INVALID CRON", options);
            string description = ceh.GetDescription();
            Assert.AreEqual("Error: Expression only has 2 parts.  At least 5 part are required.", ceh.GetDescription());
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestInvalidSyntaxException()
        {
            Options options = new Options() { ThrowExceptionOnParseError = true };
            ExpressionDescriptor ceh = new ExpressionDescriptor("* $ * * *", options);
            string description = ceh.GetDescription();
        }

        [TestMethod]
        public void TestInvalidSyntaxError()
        {
            Options options = new Options() { ThrowExceptionOnParseError = false };
            ExpressionDescriptor ceh = new ExpressionDescriptor("* $ * * *", options);
            Assert.AreEqual("An error occured when generating the expression description.  Check the cron expression syntax.", ceh.GetDescription());
        }
    }
}
