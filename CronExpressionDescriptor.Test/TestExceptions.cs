using System;
using System.Globalization;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;

namespace CronExpressionDescriptor.Test
{
    [TestFixture]
    public class TestExceptions
    {
        [TestFixtureSetUp]
        public void SetUp()
        {
            CultureInfo myCultureInfo = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = myCultureInfo;
            Thread.CurrentThread.CurrentUICulture = myCultureInfo;
        }

        [Test]
        [ExpectedException(typeof(MissingFieldException))]
        public void TestNullCronExpressionException()
        {
            Options options = new Options() { ThrowExceptionOnParseError = true };
            ExpressionDescriptor ceh = new ExpressionDescriptor(null, options);
            ceh.GetDescription(DescriptionTypeEnum.FULL);
        }

        [Test]
        [ExpectedException(typeof(MissingFieldException))]
        public void TestEmptyCronExpressionException()
        {
            Options options = new Options() { ThrowExceptionOnParseError = true };
            ExpressionDescriptor ceh = new ExpressionDescriptor(null, options);
            ceh.GetDescription(DescriptionTypeEnum.FULL);
        }

        [Test]
        public void TestNullCronExpressionError()
        {
            Options options = new Options() { ThrowExceptionOnParseError = false };
            ExpressionDescriptor ceh = new ExpressionDescriptor(null, options);
            Assert.AreEqual("Field 'ExpressionDescriptor.expression' not found.", ceh.GetDescription(DescriptionTypeEnum.FULL));
        }

        [Test]
        [ExpectedException(typeof(FormatException))]
        public void TestInvalidCronExpressionException()
        {
            Options options = new Options() { ThrowExceptionOnParseError = true };
            ExpressionDescriptor ceh = new ExpressionDescriptor("INVALID", options);
            ceh.GetDescription(DescriptionTypeEnum.FULL);
        }

        [Test]
        public void TestInvalidCronExpressionError()
        {
            Options options = new Options() { ThrowExceptionOnParseError = false };
            ExpressionDescriptor ceh = new ExpressionDescriptor("INVALID CRON", options);
            Assert.AreEqual("Error: Expression only has 2 parts.  At least 5 part are required.", ceh.GetDescription(DescriptionTypeEnum.FULL));
        }

        [Test]
        [ExpectedException(typeof(FormatException))]
        public void TestInvalidSyntaxException()
        {
            Options options = new Options() { ThrowExceptionOnParseError = true };
            ExpressionDescriptor ceh = new ExpressionDescriptor("* $ * * *", options);
            ceh.GetDescription(DescriptionTypeEnum.FULL);
        }
    }
}
